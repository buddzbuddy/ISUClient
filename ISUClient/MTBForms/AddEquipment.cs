using Domain.Entities.MTB;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.MTBForms
{
    public partial class AddEquipmentForm : Form
    {
        MTBForm _mtbForm = null;
        public AddEquipmentForm(MTBForm mtbForm)
        {
            InitializeComponent();

            _mtbForm = mtbForm;

            FormManager.InitializeComboBoxes(this, new Equipment());
        }

        public Equipment FillObj(Equipment _obj)
        {
            _obj.EquipmentCategory = (Guid)EquipmentEquipmentCategoryComboBox.SelectedValue;

            _obj.Model = EquipmentModelTextBox.Text;

            int Amount = 0;
            if (int.TryParse(EquipmentAmountTextBox.Text, out Amount) && Amount > 0)
                _obj.Amount = Amount;

            int ReleseYear = 0;
            if (int.TryParse(EquipmentReleseYearTextBox.Text, out ReleseYear) && ReleseYear > 0)
                _obj.ReleseYear = ReleseYear;

            _obj.SupplierSource = EquipmentSupplierSourceTextBox.Text;

            decimal Price = 0;
            if (decimal.TryParse(EquipmentPriceTextBox.Text, out Price) && Price > 0)
                _obj.Price = Price;

            decimal Wear = 0;
            if (decimal.TryParse(EquipmentWearTextBox.Text, out Wear) && Wear > 0)
                _obj.Wear = Wear;

            _obj.State = (Guid)EquipmentStateComboBox.SelectedValue;

            _obj.Sector = (Guid)EquipmentSectorComboBox.SelectedValue;

            _obj.Profession = (Guid)EquipmentProfessionComboBox.SelectedValue;

            return _obj;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var _docRepo = new DocRepository();

            var equipment = FillObj(new Equipment
            {
                Id = Guid.NewGuid(),
                IsNew = true
            });
            string errorMessage;
            if (SaveToLocalDb(equipment, out errorMessage))
            {
                try
                {
                    _docRepo = new DocRepository();
                    if (_docRepo.GetAll<Equipment>() == null) return;
                    var Equipments = _docRepo.GetAll<Equipment>().ToList();
                    FormManager.LoadToDataGridView(_mtbForm.DataGridViewEquipments, Equipments);
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

        private bool SaveToLocalDb(Equipment obj, out string errorMessage)
        {
            var _docRepo = new DocRepository();
            errorMessage = "";

            //TODO: Write to progress bar

            //Save to xml-db
            try
            {
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
    }
}
