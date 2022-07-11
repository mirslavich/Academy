using System.Text;

namespace StringParsing
{
    public class TextFile
    {
        private string _pathForReading;
        private string _pathForWritingWords;
        private string _pathforWritingSentence;
        public TextFile
        }
        public string GetFullText()
        {
            using (var sr= new StreamReader (_filePathForReading,Encoding.UTF8))
            {
                var allText = sr.ReadToEnd();
                return allText;
            }

        }

        public static void SaveWordsInFile(string filePathWrite, string word, int count)
        {
            using (var sw = new StreamWriter(filePathWrite, true, Encoding.UTF8))
            {
                sw.WriteLine($"Word: {word} \t {count} times");
            }
        }

        public void SaveSmthInFile(string filePathWrite, string theLongestSentence, string theShortestSentence, char letter, int letterRepetition)
        {
            using (var sw = new StreamWriter(filePathWrite, true, Encoding.UTF8))
            {
                sw.Write($">>>>>>>The longest sentene: \n {theLongestSentence}");
                sw.Write($">>>>>>>The shortest sentene: \n {theShortestSentence}");
                sw.Write($">>>>>>>>The most common letter: {letter} \t {letterRepetition} times");
            }
        }








    }
}
