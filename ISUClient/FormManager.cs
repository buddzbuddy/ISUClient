using Domain.Entities;
using Domain.Entities.Contingent;
using Domain.Filters;
using Domain.StaticReferences;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public static class FormManager
    {
        public static DataGridViewComboBoxCell InitDGVCB(object dataSource, Guid? value, string displayMember, string valueMember)
        {
            var CBCell = new DataGridViewComboBoxCell();
            CBCell.DataSource = dataSource;
            CBCell.DisplayMember = displayMember;
            CBCell.ValueMember = valueMember;
            CBCell.Value = value;
            return CBCell;
        }

        static void InitCellFromProperty(DataGridView dataGridView, DataGridViewRow row, string cellName, object obj, PropertyInfo property, Dictionary<string, IEnumerable<object>> comboBoxes)
        {
            var cellValue = property.GetValue(obj);
            if (property.Name == DBConfigInfo.Id ||
                new[]
                                    {
                                        typeof(DateTime),
                                        typeof(Int32),
                                        typeof(Nullable<Int32>),
                                        typeof(Boolean),
                                        typeof(Decimal),
                                        typeof(Double),
                                        typeof(String)
                                    }.Contains(property.PropertyType))
            {
                if (dataGridView.Columns[cellName] != null)
                    row.Cells[cellName].Value = cellValue;
            }
            else if (new[] { typeof(Guid), typeof(Nullable<Guid>) }.Contains(property.PropertyType))
            {
                if (comboBoxes.ContainsKey(property.Name) &&
                    cellValue != null &&
                    dataGridView.Columns[cellName] != null)
                {
                    var dataSource = comboBoxes[property.Name];
                    if (dataSource != null && dataSource.Count() > 0)
                    {
                        if (property.IsDefined(typeof(DocMemberAttribute), false))
                        {
                            var member = (DocMemberAttribute)Attribute.GetCustomAttribute(property, typeof(DocMemberAttribute));
                            row.Cells[cellName] = InitDGVCB(dataSource.ToList(), (Nullable<Guid>)cellValue, member.Display, member.Value);
                        }
                        else if (property.IsDefined(typeof(EnumMemberAttribute), false))
                        {
                            var member = (EnumMemberAttribute)Attribute.GetCustomAttribute(property, typeof(EnumMemberAttribute));
                            row.Cells[cellName] = InitDGVCB(dataSource.ToList(), (Nullable<Guid>)cellValue, member.Display, member.Value);
                        }
                        else
                            throw new ApplicationException("При загрузке источника в табличную форму, для отображения выпадающего списка атрибут не найден! Тип объекта \"" + obj.GetType().Name + "\" Имя свойства \"" + property.Name + "\" Тип выпадающего списка \"" + dataSource.First().GetType().Name + "\"");
                    }
                }
            }
            else
                throw new ApplicationException("Не могу загрузить источник в табличную форму, тип поля \"" + property.PropertyType.Name + "\" не определен!");

        }

        private static Dictionary<string, IEnumerable<object>> GetComboBox<T>(PropertyInfo property, T obj)
        {
            var comboBoxes = new Dictionary<string, IEnumerable<object>>();
            var _docRepo = new DocRepository();
            var _enumRepo = new EnumRepository();
            if (property.IsDefined(typeof(EnumMemberAttribute), false))
            {
                var enumDefName = ((EnumMemberAttribute)Attribute.GetCustomAttribute(property, typeof(EnumMemberAttribute))).EnumDefName;
                comboBoxes.Add(property.Name, _enumRepo.GetEnum(Enums.GetEnumDefId(enumDefName)).Items);
            }
            else if (property.IsDefined(typeof(DocMemberAttribute), false))
            {
                IEnumerable<object> dataSource = null;
                var objType = ((DocMemberAttribute)Attribute.GetCustomAttribute(property, typeof(DocMemberAttribute))).ObjType;
                if (objType.Name.Equals(typeof(Person).Name))
                {
                    dataSource = _docRepo.GetAll<Person>().ToList();
                }
                else if (objType.Name.Equals(typeof(Profession).Name))
                {
                    dataSource = _docRepo.GetAll<Profession>().ToList();
                }
                else if (objType.Name.Equals(typeof(Group).Name))
                {
                    dataSource = _docRepo.GetAll<Group>().ToList();
                }
                else
                    throw new ApplicationException("При загрузке источника в табличную форму, для отображения выпадающего списка тип выпадающего списка не найден! Тип объекта \"" + typeof(T).Name + "\" Имя свойства \"" + property.Name + "\" Тип выпадающего списка \"" + dataSource.First().GetType().Name + "\"");


                comboBoxes.Add(property.Name, dataSource);
            }
            return comboBoxes;
        }

        public static void LoadToDataGridView<T>(DataGridView dataGridView, IEnumerable<T> objs)
        {
            dataGridView.Rows.Clear();
            foreach (var obj in objs)
            {
                var newIndex = dataGridView.Rows.Add();
                var row = dataGridView.Rows[newIndex];
                foreach (var property in obj.GetType().GetProperties())
                {
                    if (property.Name == DBConfigInfo.IsNew || property.Name == DBConfigInfo.IsDeleted || property.IsDefined(typeof(SkipAttribute), false))
                        continue;

                    var comboBoxes = GetComboBox(property, obj);

                    if (property.IsDefined(typeof(BoundWithAttribute), false))
                    {
                        var customAttribute = Attribute.GetCustomAttribute(property, typeof(BoundWithAttribute), false);
                        if (customAttribute != null)
                        {
                            string boundWith = ((BoundWithAttribute)customAttribute).PropertyName;
                            var boundObj = obj.GetType().GetProperty(boundWith).GetValue(obj);
                            if (boundObj != null)
                            {
                                var cellEntityName = obj.GetType().Name + property.Name;
                                foreach (var subProperty in boundObj.GetType().GetProperties())
                                {
                                    comboBoxes = GetComboBox(subProperty, boundObj);
                                    InitCellFromProperty(dataGridView, row, cellEntityName + subProperty.Name, boundObj, subProperty, comboBoxes);
                                }

                            }
                            else throw new ApplicationException("При загрузке источника в табличную форму, при попытке получить объект. Связанный объект пуст!  Сущность \"" + boundObj.GetType().Name + "\" Свойство \"" + property.Name + "\"");
                        }
                        else
                            throw new ApplicationException("При загрузке источника в табличную форму, при попытке получить атрибут поля. Атрибут не найден!  Сущность \"" + obj.GetType().Name + "\" Свойство \"" + property.Name + "\"");
                    }
                    else
                    {
                        InitCellFromProperty(dataGridView, row, obj.GetType().Name + property.Name, obj, property, comboBoxes);
                    }
                }
            }
        }


        public static void ResetDropDownValues<T>(T obj, DataGridView dataGridView, Type owner)
        {
            var property = typeof(T).GetProperty(DBConfigInfo.Id);

            var objName = obj.GetType().Name;

            var cellName = owner.Name + objName;
            var _docRepo = new DocRepository();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Guid.Parse(row.Cells[cellName].Value.ToString()) == (Guid)property.GetValue(obj))
                {
                    InitCellFromProperty(dataGridView, row, cellName, obj, property, new Dictionary<string, IEnumerable<object>>() { { objName, _docRepo.GetAll<T>().Cast<object>() } });
                }
            }
        }
    }
}