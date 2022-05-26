using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            char[] incorrectSeparators = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            string[] sentences = text.Split(incorrectSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string sentence in sentences)
                if (ParseWords(sentence).Count > 0)
                    sentencesList.Add(ParseWords(sentence));

            return sentencesList;
        }

        public static List<string> ParseWords(string sentence)
        {
            var builder = new StringBuilder();
            var words = new List<string>();
            string word = null;
            foreach (char c in sentence)
            {               
                    if (Char.IsLetter(c) || c == '\'') builder.Append(c);
                
                    else
                    {
                        word = builder.ToString().ToLower();
                        if (word.Length > 0)
                        words.Add(word);
                        builder.Clear();
                    }
                }
                word = builder.ToString().ToLower();
            if (word.Length > 0)
                words.Add(word);
             return words;
             }

    }
}
