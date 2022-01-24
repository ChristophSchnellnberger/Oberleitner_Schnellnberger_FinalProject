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
            string inputUser=Console.ReadLine().ToLower();
            bool validInput = false;
            while (inputUser != "x")
            {
                while (validInput == false)
                {
                    Console.WriteLine("How much money do you want to set (Format: 00.00§)");
                    string userMoneySet = Console.ReadLine();
                    validInput = int.TryParse(userMoneySet, out int InsertOfUser);
                }


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
