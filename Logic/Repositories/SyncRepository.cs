using Domain;
using Domain.StaticReferences;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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
        
        public string UploadLocalDB(out string resval, string u, string p)
        {
            string html = "";
            using (var client = new CookieAwareWebClient())
            {
                var values = new NameValueCollection
                {
                    { "username", u },
                    { "password", p }
                };
                client.UploadValues(HostAddress, values);

                client.Encoding = Encoding.UTF8;
                
                client.DownloadString(HostAddress + "/Home/RunProcess/fc760b10-5f5a-4bad-a4a3-de3792ca9fdb?menuId=5461a579-c1a2-4196-ae74-4973ac4f4a58");
                
                html = UploadFileEx(DBConfigInfo.LocalDBFileName, HostAddress + "/Form/Upload/", "attachments", "text/xml", values, client.CookieContainer);
                
                client.DownloadString(HostAddress + "/Form/UserAction/b268d7b7-f3d6-4c2d-a863-97a1f0887222");//finish process
            }
            // Encoding.UTF8.GetString(data);
            resval = html;



            return ParseMesage(html);
        }

        string ParseMesage(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var divs = doc.DocumentNode
                .Descendants("div")
                .Where(d =>
                    d.Attributes.Contains("class")
                    &&
                    d.Attributes["class"].Value.Contains("frame-content"));
            return divs.First().Descendants("p").First().InnerText;
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
        public static string UploadFileEx(string uploadfile, string url,
    string fileFormName, string contenttype, NameValueCollection querystring,
    CookieContainer cookies)
        {
            if ((fileFormName == null) ||
                (fileFormName.Length == 0))
            {
                fileFormName = "file";
            }

            if ((contenttype == null) ||
                (contenttype.Length == 0))
            {
                contenttype = "application/octet-stream";
            }


            string postdata;
            postdata = "?";
            if (querystring != null)
            {
                foreach (string key in querystring.Keys)
                {
                    postdata += key + "=" + querystring.Get(key) + "&";
                }
            }
            Uri uri = new Uri(url/* + postdata*/);


            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(uri);
            webrequest.CookieContainer = cookies;
            webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webrequest.Method = "POST";


            // Build up the post message header
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append(fileFormName);
            sb.Append("\"; filename=\"");
            sb.Append(Path.GetFileName(uploadfile));
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append(contenttype);
            sb.Append("\r\n");
            sb.Append("\r\n");

            string postHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);

            // Build the trailing boundary string as a byte array
            // ensuring the boundary appears on a line by itself
            byte[] boundaryBytes =
                   Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            using (
            FileStream fileStream = new FileStream(uploadfile,
                                        FileMode.Open, FileAccess.Read))
            {
                long length = postHeaderBytes.Length + fileStream.Length +
                                                       boundaryBytes.Length;
                webrequest.ContentLength = length;

                using (Stream requestStream = webrequest.GetRequestStream())
                {


                    // Write out our post header
                    requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

                    // Write out the file contents
                    byte[] buffer = new Byte[checked((uint)Math.Min(4096,
                                             (int)fileStream.Length))];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        requestStream.Write(buffer, 0, bytesRead);

                    // Write out the trailing boundary
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                }
                using (WebResponse responce = webrequest.GetResponse())
                {
                    using (Stream s = responce.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(s);

                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }

    public static class WebExtensions
    {
        public static Boolean HasClass(this HtmlNode element, String className)
        {
            if (element == null) throw new ArgumentNullException(className);
            if (string.IsNullOrWhiteSpace(className)) throw new ArgumentNullException(className);
            if (element.NodeType != HtmlNodeType.Element) return false;

            HtmlAttribute classAttrib = element.Attributes["class"];
            if (classAttrib == null) return false;

            Boolean hasClass = CheapClassListContains(classAttrib.Value, className, StringComparison.Ordinal);
            return hasClass;
        }

        /// <summary>Performs optionally-whitespace-padded string search without new string allocations.</summary>
        /// <remarks>A regex might also work, but constructing a new regex every time this method is called would be expensive.</remarks>
        private static Boolean CheapClassListContains(String haystack, String needle, StringComparison comparison)
        {
            if (String.Equals(haystack, needle, comparison)) return true;
            Int32 idx = 0;
            while (idx + needle.Length <= haystack.Length)
            {
                idx = haystack.IndexOf(needle, idx, comparison);
                if (idx == -1) return false;

                Int32 end = idx + needle.Length;

                // Needle must be enclosed in whitespace or be at the start/end of string
                Boolean validStart = idx == 0 || Char.IsWhiteSpace(haystack[idx - 1]);
                Boolean validEnd = end == haystack.Length || Char.IsWhiteSpace(haystack[end]);
                if (validStart && validEnd) return true;

                idx++;
            }
            return false;
        }
    }
}
