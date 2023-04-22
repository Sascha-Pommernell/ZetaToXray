using System.IO;
using System.Windows;

namespace ZetaToXrayBackend.Service.Settingtransfer
{
    public class SettingReader
    {
        public string ReadSettingExcelExport()
        {
            string stettings = "";
            

            if (Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName != null)
            {
                string? Path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName;
                string SettingFilePath = Path + @"ZetaToXray\ZetaToXrayBackend\SettingFile\Setting_Excel_Export.txt";

                if (File.Exists(SettingFilePath) == true)
                {
                    using (FileStream fileStreamRead = File.OpenRead(SettingFilePath))
                    {
                        using (StreamReader streamReader = new StreamReader(fileStreamRead))
                        {
                            stettings = streamReader.ReadToEnd();
                            return stettings;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Die Setting-Datei kann nicht gefunden werden!");
                }
            }
            else
            {
                MessageBox.Show("Der Speicherort der Setting-Datei kann nicht ermittelt werden.");
            }
            return stettings;
        }

        public string ReadSettingExcelImport()
        {
            string stettings = "";


            if (Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName != null)
            {
                string? Path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName;
                string SettingFilePath = Path + @"ZetaToXray\ZetaToXrayBackend\SettingFile\Setting_Excel_Import.txt";

                if (File.Exists(SettingFilePath) == true)
                {
                    using (FileStream fileStreamRead = File.OpenRead(SettingFilePath))
                    {
                        using (StreamReader streamReader = new StreamReader(fileStreamRead))
                        {
                            stettings = streamReader.ReadToEnd();
                            return stettings;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Die Setting-Datei kann nicht gefunden werden!");
                }
            }
            else
            {
                MessageBox.Show("Der Speicherort der Setting-Datei kann nicht ermittelt werden.");
            }
            return stettings;
        }
    }
}
