﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class Bank
    {
        #region private members
        //Kontostand=balance!
        private double _balance;
        #endregion

        #region public properties
        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                //Check MinMax
                bool correctInput = CheckValidData(value);
                if (correctInput == true)
                {
                    _balance = value;
                }
                else
                {
                    int error = 15;
                    Program.PrintErrorMessage(error);
                }
            }
        }
        #endregion

        #region constructor
        public Bank (double balance)
        {
            Balance=balance;
        }

        public Bank()
            //Default Constructor (Welcome Bonus 10€)
        {
            Balance = 10;
        }
        #endregion

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

        public static void ChargeBalance(Bank bank, double inputData)
        {
            if(CheckValidData(inputData)==true)
            {
                bank.Balance = bank.Balance + inputData;
            }
            else
            {
                int error = 15;
                Program.PrintErrorMessage(error);
            }


        }

        public static void ReduceBalance(Bank bank, double inputData)
        {
            if (CheckValidData(inputData) == true)
            {
                bank.Balance = bank.Balance - inputData;
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