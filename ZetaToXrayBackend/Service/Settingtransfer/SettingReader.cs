using System.IO;
using System.Windows;

namespace ZetaToXrayBackend.Service.Settingtransfer
{
    public class SettingReader
    {
        private string fileNameExport = @"Setting_Excel_Export.txt";
        private string fileNameImport = @"Setting_Excel_Import.txt";
        
        private string ReadeFile(string filename)
        {
            SettingWriter writer = new SettingWriter();
            string settingFilePath = writer.PathInfo() + @"\" + filename;
            string settings;

            if (File.Exists(settingFilePath) == true)
            {
                using (FileStream fileStreamRead = File.OpenRead(settingFilePath))
                {
                    using (StreamReader streamReader = new StreamReader(fileStreamRead))
                    {
                        settings = streamReader.ReadToEnd();
                        return settings;
                    }
                }
            }
            else
            {
                MessageBox.Show("Die Setting-Datei kann nicht gefunden werden!");
                return "";
            }
        }
        
        
        public string ReadSettingExcelExport()
        {
            string settings = ReadeFile(fileNameExport);

            return settings;
        }

        public string ReadSettingExcelImport()
        {
            string settings = ReadeFile(fileNameImport);

            return settings;
        }
    }
}
