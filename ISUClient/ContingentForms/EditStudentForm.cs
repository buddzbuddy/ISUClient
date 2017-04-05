using Domain.Entities;
using Domain.Entities.Contingent;
using Domain.StaticReferences;
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
    public partial class EditStudentForm : Form
    {
        ContingentForm _contingentForm = null;

        Student _obj;

        public EditStudentForm(ContingentForm contingentForm, Student obj)
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.HScroll = true;
            this.VScroll = true;
            _contingentForm = contingentForm;
            _obj = obj;

            StudentPersonPINTextBox.Text = obj.PersonObj.PIN;
            StudentPersonLastNameTextBox.Text = obj.PersonObj.LastName;
            StudentPersonFirstNameTextBox.Text = obj.PersonObj.FirstName;
            StudentPersonMiddleNameTextBox.Text = obj.PersonObj.MiddleName;
            StudentPersonBirthDateDateTimePicker.Value = obj.PersonObj.BirthDate;

            StudentPassportSeriesTextBox.Text = obj.PassportSeries;
            StudentPassportNoTextBox.Text = obj.PassportNo;

            FormManager.InitializeComboBoxes(this, obj);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string errorMessage;
            FillObj();
            if (SaveToLocalDb(out errorMessage))
            {
                try
                {
                    var _docRepo = new DocRepository();
                    if(_docRepo.GetAll<Student>() != null)
                    {
                        var Students = _docRepo.GetAll<Student>().ToList();
                        Students.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                        FormManager.LoadToDataGridView(_contingentForm.DataGridViewStudents, Students);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillObj()
        {
            _obj.PersonObj.PIN = StudentPersonPINTextBox.Text;
            _obj.PersonObj.LastName = StudentPersonLastNameTextBox.Text;
            _obj.PersonObj.FirstName = StudentPersonFirstNameTextBox.Text;
            _obj.PersonObj.MiddleName = StudentPersonMiddleNameTextBox.Text;
            _obj.PersonObj.BirthDate = StudentPersonBirthDateDateTimePicker.Value;

            _obj.PersonObj.Gender = (Guid)StudentPersonGenderComboBox.SelectedValue;
            _obj.PersonObj.Nationality = (Guid)StudentPersonNationalityComboBox.SelectedValue;
            _obj.Group = (Guid)StudentGroupComboBox.SelectedValue;
            _obj.PassportSeries = StudentPassportSeriesTextBox.Text;
            _obj.PassportNo = StudentPassportNoTextBox.Text;
            _obj.PersonalDocumentType = (Guid)StudentPersonalDocumentTypeComboBox.SelectedValue;
        }

        private bool SaveToLocalDb(out string errorMessage)
        {
            var _docRepo = new DocRepository();
            errorMessage = "";
            //TODO: Write to progress bar

            //Save changes to xml-db
            try
            {
                if (!PropertiesHelper.PublicInstancePropertiesEqual(_obj.PersonObj, _docRepo.Get<Person>(_obj.Person)))
                {
                    _obj.PersonObj.IsModified = true;
                    _docRepo.Save(_obj.PersonObj, true);
                }

                if (!PropertiesHelper.PublicInstancePropertiesEqual(_obj, _docRepo.Get<Student>(_obj.Id)))
                {
                    _obj.IsModified = true;
                    _docRepo.Save(_obj, true);
                }
            }
            catch (Exception e)
            {
                //TODO: WriteLog("Breaking the initializing by exception, " + e.Message + ", count persons - " + i);
                errorMessage = e.Message;
                return false;
            }
            return true;
        }

        /*private void EditStudentForm_Load(object sender, EventArgs e)
        {
            Panel my_panel = new Panel();
            VScrollBar vScroller = new VScrollBar();
            vScroller.Dock = DockStyle.Right;
            vScroller.Width = 30;
            vScroller.Height = 200;
            vScroller.Name = "VScrollBar1";
            my_panel.Controls.Add(vScroller);
            
        }*/
    }
}
