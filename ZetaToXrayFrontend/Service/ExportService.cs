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

        public void ExportXrayTestCase (List<TestCaseXray> testCaseXray, string exportPath)
        {
            writer.WriteXrayTestCaseCSV(testCaseXray, exportPath);
        }

        public void ExportXrayPreCondition (List<PreConditionXray> preConditionXray, string exportPath)
        {
            writer.WriteXrayPreConditionCSV(preConditionXray, exportPath);
        }
    }
}
