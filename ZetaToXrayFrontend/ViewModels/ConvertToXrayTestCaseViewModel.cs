using Microsoft.Win32;
using MVVM_Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZetaToXrayBackend.Model.Xray;
using ZetaToXrayBackend.Model.Zeta;
using ZetaToXrayFrontend.Service;

namespace ZetaToXrayFrontend.ViewModels
{
    public class ConvertToXrayTestCaseViewModel : ViewModelBase
    {
        private bool isConvert;
        public List<TestCaseZeta> ListZetaTestCase = new List<TestCaseZeta>();
        public TestCaseXray TestCaseXray { get; set; } = null!;
        public DelegateCommand ListConverter { get; set; }        
        public ObservableCollection<TestCaseXray> TestCaseXrays { get; set; }
        public List<TestCaseXray> ListTestCaseXray = new List<TestCaseXray>();

        public bool IsConvert
        {
            get => isConvert;
            set
            {
                if(isConvert != value)
                {
                    isConvert = value;
                    this.RaisePropertyChange();
                }
            }
        }

        public ConvertToXrayTestCaseViewModel()
        {
            this.ListConverter = new DelegateCommand((o) => ConvertList());
            this.TestCaseXrays = new ObservableCollection<TestCaseXray>();
        }

        private void ConvertList()
        {
            string excelImportPath = "";

            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog != null)
            {
                dialog.Filter = "Excel (*.xlsx)|*.xlsx";

                if (dialog.ShowDialog().Value)
                {
                    dialog.OpenFile();
                    excelImportPath = dialog.FileName;
                }

                if (excelImportPath != "")
                {
                    this.IsConvert = true;
                    var serviceTestCaseZeta = new DataListService();
                    ListZetaTestCase = serviceTestCaseZeta.ZetaTestCaseListService(excelImportPath);
                    var serviceTestCaseXray = new DataListService();
                    ListTestCaseXray = serviceTestCaseXray.XrayTestCaseListService(ListZetaTestCase);

                    foreach (var testCaseXray in ListTestCaseXray)
                    {
                        this.TestCaseXrays.Add(testCaseXray);
                    }

                    this.IsConvert = false;
                }
                else
                {
                    MessageBox.Show("Es wurde keine Datei für den Import bereitgestellt!");
                }
            }
            else
            {
                MessageBox.Show("Der Dialog zum öffenen der Datei konnte nicht geöffnet werden!");
            }
        }
    }
}