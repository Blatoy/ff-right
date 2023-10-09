namespace ffright
{
    partial class DiceUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            radioSuccess = new System.Windows.Forms.RadioButton();
            groupBox1 = new System.Windows.Forms.GroupBox();
            radioFail = new System.Windows.Forms.RadioButton();
            tbxDiceMessage = new System.Windows.Forms.TextBox();
            tbxTime = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // radioSuccess
            // 
            radioSuccess.AutoSize = true;
            radioSuccess.Location = new System.Drawing.Point(6, 22);
            radioSuccess.Name = "radioSuccess";
            radioSuccess.Size = new System.Drawing.Size(66, 19);
            radioSuccess.TabIndex = 0;
            radioSuccess.TabStop = true;
            radioSuccess.Text = "Success";
            radioSuccess.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioFail);
            groupBox1.Controls.Add(radioSuccess);
            groupBox1.Location = new System.Drawing.Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(135, 49);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Type";
            // 
            // radioFail
            // 
            radioFail.AutoSize = true;
            radioFail.Location = new System.Drawing.Point(78, 22);
            radioFail.Name = "radioFail";
            radioFail.Size = new System.Drawing.Size(43, 19);
            radioFail.TabIndex = 1;
            radioFail.TabStop = true;
            radioFail.Text = "Fail";
            radioFail.UseVisualStyleBackColor = true;
            // 
            // tbxDiceMessage
            // 
            tbxDiceMessage.Location = new System.Drawing.Point(13, 87);
            tbxDiceMessage.Name = "tbxDiceMessage";
            tbxDiceMessage.PlaceholderText = "Skill Type";
            tbxDiceMessage.Size = new System.Drawing.Size(134, 23);
            tbxDiceMessage.TabIndex = 2;
            // 
            // tbxTime
            // 
            tbxTime.Location = new System.Drawing.Point(90, 58);
            tbxTime.Name = "tbxTime";
            tbxTime.PlaceholderText = "Start";
            tbxTime.Size = new System.Drawing.Size(57, 23);
            tbxTime.TabIndex = 1;
            tbxTime.Text = "02:20";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 61);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 15);
            label1.TabIndex = 3;
            label1.Text = "Start time";
            // 
            // DiceUI
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(159, 121);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(tbxTime);
            Controls.Add(tbxDiceMessage);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            Name = "DiceUI";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Baldur Dice Effect";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton radioSuccess;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioFail;
        private System.Windows.Forms.TextBox tbxDiceMessage;
        private System.Windows.Forms.TextBox tbxTime;
        private System.Windows.Forms.Label label1;
    }
}