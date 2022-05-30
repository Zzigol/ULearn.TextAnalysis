using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            foreach(var sentence in text)
            {   
                if (sentence.Count > 1)
                {
                    for (int i = 0; i < sentence.Count-1; i++)
                    {
                        result.Add(sentence[i], sentence[i + 1]);

                    }
                }
                if (sentence.Count > 2)
                {
                    for (int i = 0; i < sentence.Count - 2; i++)
                    {
                        result.Add(sentence[i]+" "+ sentence[i + 1], sentence[i + 2]);

                    }
                }
            }
            return result;
        }
   }
}