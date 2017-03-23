using Domain.Entities.Staff;
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
    public partial class ViewEmployeeForm : Form
    {
        StaffForm _staffForm = null;
        Employee _obj = null;
        public ViewEmployeeForm(StaffForm staffForm, Employee obj)
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
    }
}
