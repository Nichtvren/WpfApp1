using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MultiChoiceQuestion
    {
        public string preposition;
        public string answer;
        public int maxAttempts;
        public int maxScore;
        public List<string> choices;
        public List<string> hints;
        public override string ToString()
        {
            return $"{preposition}\t{answer}\t{maxAttempts}\t{maxScore}";
        }



        public MultiChoiceQuestion(StreamReader file)
        {
            string fileLine;
            string buffer;
            choices = new List<string>();
            hints = new List<string>();      
            while((fileLine = file.ReadLine()) != null)
            {
                switch (fileLine.Trim())
                { 
                    case "PREPOSITION":
                        preposition = "";
                        while((fileLine = file.ReadLine().Trim()) != "ENDPREPOSITION")
                        {
                            if(preposition == "")
                                preposition = fileLine;
                            else
                                preposition = $"{preposition}\n{fileLine}";
                        }
                        break;                   
                    case "ANSWER":
                        answer = "";
                        while((fileLine = file.ReadLine().Trim()) != "ENDANSWER")
                        {
                            if(answer == "")
                                answer = fileLine;
                            else
                                answer = $"{answer}\n{fileLine}";
                        }
                        break;
                    case "MAXATTEMPTS":
                        maxAttempts = Int32.Parse(file.ReadLine().Trim());
                        while((fileLine = file.ReadLine().Trim()) != "ENDMAXATTEMPTS")
                        {
                            continue;
                        }
                        break;
                    case "MAXSCORE":
                        maxScore = Int32.Parse(file.ReadLine().Trim());
                        while((fileLine = file.ReadLine().Trim()) != "ENDMAXSCORE")
                        {
                            continue;
                        }
                        break;
                    case "CHOICE":
                        buffer = "";
                        while((fileLine = file.ReadLine().Trim()) != "ENDCHOICE")
                        {
                            if(buffer == "")
                                buffer = fileLine;
                            else
                                buffer = $"{buffer}\n{fileLine}";
                        }
                        choices.Add(buffer);
                        break;
                    case "HINT":
                        buffer = "";
                        while((fileLine = file.ReadLine().Trim()) != "ENDHINT")
                        {
                            if (buffer == "")
                                buffer = fileLine;
                            else
                                buffer = $"{buffer}\n{fileLine}";
                        }
                        hints.Add(buffer);
                        break;
                    case "ENDMULTICHOICEQUESTION":
                        
                        break;
                    default:
                        
                        break;
                }
            }
        }

    }
}
