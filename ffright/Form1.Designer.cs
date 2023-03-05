
namespace ffright
{
    partial class FormConvertVideos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConvertVideos));
            this.tbxStart = new System.Windows.Forms.TextBox();
            this.tbxEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.tbxOut = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.tbxCommand = new System.Windows.Forms.TextBox();
            this.audioChannels = new System.Windows.Forms.CheckedListBox();
            this.tbxCRF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addExtraParams = new System.Windows.Forms.CheckBox();
            this.deleteOriginal = new System.Windows.Forms.CheckBox();
            this.extraEffects = new System.Windows.Forms.ComboBox();
            this.keepOpen = new System.Windows.Forms.CheckBox();
            this.chkHideOverlay = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbxStart
            // 
            this.tbxStart.Location = new System.Drawing.Point(105, 28);
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.PlaceholderText = "Start";
            this.tbxStart.Size = new System.Drawing.Size(43, 23);
            this.tbxStart.TabIndex = 1;
            this.tbxStart.Text = "02:20";
            this.tbxStart.TextChanged += new System.EventHandler(this.OnPathChanged);
            // 
            // tbxEnd
            // 
            this.tbxEnd.Location = new System.Drawing.Point(170, 28);
            this.tbxEnd.Name = "tbxEnd";
            this.tbxEnd.PlaceholderText = "End";
            this.tbxEnd.Size = new System.Drawing.Size(43, 23);
            this.tbxEnd.TabIndex = 2;
            this.tbxEnd.Text = "02:30";
            this.tbxEnd.TextChanged += new System.EventHandler(this.OnPathChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "to";
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(1, 2);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.PlaceholderText = "Path";
            this.tbxPath.Size = new System.Drawing.Size(288, 23);
            this.tbxPath.TabIndex = 7;
            this.tbxPath.TextChanged += new System.EventHandler(this.OnPathChanged);
            // 
            // tbxOut
            // 
            this.tbxOut.Location = new System.Drawing.Point(105, 57);
            this.tbxOut.Name = "tbxOut";
            this.tbxOut.PlaceholderText = "Clip name";
            this.tbxOut.Size = new System.Drawing.Size(184, 23);
            this.tbxOut.TabIndex = 0;
            this.tbxOut.TextChanged += new System.EventHandler(this.OnPathChanged);
            this.tbxOut.Enter += new System.EventHandler(this.tbxOut_Enter);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(1, 157);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(288, 23);
            this.btnConvert.TabIndex = 9;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvertClick);
            // 
            // tbxCommand
            // 
            this.tbxCommand.Location = new System.Drawing.Point(105, 86);
            this.tbxCommand.Name = "tbxCommand";
            this.tbxCommand.PlaceholderText = "Cmd";
            this.tbxCommand.Size = new System.Drawing.Size(184, 23);
            this.tbxCommand.TabIndex = 8;
            // 
            // audioChannels
            // 
            this.audioChannels.CheckOnClick = true;
            this.audioChannels.FormattingEnabled = true;
            this.audioChannels.Location = new System.Drawing.Point(1, 28);
            this.audioChannels.Name = "audioChannels";
            this.audioChannels.Size = new System.Drawing.Size(98, 94);
            this.audioChannels.TabIndex = 4;
            this.audioChannels.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.audioChannels_ItemCheck);
            this.audioChannels.SelectedIndexChanged += new System.EventHandler(this.audioChannels_SelectedIndexChanged);
            this.audioChannels.KeyUp += new System.Windows.Forms.KeyEventHandler(this.audioChannels_KeyUp);
            this.audioChannels.MouseUp += new System.Windows.Forms.MouseEventHandler(this.audioChannels_MouseUp);
            // 
            // tbxCRF
            // 
            this.tbxCRF.Location = new System.Drawing.Point(246, 28);
            this.tbxCRF.Name = "tbxCRF";
            this.tbxCRF.PlaceholderText = "End";
            this.tbxCRF.Size = new System.Drawing.Size(43, 23);
            this.tbxCRF.TabIndex = 3;
            this.tbxCRF.Text = "30";
            this.tbxCRF.TextChanged += new System.EventHandler(this.OnPathChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "crf";
            // 
            // addExtraParams
            // 
            this.addExtraParams.AutoSize = true;
            this.addExtraParams.Checked = true;
            this.addExtraParams.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addExtraParams.Location = new System.Drawing.Point(195, 113);
            this.addExtraParams.Name = "addExtraParams";
            this.addExtraParams.Size = new System.Drawing.Size(94, 19);
            this.addExtraParams.TabIndex = 6;
            this.addExtraParams.Text = "Extra params";
            this.addExtraParams.UseVisualStyleBackColor = true;
            this.addExtraParams.CheckedChanged += new System.EventHandler(this.OnPathChanged);
            // 
            // deleteOriginal
            // 
            this.deleteOriginal.AutoSize = true;
            this.deleteOriginal.Location = new System.Drawing.Point(108, 113);
            this.deleteOriginal.Name = "deleteOriginal";
            this.deleteOriginal.Size = new System.Drawing.Size(81, 19);
            this.deleteOriginal.TabIndex = 5;
            this.deleteOriginal.Text = "Delete clip";
            this.deleteOriginal.UseVisualStyleBackColor = true;
            // 
            // extraEffects
            // 
            this.extraEffects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extraEffects.FormattingEnabled = true;
            this.extraEffects.Items.AddRange(new object[] {
            "No extras",
            "To be continued"});
            this.extraEffects.Location = new System.Drawing.Point(1, 128);
            this.extraEffects.Name = "extraEffects";
            this.extraEffects.Size = new System.Drawing.Size(98, 23);
            this.extraEffects.TabIndex = 12;
            this.extraEffects.SelectedIndexChanged += new System.EventHandler(this.OnPathChanged);
            // 
            // keepOpen
            // 
            this.keepOpen.AutoSize = true;
            this.keepOpen.Location = new System.Drawing.Point(108, 132);
            this.keepOpen.Name = "keepOpen";
            this.keepOpen.Size = new System.Drawing.Size(82, 19);
            this.keepOpen.TabIndex = 13;
            this.keepOpen.Text = "Keep open";
            this.keepOpen.UseVisualStyleBackColor = true;
            // 
            // chkHideOverlay
            // 
            this.chkHideOverlay.AutoSize = true;
            this.chkHideOverlay.Location = new System.Drawing.Point(195, 132);
            this.chkHideOverlay.Name = "chkHideOverlay";
            this.chkHideOverlay.Size = new System.Drawing.Size(86, 19);
            this.chkHideOverlay.TabIndex = 14;
            this.chkHideOverlay.Text = "Hide Name";
            this.chkHideOverlay.UseVisualStyleBackColor = true;
            this.chkHideOverlay.CheckedChanged += new System.EventHandler(this.chkHideOverlay_CheckedChanged);
            // 
            // FormConvertVideos
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(626, 227);
            this.Controls.Add(this.chkHideOverlay);
            this.Controls.Add(this.keepOpen);
            this.Controls.Add(this.extraEffects);
            this.Controls.Add(this.deleteOriginal);
            this.Controls.Add(this.audioChannels);
            this.Controls.Add(this.addExtraParams);
            this.Controls.Add(this.tbxCommand);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.tbxOut);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.tbxCRF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormConvertVideos";
            this.Text = "FFRight";
            this.Load += new System.EventHandler(this.OnLoad);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxStart;
        private System.Windows.Forms.TextBox tbxEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.TextBox tbxOut;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox tbxCommand;
        private System.Windows.Forms.CheckedListBox audioChannels;
        private System.Windows.Forms.TextBox tbxCRF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox addExtraParams;
        private System.Windows.Forms.CheckBox deleteOriginal;
        private System.Windows.Forms.ComboBox extraEffects;
        private System.Windows.Forms.CheckBox keepOpen;
        private System.Windows.Forms.CheckBox chkHideOverlay;
    }
}

