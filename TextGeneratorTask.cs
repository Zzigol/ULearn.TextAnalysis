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
                string[] array = phraseBeginning.Split(' ');
                if (array.Length >= 2 && 
                    i > 0 && nextWords.ContainsKey(array[array.Length - 2] + " " + array[array.Length - 1]))
                {
                    builder.Append(" " + nextWords[array[array.Length - 2] + " " + array[array.Length - 1]]);
                    phraseBeginning = builder.ToString();
                    i--;
                    goto Found;
                }
                else if (i > 0 && nextWords.ContainsKey(array[array.Length - 1]))
                {
                    builder.Append(" "+nextWords[array[array.Length - 1]]);
                    phraseBeginning = builder.ToString();
                    i--;
                    goto Found;
                }
                return builder.ToString(); ;
            }    
    }
}          