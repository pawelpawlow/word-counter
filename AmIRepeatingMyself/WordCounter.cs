using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AmIRepeatingMyself
{
    public class WordCounter
    {
        public WordOccurances[] CountWordOccurances(string sentence)
        {            
            var stats = new Dictionary<string, int>(1000, StringComparer.OrdinalIgnoreCase);            

            for (var match = Regex.Match(sentence, @"\b[^\s.,?:()_@=]+\b", RegexOptions.CultureInvariant | RegexOptions.Multiline | RegexOptions.IgnoreCase); match.Success; match = match.NextMatch())
            {
                var w = match.Value;

                if (string.IsNullOrWhiteSpace(w))
                    continue; // not a word

                int wordOccurances;
                if (!stats.TryGetValue(w, out wordOccurances))
                    stats.Add(w, 1);
                else
                    stats[w] = wordOccurances + 1;
            }
                        
            return stats
                .OrderByDescending(kv => kv.Value)
                .Select(kv => new WordOccurances(kv.Value, kv.Key))
                .ToArray();
        }

    }
}
