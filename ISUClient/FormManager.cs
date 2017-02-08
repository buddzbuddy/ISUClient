using Domain.Entities;
using Domain.Entities.Contingent;
using Domain.Filters;
using Domain.StaticReferences;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public static class FormManager
    {
        public static DataGridViewComboBoxCell InitDGVCB(object dataSource, Guid? value, string displayMember = "FullName")
        {
            var CBCell = new DataGridViewComboBoxCell();
            CBCell.DataSource = dataSource;
            CBCell.DisplayMember = displayMember;
            CBCell.ValueMember = "Id";
            CBCell.Value = value;
            return CBCell;
        }


        public static void LoadToDataGridView<T>(DataGridView dataGridView, IEnumerable<T> entries, IDictionary<string, IEnumerable<object>> comboBoxes)
        {
            foreach (var entry in entries)
            {
                foreach (var property in typeof(T).GetProperties().OrderByDescending(x => x.Name))
                {
                    string boundWithProperty = "";
                    if (property.GetCustomAttributes(typeof(SkipAttribute), false).Length > 0)
                    {
                        if (property.GetCustomAttributes(typeof(BindWithPropertyAttribute), false).Length > 0)
                        {
                            boundWithProperty = ((BindWithPropertyAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(BindWithPropertyAttribute))).PropertyName;
                        }
                        else continue;
                    }
                    else
                    {

                    }
                }
            }
        }
        public static void LoadStudentsFromDb(DataGridView dataGridView, IEnumerable<Student> students)
        {
            try
            {
                var _docRepo = new DocRepository();
                var _enumRepo = new EnumRepository();
                var groups = _docRepo.GetAll<Group>();
                var genders = _enumRepo.GetEnum(Enums.GenderEnumDefId).Items;
                var nationalities = _enumRepo.GetEnum(Enums.NationalityEnumDefId).Items;
                var personalDocumentTypes = _enumRepo.GetEnum(Enums.PersonalDocumentTypeEnumDefId).Items;

                foreach (var student in students.Where(x => !x.IsDeleted))
                {
                    student.PersonObj = _docRepo.Get<Person>(student.Person);
                    if (student.PersonObj == null) continue;
                    var newIndex = dataGridView.Rows.Add();
                    dataGridView.Rows[newIndex].Cells["StudentId"].Value = student.Id;
                    dataGridView.Rows[newIndex].Cells["PIN"].Value = student.PersonObj.PIN;
                    dataGridView.Rows[newIndex].Cells["LastName"].Value = student.PersonObj.LastName;
                    dataGridView.Rows[newIndex].Cells["FirstName"].Value = student.PersonObj.FirstName;
                    dataGridView.Rows[newIndex].Cells["MiddleName"].Value = student.PersonObj.MiddleName;
                    dataGridView.Rows[newIndex].Cells["BirthDate"].Value = student.PersonObj.BirthDate;

                    dataGridView.Rows[newIndex].Cells["StudentPassportSeries"].Value = student.PassportSeries;
                    dataGridView.Rows[newIndex].Cells["StudentPassportNo"].Value = student.PassportNo;

                    if (student.Group != null && dataGridView.Columns["StudentGroup"] != null)
                    {
                        dataGridView.Rows[newIndex].Cells["StudentGroup"] = InitDGVCB(groups.ToList(), student.Group, "Name");
                    }

                    if (student.PersonObj.Gender != null && dataGridView.Columns["StudentGender"] != null)
                    {
                        dataGridView.Rows[newIndex].Cells["StudentGender"] = InitDGVCB(genders.ToList(), student.PersonObj.Gender);
                    }

                    if (student.PersonObj.Nationality != null && dataGridView.Columns["StudentNationality"] != null)
                    {
                        dataGridView.Rows[newIndex].Cells["StudentNationality"] = InitDGVCB(nationalities.ToList(), student.PersonObj.Nationality);
                    }

                    if (student.PersonalDocumentType != null && dataGridView.Columns["StudentPersonalDocumentType"] != null)
                    {
                        dataGridView.Rows[newIndex].Cells["StudentPersonalDocumentType"] = InitDGVCB(personalDocumentTypes.ToList(), student.PersonalDocumentType);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
