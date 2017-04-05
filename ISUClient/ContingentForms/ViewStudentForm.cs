using Domain.Entities.Contingent;
using System;
using System.Windows.Forms;

namespace UI.ContingentForms
{
    public partial class ViewStudentForm : Form
    {
        ContingentForm _contingentForm = null;
        Student _obj;
        public ViewStudentForm(ContingentForm contingentForm, Student obj)
        {
            InitializeComponent();
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

        private void EditButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _contingentForm.EditStudent(_obj.Id);
        }

    }
}
