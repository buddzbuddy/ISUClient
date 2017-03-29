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
            var cachedDocument = Caching.Get<XDocument>(DBConfigInfo.LocalDBFileName);
            if (cachedDocument != null)
            {
                _document = cachedDocument;//XDocument.Load(DBConfigInfo.LocalDBFileName);
            }
            else
            {
                _document = XDocument.Load(DBConfigInfo.LocalDBFileName);
                Caching.Set(DBConfigInfo.LocalDBFileName, _document);
            }
            _filePath = DBConfigInfo.LocalDBFileName;
        }
        public void UpdateSource(XDocument doc)
        {
            _document = doc;
            _document.Save(_filePath);
            Caching.Set(DBConfigInfo.LocalDBFileName, _document);
        }
        private void ReloadDocument()
        {
            //_document = XDocument.Load(_filePath);
            _document = XDocument.Load(DBConfigInfo.LocalDBFileName);
            Caching.Set(DBConfigInfo.LocalDBFileName, _document);
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
                var xOldObj = xList.FirstOrDefault(x => x.Element(DBConfigInfo.Id).Value == xObj.Element(DBConfigInfo.Id).Value);
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

        public void DeleteElement(XName fromSection, Guid Id)
        {
            var xList = GetElements(fromSection);
            if(xList != null)
            {
                var xObj = xList.FirstOrDefault(x => x.Element(DBConfigInfo.Id).Value == Id.ToString());
                if(xObj != null)
                {
                    if (xObj.Attribute(DBConfigInfo.IsNew) != null && bool.Parse(xObj.Attribute(DBConfigInfo.IsNew).Value))
                    {
                        xObj.Remove();
                    }
                    else
                        xObj.SetAttributeValue(DBConfigInfo.IsDeleted, true);
                }
                else
                    throw new ApplicationException("Запись для удаления не найдена! Имя контейнера: \"" + fromSection + "\" Ключ-айди записи: " + Id);
            }
            else
            {
                throw new ApplicationException("Контейнер для удаления не найден! Имя контейнера: \"" + fromSection + "\" Ключ-айди записи: " + Id);
            }
            _document.Save(_filePath);
            ReloadDocument();
        }
    }
}
