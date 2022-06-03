using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
       /* public static string TreeGrams(string ending, KeyValuePair<string,string> pair, int wordsCount)
            
        {
            for (int i = 0; i < wordsCount; i++)
            { 

            }

        }*/

            public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var builder = new StringBuilder();
            string ending = null;
            builder.Append(phraseBeginning);
                foreach (var pair in nextWords)
                {   
                    for (int i = 0; i < wordsCount; i++) 
                    {

                        string[] array = phraseBeginning.Split(' ');
                        if (array.Length >= 2)
                        {
                            ending = array[array.Length - 2] + " " + array[array.Length - 1];
                        }
                    if (ending == pair.Key)
                        {
                            builder.Append(" ");
                            builder.Append(pair.Value);
                            phraseBeginning = builder.ToString();
                        }
                    }
                    for (int i = 0; i < wordsCount; i++)
                    {
                        string[] array = phraseBeginning.Split(' ');
                        if (array[array.Length - 1] == pair.Key)
                        {
                            builder.Append(" ");
                            builder.Append(pair.Value);
                            phraseBeginning = builder.ToString();
                        }

                } 
                }
               
            string result = builder.ToString();
            return result;
        }    
    }
}

            
      
   
               