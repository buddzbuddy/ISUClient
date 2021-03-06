﻿using Domain.Entities;
using Domain.Entities.Staff;
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

namespace UI.StaffForms
{
    public partial class AddEmployeeForm : Form
    {
        StaffForm _staffForm = null;
        public AddEmployeeForm(StaffForm staffForm)
        {
            InitializeComponent();

            _staffForm = staffForm;
            FormManager.InitializeComboBoxes(this, new Employee { PersonObj = new Person() });
        }
        public Employee FillObj(Employee _obj)
        {
            _obj.PersonObj.PIN = EmployeePersonPINTextBox.Text;
            _obj.PersonObj.LastName = EmployeePersonLastNameTextBox.Text;
            _obj.PersonObj.FirstName = EmployeePersonFirstNameTextBox.Text;
            _obj.PersonObj.MiddleName = EmployeePersonMiddleNameTextBox.Text;
            _obj.PersonObj.BirthDate = EmployeePersonBirthDateDateTimePicker.Value;
            _obj.PersonObj.Gender = (Guid)EmployeePersonGenderComboBox.SelectedValue;
            _obj.PersonObj.Nationality = (Guid)EmployeePersonNationalityComboBox.SelectedValue;
            _obj.MaritalStatus = (Guid)EmployeeMaritalStatusComboBox.SelectedValue;
            _obj.StaffType = (Guid)EmployeeStaffTypeComboBox.SelectedValue;
            _obj.Position = (Guid)EmployeePositionComboBox.SelectedValue;
            _obj.Teacher = (Guid)EmployeeTeacherComboBox.SelectedValue;
            _obj.Profession = (Guid)EmployeeProfessionComboBox.SelectedValue;
            _obj.PassportSeries = EmployeePassportSeriesTextBox.Text;
            _obj.PassportNo = EmployeePassportNoTextBox.Text;
            _obj.PassportOrg = EmployeePassportOrgTextBox.Text;
            _obj.PassportDate = EmployeePassportDateDateTimePicker.Value;
            _obj.Area = (Guid)EmployeeAreaComboBox.SelectedValue;
            _obj.District = (Guid)EmployeeDistrictComboBox.SelectedValue;
            _obj.Town = EmployeeTownTextBox.Text;
            _obj.Street = EmployeeStreetTextBox.Text;
            _obj.House = EmployeeHouseTextBox.Text;
            _obj.Apartment = EmployeeApartmentTextBox.Text;
            _obj.MobilePhone = EmployeeMobilePhoneTextBox.Text;
            _obj.WorkPhone = EmployeeWorkPhoneTextBox.Text;
            _obj.Email = EmployeeEmailTextBox.Text;
            _obj.EnabledToMilitary = (Guid)EmployeeEnabledToMilitaryComboBox.SelectedValue;
            _obj.MilitaryPosition = EmployeeMilitaryPositionTextBox.Text;
            _obj.MilitaryDistrictOfficeName = EmployeeMilitaryDistrictOfficeNameTextBox.Text;

            return _obj;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var _docRepo = new DocRepository();

            var persons = _docRepo.GetAll<Person>();
            Person person = persons != null ? persons.FirstOrDefault(x =>
                !x.IsDeleted &&
                x.LastName.Equals(EmployeePersonLastNameTextBox.Text) &&
                x.FirstName.Equals(EmployeePersonFirstNameTextBox.Text) &&
                x.MiddleName.Equals(EmployeePersonMiddleNameTextBox.Text) &&
                x.BirthDate.Date.Equals(EmployeePersonBirthDateDateTimePicker.Value.Date)
                ) : null;
            if (person == null)
            {
                person = new Person
                {
                    Id = Guid.NewGuid(),
                    IsNew = true,
                    PIN = EmployeePersonPINTextBox.Text,
                    LastName = EmployeePersonLastNameTextBox.Text,
                    FirstName = EmployeePersonFirstNameTextBox.Text,
                    MiddleName = EmployeePersonMiddleNameTextBox.Text,
                    BirthDate = EmployeePersonBirthDateDateTimePicker.Value.Date,
                    Gender = EmployeePersonGenderComboBox.SelectedItem != null ? (Guid?)EmployeePersonGenderComboBox.SelectedValue : null,
                    Nationality = EmployeePersonNationalityComboBox.SelectedItem != null ? (Guid?)EmployeePersonNationalityComboBox.SelectedValue : null
                };
                _docRepo.Save(person);
            }
            var employee = FillObj(new Employee
            {
                Id = Guid.NewGuid(),
                IsNew = true,
                IsDeleted = false,
                Person = person.Id,
                PersonObj = person
            });
            string errorMessage;
            if (SaveToLocalDb(employee, out errorMessage))
            {
                try
                {
                    _docRepo = new DocRepository();
                    if (_docRepo.GetAll<Employee>() == null) return;
                    var employees = _docRepo.GetAll<Employee>().ToList();
                    employees.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                    FormManager.LoadToDataGridView(_staffForm.DataGridViewEmployees, employees);
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
        private bool SaveToLocalDb(Employee obj, out string errorMessage)
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
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
