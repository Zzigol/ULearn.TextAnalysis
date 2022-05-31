using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            //GetSort(GetAllNGrams(text));
            return result = GetSort(GetAllNGrams(text));
        }

        public static Dictionary<string, string> GetSort(Dictionary<string, Dictionary<string, int>> KeysNgramm)
        {
            string minKey = null;
            int max = 0;
            var AllNGrams = new Dictionary<string, string>();
            foreach (var key in KeysNgramm)
            {
                foreach (var val in key.Value)
                {
                    for (int i = 0; i < key.Value.Count; i++)
                    {
                        if (max < val.Value)
                            max = val.Value;
                    }
                    
                     if (key.Value.Count == 1)
                            AllNGrams.Add(key.Key, val.Key);
                        else
                        {
                            if (val.Value != max)
                            {
                                //AllNGrams.Add(key.Key,  )
                            }
                            else
                            {
                                foreach (var dic in KeysNgramm.Values)
                                {
                                    foreach (var key1 in dic.Keys)
                                    {

                                        if (string.CompareOrdinal(key1, minKey) > 0)
                                        {
                                            minKey = key1;
                                        }
                                    }
                                }
                                AllNGrams.Add(key.Key, minKey);
                            }
                            continue;
                        }

                    
                }
         
            }

            return AllNGrams;
        } 

        public static Dictionary<string, Dictionary<string, int>> GetAllNGrams(List<List<string>> text)
        {
            var KeysNgramm = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in text)
            {
                if (sentence.Count > 1)
                {
                    for (int i = 0; i < sentence.Count - 1; i++)
                    {
                        if (!KeysNgramm.ContainsKey(sentence[i]))
                            KeysNgramm[sentence[i]] = new Dictionary<string, int> {{ sentence[i + 1], 1 } };
                        else if (!KeysNgramm[sentence[i]].ContainsKey(sentence[i + 1]))
                            KeysNgramm[sentence[i]].Add(sentence[i + 1], 1);
                        else
                            KeysNgramm[sentence[i]][sentence[i + 1]]++;
                    }
                }
                if (sentence.Count > 2)
                {
                    for (int i = 0; i < sentence.Count - 2; i++)
                    {
                        if (!KeysNgramm.ContainsKey(sentence[i] + " " + sentence[i + 1]))
                            KeysNgramm[sentence[i] + " " + sentence[i + 1]] = new Dictionary<string, int> { { sentence[i + 2], 1 } };
                        else if (!KeysNgramm[sentence[i] + " " + sentence[i + 1]].ContainsKey(sentence[i + 2]))
                            KeysNgramm[sentence[i] + " " + sentence[i + 1]].Add(sentence[i + 2], 1);
                        else
                            KeysNgramm[sentence[i] + " " + sentence[i + 1]][sentence[i + 2]]++;
                    }
                }
            }
            return KeysNgramm;
        }
    }
}
    

   /* else if (key.Value.Count == 2)
                        {
                            foreach (var dic in KeysNgramm.Values)
                            {
                                foreach (var key1 in dic.Keys)
                                {

                                    if (string.CompareOrdinal(minKey, key1) < 0)
                                    {
                                        minKey = key1;
                                    }
                                }
                            }
                            AllNGrams.Add(key.Key, minKey);
                        }*/