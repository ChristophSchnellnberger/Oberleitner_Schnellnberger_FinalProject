using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class Casino
    {

        public static void Dealer(Person actualPlayer,string filePathPerson,string filePathUser, int choosenGame)
        {
            #region values
            string[] threeCharCard = new string[3];
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            threeCharCard[0] = "\x2663";
            threeCharCard[1] = "\x2665";
            threeCharCard[2] = "\x2666";
            string inputUser;
            List<int> list = new List<int>();
            double InsertOfUser = 0;
            bool validInputMoney = false;
            bool userWin;

            #endregion
            switch (choosenGame)
            {
                case (1):
                    {
                        break;
                    }
            }

                    
            do
            {
                Console.WriteLine("Welcome to the SlotMachine");
                Console.WriteLine("Please type \"P\" to confirm");
                Console.WriteLine("Please type \"X\" to exit");
                inputUser = Console.ReadLine().ToLower().Trim();
                Console.Clear();
                if (inputUser != "x" && inputUser != "p")
                {
                    Console.WriteLine("Please type in one of the letters.");
                    continue;
                }              
                if (inputUser == "x")
                {
                    break;
                }
                validInputMoney = false;

                while (validInputMoney == false)
                {                    
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("How much money do you want to set (Format: 00.00) in §");
                        string userMoneySet = Console.ReadLine();

                        validInputMoney = double.TryParse(userMoneySet, out InsertOfUser);
                    }
                    while (validInputMoney == false);

                    if (actualPlayer.Credit - InsertOfUser >= 0)
                    {
                        actualPlayer.Credit = actualPlayer.Credit - InsertOfUser;
                        userWin = SlotMachine.SlotGame(actualPlayer);

                        if (userWin==true)
                        {
                            actualPlayer.Credit = actualPlayer.Credit + (InsertOfUser * 2);
                            Console.WriteLine("Congratulation, you won!");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you lose the game!");
                        }
                        Console.WriteLine("Press enter");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry your credit is to low!");
                        Console.ReadKey();
                    }
                    
                }
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Your actual credit is: " + actualPlayer.Credit);
                Console.ReadKey();
            } 
            while (inputUser != "x");

            File.Delete(filePathUser);
            ProcessUserDatas.StreamWriterExcelRegisteredPerson(filePathUser, actualPlayer, ';');
            Person[] allPlayers = ProcessUserDatas.ReadPersonsFromCsv(filePathPerson, ';');
            int numberOfPersonInArray = Program.NumberOfPersonInArray(actualPlayer.FirstName, actualPlayer.Surname, allPlayers);
            
            
            allPlayers[numberOfPersonInArray].Credit = actualPlayer.Credit;
            ProcessUserDatas.StreamWriterExcelPerson(filePathPerson, allPlayers);
        }
    }
}
