using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        private static void MainMenue()
        {

        }
        public static void PrintErrorMessage(int errorCode)
        {
            #region errorCodes
            if (errorCode != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, an exeption case has happened");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }

            if (errorCode == 1)
            {
                Console.WriteLine("The argument is null or empty");
            }
            if (errorCode == 2)
            {
                Console.WriteLine("The argument is invalid");
            }
            if (errorCode == 3)
            {
                Console.WriteLine("The path cannot be found");
            }
            if (errorCode == 4)
            {
                Console.WriteLine("The filepath is too long");
            }
            if (errorCode == 5)
            {
                Console.WriteLine("You are not authorized for this action");
            }
            if (errorCode == 6)
            {
                Console.WriteLine("The file cannot be found or is opened");
            }
            if (errorCode == 7)
            {
                Console.WriteLine("Unexpectet I/O exeption");
            }
            if (errorCode == 8)
            {
                Console.WriteLine("General exeption happened. Please contact your admin");
            }
            if (errorCode == 9)
            {
                Console.WriteLine("The Format cannot be parsed");
            }
            if (errorCode == 10)
            {
                Console.WriteLine("The value is overflowed");
            }
            if (errorCode == 11)
            {
                Console.WriteLine("The index off the array is out of the arrayrange");
            }
            if (errorCode == 12)
            {
                Console.WriteLine("The method is not supported");
            }
            if (errorCode == 13)
            {
                Console.WriteLine("The system exepted a security failure");
            }
            if (errorCode == 14)
            {
                Console.WriteLine("The system is out of memory. The programm cannt run further");
            }
            if (errorCode == 15)
            {
                Console.WriteLine("The argument is out of range");
            }
            if (errorCode == 16)
            {
                Console.WriteLine("Data interchange failed");
            }
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
        }
        private static int GetErrorCodeFromExeption(Exception exception)
        {            
            if (exception is ArgumentNullException)
            {
                return 1;
            }
            if (exception is ArgumentException)
            {
                return 2;
            }
            if (exception is IOException)
            {
                return 7;
            }
            if (exception is FormatException)
            {
                return 9;
            }
            
            if (exception is OverflowException)
            {
                return 10;
            }
            if (exception is OutOfMemoryException)
            {
                return 14;
            }
            if (exception is ArgumentOutOfRangeException)
            {
                return 15;
            }
            return -1;
        }

    }
}
