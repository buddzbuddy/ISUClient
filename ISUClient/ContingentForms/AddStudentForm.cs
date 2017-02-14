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
    public partial class AddStudentForm : Form
    {
        ContingentForm _contingentForm;
        ViewGroupForm _viewGroupForm;

        Guid _groupId;

        public AddStudentForm(ContingentForm contingentForm)
        {
            InitializeComponent();
            _contingentForm = contingentForm;
            FormManager.InitializeComboBoxes(this, new Student { PersonObj = new Person() });
        }
        public AddStudentForm(ContingentForm contingentForm, ViewGroupForm viewGroupForm, Guid groupId)
        {
            _viewGroupForm = viewGroupForm;
            _groupId = groupId;

            InitializeComponent();
            _contingentForm = contingentForm;
            FormManager.InitializeComboBoxes(this, new Student { PersonObj = new Person() });
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public Student FillObj(Student _obj)
        {
            _obj.PersonObj.PIN = StudentPersonPINTextBox.Text;
            _obj.PersonObj.LastName = StudentPersonLastNameTextBox.Text;
            _obj.PersonObj.FirstName = StudentPersonFirstNameTextBox.Text;
            _obj.PersonObj.MiddleName = StudentPersonMiddleNameTextBox.Text;
            _obj.PersonObj.BirthDate = StudentPersonBirthDateDateTimePicker.Value;
            _obj.PersonObj.Gender = (Guid)StudentPersonGenderComboBox.SelectedValue;
            _obj.PersonObj.Nationality = (Guid)StudentPersonNationalityComboBox.SelectedValue;
            _obj.PassportSeries = StudentPassportSeriesTextBox.Text;
            _obj.PassportNo = StudentPassportNoTextBox.Text;
            _obj.PersonalDocumentType = (Guid)StudentPersonalDocumentTypeComboBox.SelectedValue;
            _obj.Citizenship = (Guid)StudentCitizenshipComboBox.SelectedValue;

            _obj.Area = (Guid)StudentAreaComboBox.SelectedValue;
            _obj.District = (Guid)StudentDistrictComboBox.SelectedValue;
            _obj.Address = StudentAddressTextBox.Text;

            _obj.IsNeedHostel = StudentIsNeedHostelCheckBox.Checked;

            _obj.HomePhone = StudentHomePhoneTextBox.Text;
            _obj.MobilePhone = StudentMobilePhoneTextBox.Text;
            _obj.Email = StudentEmailTextBox.Text;

            _obj.HasCriminalRecord = StudentHasCriminalRecordCheckBox.Checked;
            _obj.SocialStatus = (Guid)StudentSocialStatusComboBox.SelectedValue;
            _obj.IsDisability = StudentIsDisabilityCheckBox.Checked;
            _obj.MilitaryStatus = (Guid)StudentMilitaryStatusComboBox.SelectedValue;

            _obj.Year = string.IsNullOrEmpty(StudentYearTextBox.Text) ? null : (int?)int.Parse(StudentYearTextBox.Text);
            _obj.EducationType = (Guid)StudentEducationTypeComboBox.SelectedValue;
            _obj.EducationDocumentType = (Guid)StudentEducationDocumentTypeComboBox.SelectedValue;
            _obj.EducationDocumentNo = StudentEducationDocumentNoTextBox.Text;
            _obj.EducationDocumentStatus = (Guid)StudentEducationDocumentStatusComboBox.SelectedValue;
            _obj.SecondaryEducationYear = string.IsNullOrEmpty(StudentSecondaryEducationYearTextBox.Text) ? null : (int?)int.Parse(StudentSecondaryEducationYearTextBox.Text);
            _obj.SchoolType = (Guid)StudentSchoolTypeComboBox.SelectedValue;
            _obj.SchoolName = StudentSchoolNameTextBox.Text;

            _obj.ReceiptType = (Guid)StudentReceiptTypeComboBox.SelectedValue;
            _obj.StudyPeriod = (Guid)StudentStudyPeriodComboBox.SelectedValue;
            _obj.Sector = (Guid)StudentSectorComboBox.SelectedValue;
            _obj.Profession = (Guid)StudentProfessionComboBox.SelectedValue;
            _obj.StudyMode = (Guid)StudentStudyModeComboBox.SelectedValue;
            _obj.EducationDirection = (Guid)StudentEducationDirectionComboBox.SelectedValue;
            _obj.PayType = (Guid)StudentPayTypeComboBox.SelectedValue;
            _obj.EducationEndType = (Guid)StudentEducationEndTypeComboBox.SelectedValue;


            _obj.Group = (Guid)StudentGroupComboBox.SelectedValue;
            _obj.AdmittedToQualifExam = (Guid)StudentAdmittedToQualifExamComboBox.SelectedValue;
            _obj.AdmittedToResultExam = (Guid)StudentAdmittedToResultExamComboBox.SelectedValue;
            _obj.PassedQualifExam = (Guid)StudentPassedQualifExamComboBox.SelectedValue;
            _obj.PassedResultExam = (Guid)StudentPassedResultExamComboBox.SelectedValue;

            return _obj;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var _docRepo = new DocRepository();

            var persons = _docRepo.GetAll<Person>();
            Person person = persons != null ? persons.FirstOrDefault(x =>
                !x.IsDeleted &&
                x.LastName.Equals(StudentPersonLastNameTextBox.Text) &&
                x.FirstName.Equals(StudentPersonFirstNameTextBox.Text) &&
                x.MiddleName.Equals(StudentPersonMiddleNameTextBox.Text) &&
                x.BirthDate.Date.Equals(StudentPersonBirthDateDateTimePicker.Value.Date)
                ) : null;
            if (person == null)
            {
                person = new Person
                {
                    Id = Guid.NewGuid(),
                    IsNew = true,
                    PIN = StudentPersonPINTextBox.Text,
                    LastName = StudentPersonLastNameTextBox.Text,
                    FirstName = StudentPersonFirstNameTextBox.Text,
                    MiddleName = StudentPersonMiddleNameTextBox.Text,
                    BirthDate = StudentPersonBirthDateDateTimePicker.Value.Date,
                    Gender = StudentPersonGenderComboBox.SelectedItem != null ? (Guid?)StudentPersonGenderComboBox.SelectedValue : null,
                    Nationality = StudentPersonNationalityComboBox.SelectedItem != null ? (Guid?)StudentPersonNationalityComboBox.SelectedValue : null
                };
                _docRepo.Save(person);
            }
            var student = FillObj(new Student
            {
                Id = Guid.NewGuid(),
                IsNew = true,
                IsDeleted = false,
                Person = person.Id,
                PersonObj = person
            });
            string errorMessage;
            if (SaveToLocalDb(student, out errorMessage))
            {
                try
                {
                    _docRepo = new DocRepository();
                    if(_docRepo.GetAll<Student>() == null) return;
                    var students = _docRepo.GetAll<Student>().ToList();
                    students.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                    FormManager.LoadToDataGridView(_contingentForm.DataGridViewStudents, students);
                    if (_viewGroupForm != null)
                    {
                        FormManager.LoadToDataGridView(_viewGroupForm.DataGridViewStudents, students.Where(x => x.Group == student.Group));
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
            var _docRepo = new DocRepository();
            errorMessage = "";

            //TODO: Write to progress bar

            //Save to xml-db
            try
            {
                _docRepo.Save(obj);
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
