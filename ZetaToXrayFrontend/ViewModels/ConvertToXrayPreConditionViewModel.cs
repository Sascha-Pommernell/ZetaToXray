using Microsoft.Win32;
using MVVM_Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ZetaToXrayBackend.Model.Xray;
using ZetaToXrayBackend.Model.Zeta;
using ZetaToXrayFrontend.Service;


namespace ZetaToXrayFrontend.ViewModels
{
    public class ConvertToXrayPreConditionViewModel : ViewModelBase
    {
        private bool isConvert;
        private bool convertIsDone;
        public List<TestCaseZeta> ListZetaTestCase = new List<TestCaseZeta>();
        public PreConditionXray PreConditionXray { get; set; } = null!;
        public DelegateCommand ListConverter { get; set; }
        public DelegateCommand SaveList { get; set; }

        public ObservableCollection<PreConditionXray> PreConditionXrays { get; set; }
        public List<PreConditionXray> ListPreConditionXray = new List<PreConditionXray>();

        public bool IsConvert
        {
            get => isConvert;
            set
            {
                if (isConvert != value)
                {
                    isConvert = value;
                    this.RaisePropertyChange();
                }
            }
        }

        public ConvertToXrayPreConditionViewModel()
        {
            this.ListConverter = new DelegateCommand((o) => ConvertList());
            this.SaveList = new DelegateCommand((o) => ExportList());
            this.PreConditionXrays = new ObservableCollection<PreConditionXray>();
        }

        private void ConvertList()
        {
            string excelImportPath = "";
            convertIsDone = false;

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
                    var servicePreConditionXray = new DataListService();
                    ListPreConditionXray = servicePreConditionXray.PreConditionXrayService(ListZetaTestCase);

                    foreach (var preConditionXray in ListPreConditionXray)
                    {
                        this.PreConditionXrays.Add(preConditionXray);
                    }

                    this.IsConvert = false;
                    this.convertIsDone = true;

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

            if (convertIsDone == true)
            {
                MessageBox.Show("Die Konvertierung ist abgeschlossen! \nDer Export kann jetzt erfolgen!");
            }
        }

        private void ExportList()
        {
            string listExportPath = "";
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog != null)
            {
                dialog.Filter = "File (*.csv)|*.csv";
                if (dialog.ShowDialog().Value)
                {
                    listExportPath = dialog.FileName;
                }

                if (listExportPath != "")
                {
                    ExportService exportService = new ExportService();
                    exportService.ExportXrayPreCondition(ListPreConditionXray, listExportPath);

                    MessageBox.Show("Der Export wurde erfolgreich beendet!");
                }
                else
                {
                    MessageBox.Show("Es wurden keine Informationen über den Speicherort und Dateinamen angegeben!");
                }
            }
            else
            {
                MessageBox.Show("Es wurden keine Informationen über den Speicherort und Dateinamen angegeben!");
            }
        }
    }
}
