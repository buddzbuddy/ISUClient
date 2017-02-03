using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class XContext
    {
        private XDocument _document;
        private string _filePath;
        public XContext()
        {
            _document = XDocument.Load(DBConfigInfo.LocalDBFileName);
            _filePath = DBConfigInfo.LocalDBFileName;
        }
        private void ReloadDocument()
        {
            _document = XDocument.Load(_filePath);
        }
        public IEnumerable<XElement> GetElements(XName sectionName)
        {
            return _document.Root.Element(sectionName) != null ? _document.Root.Element(sectionName).Elements() : null;
        }

        public void AddElement(XElement xObj, XName toSectionName)
        {
            var xList = GetElements(toSectionName);
            if(xList != null)
            {
                _document.Root.Element(toSectionName).Add(xObj);
            }
            else
            {
                _document.Root.Add(new XElement(toSectionName, xObj));
            }
            _document.Save(_filePath);
            ReloadDocument();
        }

        public void UpdateElement(XElement xObj, XName toSectionName)
        {
            var xList = GetElements(toSectionName);
            if(xList != null)
            {
                var xOldObj = xList.FirstOrDefault(x => x.Element("Id").Value == xObj.Element("Id").Value);
                if(xOldObj != null)
                {
                    foreach (var xProperty in xOldObj.Elements())
                    {
                        xProperty.SetValue(xObj.Element(xProperty.Name).Value);
                    }
                }
                else
                    throw new ApplicationException("Старая запись для редактирования не найдена! Ключ-айди записи: " + xObj.Element("Id").Value);
            }
            else
            {
                throw new ApplicationException("Контейнер старых записей для редактирования не найден! Имя контейнера: \"" + toSectionName + "\" Ключ-айди записи: " + xObj.Element("Id").Value);
            }
            _document.Save(_filePath);
            ReloadDocument();
        }
    }
}
