using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Text;

namespace RandomPersonNamesGenerator
{
    public class NamesGenerator : INamesGenerator
    {
        // Method which reads a text file line by line
        public IEnumerable <string> FileWithWordsReader(string textFilePath)
        {
            var reader = new StreamReader(textFilePath);
            string line;
            // Split on all non-word characters
            // This returns an array of all the words
            while ((line = reader.ReadLine()) != null)
            {
                foreach (string word in Regex.Split(line, @"\W+"))
                {
                    if (word.Length > 0) // This will remove white spaces
                    {
                        yield return word;
                    }
                }
            }
            reader.Close();
        }

        public IEnumerable <string> GenerateNames(IEnumerable<string> words, int numberOfNames, int numberOfNameParts, char namesDelimiter)
        {
            List<string> list = new List<string>();

            foreach (string word in words)
            {
                list.Add(word);
            }
            
            while (numberOfNames > 0)
            {
                if (numberOfNameParts == 1)
                {
                    Random random = new Random(DateTime.Now.Millisecond);
                    int randomNumber = random.Next(0, list.Count);
                    yield return list[randomNumber];
                    numberOfNames--;
                    Thread.Sleep(1);
                }

                if (numberOfNameParts > 1)
                {
                    Random random = new Random(DateTime.Now.Millisecond);
                    int randomNumber = random.Next(0, list.Count);
                    StringBuilder builder = new StringBuilder();
                    // Append to StringBuilder.
                    for (int i = 0; i < numberOfNameParts; i++)
                    {
                        builder.Append(list[randomNumber]).Append(namesDelimiter);
                    }
                    yield return builder.ToString().TrimEnd(namesDelimiter);
                    numberOfNames--;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
