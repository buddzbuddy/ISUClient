using Domain.Entities.MTB;
using Domain.StaticReferences;
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
    public partial class EditEquipmentForm : Form
    {
        MTBForm _mtbForm = null;
        Equipment _obj = null;
        public EditEquipmentForm(MTBForm mtbForm, Equipment obj)
        {
            InitializeComponent();

            _mtbForm = mtbForm;
            _obj = obj;

            EquipmentModelTextBox.Text = _obj.Model;
            EquipmentAmountTextBox.Text = _obj.Amount.HasValue ? _obj.Amount.Value.ToString() : "";
            EquipmentReleseYearTextBox.Text = _obj.ReleseYear.HasValue ? _obj.ReleseYear.Value.ToString() : "";
            EquipmentSupplierSourceTextBox.Text = _obj.SupplierSource;
            EquipmentPriceTextBox.Text = _obj.Price.HasValue ? _obj.Price.Value.ToString() : "";
            EquipmentWearTextBox.Text = _obj.Wear.HasValue ? _obj.Wear.Value.ToString() : "";

            FormManager.InitializeComboBoxes(this, _obj);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillObj()
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
                    var Equipments = _docRepo.GetAll<Equipment>();
                    if (Equipments != null)
                        FormManager.LoadToDataGridView(_mtbForm.DataGridViewEquipments, Equipments.ToList());
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

        private bool SaveToLocalDb(out string errorMessage)
        {
            var _docRepo = new DocRepository();
            errorMessage = "";

            //TODO: Write to progress bar

            //Save changes to xml-db
            try
            {
                if (!PropertiesHelper.PublicInstancePropertiesEqual(_obj, _docRepo.Get<Equipment>(_obj.Id)))
                {
                    _obj.IsModified = true;
                    _docRepo.Save(_obj, true);
                }
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
