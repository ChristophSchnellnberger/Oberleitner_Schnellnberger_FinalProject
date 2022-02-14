using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            threeCharCard[2] = "\x24EA";
            int[] randomValues=new int[3];
            Random random = new Random();
            list.Clear();

            for (int i = 0; i < randomValues.Length; i++)
            {
                int value = random.Next(2);
                if (list.Contains(value))
                {
                    continue;
                    i--;
                }
                else
                {
                    list.Add(value);
                }
            }
            randomValues = list.ToArray();


            return userWin;
        }

    }
}
