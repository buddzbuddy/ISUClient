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
        public XContext(string filePath)
        {
            var isNew = !System.IO.File.Exists(filePath);

            _document = isNew ? new XDocument() : XDocument.Load(filePath);

            if (isNew)
            {
                _document.Add(new XElement("root"));
                _document.Save(filePath);
            }
            _filePath = filePath;
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
        }
    }
}
