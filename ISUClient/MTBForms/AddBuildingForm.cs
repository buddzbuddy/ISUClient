using Domain.Entities.MTB;
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
    public partial class AddBuildingForm : Form
    {
        MTBForm _mtbForm = null;
        

        public AddBuildingForm(MTBForm mtbForm)
        {
            InitializeComponent();

            _mtbForm = mtbForm;

            FormManager.InitializeComboBoxes(this, new Building());
        }

        public Building FillObj(Building _obj)
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

            return _obj;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var _docRepo = new DocRepository();

            var employee = FillObj(new Building
            {
                Id = Guid.NewGuid(),
                IsNew = true,
                IsDeleted = false
            });
            string errorMessage;
            if (SaveToLocalDb(employee, out errorMessage))
            {
                try
                {
                    _docRepo = new DocRepository();
                    if (_docRepo.GetAll<Building>() == null) return;
                    var Buildings = _docRepo.GetAll<Building>().ToList();
                    FormManager.LoadToDataGridView(_mtbForm.DataGridViewBuildings, Buildings);
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

        private bool SaveToLocalDb(Building obj, out string errorMessage)
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
