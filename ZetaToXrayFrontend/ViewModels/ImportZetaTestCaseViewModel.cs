using MVVM_Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaToXrayFrontend.Model.Zeta;

namespace ZetaToXrayFrontend.ViewModels
{
    public class ImportZetaTestCaseViewModel : ViewModelBase
    {
        public ObservableCollection<TestCaseZeta> testCaseZetas { get; set; } = new ObservableCollection<TestCaseZeta>();



    }
}