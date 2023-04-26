using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaToXrayBackend.Model.Xray;
using ZetaToXrayBackend.Service.FileTransfer;

namespace ZetaToXrayFrontend.Service
{
    class ExportService
    {
       private CsvWriter writer = new CsvWriter();

        public void ExportToExcelService (List<TestCaseXray> testCaseXray, string exportPath)
        {
            writer.WriteExcelDatei(testCaseXray, exportPath);
        }
    }
}
