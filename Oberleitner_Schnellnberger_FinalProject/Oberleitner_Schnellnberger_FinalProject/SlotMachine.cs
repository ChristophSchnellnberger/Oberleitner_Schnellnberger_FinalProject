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
        public static void PlayGame(Person actualPlayer)
        {
            string [] threeCharCard=new string[3];
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            threeCharCard[0] = "\x2663";
            threeCharCard[1] = "\x2665";
            threeCharCard[2] = "\x2666";
            string inputUser;
            List<int> list = new List<int>();
            double InsertOfUser=0;
            do
            {
                Console.WriteLine("Welcome to the SlotMachine");
                Console.WriteLine("Please type \"P\" to confirm");
                Console.WriteLine("Please type \"X\" to exit");
                inputUser = Console.ReadLine().ToLower();
                if(inputUser == "x")
                {
                    break;
                }
                Random random = new Random();
                bool validInputMoney = false;
                while (validInputMoney == false)
                {
                    Console.WriteLine("How much money do you want to set (Format: 00.00) in §");
                    string userMoneySet = Console.ReadLine();
                    do
                    {
                        validInputMoney = double.TryParse(userMoneySet, out InsertOfUser);
                    }
                    while (validInputMoney == false);
                    try
                    {
                        actualPlayer.Credit = actualPlayer.Credit - InsertOfUser;
                    }
                    catch
                    {
                        Console.WriteLine("Sorry your credit is to low!");
                        continue;
                    }
                }
                list.Clear();
                for (int i = 0; i <= 2; i++)
                {
                    int value = random.Next(2);
                    list.Add(value);
                }
                int[] randomValues = list.ToArray();

                Console.WriteLine("______________________________");
                Console.WriteLine("------------------------------");

                foreach (var item in randomValues)
                {
                    Console.Write(threeCharCard[item]);
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------");
                Console.WriteLine("______________________________");


                if (randomValues[0] == randomValues[1] && randomValues[1] == randomValues[2])
                {
                    actualPlayer.Credit = actualPlayer.Credit + (InsertOfUser * 2);
                    Console.WriteLine("Congratulation, you won!");
                }
                else
                {
                    Console.WriteLine("Sorry, you lose the game!");
                }
            }
            while (inputUser != "x");
            File.Delete("actualPlayer.csv");
            ProcessUserDatas.StreamWriterExcelRegisteredPerson("actualPlayer.csv", actualPlayer, ';');
            Person[] allPlayers = ProcessUserDatas.ReadPersonsFromCsv("LoginDatas.csv", ';');
            int numberOfPersonInArray=Program.NumberOfPersonInArray(actualPlayer.FirstName, actualPlayer.Surname, allPlayers);
            allPlayers[numberOfPersonInArray].Credit = actualPlayer.Credit;
            ProcessUserDatas.StreamWriterExcelPerson("LoginDatas.csv", allPlayers);


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
