using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();

            return result = GetSortLex(GetSort(GetAllNGrams(text)));
        }

        public static Dictionary<string, List<string>> GetSort(Dictionary<string, Dictionary<string, int>> keysGram)
        {
            var allNGrams = new Dictionary<string, List<string>>();
            foreach (var pairAll in keysGram)
            {
                foreach (var pairStrInt in pairAll.Value)
                {
                    int max = MaxValue(pairAll);
                    if (pairStrInt.Value != max) continue;
                    else if (pairStrInt.Value == max)
                    {
                        if (!allNGrams.ContainsKey(pairAll.Key))
                        {
                            allNGrams.Add(pairAll.Key, new List<string>());
                            allNGrams[pairAll.Key].Add(pairStrInt.Key);
                        }
                        else allNGrams[pairAll.Key].Add(pairStrInt.Key);
                    }
                }
            }
            return allNGrams;
        }

        public static Dictionary<string, string> GetSortLex(Dictionary<string, List<string>> allNGrams)
        {
            var lexGrams = new Dictionary<string, string>();
            foreach (var pair in allNGrams)
            {
                string minKey = null;
                for (var i = 0; i < pair.Value.Count; i++)
                {
                    if (string.CompareOrdinal(pair.Value[i], minKey) < 0) minKey = pair.Value[i];
                    if (minKey == null)
                        minKey = pair.Value[i];
                }
                lexGrams.Add(pair.Key, minKey);
            }
            return lexGrams;
        }

        public static int MaxValue(KeyValuePair<string, Dictionary<string, int>> pair)
        {
            var max = 1;
            foreach (var variki in pair.Value)
            {
                if (max < variki.Value) max = variki.Value;
            }
            return max;
        }

        public static Dictionary<string, Dictionary<string, int>> GetAllNGrams(List<List<string>> text)
        {
            var keysGram = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in text)
            {
                if (sentence.Count > 1)
                {
                    for (int i = 0; i < sentence.Count - 1; i++)
                    {
                        if (!keysGram.ContainsKey(sentence[i]))
                            keysGram[sentence[i]] = new Dictionary<string, int> { { sentence[i + 1], 1 } };
                        else if (!keysGram[sentence[i]].ContainsKey(sentence[i + 1]))
                            keysGram[sentence[i]].Add(sentence[i + 1], 1);
                        else
                            keysGram[sentence[i]][sentence[i + 1]]++;
                    }
                }
                if (sentence.Count > 2)
                {
                    for (int i = 0; i < sentence.Count - 2; i++)
                    {
                        if (!keysGram.ContainsKey(sentence[i] + " " + sentence[i + 1]))
                            keysGram[sentence[i] + " " + sentence[i + 1]] = new Dictionary<string, int> { { sentence[i + 2], 1 } };
                        else if (!keysGram[sentence[i] + " " + sentence[i + 1]].ContainsKey(sentence[i + 2]))
                            keysGram[sentence[i] + " " + sentence[i + 1]].Add(sentence[i + 2], 1);
                        else
                            keysGram[sentence[i] + " " + sentence[i + 1]][sentence[i + 2]]++;
                    }
                }
            }
            return keysGram;
        }
    }
}