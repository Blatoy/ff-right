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
            // ffmpeg.exe -i "Spelunky 2 2022.04.16 - 00.59.58.06.DVR.mp4" -ss 02:20 -crf 30 -filter_complex "[0:a:1][0:a:0]amix=2:longest[aout]" -map 0:V:0 -map "[aout]" out.mp4
            tbxPath.Text = Environment.GetCommandLineArgs()[1];
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
            ((Form)sender).Location = new Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);

            string filePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @".\\ffright-params.txt";
            extraParams = File.ReadAllText(filePath);
            updateCommandLine();
        }

        private void tbxPath_TextChanged(object sender, EventArgs e)
        {
            updateCommandLine();
        }

        void updateCommandLine()
        {
            tbxCommand.Text = $"ffmpeg.exe -i \"{tbxPath.Text}\" -ss {tbxStart.Text} -to {tbxEnd.Text} -crf {tbxCRF.Text} {(addExtraParams.Checked ? extraParams : "")} \"{tbxOut.Text}\"";
        }
    }
}
