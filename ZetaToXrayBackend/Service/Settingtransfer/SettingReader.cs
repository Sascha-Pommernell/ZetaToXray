using System.IO;
using System.Windows;

namespace ZetaToXrayBackend.Service.Settingtransfer
{
    public class SettingReader
    {
        private string fileNameExport = @"\Setting_Excel_Export.txt";
        private string fileNameImport = @"\Setting_Excel_Import.txt";
        
        public string ReadSettingExcelExport()
        {
            string stettings = "";


            /*if (Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName != null)
            {
                //string? path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName;
                string path = @"D:\Entwicklung\Visual_Studio\ZetaToXray\ZetaToXrayBackend\SettingFile";
                string settingFilePath = path + fileNameExport;

                if (File.Exists(settingFilePath) == true)
                {
                    using (FileStream fileStreamRead = File.OpenRead(settingFilePath))
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
            }*/

            string path = @"D:\Entwicklung\Visual_Studio\ZetaToXray\ZetaToXrayBackend\SettingFile";
            string settingFilePath = path + fileNameExport;

            if (File.Exists(settingFilePath) == true)
            {
                using (FileStream fileStreamRead = File.OpenRead(settingFilePath))
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
            return stettings;
        }

        public string ReadSettingExcelImport()
        {
            string stettings = "";


            /*if (Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName != null)
              {
                  //string? Path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName;

                  string path = @"D:\Entwicklung\Visual_Studio\ZetaToXray\ZetaToXrayBackend\SettingFile";
                  string settingFilePath = path + fileNameImport;

                  if (File.Exists(settingFilePath) == true)
                  {
                      using (FileStream fileStreamRead = File.OpenRead(settingFilePath))
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
              }*/

            string path = @"D:\Entwicklung\Visual_Studio\ZetaToXray\ZetaToXrayBackend\SettingFile";
            string settingFilePath = path + fileNameImport;

            if (File.Exists(settingFilePath) == true)
            {
                using (FileStream fileStreamRead = File.OpenRead(settingFilePath))
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
            return stettings;
        }
    }
}
