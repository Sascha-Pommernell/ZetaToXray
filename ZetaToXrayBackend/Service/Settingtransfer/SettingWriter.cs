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
        private string fileNameExport = @"Setting_Excel_Export.txt";
        private string fileNameImport = @"Setting_Excel_Import.txt";
        private string path = @"c:\tmpZetaToxtay";

        private void CreateDitectory()
        {
            Directory.CreateDirectory(path);
        }

        private void CreateWriteFile( string path, string filename, string setting)
        {
            string settingFilePath = path + @"\" + filename;

            using (FileStream fileStreamWrite = File.Create(settingFilePath))
            {
                byte[] settingConvertedToBytes = Encoding.ASCII.GetBytes(setting);
                fileStreamWrite.Write(settingConvertedToBytes, 0, settingConvertedToBytes.Length);
            }

            MessageBox.Show("Die Einstellungen wurden gespeichert.");
        }
        
        public void WriteSettingsExcelExport(string setting)
        { 
            CreateWriteFile(path, fileNameExport, setting);
        }

        public void WriteSettingsExcelImport(string settings)
        {
            CreateWriteFile(path, fileNameImport, settings);
        }

        public string PathInfo()
        {
            string pathinfo = path;

            return pathinfo;
        }
    }
}
