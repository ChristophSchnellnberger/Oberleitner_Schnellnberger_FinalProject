using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class Casino
    {

        public static void NewMain()
        {
            Bank casino = new Bank();
            Bank.ChargeBalance(casino, 1);

            Bank user = new Bank();
            Bank.ChargeBalance(user, 2);
        }
    }
}
