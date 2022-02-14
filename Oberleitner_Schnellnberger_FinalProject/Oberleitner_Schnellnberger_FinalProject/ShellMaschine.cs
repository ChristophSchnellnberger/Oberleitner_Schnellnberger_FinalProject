using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class ShellMaschine
    {
        public static bool ShellGame(Person actualPlayer)
        {
            bool userWin = false;
            List<int> list = new List<int>();
            string[] threeCharCard = new string[3];
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            threeCharCard[0] = "\x2666";
            threeCharCard[1] = "\x2666";
            threeCharCard[2] = "\x2665";
            int[] randomValues=new int[3];
            Random random = new Random();
            int choosenValue;
            int k = 3;
            bool conversionSuccessfull;
            for (int i = 0; i < 10; i++)
            {
                list.Clear();
                for (int j = 0; j < randomValues.Length; j++)
                {
                    int value = random.Next(3);
                    if (list.Contains(value))
                    {
                        j--;
                        continue;
                    }
                    else
                    {
                        list.Add(value);
                    }
                }
                randomValues = list.ToArray();
                k = 3;
                Console.Clear();
                foreach (var item in randomValues)
                {
                    Console.SetCursorPosition((Console.WindowWidth - k) / 2, Console.CursorTop);
                    Console.Write(threeCharCard[item]);
                    k=k-2;
                }
                Thread.Sleep(500);
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - 3) / 2, Console.CursorTop);
                Console.Write("\x2666" + "\x2666" + "\x2666");
            }
            Console.WriteLine();
            do
            {
                Console.WriteLine("At which kind of place do you think is the heart? (0, 1 or 2)");
                conversionSuccessfull = int.TryParse(Console.ReadLine(), out choosenValue);
                if (choosenValue >= 0 && choosenValue <= 2)
                {
                    conversionSuccessfull = true;
                }
                else
                {
                    conversionSuccessfull = false;
                }
            } while (!conversionSuccessfull);
           if (2 == randomValues[choosenValue])
            {
                userWin = true;
            }
           else
            {
                userWin = false;
            }
            Console.WriteLine("The result was: ");
            k = 3;
            foreach (var item in randomValues)
            {
                Console.SetCursorPosition((Console.WindowWidth - k) / 2, Console.CursorTop);
                Console.Write(threeCharCard[item]);
                k = k - 2;
            }
            Console.WriteLine();
            Console.WriteLine("Please press enter for futher actions!");
            Console.ReadKey();
            Console.Clear();
            return userWin;
        }

    }
}
