using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Page
    {
        public Dictionary<string, Object> data;
        public string name;

        public Page(StreamReader file)
        {
            string path = (file.BaseStream as FileStream).Name;
            int i = path.LastIndexOf('\\');
            name = path.Substring(i + 1);
            
            data = new Dictionary<string, Object>();
            string fileLine;
            string buffer;
            int counter = 0;
            while ((fileLine = file.ReadLine()) != null)
            {
                switch (fileLine.Trim())
                {
                    case "PAGENAME":
                        buffer = "";
                        while ((fileLine = file.ReadLine().Trim()) != "ENDPAGENAME")
                        {
                            if (buffer == "")
                                buffer = fileLine;
                            else
                                buffer = $"{buffer}\n{fileLine}";
                        }
                        data.Add($"{counter.ToString("000")} PAGENAME", buffer);
                        ++counter;
                        break;
                    case "TITLE":
                        buffer = "";
                        while ((fileLine = file.ReadLine().Trim()) != "ENDTITLE")
                        {
                            if (buffer == "")
                                buffer = fileLine;
                            else
                                buffer = $"{buffer}\n{fileLine}";
                        }
                        data.Add($"{counter.ToString("000")} TITLE", buffer);
                        ++counter;
                        break;
                    case "SUBTITLE":
                        buffer = "";
                        while ((fileLine = file.ReadLine().Trim()) != "ENDSUBTITLE")
                        {
                            if (buffer == "")
                                buffer = fileLine;
                            else
                                buffer = $"{buffer}\n{fileLine}";
                        }
                        data.Add($"{counter.ToString("000")} SUBTITLE", buffer);
                        ++counter;
                        break;
                    case "PARAGRAPH":
                        buffer = "";
                        while ((fileLine = file.ReadLine().Trim()) != "ENDPARAGRAPH")
                        {
                            if (buffer == "")
                                buffer = fileLine;
                            else
                                buffer = $"{buffer}\n{fileLine}";
                        }
                        data.Add($"{counter.ToString("000")} PARAGRAPH", buffer);
                        ++counter;
                        break;
                    case "MULTICHOICEQUESTION":
                        data.Add($"{counter.ToString("000")} MULTICHOICEQUESTION", new MultiChoiceQuestion(file));
                        ++counter;
                        break;
                    default:

                        break;
                }


            }
        }

    }
}
