using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StringParsing
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var filePathRead = @"sample.txt";
            var fileTestPathR = @"sample1.txt";
            //var fileTestPathR = @"testR.txt";
            var wordsTestPathW = @"testWordsW.txt";
            var sentenceTestPathW = @"testSentenceW.txt";


            var regexWord = new Regex(@"(?<ApWord>((\w+)(')(\w+)))|(?<HyWord>((\w+)(-)(\w+)))|(?<Rest>\w+)"); //only woord not always correct
            var regexSentence = new Regex(@"((?:[A-Z]\.|[^\.!?])+)[\.!?]"); // only sentence not always correct
            var regexPunctuationMarks = new Regex(@"");   // need to add punction regex

            var workWithFile = new TextFile(fileTestPathR, wordsTestPathW, sentenceTestPathW);
            GetWordsAndTheirNumbersByLinq(workWithFile, regexWord);
            var isMaxRepetitionLetter = GetLetterWithMaxRepetititonByLinq(workWithFile);
            var isTheLongestSentence = GetSentenceWithMaxLetters(workWithFile, regexSentence);
            var isTheShortestSentence = GetTheShortestSentence(workWithFile, regexSentence, regexWord);
            workWithFile.SaveSmthInFile(isTheLongestSentence, isTheShortestSentence, isMaxRepetitionLetter);
            
        }
        static void GetWordsAndTheirNumbersByLinq(TextFile workWithFile,Regex regexWord)
        {
             var matchesWords = regexWord.Matches(workWithFile.GetFullText())
                .GroupBy(x => x.Value)
                .Where(r => r.Count() >= 1)
                .OrderBy(m => m.Key);
            foreach (var item in matchesWords)
            {
                workWithFile.SaveWordsInFile(item.Key, item.Count());
            }
        }
        
        static string GetSentenceWithMaxLetters(TextFile workWithFile, Regex regexSentence)
        {
            var matchesMaxSentence = regexSentence.Matches(workWithFile.GetFullText()).ToList();
            int maxLength = 0;
            string maxSentense = "";
            foreach (var item in matchesMaxSentence)
            {
                if (item.Value.Length > maxLength)
                {
                    maxLength = item.Value.Length;
                    maxSentense = item.Value;
                }
            }
            return maxSentense;
        }

        static string GetTheShortestSentence(TextFile workWithFile, Regex regexSentence, Regex regexWord)
        {
            var minTimesWordsInSentence = int.MaxValue;
            string shortSentence = "";
            var matchesShortSentence = regexSentence.Matches(workWithFile.GetFullText()).ToList();
            foreach (var item in matchesShortSentence)
            {
                var coutWordsInSentence = 0;
                var matchesWordsInSentence = regexWord.Matches(item.Value);
                if (matchesWordsInSentence.Count < minTimesWordsInSentence)
                {
                    shortSentence = item.Value;
                }
            }
            return shortSentence;
        }
        
        static string GetLetterWithMaxRepetititonByLinq(TextFile worsWithFile)
        {
            string st = worsWithFile.GetFullText().ToLower();
            var count = st.Where(c => char.IsLetter(c))
                .GroupBy(litteral => litteral)
                .Select(item => new { Key = item.Key, Count = item.Count() })
                .MaxBy(item => item.Count);
            return count.Key + " " + count.Count;
        }
    }
}
        


    
