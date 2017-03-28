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
        public SynchronizeForm(string objName, string objNameRu)
        {
            InitializeComponent();

            _objName = objName;
            _objNameRu = objNameRu;

        }

        void Start()
        {
            SetInfo(string.Format("Начинаю выгрузку данных \"{0}\"...", _objNameRu));

            System.Threading.Thread.Sleep(3000);

            var syncRepo = new SyncRepository("http://192.168.55.5/");
            string result = "";
            string resval = "";
            try
            {
                result = syncRepo.GetTestData(out resval);
            }
            catch (Exception e)
            {
                result = " ОШИБКА: ТЕКСТ: " + e.Message + " МЕСТО: " + e.TargetSite.Name + " STACKTRACE: " + e.StackTrace + " ЗНАЧЕНИЕ ОТ СЕРВЕРА: " + resval;
            }

            SetInfo(string.Format("Результат: {0}", result));
            
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
