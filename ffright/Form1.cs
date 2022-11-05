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

namespace ffright
{
    public partial class Form1 : Form
    {
        string extraParams = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var sb = new StringBuilder();

            var cmd = new Process();
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.EnableRaisingEvents = true;
            cmd.StartInfo.Arguments = "/C " + tbxCommand.Text;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.RedirectStandardInput = false;

            cmd.Exited += (object sender, System.EventArgs e) => {
                Application.Exit();
            };

            cmd.Start();

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            int defaultDuration = int.Parse(fileParams[5]);

            // ffmpeg.exe -i "Spelunky 2 2022.04.16 - 00.59.58.06.DVR.mp4" -ss 02:20 -crf 30 -filter_complex "[0:a:1][0:a:0]amix=2:longest[aout]" -map 0:V:0 -map "[aout]" out.mp4
            try
            {
                if (Environment.GetCommandLineArgs().Length > 0)
                {
                    tbxPath.Text = Environment.GetCommandLineArgs()[1];

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

                    tbxEnd.Text = (videoLength[0] == "0" ? "" : videoLength + ":") + videoLength[1] + ":" + videoLength[2];
                    tbxStart.Text = videoLength[1] + ":" + (int.Parse(videoLength[2]) - defaultDuration);
                }
            }
            catch(Exception) { }

            updateCommandLine();
        }

        private void tbxPath_TextChanged(object sender, EventArgs e)
        {
            updateCommandLine();
        }

        void updateCommandLine()
        {
            string map = "";
            foreach(var index in audioChannels.CheckedIndices)
            {
                map += "-map 0:a:" + index + " ";
            }
            tbxCommand.Text = $"ffmpeg.exe -y -i \"{tbxPath.Text}\" " +
                              $"-ss {tbxStart.Text} -to {tbxEnd.Text} -crf {tbxCRF.Text} " +
                              $"-map 0:v:0 {map}" +
                              $"{(addExtraParams.Checked ? extraParams : "")} \"{tbxOut.Text}.mp4\"";
        }

        private void audioChannels_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            updateCommandLine();
        }

        private void audioChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCommandLine();
        }

        private void audioChannels_MouseUp(object sender, MouseEventArgs e)
        {
            updateCommandLine();
        }

        private void audioChannels_KeyUp(object sender, KeyEventArgs e)
        {
            updateCommandLine();
        }
    }
}
