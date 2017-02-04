using Domain.Entities.Contingent;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.ContingentForms
{
    public partial class AddStudentForm : Form
    {
        ContingentForm _contingentForm;

        GroupRepository _groupRepo;

        public AddStudentForm(ContingentForm contingentForm)
        {
            InitializeComponent();
            _contingentForm = contingentForm;

            _groupRepo = new GroupRepository();

            LoadSources();
        }

        private void LoadSources()
        {
            LoadGroups();
        }

        private void LoadGroups()
        {
            var groups = _groupRepo.GetAll<Group>().ToList();
            GroupComboBox.DataSource = groups;
            GroupComboBox.DisplayMember = "Name";
            GroupComboBox.ValueMember = "Id";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                LastName = LastNameTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                MiddleName = MiddleNameTextBox.Text,
                BirthDate = BirthDateDateTimePicker.Value,
                GroupId = Guid.Parse(GroupComboBox.SelectedValue.ToString()),
                IsNew = true
            };
            string errorMessage;
            if (SaveToLocalDb(student, out errorMessage))
            {
                try
                {
                    var newIndex = _contingentForm.DataGridViewStudents.Rows.Add();
                    _contingentForm.DataGridViewStudents.Rows[newIndex].Cells["LastName"].Value = student.LastName;
                    _contingentForm.DataGridViewStudents.Rows[newIndex].Cells["FirstName"].Value = student.FirstName;
                    _contingentForm.DataGridViewStudents.Rows[newIndex].Cells["MiddleName"].Value = student.MiddleName;
                    _contingentForm.DataGridViewStudents.Rows[newIndex].Cells["BirthDate"].Value = student.BirthDate;

                    if (student.GroupId != null)
                    {
                        _contingentForm.DataGridViewStudents.Rows[newIndex].Cells["StudentGroupId"] = _contingentForm.InitDGVCB(_groupRepo.GetAll<Group>().ToList(), student.GroupId, "Name");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show(errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SaveToLocalDb(Student obj, out string errorMessage)
        {
            errorMessage = "";

            //TODO: Write to progress bar

            //Save to xml-db
            try
            {
                _groupRepo.Save(obj);
            }
            catch (Exception e)
            {
                //TODO: WriteLog("Breaking the initializing by exception, " + e.Message + ", count persons - " + i);
                errorMessage = e.Message;
                return false;
            }
            return true;
        }
    }
}
