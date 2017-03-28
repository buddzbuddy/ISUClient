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
                
                //_document = XDocument.Load(DBConfigInfo.EnumDefsFileName);
                var cachedDocument = Caching.Get<XDocument>(DBConfigInfo.EnumDefsFileName);
                if (cachedDocument != null)
                {
                    _document = cachedDocument;//XDocument.Load(DBConfigInfo.LocalDBFileName);
                }
                else
                {
                    _document = XDocument.Load(DBConfigInfo.EnumDefsFileName);
                    Caching.Set(DBConfigInfo.EnumDefsFileName, _document);
                }
            }
            else throw new ApplicationException("Файл \"" + DBConfigInfo.EnumDefsFileName + "\" не найден!");
        }
        public IEnumerable<XElement> GetAllElements()
        {
            return _document.Root.Element("ProjectFolder").Elements() != null ? _document.Root.Element("ProjectFolder").Elements() : null;
        }
    }
}
