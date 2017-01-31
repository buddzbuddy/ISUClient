using UI.ContingentForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Logic.Implementations;

namespace UI
{
    public partial class ContingentForm : Form
    {

        AddStudentForm _addStudentForm = null;
        AddGroupForm _addGroupForm = null;

        GroupRepository _groupRepo;

        public ContingentForm()
        {
            InitializeComponent();
            _groupRepo = new GroupRepository();
            LoadGroupsFromDb();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            _addStudentForm = new AddStudentForm();
            DialogResult dialog = _addStudentForm.ShowDialog();
        }

        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            _addGroupForm = new AddGroupForm(this);
            DialogResult dialog = _addGroupForm.ShowDialog();
        }
        private void copyAlltoClipboard()
        {
            DataGridViewGroups.SelectAll();
            DataObject dataObj = DataGridViewGroups.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void ToExcelGroupsButton_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void LoadGroupsFromDb()
        {
            try
            {
                var groups = _groupRepo.GetAll();
                if (groups == null) return;
                foreach (var group in groups)
                {
                    var newIndex = DataGridViewGroups.Rows.Add();
                    DataGridViewGroups.Rows[newIndex].Cells["GroupName"].Value = group.Name;

                    if (group.Language != "") DataGridViewGroups.Rows[newIndex].Cells["Language"].Value = group.Language;
                    if (group.Profession != "") DataGridViewGroups.Rows[newIndex].Cells["Profession"].Value = group.Profession;
                    if (group.StudyPeriod != "") DataGridViewGroups.Rows[newIndex].Cells["StudyPeriod"].Value = group.StudyPeriod;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
