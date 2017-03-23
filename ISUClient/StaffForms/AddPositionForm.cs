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
    public partial class AddPositionForm : Form
    {
        StaffForm _staffForm = null;
        public AddPositionForm(StaffForm staffForm)
        {
            InitializeComponent();

            _staffForm = staffForm;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var position = new Position
            {
                Id = Guid.NewGuid(),
                Name = PositionNameTextBox.Text,
                IsNew = true
            };
            string errorMessage;
            if (SaveToLocalDb(position, out errorMessage))
            {
                try
                {
                    var _docRepo = new DocRepository();
                    FormManager.LoadToDataGridView(_staffForm.DataGridViewPositions, _docRepo.GetAll<Position>());
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

        private bool SaveToLocalDb(Position obj, out string errorMessage)
        {
            errorMessage = "";

            //TODO: Write to progress bar

            //Save to xml-db
            try
            {
                var _docRepo = new DocRepository();
                _docRepo.Save(obj);
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
    }
}
