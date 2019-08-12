using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    
    public class Book
    {
        public List<Chapter> chapters;

        public Book(string path)
        {
            chapters = new List<Chapter>();
            IEnumerable<string> dirNames = Directory.EnumerateDirectories(path, "*");

            foreach(string name in dirNames)
            {
                chapters.Add(new Chapter(name));
            }
        }
    }
}
