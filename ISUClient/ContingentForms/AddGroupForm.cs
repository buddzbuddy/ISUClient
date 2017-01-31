using Domain.Entities.Contingent;
using Logic.Implementations;
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

namespace UI.ContingentForms
{
    public partial class AddGroupForm : Form
    {
        ContingentForm _contingentForm = null;

        GroupRepository _groupRepo;

        public AddGroupForm(ContingentForm contingentForm)
        {
            _contingentForm = contingentForm;
            _groupRepo = new GroupRepository();
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var group = new Group
            {
                Id = Guid.NewGuid(),//TODO: Refactor to stable logic
                Name = NameTextBox.Text,
                Language = LanguageComboBox.SelectedItem != null ? LanguageComboBox.SelectedItem.ToString() : "",
                Profession = ProfessionComboBox.SelectedItem != null ? ProfessionComboBox.SelectedItem.ToString() : "",
                StudyPeriod = StudyPeriodComboBox.SelectedItem != null ? StudyPeriodComboBox.SelectedItem.ToString() : ""
            };
            string errorMessage;
            if (SaveToLocalDb2(group, out errorMessage))
            {
                try
                {
                    var newIndex = _contingentForm.DataGridViewGroups.Rows.Add();
                    _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["GroupName"].Value = group.Name;

                    if (group.Language != "") _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["Language"].Value = group.Language;
                    if (group.Profession != "") _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["Profession"].Value = group.Profession;
                    if (group.StudyPeriod != "") _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["StudyPeriod"].Value = group.StudyPeriod;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show(errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SaveToLocalDb(Group obj, out string errorMessage)
        {
            errorMessage = "";

            string filePath = "ISUClient.xml";
            var isNew = !System.IO.File.Exists(filePath);
            
            var xDoc = isNew ? new XDocument() : XDocument.Load(filePath);
            
            var xRootElement = isNew ? new XElement("root") : xDoc.Root;
            if (isNew) xDoc.Add(xRootElement);
            
            var xGroupsElement = isNew ? new XElement("Groups") : xRootElement.Element("Groups");
            if (isNew) xRootElement.Add(xGroupsElement);
            //TODO: Write to progress bar

            //Create xml element
            try
            {
                xGroupsElement.Add(new XElement("Group",
                    new[]
                        {
                            new XElement("Name", obj.Name),
                            new XElement("Language", obj.Language),
                            new XElement("Profession", obj.Profession),
                            new XElement("StudyPeriod", obj.StudyPeriod)
                        }));
                //TODO: WriteLog("Saving xml doc to file");
                xDoc.Save(filePath);
            }
            catch (Exception e)
            {
                //TODO: WriteLog("Breaking the initializing by exception, " + e.Message + ", count persons - " + i);
                errorMessage = e.Message;
                return false;
            }
            return true;
        }

        private bool SaveToLocalDb2(Group obj, out string errorMessage)
        {
            errorMessage = "";

            //TODO: Write to progress bar

            //Save to xml-db
            try
            {
                _groupRepo.Save(obj);
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
