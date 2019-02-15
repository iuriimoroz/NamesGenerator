using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace RandomPersonNamesGenerator
{
    public class NamesGenerator : INamesGenerator
    {
        // Method which reads a text file line by line
        public IEnumerable<string> FileWithWordsReader(string textFilePath)
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

        public IEnumerable<string> GenerateNames(IEnumerable<string> words, int numberOfNames, int numberOfNameParts, char namesDelimiter)
        {
            var list = new List<string>(); // List<T> collection to which words will be added before processing
            // Adding words from the text file
            foreach (string word in words)
            {
                list.Add(word);
            }
            // Below the names generation code
            while (numberOfNames > 0)
            {
                // Only two valid cases will be sent to the method - single part names and names with multi parts - all incorrect input should be processed separately 
                if (numberOfNameParts == 1)
                {
                    var random = new Random(RandomSeedGenerator.GetSeed());
                    int randomNumber = random.Next(0, list.Count);
                    yield return list[randomNumber];
                }

                if (numberOfNameParts > 1)
                {
                    // String builder is used to build multi parts names
                    var builder = new StringBuilder();
                    // Append to StringBuilder.
                    for (int i = 0; i < numberOfNameParts; i++)
                    {
                        var random = new Random(RandomSeedGenerator.GetSeed());
                        int randomNumber = random.Next(0, list.Count);
                        builder.Append(list[randomNumber]).Append(namesDelimiter);
                    }
                    yield return builder.ToString().TrimEnd(namesDelimiter);
                }
                numberOfNames--;
            }
        }
    }
}
