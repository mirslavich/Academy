using System.Text.RegularExpressions;
using System.Linq;

namespace StringParsing
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var filePathRead = @"sample.txt";
            //var fileTestPathR = @"sample1.txt";
            var fileTestPathR = @"testR.txt";
            var wordsTestPathW = @"testWordsW.txt";
            var sentenceTestPathW = @"testSentenceW.txt";


            

            var regexPunctuationMarks = new Regex(@"");   // need to add punction regex

            var workWithFile = new TextFile(fileTestPathR, wordsTestPathW, sentenceTestPathW);
            GetWordsAndTheirNumbersByLinq(workWithFile);
            var getLetter = GetLetterWithMaxRepetititonByLinq(workWithFile);
            var getMaxSentence = GetSentenceWithMaxLetters(workWithFile);

            






            //Console.WriteLine($"Symbol MAX: {letterWithMaxValue} value is: {letterMaxValue}");
            /*
            var letterMaxValue = 0;
            char? letterWithMaxValue = null;
            string st = fr.GetFullText(fileTestPathR).ToLower();
            var counts = st.Where(c => char.IsLetter(c))
                            .GroupBy(c => c)
                            .ToDictionary(grp => grp.Key, grp => grp.Count());
            foreach (var item in counts)
            {
                Console.WriteLine($"Symbol: {item.Key} value is: {item.Value}");


                if (item.Value > letterMaxValue)
                {
                    letterMaxValue = item.Value;
                    letterWithMaxValue = item.Key;
                }
            }
            Console.WriteLine($"Symbol MAX: {letterWithMaxValue} value is: {letterMaxValue}");
            */
        }
        static void GetWordsAndTheirNumbersByLinq(TextFile workWithFile)
        {
            var regexWord = new Regex(@"(?<ApWord>((\w+)(')(\w+)))|(?<HyWord>((\w+)(-)(\w+)))|(?<Rest>\w+)"); //only woord not always correct
            var matchesWords = regexWord.Matches(workWithFile.GetFullText())
                .GroupBy(x => x.Value)
                .Where(r => r.Count() >= 1)
                .OrderBy(m => m.Key);
            foreach (var item in matchesWords)
            {
                workWithFile.SaveWordsInFile(item.Key, item.Count());
            }
        }
        /*
        static string GetSentenceWithMaxLetters(TextFile workWithFile)
        {
            var regexSentence = new Regex(@"((?:[A-Z]\.|[^\.!?])+)[\.!?]"); // only sentence not always correct
            var matchesMaxSentence = regexSentence.Matches(workWithFile.GetFullText().ToList());
            
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
        */
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
        


    
