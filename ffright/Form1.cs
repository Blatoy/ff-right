using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections.Specialized;
using System.Threading;
using System.Runtime.InteropServices;

namespace ffright
{
    public partial class FormConvertVideos : Form
    {

        [DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        [DllImportAttribute("User32.DLL")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool SetActiveWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool SetFocus(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool SetParent(IntPtr hWnd, IntPtr newParent);

        DiceUI diceUI = null;

        volatile bool needToStealFocus = false;

        string extraParams = "";
        string toBeContinuedImage = "";
        string toBeContinuedAudio = "";
        string textFontPath = "";
        string memeFolder = "";
        DateTime fileCreationDate;
        Process viewerProcess;

        public FormConvertVideos()
        {
            InitializeComponent();
            Application.ApplicationExit += (a, e) =>
            {
                KillViewer();
            };
        }

        private void btnConvertClick(object sender, EventArgs e)

        {
            if (!keepOpen.Checked)
            {
                Hide();
                if (diceUI != null)
                {
                    diceUI.Hide();
                }
            }

            var sb = new StringBuilder();

            var cmd = new Process();
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.EnableRaisingEvents = true;
            cmd.StartInfo.Arguments = "/C " + tbxCommand.Text;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.RedirectStandardInput = false;

            cmd.Exited += (object sender, System.EventArgs e) =>
            {
                StringCollection paths = new StringCollection();
                paths.Add(Path.GetDirectoryName(tbxPath.Text) + "\\" + tbxOut.Text + ".mp4");

                Thread thread = new Thread(() => Clipboard.SetFileDropList(paths));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

                if (deleteOriginal.Checked)
                {
                    File.Delete(tbxPath.Text);
                }
                else
                {
                    try
                    {
                        File.Move(tbxPath.Text, tbxPath.Text.Insert(tbxPath.Text.Length - 4, " (" + tbxOut.Text + ")"));
                        tbxPath.Text = tbxPath.Text.Insert(tbxPath.Text.Length - 4, " (" + tbxOut.Text + ")");
                    }
                    catch (Exception exception)
                    {

                    }
                }

                if (!keepOpen.Checked)
                {
                    Application.Exit();
                }
            };

            cmd.Start();

            KillViewer();

        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            extraEffects.SelectedIndex = 0;

            ((Form)sender).Location = new Point(Cursor.Position.X, Cursor.Position.Y);

            // Parse "config"

            string[] fileParams = { "\nAudioStream 1\n\n30\n\n20\n\n" };
            try
            {
                string filePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @".\\ffright-params.txt";
                fileParams = File.ReadAllText(filePath).Replace("\r", "").Split("\n");
            }
            catch (Exception)
            {
                MessageBox.Show("Missing ffright-params.txt next to ffright.exe", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var channels = fileParams[1].Split(",");
            foreach (var channel in channels)
            {
                audioChannels.Items.Add(channel);
            }

            audioChannels.SetItemChecked(0, true);

            tbxCRF.Text = fileParams[3];
            extraParams = fileParams[7];
            toBeContinuedImage = fileParams[9];
            toBeContinuedAudio = fileParams[10];
            textFontPath = fileParams[12];
            memeFolder = fileParams[14];

            int defaultDuration = int.Parse(fileParams[5]);

            // ffmpeg.exe -i "Spelunky 2 2022.04.16 - 00.59.58.06.DVR.mp4" -ss 02:20 -crf 30 -filter_complex "[0:a:1][0:a:0]amix=2:longest[aout]" -map 0:V:0 -map "[aout]" out.mp4
            try
            {
                if (Environment.GetCommandLineArgs().Length > 0)
                {
                    tbxPath.Text = Environment.GetCommandLineArgs()[1];
                    fileCreationDate = File.GetCreationTime(tbxPath.Text);

                    // Query time of video for auto end and start time
                    var cmd = new Process();
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.Arguments = "/C " + "ffprobe.exe -v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 -sexagesimal \"" + tbxPath.Text + "\"";
                    cmd.StartInfo.RedirectStandardOutput = true;

                    cmd.Start();

                    string output = cmd.StandardOutput.ReadToEnd();
                    cmd.WaitForExit();

                    string videoLengthNoMs = output.Split(".")[0];
                    var videoLength = videoLengthNoMs.Split(":"); // 0 = h, 1 = m, 2 = s
                    int seconds = int.Parse(videoLength[2]) - defaultDuration;
                    int minutes = int.Parse(videoLength[1]);
                    if (seconds < 0) { seconds += 60; minutes -= 1; }
                    if (minutes < 0) { seconds = 0; minutes = 0; }

                    tbxEnd.Text = (videoLength[0] == "0" ? "" : videoLength + ":") + videoLength[1] + ":" + videoLength[2];
                    tbxStart.Text = minutes + ":" + seconds;
                }
            }
            catch (Exception) { }

            UpdateCommandLine();
            tbxOut.Focus();
        }

        private void OnPathChanged(object sender, EventArgs e)
        {
            UpdateCommandLine();
        }

        private void parseTime(string time, out float s, out float m)
        {
            var videoLength = time.Split(":");
            m = float.Parse(videoLength[0]);
            s = float.Parse(videoLength[1]);
        }

        private void AddSecondsToTime(ref string time, float seconds)
        {
            parseTime(time, out float s, out float m);
            s += seconds;
            m += MathF.Floor(s / 60);
            s %= 60;
            if (s < 0) s += 60;
            time = m + ":" + s;
        }
        private void UpdateCommandLineWithoutRestartingPlayer(object sender, EventArgs e)
        {
            UpdateCommandLine(false);
        }

        void UpdateCommandLine(bool restartPlayer = true)
        {
            btnConvert.Enabled = tbxOut.Text.Length > 0;

            string filterComplexMap = "";

            foreach (var index in audioChannels.CheckedIndices)
            {
                filterComplexMap += "[0:a:" + index + "]";
            }

            filterComplexMap += "amix=" + audioChannels.CheckedIndices.Count + ":longest";

            string nameOverlay = $"";

            float ss = 0, sm = 0;
            try
            {
                parseTime(tbxStart.Text, out ss, out sm);
            }
            catch (Exception e) { }

            if (!chkHideOverlay.Checked)
            {
                int frameIndex = (int)(sm * 60 + ss);
                string creationDate = "";
                if (fileCreationDate != null)
                {
                    creationDate = fileCreationDate.ToString("dd.MM.yyyy HH\\\\:mm");
                }

                nameOverlay += $";drawtext=fontfile='{textFontPath}':text='{tbxOut.Text}':fontcolor=white:fontsize=64:box=1:boxcolor=black@0.7:boxborderw=15:x=(w-text_w)/2:y=200:enable='between(t,{frameIndex},{frameIndex})',drawtext=fontfile='{textFontPath}':text='{creationDate}':fontcolor=white:fontsize=54:box=1:boxcolor=black@0.5:boxborderw=15:x=(w-text_w)/2:y=(h - 300):enable='between(t,{frameIndex},{frameIndex})'";
            }

            // TODO: Save in config
            const double SCREEN_HEIGHT = 1440;
            const double RECORDING_WIDTH = 3360;

            // TODO: Add option to hide that
            double.TryParse(tbxCrop1.Text, out double ratio1);
            double.TryParse(tbxCrop2.Text, out double ratio2);

            double ratio = ratio1 / ratio2;
            double screenWidth = SCREEN_HEIGHT * ratio;

            string cropText = $",crop={screenWidth}:{SCREEN_HEIGHT}:{(int)((RECORDING_WIDTH - screenWidth) / 2)}:0";

            tbxCommand.Text = $"ffmpeg.exe -y -i \"{tbxPath.Text}\" " +
                            $"-ss {tbxStart.Text} -to {tbxEnd.Text} -crf {tbxCRF.Text} " +
                            $"-filter_complex \"{filterComplexMap}{nameOverlay}{cropText}\" " +
                            $"{(addExtraParams.Checked ? extraParams : "")} \"{tbxOut.Text + (extraEffects.SelectedIndex == 2 ? "_tmp" : "")}.mp4\"";

            float es = 0, em = 0;
            try
            {
                parseTime(tbxEnd.Text, out es, out em);
            }
            catch (Exception) { }

            float durationM = em - sm;
            float durationS = es - ss;

            if (durationS < 0)
            {
                durationS += 60;
                durationM -= 1;
            }

            float endSeconds = durationM * 60 + durationS;

            switch (extraEffects.SelectedIndex)
            {
                case 1:
                    // to be continued
                    string zoom = "1.05";

                    tbxCommand.Text += $" & ffmpeg.exe -y -i \"{tbxOut.Text}.mp4\" -vf tpad=stop_mode=clone:stop_duration=3 \"{tbxOut.Text}_tmp.mp4\"";
                    tbxCommand.Text += $" & ffmpeg.exe -y -i \"{tbxOut.Text}_tmp.mp4\"  -i \"{toBeContinuedImage}\" -filter_complex \"[0:v] zoompan=z='if(between(in_time,{endSeconds},{endSeconds + 4}),{zoom},1)':x='iw/2-iw/zoom/2':y='ih/2-ih/zoom/2':d=1:s=1920x1080:fps=30, hue=s=0:enable='between(t,{endSeconds},{endSeconds + 4})'[b]; [b][1:v] overlay=0:0:enable='between(t,{endSeconds},{endSeconds + 4})\" -itsoffset 00:{durationM}:{durationS} -i \"{toBeContinuedAudio}\" -map 0 -map 1:0 -filter_complex \"amix=inputs=2\" -async 1 \"{tbxOut.Text}.mp4\"";
                    tbxCommand.Text += $" & del \"{tbxOut.Text}_tmp.mp4\"";
                    break;
                case 2:
                    {
                        var effectDuration = 5;

                        parseTime(diceUI.startTime.Text, out float diceStartSeconds, out float diceStartMinutes);
                        var cutStartSeconds = diceStartSeconds - ss;
                        var cutStartMinutes = diceStartMinutes - sm;

                        if (cutStartSeconds < 0)
                        {
                            cutStartSeconds += 1;
                            cutStartMinutes -= 1;
                        }

                        float startSeconds = 60 * cutStartMinutes + cutStartSeconds;
                        var rollType = "success";
                        var textType = "Success\\:";
                        if (diceUI.failure.Checked)
                        {
                            rollType = "failure";
                            textType = "Failure\\:";
                        }

                        var mathThing = $"100 + max(0\\, 200 - 900 * sqrt((t - {startSeconds}) / {effectDuration}))";

                        tbxCommand.Text += $" & ffmpeg.exe -y -i \"{tbxOut.Text}_tmp.mp4\" -itsoffset {startSeconds} -async 1 -i \"{memeFolder}roll-{rollType}.wav\" -i \"{memeFolder}roll-{rollType}.png\" -filter_complex \"[0:a:0][1:a:0]amix=2;drawtext=fontfile='{memeFolder.Replace("\\", "\\\\").Replace(":", "\\:")}12-post-antiqua-roman-05554.ttf':text='{textType} {diceUI.diceMessage.Text}':fontcolor=white:fontsize=18:box=1:boxcolor=black@0.95:boxborderw=12:x=50 + {mathThing}:y=70+12:enable='between(t,{startSeconds},{startSeconds + effectDuration})'[out];[out][2:v]overlay=enable='between=(t,{startSeconds},{startSeconds + effectDuration})':x={mathThing}:y=70\" \"{tbxOut.Text}.mp4\"";
                        tbxCommand.Text += $" & del \"{tbxOut.Text}_tmp.mp4\"";
                    }

                    break;
            }

            // Display viewer
            if (restartPlayer && chkPreview.Checked)
            {
                KillViewer();

                viewerProcess = new Process();

                viewerProcess.StartInfo.CreateNoWindow = true;
                viewerProcess.StartInfo.UseShellExecute = false;
                viewerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                viewerProcess.StartInfo.FileName = "ffplay.exe";
                // -ss 00:14 -t 1
                int height = (int)Math.Round(Height * 1.8);
                var width = Math.Round(height * (16d / 9d));
                var top = Top - height / 4;

                viewerProcess.StartInfo.Arguments = $"-vf \"drawtext=text='%{{pts\\:hms}}':box=1:x=(w-text_w)/2:y=25:fontsize=80\" -alwaysontop -top {top} -left {Right} -x {width} -y {height} -noborder -volume 5 -loop 0 -ss {tbxStart.Text} -t {durationS + 1 + durationM * 60} -i \"{tbxPath.Text}\"";
                Debug.WriteLine(viewerProcess.StartInfo.Arguments);

                viewerProcess.Start();
                needToStealFocus = true;
                SetParent(viewerProcess.Handle, Handle);
            }

        }

        void KillViewer()
        {
            if (viewerProcess != null && !viewerProcess.HasExited)
            {
                viewerProcess.Kill();
            }
        }

        private void audioChannels_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            UpdateCommandLine(false);
        }

        private void audioChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCommandLine(false);
        }

        private void audioChannels_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateCommandLine(false);
        }

        private void audioChannels_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateCommandLine(false);
        }

        private void tbxOut_Enter(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void chkHideOverlay_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCommandLine(false);
        }

        private void tbxStart_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            TextBox box = (TextBox)sender;
            if (box.Name == "tbxOut")
            {
                box = tbxStart;
            }
            string time = box.Text;

            int seconds = 1;

            if (e.Control) seconds = 5;
            if (e.Alt) seconds = 30;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    AddSecondsToTime(ref time, seconds);
                    break;
                case Keys.Down:
                    AddSecondsToTime(ref time, -seconds);
                    break;
                default:
                    return;
            }

