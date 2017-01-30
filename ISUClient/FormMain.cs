using UI.AccountForms;
using UI.ContingentForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormMain : Form
    {
        ContingentForm _contingentForm = null;
        public FormMain()
        {
            InitializeComponent();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автономная программа заполнения ИСУ без подключения к сети интернет.");
        }

        private void ContingentOpenButton_Click(object sender, EventArgs e)
        {
            _contingentForm = new ContingentForm();
            DialogResult dialog = _contingentForm.ShowDialog();
        }

        public void FillUserInfo(string userName, string positionName, string OrgName, string userIdStr)
        {
            UserNameTextBox.Text = userName;
            PositionNameTextBox.Text = positionName;
            OrganizationNameTextBox.Text = OrgName;
            UserIdTextBox.Text = userIdStr;
        }

        public void EnableContingent()
        {
            ContingentOpenButton.Enabled = true;
        }
        public void EnableLedger()
        {
            LedgerOpenButton.Enabled = true;
        }
        public void EnableEmployee()
        {
            EmployeeOpenButton.Enabled = true;
        }
        public void EnableAll()
        {
            EnableContingent();
            EnableLedger();
            EnableEmployee();
        }
    }
}