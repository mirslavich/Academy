using System.Text.RegularExpressions;
using System.Linq;

namespace StringParsing
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var filePathRead = @"sample.txt";
            var fileTestPathR = @"sample1.txt";
            //var fileTestPathR = @"test.txt";
            var fileTestPathW = @"testW.txt";

            var regexWord = new Regex(@"(?<ApWord>((\w+)(')(\w+)))|(?<HyWord>((\w+)(-)(\w+)))|(?<Rest>\w+)"); //only woord not always correct
            var regexSentence = new Regex(@"((?:[A-Z]\.|[^\.!?])+)[\.!?]"); // only sentence not always correct
            var regexPunctuationMarks = new Regex(@"");   // need to add punction regex

            var fr = new TextFile();
            //var fOrder = new FileInAlphabeticalOrder();
            var matches2 = regexWord.Matches(fr.GetFullText(fileTestPathR))
                .GroupBy(x => x.Value)
                .Where(r => r.Count() >= 1)
                .OrderBy(m => m.Key);   
            foreach (var item in matches2)
            {
                fr.SaveWordsInFile(fileTestPathW,item.Key,item.Count());
                //Console.WriteLine("{0}: \t{1}", item.Key, item.Count());
            }

            var matches3 = regexSentence.Matches(fr.GetFullText(fileTestPathR)).ToList();
            ////.Select(m => m.Value)
            //.GroupBy(
            //x => x.Value,
            //y => y.Value.Length,
            //(pString, pString2) => new
            //{
            //    Sentence = pString,
            //    SentenceLenght = pString2
            //});
            int maxLength=0;
            string maxSentense="";
            foreach (var item in matches3)
            {
                
                if (item.Value.Length>maxLength)
                { 
                    maxLength= item.Value.Length;
                    maxSentense=item.Value;
                }
            }

            Console.WriteLine(maxSentense);
           
        }
        
    }
}