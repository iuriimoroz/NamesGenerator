using System;
using System.IO;

namespace RandomPersonNamesGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Empty "textFilePath" variable declared which will store the path to a text file used by the program for names generation
            string textFilePath = null;

            // In orded to avoid incorrect file path input I used while loop which checks that user entered the correct path to the text file
            while (!File.Exists(textFilePath)) // First iteration will always fail in order to prompt the user input the path to the text file
            {
                Console.WriteLine("Input a path to the text file with words which will be used for person names generation:");
                textFilePath = Console.ReadLine();
                if (File.Exists(textFilePath))
                {
                    Console.WriteLine("Input a number of person names you wish to be generated:");
                    bool isNumberOfNamesSuccess = int.TryParse(Console.ReadLine(), out int numberOfNames);
                    Console.WriteLine("Input the number of parts you wish each name should consist of:");
                    bool isnumberOfNamePartsSuccess = int.TryParse(Console.ReadLine(), out int numberOfNameParts);

                    char namesDelimiter = ' '; // Declaration of default char delimiter

                    // There is no need to ask about name delimiter in case of names will be only with one part
                    if (numberOfNameParts > 1)
                    {
                        Console.WriteLine("Input a delimiter character for multi-parts name:");
                     // try-catch block is used when user input blank name delimiter or a delimiter with more than one symbol - in that case the default delimiter will be used
                        try
                        {
                            namesDelimiter = Convert.ToChar(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("You did not provide name delimiter or provided delimiter has more than one symbol. Default \"space\" delimiter will be used.");
                        }
                    }
                    // Below if-else block is used to avoid names generation when user entered some incorrect values. He will receive a message about that
                    if (numberOfNameParts > 0 && numberOfNames > 0)
                    {   
                        Console.WriteLine("See generated names below:");

                        INamesGenerator namesGenerator = new NamesGenerator();
                        foreach (string name in namesGenerator.GenerateNames(namesGenerator.FileWithWordsReader(textFilePath), numberOfNames, numberOfNameParts, namesDelimiter))
                        {

                            Console.WriteLine(name);
                        }
                    }
                    else
                    {
                        if (!isNumberOfNamesSuccess)
                        {
                            Console.WriteLine("Number of person names value must be a positive integer number. Nothing was generated.");
                        }
                        else if (!isnumberOfNamePartsSuccess)
                        {
                            Console.WriteLine("Number of name parts value must be a positive integer number. Nothing was generated.");
                        }
                        else if (numberOfNameParts <= 0)
                        {
                            Console.WriteLine("The name can not consist with 0 or negative number of parts. Nothing was generated.");
                        }
                        else
                        {
                            Console.WriteLine("You provided number of names to be generated 0 or below the 0. Nothing was generated.");
                        }
                    }

                }
                // When user provided incorrect or misspelled source file path he will be prompted to try again.
                // Printing the name of the path should help him to fix the problem (I hope)
                else
                {
                    Console.WriteLine($"The program was unable to find the file by the provided path: \"{textFilePath}\". Please double check the path and try again...");
                }
            };

            Console.WriteLine("Press any key to close the screen...");
            Console.ReadKey();

        }
    }
}
