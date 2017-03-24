using Domain.Entities;
using Domain.Entities.Staff;
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

namespace UI.StaffForms
{
    public partial class EditPositionForm : Form
    {
        StaffForm _staffForm = null;
        Position _obj = null;
        public EditPositionForm(StaffForm staffForm, Position obj)
        {
            InitializeComponent();

            _staffForm = staffForm;
            _obj = obj;

            PositionNameTextBox.Text = obj.Name;
        }
        public Position FillObj()
        {
            _obj.Name = PositionNameTextBox.Text;
            return _obj;
        }
        private bool SaveToLocalDb(out string errorMessage)
        {
            var _docRepo = new DocRepository();
            errorMessage = "";

            //TODO: Write to progress bar

            //Save changes to xml-db
            try
            {
                _docRepo.Save(_obj, true);
            }
            catch (Exception e)
            {
                //TODO: WriteLog("Breaking the initializing by exception, " + e.Message + ", count persons - " + i);
                errorMessage = e.Message;
                return false;
            }
            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string errorMessage;
            FillObj();
            if (SaveToLocalDb(out errorMessage))
            {
                try
                {
                    var _docRepo = new DocRepository();
                    if (_docRepo.GetAll<Position>() != null)
                    {
                        var Positions = _docRepo.GetAll<Position>().ToList();
                        FormManager.LoadToDataGridView(_staffForm.DataGridViewPositions, Positions);
                        if (_docRepo.GetAll<Employee>() != null)
                        {
                            var Employees = _docRepo.GetAll<Employee>().ToList();
                            Employees.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                            FormManager.LoadToDataGridView(_staffForm.DataGridViewEmployees, Employees);
                        }
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
