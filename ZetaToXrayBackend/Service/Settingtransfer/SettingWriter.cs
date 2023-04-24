using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZetaToXrayBackend.Service.Settingtransfer
{
    public class SettingWriter
    {
        private string fileNameExport = @"\Setting_Excel_Export.txt";
        private string fileNameImport = @"\Setting_Excel_Import.txt";

        public void WriteSettingsExcelExport(string settings)
        {
            if (Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName != null)
            {
                string? path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName;
                string settingFilePath = path + fileNameExport;

                using (FileStream fileStreamWrite = File.Create(settingFilePath))
                {
                    byte[] settingConvertedToBytes = Encoding.ASCII.GetBytes(settings);
                    fileStreamWrite.Write(settingConvertedToBytes, 0, settingConvertedToBytes.Length);
                }

                MessageBox.Show("Die Einstellungen wurden gespeichert.");
            }
        }

        public void WriteSettingsExcelImport(string settings)
        {
            if (Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName != null)
            {
                string? path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName;
                string settingFilePath = path + fileNameImport;

                using (FileStream fileStreamWrite = File.Create(settingFilePath))
                {
                    byte[] settingConvertedToBytes = Encoding.ASCII.GetBytes(settings);
                    fileStreamWrite.Write(settingConvertedToBytes, 0, settingConvertedToBytes.Length);
                }

                MessageBox.Show("Die Einstellungen wurden gespeichert.");
            }
        }
    }
}
