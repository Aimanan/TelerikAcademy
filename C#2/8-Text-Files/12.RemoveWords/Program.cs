﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class RemoveWords
{
    static void Main()
    {
        try
        {
            StreamReader readFile;
            string[] words;
            string[] separatedText;

            readFile = new StreamReader(@"..\..\words.txt");
            using (readFile)
            {
                words = (readFile.ReadToEnd()).Split(' ');
            }

            readFile = new StreamReader(@"..\..\text.txt");
            using (readFile)
            {
                separatedText = (readFile.ReadToEnd()).Split(' ');
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < separatedText.Length; i++)
            {
                foreach (var word in words)
                {
                    if (separatedText[i].Length >= word.Length)
                    {
                        if (separatedText[i] == word)
                        {
                            separatedText[i] = string.Empty;
                        }
                    }
                }

                if (separatedText[i] == string.Empty)
                {
                    result.Append(string.Empty);
                }
                else
                {
                    result.Append(separatedText[i] + " ");
                }
            }

            StreamWriter writeFile = new StreamWriter(@"..\..\text.txt");

            using (writeFile)
            {
                writeFile.Write(result.ToString());
            }
           
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Program runs out of memory.");
            return;
        }
        catch (IOException)
        {
            Console.WriteLine("File cannot be open.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Enlarging the value of this instance would exceed the max capacity.");
        }
        catch (ObjectDisposedException)
        {
            Console.WriteLine("Buffer is full.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Contents of buffer cannot be written.");
        }
    }
}