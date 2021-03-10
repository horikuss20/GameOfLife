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
    public partial class UniverseTypeDialog : Form
    {
        public bool FiniteUniverse; // false = toroidal
        public UniverseTypeDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FiniteUniverse = true;
            this.DialogResult = DialogResult.OK;
        }

        private void ToroidalButton_Click(object sender, EventArgs e)
        {
            FiniteUniverse = false;
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
