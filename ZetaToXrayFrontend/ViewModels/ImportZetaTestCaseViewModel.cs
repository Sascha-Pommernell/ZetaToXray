using MVVM_Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZetaToXrayBackend.Model.Zeta;
using ZetaToXrayFrontend.Service;

namespace ZetaToXrayFrontend.ViewModels
{
    public class ImportZetaTestCaseViewModel : ViewModelBase
    {
        private bool isLoading;
        public TestCaseZeta TestCaseZeta { get; set; } = null!;
        public DelegateCommand LoadList { get; set; }
        public ObservableCollection<TestCaseZeta> TestCaseZetas { get; set; }
        public List<TestCaseZeta> ListZetaTestCase = new List<TestCaseZeta>();
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    this.RaisePropertyChange();
                }
            }
        }


        public ImportZetaTestCaseViewModel()
        {
            this.LoadList = new DelegateCommand((o) => ExecLoadList());
            this.TestCaseZetas = new ObservableCollection<TestCaseZeta>();
        }

        private void ExecLoadList()
        {
            //Todo: Hier den Öffnendialog implementieren
            this.IsLoading = true;
            var serviceTestCaseZeta = new DataListService();
            ListZetaTestCase = serviceTestCaseZeta.ZetaTestCaseListService();


            foreach (var testCaseZeta in ListZetaTestCase)
            {
                this.TestCaseZetas.Add(testCaseZeta);
            }

            this.IsLoading = false;
        }
    }
}