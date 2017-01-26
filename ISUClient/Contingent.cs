using ISUClient.Models.Contingent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ISUClient
{
    public partial class ContingentForm : Form
    {
        public ContingentForm()
        {

            InitializeComponent();
            //FillGroups();
        }

        private void UpdateGroupsComboBox()
        {
            try
            {
                Group.Items.Clear();
            }
            catch
            {

            }
            foreach (DataGridViewRow row in DataGridViewGroups.Rows)
            {
                try
                {
                    Group.Items.Add(row.Cells[1].Value.ToString());
                }
                catch
                {

                }
            }
        }

        private void FillGroups()
        {
            var n = DataGridViewGroups.Rows.Add();
            DataGridViewGroups.Rows[n].Cells["GroupId"].Value = "1";
            DataGridViewGroups.Rows[n].Cells["GroupName"].Value = "Group 1";
        }

        private bool SaveToLocalDb(Student obj, out string errorMessage)
        {
            errorMessage = "";
            var xDoc = new XDocument();
            var xPersonsElement = new XElement("Students");
            xDoc.Add(xPersonsElement);
            //TODO: Write to progress bar

            //Create xml element
            try
            {
                xPersonsElement.Add(new XElement("Student",
                    new[]
                        {
                            new XElement("LastName", obj.LastName),
                            new XElement("FirstName", obj.FirstName),
                            new XElement("MiddleName", obj.MiddleName),
                            new XElement("BirthDate", obj.BirthDate),
                            new XElement("GroupName", obj.GroupName)
                        }));
                //TODO: WriteLog("Saving xml doc to file");
                xDoc.Save("ISULocalDb.xml");
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
