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
        ContingentRepository _contingentRepo;
        EnumRepository _enumRepo;

        public ContingentForm()
        {
            InitializeComponent();
            _groupRepo = new GroupRepository();
            _contingentRepo = new ContingentRepository();
            _enumRepo = new EnumRepository();
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
            _contingentRepo.ClipboardToExcel();
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

                    if (group.LanguageId != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["Language"].Value = _enumRepo.GetEnumItem(group.LanguageId.Value).FullName;
                    }
                    /*if (group.ProfessionId != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["Profession"].Value = group.ProfessionId;
                    }*/
                    if (group.StudyPeriodId != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["StudyPeriod"].Value = _enumRepo.GetEnumItem(group.StudyPeriodId.Value).FullName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
