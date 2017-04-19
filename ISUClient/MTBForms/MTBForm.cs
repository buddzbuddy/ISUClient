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
    public partial class MTBForm : Form
    {
        public MTBForm()
        {
            InitializeComponent();
            var _docRepo = new DocRepository();
            FormManager.LoadToDataGridView(DataGridViewBuildings, _docRepo.GetAll<Building>());
            FormManager.LoadToDataGridView(DataGridViewEquipments, _docRepo.GetAll<Equipment>());
        }

        private void DataGridViewBuildings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = DataGridViewBuildings.Rows[e.RowIndex];
                var cell = row.Cells[e.ColumnIndex];
                var BuildingId = (Guid)row.Cells["BuildingId"].Value;
                if (cell.Equals(row.Cells["EditBuildingLink"]))//Edit button clicked
                {
                    EditBuilding(BuildingId);
                }
                else if (cell.Equals(row.Cells["DeleteBuildingLink"]))//Delete button clicked
                {
                    DeleteBuilding(BuildingId);
                }
                else if (cell.Equals(row.Cells["ShowBuildingLink"]))//Show button clicked
                {
                    ShowBuilding(BuildingId);
                }
            }
        }

        public void EditBuilding(Guid BuildingId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Building>(BuildingId);
            var _editBuildingForm = new EditBuildingForm(this, obj);
            DialogResult dialog = _editBuildingForm.ShowDialog();
        }
        private void DeleteBuilding(Guid BuildingId)
        {
            if (IsBoundWithAnyPremise(BuildingId))
            {
                MessageBox.Show("В данном здании имеются помещения!\n\nПожалуйста, перед удалением здания удалите все помещения внутри здания.");
                return;
            }
            var _docRepo = new DocRepository();

            var obj = _docRepo.Get<Building>(BuildingId);

            var confirmResult = MessageBox.Show("Вы уверены что хотите удалить здание?",
                             "Подтверждение",
                             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _docRepo.Delete<Building>(BuildingId);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка произошла при попытке удалить здание, текст ошибки: " + e.Message);
                }
            }
            FormManager.LoadToDataGridView(DataGridViewBuildings, _docRepo.GetAll<Building>());
        }
        private bool IsBoundWithAnyPremise(Guid BuildingId)
        {
            var _docRepo = new DocRepository();
            return _docRepo.GetAll<Premise>().Any(x => x.Building == BuildingId);
        }

        private void ShowBuilding(Guid BuildingId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Building>(BuildingId);
            var _viewBuildingForm = new ViewBuildingForm(this, obj);

            DialogResult dialog = _viewBuildingForm.ShowDialog();
        }

        private void AddBuildingButton_Click(object sender, EventArgs e)
        {
            var _addBuildingForm = new AddBuildingForm(this);
            DialogResult dialog = _addBuildingForm.ShowDialog();
        }

        private void AddEquipmentButton_Click(object sender, EventArgs e)
        {
            var _addEquipmentForm = new AddEquipmentForm(this);
            DialogResult dialog = _addEquipmentForm.ShowDialog();
        }

        private void DataGridViewEquipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = DataGridViewEquipments.Rows[e.RowIndex];
                var cell = row.Cells[e.ColumnIndex];
                var EquipmentId = (Guid)row.Cells["EquipmentId"].Value;
                if (cell.Equals(row.Cells["EditEquipmentLink"]))//Edit button clicked
                {
                    EditEquipment(EquipmentId);
                }
                else if (cell.Equals(row.Cells["DeleteEquipmentLink"]))//Delete button clicked
                {
                    //DeleteEquipment(EquipmentId);
                }
                else if (cell.Equals(row.Cells["ShowEquipmentLink"]))//Show button clicked
                {
                    //ShowEquipment(EquipmentId);
                }
            }
        }

        public void EditEquipment(Guid EquipmentId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Equipment>(EquipmentId);
            var _editEquipmentForm = new EditEquipmentForm(this, obj);
            DialogResult dialog = _editEquipmentForm.ShowDialog();
        }
        private void DeleteEquipment(Guid EquipmentId)
        {
            var _docRepo = new DocRepository();

            var obj = _docRepo.Get<Equipment>(EquipmentId);

            var confirmResult = MessageBox.Show("Вы уверены что хотите удалить оборудование?",
                             "Подтверждение",
                             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _docRepo.Delete<Equipment>(EquipmentId);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка произошла при попытке удалить оборудование, текст ошибки: " + e.Message);
                    return;
                }
                FormManager.LoadToDataGridView(DataGridViewEquipments, _docRepo.GetAll<Equipment>());
            }
        }
    }
}
