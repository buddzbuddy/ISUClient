using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class AccountRepository
    {
        private string _fileLocation = "";
        public AccountRepository()
        {

        }
        public AccountRepository(string fileLocation)
        {
            _fileLocation = fileLocation;
        }
        public bool AuthenticateUser(string userName, string password, out string positionIdStr, out string orgName, out string userIdStr, out string errorMessage)
        {
            positionIdStr = "";
            orgName = "";
            userIdStr = "";
            errorMessage = "";
            string dbpassword = DBConfigInfo.accountMetaDBPassword;
            string fullPath = System.IO.Path.Combine(_fileLocation, DBConfigInfo.AccountMetaFileName);

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
                        if (userNameDb != null && passwordDb != null)
                        {
                            if (!string.IsNullOrEmpty(userNameDb.ToString()) && !string.IsNullOrEmpty(passwordDb.ToString()))
                            {
                                if (userName.ToUpper().Equals(userNameDb.ToUpper()) && password.ToUpper().Equals(passwordDb.ToString().ToUpper()))
                                {
                                    positionIdStr = cells[row, positionIdColIndex].Value;
                                    orgName = cells[row, orgNameColIndex].Value;
                                    userIdStr = cells[row, userIdColIndex].Value;
                                    isLogged = true;
                                    break;
                                }
                            }
                        }
                    }
                    excelWorkbook.Close();
                    excelApp.Quit();

                    return isLogged;
                }
                catch (Exception e)
                {
                    errorMessage = "Проблемы при открытии мета-базы ИСУ. Описание: \"" + e.Message + "\", stacktrace: " + e.StackTrace;
                }
                finally
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            else
            {
                errorMessage = "Файл \"" + DBConfigInfo.AccountMetaFileName + "\" не найден.\n\n\nДанный файл дожен находиться в этой папке: \"" + _fileLocation + "\"\n\n\nПожалуйста обратитесь за помощью к администраторам ИСУ.";
            }

            return false;
        }
    }
}
