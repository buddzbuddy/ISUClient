using Domain;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Logic.Repositories
{
    public class SyncRepository
    {
        public string HostAddress = "";
        public SyncRepository(string hostAddress)
        {
            HostAddress = hostAddress;
        }

        public string GetLocalDB(out string resval, string u, string p)
        {
            string result = "no result";
            resval = "no val";
            byte[] data = null;
            using (var client = new CookieAwareWebClient())
            {
                var values = new NameValueCollection
                {
                    { "username", u },
                    { "password", p }
                };
                client.UploadValues(HostAddress, values);

                client.Encoding = Encoding.UTF8;
                // If the previous call succeeded we now have a valid authentication cookie
                // so we could download the protected page
                client.DownloadString(HostAddress + "/Home/RunProcess/33555f9a-6be7-41cd-9c4a-241b8a62cc17?menuId=a8d7a6dd-6c56-4cfa-b33a-62730fd5dcdd");
                data = client.DownloadData(HostAddress + "/Report/Download");
            }
            result = Encoding.UTF8.GetString(data);
            var lastRootIndex = result.IndexOf("</root>");
            var lastRootStr = result.Substring(lastRootIndex);
            result = result.Substring(0, lastRootIndex);//result.Replace(lastRootStr, "</root>");
            result += "</root>";
            resval = result;

            var xml = new System.Xml.XmlDocument();
            xml.LoadXml(result.Substring(result.IndexOf(Environment.NewLine)));

            var docRepo = new DocRepository();
            docRepo.UpdateSource(ToXDocument(xml)/*.Load(new System.IO.MemoryStream(data))*/);
            return result;
        }
        public XmlDocument ToXmlDocument(XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public XDocument ToXDocument(XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}
