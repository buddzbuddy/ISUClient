using Domain.Entities.Staff;
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
    public partial class ViewPositionForm : Form
    {
        StaffForm _staffForm = null;
        Position _obj = null;
        public ViewPositionForm(StaffForm staffForm, Position obj)
        {
            InitializeComponent();

            _staffForm = staffForm;
            _obj = obj;

            PositionNameTextBox.Text = obj.Name;
        }
    }
}
