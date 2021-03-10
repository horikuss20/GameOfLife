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
    public partial class RandomizeDialog : Form
    {
        public int newseed
        {
            get
            {
                if (SeedText.TextLength < 9)
                    return int.Parse(SeedText.Text);
                else return 10;
            }
            set
            {
                SeedText.Text = value.ToString();
            }
        }
        public RandomizeDialog()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CancelButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
        }
    }
}
