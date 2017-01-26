using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISUClient
{
    public partial class FormMain : Form
    {
        ContingentForm _contingent = null;
        public FormMain()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автономная программа");
        }

        private void opentContingent_Click(object sender, EventArgs e)
        {
            _contingent = new ContingentForm();
            DialogResult dialog = _contingent.ShowDialog();
        }
    }
}
