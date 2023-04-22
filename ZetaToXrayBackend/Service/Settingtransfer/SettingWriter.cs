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
        public void WriteSettingsExcelExport(string settings)
        {
            if (Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName != null)
            {
                string? path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName;
                string settingFilePath = path + @"ZetaToXray\ZetaToXrayBackend\SettingFile\Setting_Excel_Export.txt";

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
                string settingFilePath = path + @"ZetaToXray\ZetaToXrayBackend\SettingFile\Setting_Excel_Import.txt";

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
