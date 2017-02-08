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
    public partial class ViewGroupForm : Form
    {
        ContingentForm _contingentForm = null;
        AddStudentForm _addStudentForm = null;

        EnumRepository _enumRepo;
        DocRepository _docRepo;
        Group _obj;
        public ViewGroupForm(ContingentForm contingentForm, Group obj)
        {
            InitializeComponent();

            _contingentForm = contingentForm;
            _enumRepo = new EnumRepository();
            _docRepo = new DocRepository();
            _obj = obj;

            NameTextBox.Text = obj.Name;
            InitSources(obj.Language, obj.StudyPeriod, obj.Profession);
        }

        private void InitSources(Guid? Language, Guid? studyPeriodId, Guid? professionId)
        {
            InitLanguages(Language);
            InitStudyPeriods(studyPeriodId);
            InitProfessions(professionId);

            var students = _docRepo.GetAll<Student>();
            if (students == null) return;
            _contingentForm.LoadStudentsFromDb(DataGridViewStudents, students.Where(x => !x.IsDeleted && x.Group == _obj.Id));
        }

        private void InitLanguages(Guid? value)
        {
            LanguageComboBox.DataSource = _enumRepo.GetEnum(Enums.LanguageEnumDefId).Items;
            LanguageComboBox.DisplayMember = "FullName";
            LanguageComboBox.ValueMember = "Id";
            if (value != null)
                LanguageComboBox.SelectedValue = value;
        }
        private void InitStudyPeriods(Guid? value)
        {
            StudyPeriodComboBox.DataSource = _enumRepo.GetEnum(Enums.StudyPeriodEnumDefId).Items;
            StudyPeriodComboBox.DisplayMember = "FullName";
            StudyPeriodComboBox.ValueMember = "Id";
            if (value != null)
                StudyPeriodComboBox.SelectedValue = value;
        }

        private void InitProfessions(Guid? value)
        {
            ProfessionComboBox.DataSource = _docRepo.GetAll<Profession>().ToList();
            ProfessionComboBox.DisplayMember = "Name";
            ProfessionComboBox.ValueMember = "Id";
            if (value != null)
                ProfessionComboBox.SelectedValue = value;
        }

        private void LoadStudents()
        {
            try
            {
                var students = _docRepo.GetAll<Student>();
                if (students == null) return;
                foreach (var student in students.Where(x => !x.IsDeleted && x.Group == _obj.Id))
                {
                    student.PersonObj = _docRepo.Get<Person>(student.Person);
                    var newIndex = DataGridViewStudents.Rows.Add();
                    DataGridViewStudents.Rows[newIndex].Cells["LastName"].Value = student.PersonObj.LastName;
                    DataGridViewStudents.Rows[newIndex].Cells["FirstName"].Value = student.PersonObj.FirstName;
                    DataGridViewStudents.Rows[newIndex].Cells["MiddleName"].Value = student.PersonObj.MiddleName;
                    DataGridViewStudents.Rows[newIndex].Cells["BirthDate"].Value = student.PersonObj.BirthDate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void AddStudent()
        {
            _addStudentForm = new AddStudentForm(_contingentForm, this, _obj.Id);
            DialogResult dialog = _addStudentForm.ShowDialog();
        }
    }
}
