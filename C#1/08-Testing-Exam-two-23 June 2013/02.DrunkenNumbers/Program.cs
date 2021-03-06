﻿using System;

class DrunkenNumbers
{
    static void Main()
    {
        int numberOfRounds = int.Parse(Console.ReadLine());
        int counterM = 0;
        int counterV = 0;

        for (int i = 0; i < numberOfRounds; i++)
        {
            long tempNumber = long.Parse(Console.ReadLine());
            if (tempNumber < 0)
            {
                tempNumber = -tempNumber;
            }
            int basicCounter = 1;
            string drunkenNumber = tempNumber.ToString().TrimStart('0');

            foreach (var digit in drunkenNumber)
            {
                if (drunkenNumber.Length % 2 != 0)
                {
                    if (basicCounter == ((drunkenNumber.Length + 1) / 2))
                    {
                        counterV += digit - '0';
                        counterM += digit - '0';
                        basicCounter++;
                        continue;
                    }
                    if (basicCounter > ((drunkenNumber.Length + 1) / 2))
                    {
                        counterV += digit - '0';
                        continue;
                    }
                    counterM += digit - '0';
                    basicCounter++;
                }
                else
                {
                    if (basicCounter > (drunkenNumber.Length / 2))
                    {
                        counterV += digit - '0';
                        continue;
                    }
                    counterM += digit - '0';
                    basicCounter++;
                }
            }
        }

        if (counterM > counterV)
        {
            Console.WriteLine("M {0}", counterM - counterV);
        }
        if (counterM < counterV)
        {
            Console.WriteLine("V {0}", counterV - counterM);
        }
        if (counterM == counterV)
        {
            Console.WriteLine("No {0}", counterV + counterM);
        }
    }
}


