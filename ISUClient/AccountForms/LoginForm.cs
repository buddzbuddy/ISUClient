using Domain.StaticReferences;
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
        public LoginForm(FormMain formMain)
        {
            _formMain = formMain;
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

            if (AuthenticateUser(userName, password, out positionIdStr, out orgName, out userIdStr, out errorMessage))
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
                    else if (positionId == OrgStructures.EmployeeEntryPositionId)
                    {
                        _formMain.EnableEmployee();
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

        private bool AuthenticateUser(string userName, string password, out string positionIdStr, out string orgName, out string userIdStr, out string errorMessage)
        {
            positionIdStr = "";
            orgName = "";
            userIdStr = "";
            errorMessage = "";
            string fileName = "isu-meta-local.xls";
            string dbpassword = "QQQwww123";
            string fileLocation = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string fullPath = System.IO.Path.Combine(fileLocation, fileName);

            int userNameColIndex = 36;
            int passwordColIndex = 37;
            int fnColIndex = 38;
            int lnColIndex = 46;
            int userIdColIndex = 39;
            int positionIdColIndex = 35;
            int orgIdColIndex = 43;
            int orgNameColIndex = 31;

            int rowMax = 1000;


            var hasFile = System.IO.File.Exists(fullPath);
            if (hasFile)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                try
                {
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(
                        fullPath,
                        Type.Missing,
                        false,
                        Type.Missing,
                        dbpassword);
                    Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = excelWorkbook.Worksheets[1];

                    var cells = excelWorksheet.Cells;

                    bool isLogged = false;
                    for (int row = 1; row <= rowMax; row++)
                    {
                        var userNameDb = cells[row, userNameColIndex].Value;
                        var passwordDb = cells[row, passwordColIndex].Value;
                        if (!string.IsNullOrEmpty(userNameDb) && !string.IsNullOrEmpty(passwordDb))
                        {
                            if (userName.ToUpper().Equals(userNameDb.ToUpper()) && password.ToUpper().Equals(passwordDb.ToUpper()))
                            {
                                positionIdStr = cells[row, positionIdColIndex].Value;
                                orgName = cells[row, orgNameColIndex].Value;
                                userIdStr = cells[row, userIdColIndex].Value;
                                isLogged = true;
                                break;
                            }
                        }
                    }
                    excelWorkbook.Close();
                    excelApp.Quit();

                    return isLogged;
                }
                catch (Exception e)
                {
                    errorMessage = "Проблемы при открытии мета-базы ИСУ. Описание: \"" + e.Message + "\"";
                }
                finally
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            else
            {
                errorMessage = "Файл \"" + fileName + "\" не найден.\n\n\nДанный файл дожен находиться в этой папке: \"" + fileLocation + "\"\n\n\nПожалуйста обратитесь за помощью к администраторам ИСУ.";
            }

            return false;
        }
    }
}
