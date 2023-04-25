using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaToXrayBackend.Service.Settingtransfer;

namespace ZetaToXrayFrontend.Service
{
    class SettingService
    {
        private SettingReader reader = new SettingReader();
        private SettingWriter writer = new SettingWriter();
        private string importFilePath = null!;
        private string exportFilePath = null!;

        public void ImportPathWriteService(string importFilePath)
        {
            writer.WriteSettingsExcelImport(importFilePath);
        }

        public string ImportPathReadService()
        {
            return importFilePath = reader.ReadSettingExcelImport();
        }

        public void ExportPathWriteService(string exportFilePath)
        {
            writer.WriteSettingsExcelExport(exportFilePath);
        }

        public string ExportPathReadService()
        {
            return exportFilePath = reader.ReadSettingExcelExport();
        }
    }
}
