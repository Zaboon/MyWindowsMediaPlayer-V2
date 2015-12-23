using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer
{
    class File
    {
        private string fileUri;
        public static string[] allTypes =
                                {
                                    ".mpg", ".mp4", ".avi", ".wmv", ".mpa",
                                    ".mpe", ".m1v",".mp2", ".mpg", ".mpeg",
                                    ".jpg", ".png", ".bmp", ".gif", ".mov"
                                };

        public File(string value)
        {
            this.fileUri = value;
        }

        public string getUri
        {
            get { return fileUri; }
        }

        public override string ToString()
        {
            return fileUri.Substring(fileUri.LastIndexOf("\\") + 1);
        }
    }
}
