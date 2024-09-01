
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
            tbxStart = new System.Windows.Forms.TextBox();
            tbxEnd = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            tbxPath = new System.Windows.Forms.TextBox();
            tbxOut = new System.Windows.Forms.TextBox();
            btnConvert = new System.Windows.Forms.Button();
            tbxCommand = new System.Windows.Forms.TextBox();
            audioChannels = new System.Windows.Forms.CheckedListBox();
            tbxCRF = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            addExtraParams = new System.Windows.Forms.CheckBox();
            deleteOriginal = new System.Windows.Forms.CheckBox();
            extraEffects = new System.Windows.Forms.ComboBox();
            keepOpen = new System.Windows.Forms.CheckBox();
            chkHideOverlay = new System.Windows.Forms.CheckBox();
            chkPreview = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            tbxCrop1 = new System.Windows.Forms.TextBox();
            tbxCrop2 = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // tbxStart
            // 
            tbxStart.Location = new System.Drawing.Point(105, 28);
            tbxStart.Name = "tbxStart";
            tbxStart.PlaceholderText = "Start";
            tbxStart.Size = new System.Drawing.Size(43, 23);
            tbxStart.TabIndex = 1;
            tbxStart.Text = "02:20";
            tbxStart.TextChanged += OnPathChanged;
            tbxStart.PreviewKeyDown += tbxStart_PreviewKeyDown;
            // 
            // tbxEnd
            // 
            tbxEnd.Location = new System.Drawing.Point(170, 28);
            tbxEnd.Name = "tbxEnd";
            tbxEnd.PlaceholderText = "End";
            tbxEnd.Size = new System.Drawing.Size(43, 23);
            tbxEnd.TabIndex = 2;
            tbxEnd.Text = "02:30";
            tbxEnd.TextChanged += OnPathChanged;
            tbxEnd.PreviewKeyDown += tbxStart_PreviewKeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(150, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 15);
            label1.TabIndex = 10;
            label1.Text = "to";
            // 
            // tbxPath
            // 
            tbxPath.Location = new System.Drawing.Point(1, 2);
            tbxPath.Name = "tbxPath";
            tbxPath.PlaceholderText = "Path";
            tbxPath.Size = new System.Drawing.Size(212, 23);
            tbxPath.TabIndex = 7;
            tbxPath.TextChanged += OnPathChanged;
            // 
            // tbxOut
            // 
            tbxOut.Location = new System.Drawing.Point(105, 57);
            tbxOut.Name = "tbxOut";
            tbxOut.PlaceholderText = "Clip name";
            tbxOut.Size = new System.Drawing.Size(108, 23);
            tbxOut.TabIndex = 0;
            tbxOut.TextChanged += UpdateCommandLineWithoutRestartingPlayer;
            tbxOut.Enter += tbxOut_Enter;
            tbxOut.PreviewKeyDown += tbxStart_PreviewKeyDown;
            // 
            // btnConvert
            // 
            btnConvert.Location = new System.Drawing.Point(1, 159);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(288, 23);
            btnConvert.TabIndex = 9;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvertClick;
            // 
            // tbxCommand
            // 
            tbxCommand.Location = new System.Drawing.Point(105, 86);
            tbxCommand.Name = "tbxCommand";
            tbxCommand.PlaceholderText = "Cmd";
            tbxCommand.Size = new System.Drawing.Size(184, 23);
            tbxCommand.TabIndex = 8;
            // 
            // audioChannels
            // 
            audioChannels.CheckOnClick = true;
            audioChannels.FormattingEnabled = true;
            audioChannels.Location = new System.Drawing.Point(1, 28);
            audioChannels.Name = "audioChannels";
            audioChannels.Size = new System.Drawing.Size(98, 94);
            audioChannels.TabIndex = 4;
            audioChannels.ItemCheck += audioChannels_ItemCheck;
            audioChannels.SelectedIndexChanged += audioChannels_SelectedIndexChanged;
            audioChannels.KeyUp += audioChannels_KeyUp;
            audioChannels.MouseUp += audioChannels_MouseUp;
            // 
            // tbxCRF
            // 
            tbxCRF.Location = new System.Drawing.Point(246, 28);
            tbxCRF.Name = "tbxCRF";
            tbxCRF.PlaceholderText = "0=best";
            tbxCRF.Size = new System.Drawing.Size(43, 23);
            tbxCRF.TabIndex = 3;
            tbxCRF.Text = "30";
            tbxCRF.TextChanged += UpdateCommandLineWithoutRestartingPlayer;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(219, 31);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(21, 15);
            label2.TabIndex = 11;
            label2.Text = "crf";
            // 
            // addExtraParams
            // 
            addExtraParams.AutoSize = true;
            addExtraParams.Checked = true;
            addExtraParams.CheckState = System.Windows.Forms.CheckState.Checked;
            addExtraParams.Location = new System.Drawing.Point(195, 115);
            addExtraParams.Name = "addExtraParams";
            addExtraParams.Size = new System.Drawing.Size(94, 19);
            addExtraParams.TabIndex = 6;
            addExtraParams.Text = "Extra params";
            addExtraParams.UseVisualStyleBackColor = true;
            addExtraParams.CheckedChanged += OnPathChanged;
            // 
            // deleteOriginal
            // 
            deleteOriginal.AutoSize = true;
            deleteOriginal.Location = new System.Drawing.Point(105, 115);
            deleteOriginal.Name = "deleteOriginal";
            deleteOriginal.Size = new System.Drawing.Size(81, 19);
            deleteOriginal.TabIndex = 5;
            deleteOriginal.Text = "Delete clip";
            deleteOriginal.UseVisualStyleBackColor = true;
            // 
            // extraEffects
            // 
            extraEffects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            extraEffects.FormattingEnabled = true;
            extraEffects.Items.AddRange(new object[] { "No extras", "To be continued", "Baldur dice" });
            extraEffects.Location = new System.Drawing.Point(1, 128);
            extraEffects.Name = "extraEffects";
            extraEffects.Size = new System.Drawing.Size(98, 23);
            extraEffects.TabIndex = 12;
            extraEffects.SelectedIndexChanged += extraEffects_SelectedIndexChanged;
            // 
            // keepOpen
            // 
            keepOpen.AutoSize = true;
            keepOpen.Location = new System.Drawing.Point(105, 134);
            keepOpen.Name = "keepOpen";
            keepOpen.Size = new System.Drawing.Size(82, 19);
            keepOpen.TabIndex = 13;
            keepOpen.Text = "Keep open";
            keepOpen.UseVisualStyleBackColor = true;
            // 
            // chkHideOverlay
            // 
            chkHideOverlay.AutoSize = true;
            chkHideOverlay.Location = new System.Drawing.Point(195, 134);
            chkHideOverlay.Name = "chkHideOverlay";
            chkHideOverlay.Size = new System.Drawing.Size(86, 19);
            chkHideOverlay.TabIndex = 14;
            chkHideOverlay.Text = "Hide Name";
            chkHideOverlay.UseVisualStyleBackColor = true;
            chkHideOverlay.CheckedChanged += chkHideOverlay_CheckedChanged;
            // 
            // chkPreview
            // 
            chkPreview.AutoSize = true;
            chkPreview.Checked = true;
            chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            chkPreview.Location = new System.Drawing.Point(222, 4);
            chkPreview.Name = "chkPreview";
            chkPreview.Size = new System.Drawing.Size(67, 19);
            chkPreview.TabIndex = 15;
            chkPreview.Text = "Preview";
            chkPreview.UseVisualStyleBackColor = true;
            chkPreview.CheckedChanged += chkPreview_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(251, 60);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(10, 15);
            label3.TabIndex = 18;
            label3.Text = ":";
            // 
            // tbxCrop1
            // 
            tbxCrop1.Location = new System.Drawing.Point(221, 57);
            tbxCrop1.Name = "tbxCrop1";
            tbxCrop1.PlaceholderText = "Start";
            tbxCrop1.Size = new System.Drawing.Size(24, 23);
            tbxCrop1.TabIndex = 16;
            tbxCrop1.Text = "16";
            tbxCrop1.TextChanged += UpdateCommandLineWithoutRestartingPlayer;
            tbxCrop1.DoubleClick += tbxCrop1_DoubleClick;
            // 
            // tbxCrop2
            // 
            tbxCrop2.Location = new System.Drawing.Point(265, 57);
            tbxCrop2.Name = "tbxCrop2";
            tbxCrop2.PlaceholderText = "End";
            tbxCrop2.Size = new System.Drawing.Size(24, 23);
            tbxCrop2.TabIndex = 17;
            tbxCrop2.Text = "9";
            tbxCrop2.TextChanged += UpdateCommandLineWithoutRestartingPlayer;
            // 
            // FormConvertVideos
            // 
            AcceptButton = btnConvert;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(626, 227);
            Controls.Add(label3);
            Controls.Add(tbxCrop2);
            Controls.Add(tbxCrop1);
            Controls.Add(chkPreview);
            Controls.Add(chkHideOverlay);
            Controls.Add(keepOpen);
            Controls.Add(extraEffects);
            Controls.Add(deleteOriginal);
            Controls.Add(audioChannels);
            Controls.Add(addExtraParams);
            Controls.Add(tbxCommand);
            Controls.Add(btnConvert);
            Controls.Add(tbxOut);
            Controls.Add(tbxPath);
            Controls.Add(tbxCRF);
            Controls.Add(label1);
            Controls.Add(tbxEnd);
            Controls.Add(label2);
            Controls.Add(tbxStart);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "FormConvertVideos";
            Text = "FFRight";
            TopMost = true;
            Activated += FormConvertVideos_Activated;
            Deactivate += FormConvertVideos_Deactivate;
            FormClosing += FormConvertVideos_FormClosing;
            Load += OnLoad;
            ResizeBegin += FormConvertVideos_Move;
            ResizeEnd += FormConvertVideos_ResizeEnd;
            Enter += FormConvertVideos_Enter;
            KeyUp += OnKeyUp;
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxCrop1;
        private System.Windows.Forms.TextBox tbxCrop2;
    }
}

