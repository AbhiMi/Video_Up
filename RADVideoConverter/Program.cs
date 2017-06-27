using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NReco.VideoConverter;
using System.IO;

namespace RADVideoConverter
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileLocaion = ConfigurationManager.AppSettings["fileLocation"].ToString();
            string pathString = fileLocaion + @"\ConvertedFiles";

            Directory.CreateDirectory(pathString);

            var list = new DirectoryInfo(fileLocaion).GetFiles()
                .Where(f => (!f.Attributes.HasFlag(FileAttributes.System)) && (!f.Extension.Equals(".mp4")))
                .Select(f => f.FullName)
                .ToList();

            foreach (string filePath in list)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                string directoryFullPath = fileInfo.DirectoryName;

                string oldFileName = Path.GetFileName(filePath);
                string newFileName = Path.GetFileNameWithoutExtension(filePath);

                string destinationFilePath = pathString + @"\" + oldFileName;

                var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                ffMpeg.ConvertMedia(filePath, directoryFullPath + @"\" + newFileName + ".mp4", Format.mp4);

                File.Move(filePath, destinationFilePath);
            }
        }
    }
}
