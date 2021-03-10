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
    public partial class UniverseDialog : Form
    {
        public UniverseDialog()
        {
            InitializeComponent();
        }

        private void UniverseDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
        }
        public int UniverseX
        {
            get
            {
                return int.Parse(UniverseXtxt.Text);
            }

            set
            {
                UniverseXtxt.Text = value.ToString();
            }
        }
        public int UniverseY
        {
            get
            {
                return int.Parse(UniverseYtxt.Text);
            }

            set
            {
                UniverseYtxt.Text = value.ToString();
            }
        }
    }
}
