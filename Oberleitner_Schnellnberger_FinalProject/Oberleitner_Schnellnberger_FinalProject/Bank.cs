using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class Bank
    {
        #region methods
        //1. Kredit aufladen/abheben
        //2. Zwischenspeicher
        //3. Gewinne/Verluste/Abzug KeSt
        private static bool CheckValidData(double inputData)
        {
            bool validInput = false;
            int counterVality = 2;
            int counter = 0;
            if (inputData > 0)
            {
                counter++;
            }
            if (inputData < 1000)
            {
                counter++;
            }
            if (counterVality == counter)
            {
                validInput = true;
            }
            return validInput;
        }
        public static void ChargeBalance(Person bank, double inputData)
        {
            if(CheckValidData(inputData)==true)
            {
                if(inputData > 0)
                {
                    bank.Credit = bank.Credit + inputData;
                }
              
            }
            else
            {
                int error = 15;
                Program.PrintErrorMessage(error);
            }
        }
        public static void ReduceBalance(Person bank, double inputData)
        {
            if (CheckValidData(inputData) == true)
            {
                if(bank.Credit >= inputData)
                {
                    bank.Credit = bank.Credit - inputData;
                }               
            }
            else
            {
                int error = 15;
                Program.PrintErrorMessage(error);
            }
        }
        #endregion

    }
}
