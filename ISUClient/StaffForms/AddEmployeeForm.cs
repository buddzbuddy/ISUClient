using Domain.Entities;
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
    public partial class AddEmployeeForm : Form
    {
        StaffForm _staffForm = null;
        public AddEmployeeForm(StaffForm staffForm)
        {
            InitializeComponent();

            _staffForm = staffForm;
            FormManager.InitializeComboBoxes(this, new Employee { PersonObj = new Person() });
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
