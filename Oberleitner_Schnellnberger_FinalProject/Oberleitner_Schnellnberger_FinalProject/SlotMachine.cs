using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class SlotMachine
    {
        public static bool SlotGame(Person actualPlayer)
        {
            #region values
            string[] threeCharCard = new string[3];
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            threeCharCard[0] = "\x2663";
            threeCharCard[1] = "\x2665";
            threeCharCard[2] = "\x2666";
            List<int> list = new List<int>();
            bool userWin;
           
            #endregion

            Random random = new Random();
            list.Clear();

            for (int i = 0; i <= 2; i++)
            {
                int value = random.Next(2);
                list.Add(value);
            }
            int[] randomValues = list.ToArray();

            #region CW
            Console.WriteLine("______________________________");
            Console.WriteLine("------------------------------");

            foreach (var item in randomValues)
            {
                Console.Write(threeCharCard[item]);
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("______________________________");
            #endregion

            #region WinOrLoose
            if (randomValues[0] == randomValues[1] && randomValues[1] == randomValues[2])
            {
                userWin = true;
            }
            else
            {
                userWin=false;
            }
            return userWin;

            #endregion

            #region Output Unicode Caracters
            //Console.OutputEncoding = System.Text.Encoding.Unicode;
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("\x2660"); // Pik
            //Console.WriteLine("\x2663"); // Kreuz
            //Console.WriteLine("\x2665"); // Herz
            //Console.WriteLine("\x2666"); // Karo
            //Console.WriteLine("\x24EA"); // Eingekreiste 0
            //Console.WriteLine("\x2460"); // 1
            //Console.WriteLine("\x2461"); // 2
            //Console.WriteLine("\x2462"); // 3
            //Console.WriteLine("\x2463"); // 4
            //Console.WriteLine("\x2464"); // 5
            //Console.WriteLine("\x2465"); // 6
            //Console.WriteLine("\x2466"); // 7
            //Console.WriteLine("\x2467"); // 8
            //Console.WriteLine("\x2468"); // 9
            //Console.WriteLine("\x2469"); // 10
            //Console.WriteLine("\x246A"); // 11
            //Console.WriteLine("\x246B"); // 12
            //Console.WriteLine("\x246C"); // 13
            //Console.OutputEncoding = System.Text.Encoding.Unicode;
            //Console.ReadKey();
            #endregion



        }
    }
}
