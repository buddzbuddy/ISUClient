using Domain.Entities.MTB;
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
    public partial class ViewBuildingForm : Form
    {
        MTBForm _mtbForm = null;
        Building _obj = null;
        public ViewBuildingForm(MTBForm mtbForm, Building obj)
        {
            InitializeComponent();
        }
    }
}
