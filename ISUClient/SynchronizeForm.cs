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
        public SynchronizeForm(string objName, string objNameRu, FormMain formMain)
        {
            InitializeComponent();

            _objName = objName;
            _objNameRu = objNameRu;
            _formMain = formMain;
        }

        void Start()
        {
            SetInfo(string.Format("Начинаю выгрузку данных \"{0}\"...", _objNameRu));

            //System.Threading.Thread.Sleep(3000);

            var syncRepo = new SyncRepository("http://isu.kesip.kg:8080/");
            string result = "";
            string resval = "";
            try
            {
                result = syncRepo.GetLocalDB(out resval, _formMain._u, _formMain._p);
                SetInfo("Выгрузка выполнена успешно.");
            }
            catch (Exception e)
            {
                SetInfo(" ОШИБКА: ТЕКСТ: " + e.Message + " МЕСТО: " + e.TargetSite.Name + " STACKTRACE: " + e.StackTrace + " ЗНАЧЕНИЕ ОТ СЕРВЕРА: " + resval);
            }
        }

        void SetInfo(string text)
        {
            SyncInfoTextBox.Text = text;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Start();
        }
    }
}
