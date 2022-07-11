using System.Text;

namespace StringParsing
{
    public class TextFile
    {
        private string _pathForReading;
        private string _pathForWritingWords;
        private string _pathforWritingSentence;

        public TextFile(string pathForReading,string pathForWritingWords, string pathforWritingSentence)
        {
            _pathForReading = pathForReading;
            _pathForWritingWords = pathForWritingWords; 
            _pathforWritingSentence=pathforWritingSentence;
        }
        
        public string GetFullText()
        {
            using (var sr= new StreamReader (_pathForReading, Encoding.UTF8))
            {
                var allText = sr.ReadToEnd();
                return allText;
            }
        }

        public  void SaveWordsInFile(string word, int count)
        {
            using (var sw = new StreamWriter(_pathForWritingWords, true, Encoding.UTF8))
            {
                sw.WriteLine($"Word: {word} \t {count} times");
            }
        }

        public void SaveSmthInFile(string theLongestSentence, string theShortestSentence, string letterAndLetterRepetition)
        {
            using (var sw = new StreamWriter(_pathforWritingSentence, true, Encoding.UTF8))
            {
                sw.Write($"\t>>>>>>>The longest sentene: \n {theLongestSentence}");
                sw.Write($"\n\t>>>>>>>Firs the shortest sentence: \n {theShortestSentence}");
                sw.Write($"\n\t>>>>>>>>The most common letter:\n {letterAndLetterRepetition}");
            }
        }
    }
}
