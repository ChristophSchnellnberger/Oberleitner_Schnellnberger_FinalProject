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