            box.Text = time;
            box.SelectionStart = time.Length;
        }

        private void MoveWindowsStart()
        {
            if (diceUI != null)
            {
                diceUI.Hide();
            }
        }

        private void MoveWindowsEnd()
        {
            if (diceUI != null)
            {
                diceUI.Show();
                diceUI.Top = Bottom - diceUI.Height;
                diceUI.Left = Left - diceUI.Width;
            }
        }

        private void extraEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).SelectedIndex)
            {
                case 2:
                    diceUI = new DiceUI();
                    MoveWindowsEnd();

                    diceUI.diceMessage.Focus();
                    diceUI.startTime.Text = tbxStart.Text;

                    break;
                default:
                    if (diceUI != null)
                    {
                        diceUI.Hide();
                        diceUI = null;
                    }
                    break;
            }

            OnPathChanged(sender, e);
        }

        private void FormConvertVideos_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillViewer();
        }

        private void FormConvertVideos_Move(object sender, EventArgs e)
        {
            KillViewer();
            MoveWindowsStart();
        }

        private void FormConvertVideos_ResizeEnd(object sender, EventArgs e)
        {
            UpdateCommandLine();
            MoveWindowsEnd();
        }

        private void FormConvertVideos_Deactivate(object sender, EventArgs e)
        {
            if (needToStealFocus)
            {
                Task.Run(() =>
                {
                    var myWindowHandler = Process.GetCurrentProcess().MainWindowHandle;
                    ShowWindow(myWindowHandler, 5);
                    SetForegroundWindow(myWindowHandler);
                    needToStealFocus = false;
                });
            }
        }

        private void FormConvertVideos_Enter(object sender, EventArgs e)
        {
            UpdateCommandLine(false);
        }

        private void FormConvertVideos_Activated(object sender, EventArgs e)
        {
            UpdateCommandLine(false);
        }

        private void chkPreview_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreview.Checked)
            {
                UpdateCommandLine();
            }
            else
            {
                KillViewer();
            }
        }

        private void tbxCrop1_DoubleClick(object sender, EventArgs e)
        {
            // TODO: Preset list of resolutions
            tbxCrop1.Text = "16";
        }
    }
}
