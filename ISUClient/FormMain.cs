using ISUClient.ContingentForms;using System;
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
        ContingentForm _contingentForm = null;
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
            _contingentForm = new ContingentForm();
            DialogResult dialog = _contingentForm.ShowDialog();
        }

        private static void TestResource()
        {

            //var res = ISUClient.Resource_meta.ResourceManager.GetObject("isu_meta");
            
            //return;
        }

        private void TestResourceButton_Click(object sender, EventArgs e)
        {
            TestResource();
        }
    }
}
