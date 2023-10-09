using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ffright
{
    public partial class DiceUI : Form
    {
        public TextBox diceMessage;
        public TextBox startTime;
        public RadioButton failure;
        public RadioButton success;

        public DiceUI()
        {
            InitializeComponent();
            diceMessage = tbxDiceMessage;
            startTime = tbxTime;
            failure = radioFail;
            success = radioSuccess;
        }
    }
}
