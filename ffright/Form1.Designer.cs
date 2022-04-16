
namespace ffright
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCRF = new System.Windows.Forms.TextBox();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.tbxOut = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxCommand = new System.Windows.Forms.TextBox();
            this.addExtraParams = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbxStart
            // 
            this.tbxStart.Location = new System.Drawing.Point(1, 29);
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.PlaceholderText = "Start";
            this.tbxStart.Size = new System.Drawing.Size(43, 23);
            this.tbxStart.TabIndex = 0;
            this.tbxStart.Text = "02:20";
            this.tbxStart.TextChanged += new System.EventHandler(this.tbxPath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "crf";
            // 
            // tbxEnd
            // 
            this.tbxEnd.Location = new System.Drawing.Point(66, 29);
            this.tbxEnd.Name = "tbxEnd";
            this.tbxEnd.PlaceholderText = "End";
            this.tbxEnd.Size = new System.Drawing.Size(43, 23);
            this.tbxEnd.TabIndex = 1;
            this.tbxEnd.Text = "02:30";
            this.tbxEnd.TextChanged += new System.EventHandler(this.tbxPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "to";
            // 
            // tbxCRF
            // 
            this.tbxCRF.Location = new System.Drawing.Point(143, 29);
            this.tbxCRF.Name = "tbxCRF";
            this.tbxCRF.PlaceholderText = "End";
            this.tbxCRF.Size = new System.Drawing.Size(43, 23);
            this.tbxCRF.TabIndex = 3;
            this.tbxCRF.Text = "30";
            this.tbxCRF.TextChanged += new System.EventHandler(this.tbxPath_TextChanged);
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(1, 2);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.PlaceholderText = "Path";
            this.tbxPath.Size = new System.Drawing.Size(288, 23);
            this.tbxPath.TabIndex = 6;
            this.tbxPath.TextChanged += new System.EventHandler(this.tbxPath_TextChanged);
            // 
            // tbxOut
            // 
            this.tbxOut.Location = new System.Drawing.Point(1, 58);
            this.tbxOut.Name = "tbxOut";
            this.tbxOut.PlaceholderText = "Out";
            this.tbxOut.Size = new System.Drawing.Size(288, 23);
            this.tbxOut.TabIndex = 4;
            this.tbxOut.Text = "out.mp4";
            this.tbxOut.TextChanged += new System.EventHandler(this.tbxPath_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxCommand
            // 
            this.tbxCommand.Location = new System.Drawing.Point(1, 87);
            this.tbxCommand.Name = "tbxCommand";
            this.tbxCommand.PlaceholderText = "Cmd";
            this.tbxCommand.Size = new System.Drawing.Size(288, 23);
            this.tbxCommand.TabIndex = 5;
            // 
            // addExtraParams
            // 
            this.addExtraParams.AutoSize = true;
            this.addExtraParams.Location = new System.Drawing.Point(192, 32);
            this.addExtraParams.Name = "addExtraParams";
            this.addExtraParams.Size = new System.Drawing.Size(94, 19);
            this.addExtraParams.TabIndex = 2;
            this.addExtraParams.Text = "Extra params";
            this.addExtraParams.UseVisualStyleBackColor = true;
            this.addExtraParams.CheckedChanged += new System.EventHandler(this.tbxPath_TextChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(626, 227);
            this.Controls.Add(this.addExtraParams);
            this.Controls.Add(this.tbxCommand);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxOut);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.tbxCRF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "FFRight";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCRF;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.TextBox tbxOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxCommand;
        private System.Windows.Forms.CheckBox addExtraParams;
    }
}

