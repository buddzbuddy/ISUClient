using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public class XDocumentProvider
    {
        // not thread safe yet
        private static bool pendingChanges;

        private bool _documentLoadedFromFile;

        FileSystemWatcher fileWatcher;

        public static XDocumentProvider Default = new XDocumentProvider();

        public event EventHandler CurrentDocumentChanged;

        private XDocument _loadedDocument;

        public string FileName { get; set; }


        public XDocumentProvider()
        {
            fileWatcher = new FileSystemWatcher();
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.Changed += fileWatcher_Changed;

            FileName = "Списки.ProjectFolder.xml";
        }

        void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (_documentLoadedFromFile && !pendingChanges)
            {
                GetDocument(true);
            }
        }


        /// <summary>
        /// Returns an open XDocument or create a new document
        /// </summary>
        /// <returns></returns>
        public XDocument GetDocument(bool refresh = false)
        {
            if (refresh || _loadedDocument == null)
            {
                // we need to refactor it, but just to demonstrate how should work I will send this way ;P
                if (File.Exists(FileName))
                {
                    _loadedDocument = XDocument.Load(FileName);
                    _documentLoadedFromFile = true;

                    if (fileWatcher.Path != Environment.CurrentDirectory)
                    {
                        fileWatcher.Path = Environment.CurrentDirectory;
                        fileWatcher.Filter = FileName;
                        fileWatcher.EnableRaisingEvents = true;
                    }
                }
                else
                {
                    _loadedDocument = CreateNewDocument();
                    fileWatcher.EnableRaisingEvents = false;
                    _documentLoadedFromFile = false;
                }

                if (CurrentDocumentChanged != null) CurrentDocumentChanged(this, EventArgs.Empty);
            }

            return _loadedDocument;
        }

        /// <summary>
        /// Creates a new XDocument with a determined schemma.
        /// </summary>
        public XDocument CreateNewDocument()
        {
            var document = new XDocument();
            var root = new XElement("CissaMeta");
            var groups = new XElement("Groups");
            root.Add(groups);
            document.Add(root);
            return document;
        }

        public void Save()
        {
            if (_loadedDocument == null)
                throw new InvalidOperationException();

            try
            {
                // tells the file watcher that he cannot raise the changed event, because his function is to capture external changes.
                pendingChanges = true;
                _loadedDocument.Save(FileName);
            }
            finally
            {
                pendingChanges = false;
            }
        }
    }
}
