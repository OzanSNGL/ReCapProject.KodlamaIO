using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            var result = newPath(file);
            File.Move(sourcePath, result);
            return result;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var fileStream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }



        //new Path
        public static string newPath(IFormFile file)
        {
            FileInfo fi = new FileInfo(file.FileName);
            string fileExtension = fi.Extension;

            string path = Environment.CurrentDirectory + @"\Images\carImages";
            var newPath = Guid.NewGuid().ToString() + " " + DateTime.Now.Month + " " + DateTime.Now.Day + " " + DateTime.Now.Year + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
