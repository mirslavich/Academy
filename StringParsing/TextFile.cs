using System.Text;

namespace StringParsing
{
    public class TextFile
    {
        
        public string GetFullText(string filePath)
        {
            using (var sr= new StreamReader (filePath,Encoding.UTF8))
            {
                var allText = sr.ReadToEnd();
                return allText;
            }

        }

        public void SaveWordsInFile(string filePathWrite, string word, int count)
        {
            using (var sw = new StreamWriter(filePathWrite, true, Encoding.UTF8))
            {
                sw.WriteLine($"Word: {word} \t {count} times");
            }
        }

        public void SaveSmthInFile(string filePathWrite, string theLongestSentence, string theShortestSentence, char letter)
        {
            using (var sw = new StreamWriter(filePathWrite, true, Encoding.UTF8))
            {
                sw.Write($">>>>>>>The longest sentene: \n {theLongestSentence}");
                sw.Write($">>>>>>>The shortest sentene: \n {theShortestSentence}");
                sw.Write($">>>>>>>>The most common letter: {letter}");
            }
        }








    }
}
