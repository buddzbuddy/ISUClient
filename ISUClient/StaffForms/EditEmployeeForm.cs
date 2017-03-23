using Domain.Entities;
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
    public partial class EditEmployeeForm : Form
    {
        StaffForm _staffForm = null;
        Employee _obj = null;
        public EditEmployeeForm(StaffForm staffForm, Employee obj)
        {
            InitializeComponent();

            _staffForm = staffForm;
            _obj = obj;

            EmployeePersonPINTextBox.Text = obj.PersonObj.PIN;
            EmployeePersonLastNameTextBox.Text = obj.PersonObj.LastName;
            EmployeePersonFirstNameTextBox.Text = obj.PersonObj.FirstName;
            EmployeePersonMiddleNameTextBox.Text = obj.PersonObj.MiddleName;
            EmployeePersonBirthDateDateTimePicker.Value = obj.PersonObj.BirthDate;

            EmployeePassportSeriesTextBox.Text = obj.PassportSeries;
            EmployeePassportNoTextBox.Text = obj.PassportNo;
            EmployeePassportOrgTextBox.Text = obj.PassportOrg;
            EmployeePassportDateDateTimePicker.Value = obj.PassportDate ?? DateTime.Now;
            EmployeeTownTextBox.Text = obj.Town;
            EmployeeStreetTextBox.Text = obj.Street;
            EmployeeHouseTextBox.Text = obj.House;
            EmployeeApartmentTextBox.Text = obj.Apartment;
            EmployeeMobilePhoneTextBox.Text = obj.MobilePhone;
            EmployeeWorkPhoneTextBox.Text = obj.WorkPhone;
            EmployeeEmailTextBox.Text = obj.Email;
            EmployeeMilitaryPositionTextBox.Text = obj.MilitaryPosition;
            EmployeeMilitaryDistrictOfficeNameTextBox.Text = obj.MilitaryDistrictOfficeName;

            FormManager.InitializeComboBoxes(this, obj);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Employee FillObj()
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
            string errorMessage;
            FillObj();
            if (SaveToLocalDb(out errorMessage))
            {
                try
                {
                    var _docRepo = new DocRepository();
                    if (_docRepo.GetAll<Employee>() != null)
                    {
                        var Employees = _docRepo.GetAll<Employee>().ToList();
                        Employees.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                        FormManager.LoadToDataGridView(_staffForm.DataGridViewEmployees, Employees);
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
        private bool SaveToLocalDb(out string errorMessage)
        {
            var _docRepo = new DocRepository();
            errorMessage = "";

            //TODO: Write to progress bar

            //Save changes to xml-db
            try
            {
                _docRepo.Save(_obj, true);
                _docRepo.Save(_obj.PersonObj, true);
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
