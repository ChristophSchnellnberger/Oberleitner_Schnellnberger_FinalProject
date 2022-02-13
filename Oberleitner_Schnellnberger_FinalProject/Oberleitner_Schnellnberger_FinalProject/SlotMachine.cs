using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class SlotMachine
    {
        private double InsertOfUser { get; set; }

        public static void PlayGame(Bank user, Bank casino)
        {
            Console.WriteLine("Welcome to the SlotMachine");
            Console.WriteLine("Please type \"P\" to confirm");
            Console.WriteLine("Please type \"X\" to exit");
            Random randomGenerator = new Random();
            string inputUser=Console.ReadLine().ToLower();
            bool validInputMoney = false;
            int firstRandom;
            int secondRandom;
            int thirdRandom;

            while (inputUser != "x")
            {
                while (validInputMoney == false)
                {
                    Console.WriteLine("How much money do you want to set (Format: 00.00) in §");
                    string userMoneySet = Console.ReadLine();
                    validInputMoney = int.TryParse(userMoneySet, out int InsertOfUser);
                }

                firstRandom = randomGenerator.Next(1, 3);
                secondRandom = randomGenerator.Next(1, 3);
                thirdRandom = randomGenerator.Next(1, 3);

                //Symbole erzeugen 
                //Symbole vergleichen







            }
            #region Output Unicode Caracters
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\x2660"); // Pik
            Console.WriteLine("\x2663"); // Kreuz
            Console.WriteLine("\x2665"); // Herz
            Console.WriteLine("\x2666"); // Karo
            Console.WriteLine("\x24EA"); // Eingekreiste 0
            Console.WriteLine("\x2460"); // 1
            Console.WriteLine("\x2461"); // 2
            Console.WriteLine("\x2462"); // 3
            Console.WriteLine("\x2463"); // 4
            Console.WriteLine("\x2464"); // 5
            Console.WriteLine("\x2465"); // 6
            Console.WriteLine("\x2466"); // 7
            Console.WriteLine("\x2467"); // 8
            Console.WriteLine("\x2468"); // 9
            Console.WriteLine("\x2469"); // 10
            Console.WriteLine("\x246A"); // 11
            Console.WriteLine("\x246B"); // 12
            Console.WriteLine("\x246C"); // 13
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ReadKey();
            #endregion


        }
       


        //member 
        //Balance übergeben in die klasse
        //Einarmiger Bantit
        //Ask for input 
        //Play gmae
        //win or lose
        //do you you want to play again
        //Am schluss erst ins casino




    }
}
