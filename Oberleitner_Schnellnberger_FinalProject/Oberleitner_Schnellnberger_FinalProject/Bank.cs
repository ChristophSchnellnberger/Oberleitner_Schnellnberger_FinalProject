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
                //Check correct input!!
                //kein negativer wert, max. werte, ect...
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
                //Check correct input!!
                //kein negativer wert, max. werte, ect...
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
        #endregion

    }
}
