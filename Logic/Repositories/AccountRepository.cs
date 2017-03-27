using Domain.Entities.Meta;
using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public bool AuthenticateUser2(string userName, string password, out string positionIdStr, out string orgName, out string userIdStr, out string errorMessage)
        {
            positionIdStr = "";
            orgName = "";
            userIdStr = "";
            errorMessage = "";
            string fullPath = System.IO.Path.Combine(_fileLocation, DBConfigInfo.AccountMetaFileName2);

            var xAccounts = XDocument.Load(fullPath);
            var organizations = new List<Organization>();
            var workers = new List<Worker>();

            foreach (var x in xAccounts.Root.Descendants("Organization"))
            {
                organizations.Add(new Organization
                {
                    Id = x.Attribute("Id") != null ? Guid.Parse(x.Attribute("Id").Value) : Guid.Empty,
                    Code = x.Attribute("Code") != null ? x.Attribute("Code").Value : "",
                    Deleted = x.Attribute("Deleted") != null ? bool.Parse(x.Attribute("Deleted").Value) : true,
                    Description = x.Attribute("Description") != null ? x.Attribute("Description").Value : "",
                    FullName = x.Attribute("FullName") != null ? x.Attribute("FullName").Value : "",
                    OrderIndex = x.Attribute("OrderIndex") != null ? int.Parse(x.Attribute("OrderIndex").Value) : 0,
                    OrgUnitId = x.Attribute("OrgUnitId") != null ? Guid.Parse(x.Attribute("OrgUnitId").Value) : Guid.Empty,
                    ParentId = x.Attribute("ParentId") != null ? Guid.Parse(x.Attribute("ParentId").Value) : Guid.Empty
                });
            }
            foreach (var x in xAccounts.Root.Descendants("Worker"))
            {
                workers.Add(new Worker
                {
                    Id = x.Attribute("Id") != null ? Guid.Parse(x.Attribute("Id").Value) : Guid.Empty,
                    Deleted = x.Attribute("Deleted") != null ? bool.Parse(x.Attribute("Deleted").Value) : true,
                    Description = x.Attribute("Description") != null ? x.Attribute("Description").Value : "",
                    FullName = x.Attribute("FullName") != null ? x.Attribute("FullName").Value : "",
                    OrderIndex = x.Attribute("OrderIndex") != null ? int.Parse(x.Attribute("OrderIndex").Value) : 0,
                    ParentId = x.Attribute("ParentId") != null ? Guid.Parse(x.Attribute("ParentId").Value) : Guid.Empty,
                    FirstName = x.Attribute("FirstName") != null ? x.Attribute("FirstName").Value : "",
                    LastName = x.Attribute("LastName") != null ? x.Attribute("LastName").Value : "",
                    Name = x.Attribute("Name") != null ? x.Attribute("Name").Value : "",
                    Password = x.Attribute("Password") != null ? x.Attribute("Password").Value : "",
                    UserName = x.Attribute("UserName") != null ? x.Attribute("UserName").Value : "",
                    PositionId = x.Attribute("PositionId") != null ? Guid.Parse(x.Attribute("PositionId").Value) : Guid.Empty
                });
            }

            var user = workers.FirstOrDefault(x => x.UserName.ToUpper() == userName.ToUpper() && x.Password == password);
            if (user != null)
            {
                positionIdStr = user.PositionId.ToString();
                var organization = organizations.FirstOrDefault(x => x.Id == user.ParentId);
                if (organization != null)
                {
                    orgName = organization.FullName;
                }
                userIdStr = user.Id.ToString();
                return true;
            }

            return false;
        }
    }
}
