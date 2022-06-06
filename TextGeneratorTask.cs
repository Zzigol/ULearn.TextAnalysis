using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
            public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var builder = new StringBuilder();
            
            builder.Append(phraseBeginning);
            int i = wordsCount;
            Found:
            foreach (var pair in nextWords)
            {
               // if ()
               // {
                    string[] array = phraseBeginning.Split(' ');
                    if (array.Length >= 2 && array[array.Length - 2] + " " + array[array.Length - 1] == pair.Key && i > 0 && nextWords.ContainsKey(array[array.Length - 2] + " " + array[array.Length - 1]))
                    {
                        builder.Append(" ");
                        builder.Append(pair.Value);
                        phraseBeginning = builder.ToString();
                        array = phraseBeginning.Split(' ');
                        i--;
                        if (i > 0) goto Found;
                    }
                    else if (array[array.Length - 1] == pair.Key && i > 0 && nextWords.ContainsKey(array[array.Length - 1]))
                    {
                        builder.Append(" ");
                        builder.Append(pair.Value);
                        phraseBeginning = builder.ToString();
                        i--;
                        if (i > 0 && nextWords.ContainsKey(array[array.Length - 1])) goto Found;
                    }
               // }
                
                /*else
                {
                    if (i > 0) goto Found;
                    else continue;

                }*/
            }  
            return builder.ToString(); ;
            }    
     }
}

            
      
   
               