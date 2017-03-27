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

namespace UI.AccountForms
{
    public partial class LoginForm : Form
    {
        FormMain _formMain = null;
        AccountRepository _accountRepo;
        public LoginForm(FormMain formMain)
        {
            _formMain = formMain;
            _accountRepo = new AccountRepository(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var userName = UserNameTextBox.Text;
            var password = PasswordTextBox.Text;
            string errorMessage;
            string positionIdStr;
            string orgName;
            string userIdStr;

            if(string.IsNullOrEmpty(userName))
            {
                UserNameTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                PasswordTextBox.Focus();
                return;
            }
            LoginButton.Enabled = false;

            if (_accountRepo.AuthenticateUser2(userName, password, out positionIdStr, out orgName, out userIdStr, out errorMessage))
            {
                // save the user has logged in somewhere
                // set the dialog result to ok
                this.DialogResult = DialogResult.OK;

                string positionName = "Должность не распознана";
                Guid positionId = Guid.Empty;
                if (Guid.TryParse(positionIdStr, out positionId))
                {
                    positionName = OrgStructures.GetPositionName(positionId);

                    if (positionId == OrgStructures.StudentEntryPositionId)
                    {
                        _formMain.EnableContingent();
                    }
                    else if (positionId == OrgStructures.LedgerEntryPositionId)
                    {
                        _formMain.EnableLedger();
                    }
                    else if (positionId == OrgStructures.StudentEntryPositionId)
                    {
                        _formMain.EnableStudent();
                    }
                    else if (positionId == OrgStructures.AllEntryPositionId)
                    {
                        _formMain.EnableAll();
                    }
                }


                _formMain.FillUserInfo(userName, positionName, orgName, userIdStr);

                // close the dialog
                this.Close();
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMessage))//another errors
                {
                    MessageBox.Show(errorMessage);
                    this.Close();
                }
                else// just login failed
                    MessageBox.Show("Вход в систему не произведен. Неправильные имя пользователя или пароль.");
                // do not close the window
            }
            LoginButton.Enabled = true;
        }
    }
}
