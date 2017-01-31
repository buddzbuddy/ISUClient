using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class XEnumContext
    {
        private XDocument _document;
        public XEnumContext()
        {
            if (System.IO.File.Exists(DBConfigInfo.EnumDefsFileName))
            {
                _document = XDocument.Load(DBConfigInfo.EnumDefsFileName);
            }
            else throw new ApplicationException("Файл \"" + DBConfigInfo.EnumDefsFileName + "\" не найден!");
        }
        public IEnumerable<XElement> GetAllElements()
        {
            return _document.Root.Element("ProjectFolder").Elements() != null ? _document.Root.Element("ProjectFolder").Elements() : null;
        }
    }
}
