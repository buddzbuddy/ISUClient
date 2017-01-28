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
            string filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\isu-meta-local.xls";

            var hasFile = System.IO.File.Exists(filePath);
            if (hasFile)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath, Type.Missing, false, Type.Missing, System.Configuration.ConfigurationManager.AppSettings["workbookPass"], System.Configuration.ConfigurationManager.AppSettings["workbookPass"]);
                Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                var cells = excelWorksheet.Cells;
                var val = cells[5, 3].Value;
                excelWorkbook.Close();
                excelApp.Quit();

                MessageBox.Show(val);
            }
            else
            {
                MessageBox.Show("File not found!");
                return;
            }
            
            //MessageBox.Show(System.Configuration.ConfigurationManager.AppSettings["workbookPass"]);
        }

        private void TestResourceButton_Click(object sender, EventArgs e)
        {
            TestResource();
        }
    }
}
