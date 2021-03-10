using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoahWilson_GOL
{
    public partial class TimerDialog : Form
    {
        public TimerDialog()
        {
            InitializeComponent();
        }

        private void TimerDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
        }
        public int timervalue
        {
            get
            {
                return int.Parse(TimerText.Text);
            }
            set
            {
                TimerText.Text = value.ToString();
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (TimerText.Text == "")
            {
                MessageBox.Show("Please input a number for your timer interval");
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
