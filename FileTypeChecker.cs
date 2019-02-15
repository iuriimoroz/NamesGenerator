using System.IO;

namespace RandomPersonNamesGenerator
{
    public static class FileTypeChecker
    {
        // Method that checks that provided file is a text file or binary file
        public static bool IsTextFile(string FilePath)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                int Character;
                while ((Character = reader.Read()) != -1)
                {
                    // In case of program finds a character in the file being checked which does not correspond to be a "text file" character - false will be returned
                    if ((Character > 0 && Character < 8) || (Character > 13 && Character < 26))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
