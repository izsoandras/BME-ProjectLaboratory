using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RoboPro.Utils
{
    class FileLogListener
    {
        private FileInfo file;

        public FileLogListener(FileInfo fileInfo)
        {
            if (fileInfo.Exists)
            {
                file = fileInfo;
            }
            else
            {
                throw new FileNotFoundException(fileInfo.FullName);
            }
        }

        public void LogToFile(string msg)
        {
            using(StreamWriter sw = file.AppendText())
            {
                sw.WriteLine(msg);
            }
        }
    }
}
