using System.Collections.Generic;

namespace RandomPersonNamesGenerator
{
    /// <summary>
    /// Names generator that generates random person names from words
    /// </summary>
    public interface INamesGenerator
    {
        /// <summary>
        /// A method that reads a text file with words for further names generation
        /// </summary>
        IEnumerable<string> FileWithWordsReader(string textFilePath);
        /// <summary>
        /// A method that generates names by user provided amount of names to be generated, names parts and names delimiter
        /// </summary>
        IEnumerable<string> GenerateNames(IEnumerable<string> words, int numberOfNames, int numberOfNameParts, char namesDelimiter);
    }
}
