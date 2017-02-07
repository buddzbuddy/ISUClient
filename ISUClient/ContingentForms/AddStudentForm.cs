﻿using Domain.Entities;
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

        DocRepository _docRepo;
        EnumRepository _enumRepo;

        Guid _groupId;

        public AddStudentForm(ContingentForm contingentForm)
        {
            InitializeComponent();
            _contingentForm = contingentForm;

            _docRepo = new DocRepository();
            _enumRepo = new EnumRepository();
            LoadSources();
        }
        public AddStudentForm(ContingentForm contingentForm, ViewGroupForm viewGroupForm, Guid groupId)
        {
            _viewGroupForm = viewGroupForm;
            _groupId = groupId;

            InitializeComponent();
            _contingentForm = contingentForm;

            _docRepo = new DocRepository();
            LoadSources();
        }

        private void LoadSources()
        {
            LoadGroups();
            LoadGenders();
            LoadNationalities();
        }

        private void LoadGroups()
        {
            var groups = _docRepo.GetAll<Group>().ToList();
            GroupComboBox.DataSource = groups;
            GroupComboBox.DisplayMember = "Name";
            GroupComboBox.ValueMember = "Id";
            if (_viewGroupForm != null)
                GroupComboBox.SelectedValue = _groupId;
        }

        private void LoadGenders()
        {
            GenderComboBox.DataSource = _enumRepo.GetEnum(Enums.GenderEnumDefId).Items;
            GenderComboBox.DisplayMember = "FullName";
            GenderComboBox.ValueMember = "Id";
        }

        private void LoadNationalities()
        {
            NationalityComboBox.DataSource = _enumRepo.GetEnum(Enums.NationalityEnumDefId).Items;
            NationalityComboBox.DisplayMember = "FullName";
            NationalityComboBox.ValueMember = "Id";
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var persons = _docRepo.GetAll<Person>();
            Person person = persons != null ? persons.FirstOrDefault(x =>
                !x.IsDeleted &&
                x.LastName.Equals(LastNameTextBox.Text) &&
                x.FirstName.Equals(FirstNameTextBox.Text) &&
                x.MiddleName.Equals(MiddleNameTextBox.Text) &&
                x.BirthDate.Date.Equals(BirthDateDateTimePicker.Value.Date)
                ) : null;
            if (person == null)
            {
                person = new Person
                {
                    Id = Guid.NewGuid(),
                    IsNew = true,
                    PIN = PINTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    FirstName = FirstNameTextBox.Text,
                    MiddleName = MiddleNameTextBox.Text,
                    BirthDate = BirthDateDateTimePicker.Value.Date,
                    Gender = GenderComboBox.SelectedItem != null ? (Guid?)GenderComboBox.SelectedValue : null,
                    Nationality = NationalityComboBox.SelectedItem != null ? (Guid?)NationalityComboBox.SelectedValue : null
                };
                _docRepo.Save(person);
            }
            var student = new Student
            {
                Id = Guid.NewGuid(),
                PersonId = person.Id,
                Person = person,
                Group = Guid.Parse(GroupComboBox.SelectedValue.ToString()),
                IsNew = true
            };
            string errorMessage;
            if (SaveToLocalDb(student, out errorMessage))
            {
                try
                {
                    AddToDataGridViewStudents(student, _contingentForm.DataGridViewStudents);
                    if (_viewGroupForm != null)
                    {
                        //AddToDataGridViewStudents(student, _contingentForm.DataGridViewStudents);
                        AddToDataGridViewStudents(student, _viewGroupForm.DataGridViewStudents);
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
        private void AddToDataGridViewStudents(Student obj, DataGridView dataGridView)
        {
            var newIndex = dataGridView.Rows.Add();
            dataGridView.Rows[newIndex].Cells["PIN"].Value = obj.Person.PIN;
            dataGridView.Rows[newIndex].Cells["LastName"].Value = obj.Person.LastName;
            dataGridView.Rows[newIndex].Cells["FirstName"].Value = obj.Person.FirstName;
            dataGridView.Rows[newIndex].Cells["MiddleName"].Value = obj.Person.MiddleName;
            dataGridView.Rows[newIndex].Cells["BirthDate"].Value = obj.Person.BirthDate;

            if (obj.Group != null && dataGridView.Columns["StudentGroup"] != null)
            {
                _contingentForm.DataGridViewStudents.Rows[newIndex].Cells["StudentGroup"] = _contingentForm.InitDGVCB(_docRepo.GetAll<Group>().ToList(), obj.Group, "Name");
            }

            if (obj.Person.Gender != null && dataGridView.Columns["StudentGender"] != null)
            {
                _contingentForm.DataGridViewStudents.Rows[newIndex].Cells["StudentGender"] = _contingentForm.InitDGVCB(_enumRepo.GetEnum(Enums.GenderEnumDefId).Items, obj.Person.Gender);
            }

            if (obj.Person.Nationality != null && dataGridView.Columns["StudentNationality"] != null)
            {
                _contingentForm.DataGridViewStudents.Rows[newIndex].Cells["StudentNationality"] = _contingentForm.InitDGVCB(_enumRepo.GetEnum(Enums.NationalityEnumDefId).Items, obj.Person.Nationality);
            }
        }
        private bool SaveToLocalDb(Student obj, out string errorMessage)
        {
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
