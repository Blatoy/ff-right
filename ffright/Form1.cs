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
        volatile bool needToStealFocus = false;

        string extraParams = "";
        string toBeContinuedImage = "";
        string toBeContinuedAudio = "";
        string textFontPath = "";
        DateTime fileCreationDate;
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

        void UpdateCommandLine()
        {
            btnConvert.Enabled = tbxOut.Text.Length > 0;

            string filterComplexMap = "";

            foreach(var index in audioChannels.CheckedIndices)
            {
                filterComplexMap += "[0:a:" + index + "]";
            }

            filterComplexMap += "amix=" + audioChannels.CheckedIndices.Count + ":longest";

            string nameOverlay = $"";
            if (!chkHideOverlay.Checked)
            {
                float ss = 0, sm = 0;
                try
                {
                    parseTime(tbxStart.Text, out ss, out sm);
                } catch (Exception e) { }

                int frameIndex = (int)(sm * 60 + ss);
                string creationDate = "";
                if (fileCreationDate != null)
                {
                    creationDate = fileCreationDate.ToString("dd.MM.yyyy HH\\\\:mm");
                }

                string textFontSanitized = textFontPath.Replace(":", "\\\\:");
                nameOverlay += $";drawtext=fontfile={textFontSanitized}:text='{tbxOut.Text}':fontcolor=white:fontsize=64:box=1:boxcolor=black@0.7:boxborderw=15:x=(w-text_w)/2:y=200:enable='between(t,{frameIndex},{frameIndex})',drawtext=fontfile={textFontSanitized}:text='{creationDate}':fontcolor=white:fontsize=54:box=1:boxcolor=black@0.5:boxborderw=15:x=(w-text_w)/2:y=(h - 300):enable='between(t,{frameIndex},{frameIndex})'";
            }

            tbxCommand.Text = $"ffmpeg.exe -y -i \"{tbxPath.Text}\" " +
                            $"-ss {tbxStart.Text} -to {tbxEnd.Text} -crf {tbxCRF.Text} " +
                            $"-filter_complex \"{filterComplexMap}{nameOverlay}\" " +
                            $"{(addExtraParams.Checked ? extraParams : "")} \"{tbxOut.Text}.mp4\"";

            if (extraEffects.SelectedIndex == 1)
            {
                string zoom = "1.05";
                float ss = 0, sm = 0, es = 0, em = 0; 
                try
                {
                    parseTime(tbxStart.Text, out ss, out sm);
                    parseTime(tbxEnd.Text, out es, out em);
                }
                catch (Exception e)
                {
                    
                }

                float durationM = em - sm;
                float durationS = es - ss;
                if (durationS < 0)
                {
                    durationS += 60;
                    durationM -= 1;
                }

                float endSeconds = durationM * 60 + durationS;


            // Display viewer
            if (restartPlayer)
            {
                KillViewer();

                viewerProcess = new Process();

                viewerProcess.StartInfo.CreateNoWindow = true;
                viewerProcess.StartInfo.UseShellExecute = false;
                viewerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                viewerProcess.StartInfo.FileName = "ffplay.exe";
                // -ss 00:14 -t 1
                var width = Math.Round(Height * (16d / 9d));

                viewerProcess.StartInfo.Arguments = $"-vf \"drawtext=text='%{{pts\\:hms}}':box=1:x=(w-text_w)/2:y=25:fontsize=148\" -alwaysontop -top {Top} -left {Right} -x {width} -y {Height} -noborder -volume 5 -loop 0 -ss {tbxStart.Text} -t {durationS + 1} -i \"{tbxPath.Text}\"";
                Debug.WriteLine(viewerProcess.StartInfo.Arguments);

                viewerProcess.Start();
                needToStealFocus = true;
                SetParent(viewerProcess.Handle, Handle);
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
            UpdateCommandLine();
        }

        private void audioChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCommandLine();
        }

        private void audioChannels_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateCommandLine();
        }

        private void audioChannels_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateCommandLine();
        }

        private void tbxOut_Enter(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void chkHideOverlay_CheckedChanged(object sender, EventArgs e)
        private void FormConvertVideos_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillViewer();
        }

        private void FormConvertVideos_Move(object sender, EventArgs e)
        {
            KillViewer();
        }

        {
            UpdateCommandLine();

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

        }
    }
}
