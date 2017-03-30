using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class SynchronizeForm : Form
    {
        string _objName = "";
        string _objNameRu = "";
        FormMain _formMain = null;
        string hostAddress = "http://192.168.55.5/";//"http://isu.kesip.kg:8080/";
        public SynchronizeForm(string objName, string objNameRu, FormMain formMain)
        {
            InitializeComponent();

            _objName = objName;
            _objNameRu = objNameRu;
            _formMain = formMain;

        }

        delegate void SetTextCallback(string text);

        private void SetInfo(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.SyncInfoTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetInfo);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.SyncInfoTextBox.Text += text;
            }
        }

        async void Start(EventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                //SetInfo(string.Format(Environment.NewLine + "Начинаю выгрузку из центральной базы данных {0}", hostAddress));

                var syncRepo = new SyncRepository(hostAddress);
                string result = "";
                string resval = "";
                try
                {
                    SetInfo(Environment.NewLine + "Отправка запроса...");
                    result = syncRepo.GetLocalDB(out resval, _formMain._u, _formMain._p);
                    SetInfo(Environment.NewLine + "Данные получены");
                    SetInfo(Environment.NewLine + "Выгрузка успешно завершена.");
                    //SetInfo(Environment.NewLine + "Начинаю загрузку...");
                    //SetInfo(Environment.NewLine + "Загрузка завершена. Результат:" + Environment.NewLine + syncRepo.UploadLocalDB(out resval, _formMain._u, _formMain._p));
                }
                catch (Exception ex)
                {
                    SetInfo(Environment.NewLine + "ОШИБКА: ТЕКСТ: " + ex.Message + " МЕСТО: " + ex.TargetSite.Name + " STACKTRACE: " + ex.StackTrace + " ЗНАЧЕНИЕ ОТ СЕРВЕРА: " + resval);
                }
            });
        }

        void SetInfo_old(string text)
        {
            SyncInfoTextBox.Text += text;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;
            Start(e);
        }
    }
}
