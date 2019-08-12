using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Chapter
    {
        public List<Page> pages;
        public string name;
        public Chapter(string path)
        {
            pages = new List<Page>();
            IEnumerable<string> fileNames = Directory.EnumerateFiles(path, "*.txt");

            foreach(string name in fileNames)
            {
                pages.Add(new Page(new StreamReader(name))); // something strange occurred here...
            }

            int i = path.LastIndexOf('\\');
            name = path.Substring(i + 1);
        }
    }
}
