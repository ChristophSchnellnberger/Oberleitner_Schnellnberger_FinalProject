using System;
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
        private double _balancePlayer;
        private double _balanceCasino;
        #endregion

        #region public properties
        public double BalancePlayer
        {
            get
            {
                return _balancePlayer;
            }
            set
            {
                //Check MinMax
                bool correctInput = CheckValidData(value);
                if (correctInput == true)
                {
                    _balancePlayer = value;
                }
                else
                {
                    int error = 15;
                    Program.PrintErrorMessage(error);
                }
            }
        }

        public double BalanceCasino
        {
            get
            {
                return _balanceCasino;
            }
            set
            {
                //Check MinMax
                bool correctInput = CheckValidData(value);
                if (correctInput == true)
                {
                    _balanceCasino = value;
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
        public Bank (int balancePlayer, int balanceBank)
        {
            _balancePlayer = balancePlayer;
            _balanceCasino = balanceBank;
        }

        public Bank()
            //Default Constructor (Welcome Bonus 10€ for Player)
        {
            _balanceCasino = 100;
            _balancePlayer = 10;
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

        public static void ChargeBankBalance(double inputData)
        {
            if(CheckValidData(inputData)==true)
            {
                

            }
            else
            {
                int error = 15;
                Program.PrintErrorMessage(error);
            }


        }

        public static void ReduceBankBalance(double inputData)
        {
            if (CheckValidData(inputData) == true)
            {

            }
            else
            {
                int error = 15;
                Program.PrintErrorMessage(error);
            }
        }

        public static void ChargePlayerBalance(double inputData)
        {
            if (CheckValidData(inputData) == true)
            {

            }
            else
            {
                int error = 15;
                Program.PrintErrorMessage(error);
            }

        }

        public static void ReducePlayerBalance(double inputData)
        {
            if (CheckValidData(inputData) == true)
            {

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
