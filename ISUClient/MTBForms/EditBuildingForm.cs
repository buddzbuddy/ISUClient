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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.MTBForms
{
    public partial class EditBuildingForm : Form
    {
        MTBForm _mtbForm = null;
        Building _obj = null;

        public EditBuildingForm(MTBForm mtbForm, Building obj)
        {
            InitializeComponent();

            _mtbForm = mtbForm;
            _obj = obj;

            BuildingBuildYearTextBox.Text = _obj.BuildYear != null ? _obj.BuildYear.Value.ToString() : "";
            BuildingExploitationYearTextBox.Text = _obj.ExploitationYear != null ? _obj.ExploitationYear.Value.ToString() : "";
            BuildingFloorAmountTextBox.Text = _obj.FloorAmount != null ? _obj.FloorAmount.Value.ToString() : "";
            BuildingBuildingAreaTextBox.Text = _obj.BuildingArea != null ? _obj.BuildingArea.Value.ToString() : "";
            BuildingUnusefulAreaTextBox.Text = _obj.UnusefulArea != null ? _obj.UnusefulArea.Value.ToString() : "";
            BuildingUsefulAreaTextBox.Text = _obj.UsefulArea != null ? _obj.UsefulArea.Value.ToString() : "";
            BuildingRentedAreaTextBox.Text = _obj.RentedArea != null ? _obj.RentedArea.Value.ToString() : "";
            BuildingRentPriceTextBox.Text = _obj.RentPrice != null ? _obj.RentPrice.Value.ToString() : "";
            BuildingHiredAreaTextBox.Text = _obj.HiredArea != null ? _obj.HiredArea.Value.ToString() : "";
            BuildingHirePriceTextBox.Text = _obj.HirePrice != null ? _obj.HirePrice.Value.ToString() : "";

            FormManager.InitializeComboBoxes(this, _obj);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillObj()
        {
            _obj.BuildingPurpose = (Guid)BuildingBuildingPurposeComboBox.SelectedValue;
            _obj.BuildingType = (Guid)BuildingBuildingTypeComboBox.SelectedValue;

            int BuildYear = 0;
            if (int.TryParse(BuildingBuildYearTextBox.Text, out BuildYear) && BuildYear > 0)
                _obj.BuildYear = BuildYear;

            int ExploitationYear = 0;
            if (int.TryParse(BuildingExploitationYearTextBox.Text, out ExploitationYear) && ExploitationYear > 0)
                _obj.ExploitationYear = ExploitationYear;

            int FloorAmount = 0;
            if (int.TryParse(BuildingFloorAmountTextBox.Text, out FloorAmount) && FloorAmount > 0)
                _obj.FloorAmount = FloorAmount;

            _obj.Electrosupply = (Guid)BuildingElectrosupplyComboBox.SelectedValue;


            double BuildingArea = 0;
            if (double.TryParse(BuildingBuildYearTextBox.Text, out BuildingArea) && BuildingArea > 0)
                _obj.BuildingArea = BuildingArea;

            double UnusefulArea = 0;
            if (double.TryParse(BuildingUnusefulAreaTextBox.Text, out UnusefulArea) && UnusefulArea > 0)
                _obj.UnusefulArea = UnusefulArea;

            double UsefulArea = 0;
            if (double.TryParse(BuildingUsefulAreaTextBox.Text, out UsefulArea) && UsefulArea > 0)
                _obj.UsefulArea = UsefulArea;

            double RentedArea = 0;
            if (double.TryParse(BuildingRentedAreaTextBox.Text, out RentedArea) && RentedArea > 0)
                _obj.RentedArea = RentedArea;

            decimal RentPrice = 0;
            if (decimal.TryParse(BuildingRentPriceTextBox.Text, out RentPrice) && RentPrice > 0)
                _obj.RentPrice = RentPrice;

            double HiredArea = 0;
            if (double.TryParse(BuildingHiredAreaTextBox.Text, out HiredArea) && HiredArea > 0)
                _obj.HiredArea = HiredArea;

            decimal HirePrice = 0;
            if (decimal.TryParse(BuildingHirePriceTextBox.Text, out HirePrice) && HirePrice > 0)
                _obj.HirePrice = HirePrice;

            _obj.RoofType = (Guid)BuildingRoofTypeComboBox.SelectedValue;
            _obj.RoofState = (Guid)BuildingRoofStateComboBox.SelectedValue;

            _obj.WaterSupply = (Guid)BuildingWaterSupplyComboBox.SelectedValue;
            _obj.WaterSupplyState = (Guid)BuildingWaterSupplyStateComboBox.SelectedValue;

            _obj.Sewerage = (Guid)BuildingSewerageComboBox.SelectedValue;
            _obj.SewerageState = (Guid)BuildingSewerageStateComboBox.SelectedValue;

            _obj.HeatingSystem = (Guid)BuildingHeatingSystemComboBox.SelectedValue;
            _obj.HeatingSystemState = (Guid)BuildingHeatingSystemStateComboBox.SelectedValue;
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
                    var Buildings = _docRepo.GetAll<Building>();
                    if (Buildings != null)
                        FormManager.LoadToDataGridView(_mtbForm.DataGridViewBuildings, Buildings.ToList());
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
                if (!PropertiesHelper.PublicInstancePropertiesEqual(_obj, _docRepo.Get<Building>(_obj.Id)))
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
