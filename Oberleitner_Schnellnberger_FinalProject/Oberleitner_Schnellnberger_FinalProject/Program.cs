using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Values
            string filePathPerson = "LoginDatas.csv";
            string loginfile = "actualPlayer.csv";
            bool conversionSuccessful = false;
            char seperator = ';';
            #endregion

            #region Call Methods
            WelcomeGraphics();
            Person[] allPersonsfromCsv = ProcessUserDatas.ReadPersonsFromCsv(filePathPerson, seperator);
            MainMenue(filePathPerson, allPersonsfromCsv, seperator, loginfile);
            #endregion
        }
        private static void WelcomeGraphics()
        {
            bool conversionSuccessful = false;

            #region WelcomeGraphics
            do
            {
                ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
                string welcome = "Welcome to the world of gaming";
                string enjoy = "Lean back and enjoy the welcome graphics";
                string enter = "Press enter to get to main menu";
                for (int i = 0; i < 3; i++)
                {
                    foreach (var colour in colors)
                    {
                        Console.Clear();
                        Console.ForegroundColor = colour;
                        Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcome);
                        Console.WriteLine();
                        Console.SetCursorPosition((Console.WindowWidth - enjoy.Length) / 2, Console.CursorTop);
                        Console.WriteLine(enjoy);
                        Thread.Sleep(20);
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition((Console.WindowWidth - enter.Length) / 2, Console.CursorTop);
                Console.WriteLine(enter);
                Console.ResetColor();
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    conversionSuccessful = false;
                    Console.Clear();
                }
            } while (conversionSuccessful);
            #endregion

        }
        private static void MainMenue(string filePathPerson, Person[] allUsers, char seperator, string filePathUser)
        {
            Person actualPlayer = UserLoginOrRegister(filePathPerson, allUsers, seperator, filePathUser);

            ProcessUserDatas.GamesAccountCredit(actualPlayer, allUsers, filePathPerson, filePathUser);
        }
        private static Person UserLoginOrRegister(string filePathPerson, Person[] allUsers, char seperator, string filePathUser)
        {
            bool conversionSuccessful = true;
            int userinput = 0;
            Person loggedinPerson = new Person();

            #region Login/Register
            do
            {
                if (File.Exists(filePathUser))
                {
                    File.Delete(filePathUser);
                }

                #region User interaction
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press: \n \"1\" for Login \n \"2\" for Register\n \"3\" to play as a guest");
                Console.WriteLine();
                string choosenValue = Console.ReadLine();
                choosenValue = choosenValue.ToLower();
                choosenValue = choosenValue.Trim();
                #endregion

                userinput = CheckDatasFromMainMenue(choosenValue);

                switch (userinput)
                {
                    #region Case Login
                    case 1:
                        {
                            Console.Clear();
                            int arrayPlace = ProcessUserDatas.SearchPerson(allUsers);
                            if (arrayPlace == -1)
                            {
                                conversionSuccessful = false;
                                break;
                            }
                            loggedinPerson = allUsers[arrayPlace];
                            
                            do
                            {                              
                                bool loginSucessfull = ProcessUserDatas.Login(loggedinPerson);

                                if (loginSucessfull == false)
                                {
                                    loginSucessfull = TryAgain();

                                    if (loginSucessfull ==true)
                                    {
                                        Console.WriteLine("Congratulation, you are loged in. \n Press enter to get further");
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                            }
                            while (false);

                            ProcessUserDatas.StreamWriterExcelRegisteredPerson(filePathUser, loggedinPerson, seperator);
                            break;
                        }
                    #endregion

                    #region Case Register
                    case 2:
                        {
                            Console.Clear();
                            loggedinPerson = AskUserForInput(filePathPerson, seperator);
                            ProcessUserDatas.StreamWriterExcelRegisteredPerson(filePathUser, loggedinPerson, seperator);
                            conversionSuccessful = true;
                            break;
                        }
                    #endregion

                    #region Case Register as a guest
                    case 3:
                        {
                            Console.Clear();
                            Person musterMann = new Person("fistName", "surname", DateTime.MinValue, Person.Gender.male, "Musterstrasse", 01, 4811, "Musterstadt", "Pas§word123", 0);
                            ProcessUserDatas.StreamWriterExcelRegisteredPerson(filePathUser, loggedinPerson, seperator);
                            ProcessUserDatas.StreamWriterExcelRegisteredPerson(filePathPerson, loggedinPerson, seperator);
                            break;

                        }
                    #endregion

                    default:
                        {
                            conversionSuccessful = false;
                            break;
                        }
                }
            }
            while (!conversionSuccessful);

            Console.Clear();
            #endregion

            return loggedinPerson;
        }
        private static bool TryAgain()
        {
            string userInput;
            do
            {
                Console.WriteLine("Do you want to try again?");
                Console.WriteLine("If yes, type \"y\" ; if not type \"n\" ");
                userInput = Console.ReadLine();

                if (userInput.ToLower().Trim() == "y")
                {
                    return true;
                }
                if (userInput.ToLower().Trim() == "n")
                {
                    return false;
                }
                Console.Clear();
            }
            while (userInput != "n" && userInput != "y");

            return false;
        }
        public static int CheckDatasFromMainMenue(string userinput)
        {
            int choosennumber = 0;

            bool conversionSuccessful = int.TryParse(userinput, out choosennumber);
            if (!conversionSuccessful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your input is not a number \n \nPlease try again");
                Console.ResetColor();
                choosennumber = -1;
            }

            return choosennumber;
        }
        private static Person AskUserForInput(string filePath, char seperator)
        {
            #region values
            int error = 0;
            string surname;
            string firstName;
            DateTime birthdate = default;
            string street;
            int houseNumber;
            int postalCode;
            string cityName;
            string password;
            Person.Gender gender = 0;
            bool createNewUser;
            bool conversionSuccessful = false;
            Person newUser = null;
            #endregion

            try
            {
                do
                {
                    #region Surname
                    do
                    {
                        Console.Write("Please enter your surname: ");
                        surname = Console.ReadLine();
                        Console.WriteLine();
                        surname = ProcessUserDatas.firstCharToUpper(surname);
                        conversionSuccessful = Person.CheckName(surname);
                    }
                    while (!conversionSuccessful);

                    #endregion

                    #region firstName
                    do
                    {
                        Console.Write("Please enter your first name: ");
                        firstName = Console.ReadLine();
                        Console.WriteLine();
                        firstName = ProcessUserDatas.firstCharToUpper(firstName);
                        conversionSuccessful = Person.CheckName(firstName);
                    }
                    while (!conversionSuccessful);

                    #endregion

                    #region Birthdate
                    int year = 0;
                    int month = 0;
                    int day = 0;
                    string inputDay;
                    string inputMonth;
                    string inputYear;

                    do
                    {
                        Console.WriteLine("Please enter your birthday in steps");

                        #region enterYear
                        do
                        {
                            Console.Write("Please enter the year (Form: yyyy): ");
                            inputYear = Console.ReadLine();
                            Console.WriteLine();
                            conversionSuccessful = Person.CheckBirthdate(inputYear.ToString(), DateTime.Now.Year - 120, DateTime.Now.Year - 18);

                            if (conversionSuccessful)
                            {
                                int.TryParse(inputYear, out year);
                            }
                        }
                        while (!conversionSuccessful);
                        #endregion

                        #region enterMonth
                        do
                        {
                            Console.Write("Please enter the month (Form: mm): ");
                            inputMonth = Console.ReadLine();
                            Console.WriteLine();
                            conversionSuccessful = Person.CheckBirthdate(inputMonth.ToString(), DateTime.MinValue.Month, DateTime.MaxValue.Month);

                            if (conversionSuccessful)
                            {
                                int.TryParse(inputMonth, out month);
                            }
                        }
                        while (!conversionSuccessful);
                        #endregion

                        #region enterDay
                        do
                        {
                            Console.Write("Please enter the day (Form: dd): ");
                            inputDay = Console.ReadLine();
                            Console.WriteLine();
                            conversionSuccessful = Person.CheckBirthdate(inputDay.ToString(), DateTime.MinValue.Day, DateTime.MaxValue.Day);

                            if (conversionSuccessful)
                            {
                                int.TryParse(inputDay, out day);
                            }
                        }
                        while (!conversionSuccessful);
                        #endregion

                        try
                        {
                            birthdate = new DateTime(year, month, day);
                        }
                        catch
                        {
                            conversionSuccessful = false;
                            Console.WriteLine("Sorry, but the conversion to a correct format was mistaken");
                        }
                    }
                    while (!conversionSuccessful);
                    #endregion

                    #region Gender
                    do
                    {
                        Console.WriteLine("Please choose your gender from the following choices:");
                        Console.WriteLine("1 = m, 2 = w, 3 = d, 4 = nA");
                        string inputGender = Console.ReadLine();
                        Console.WriteLine();
                        conversionSuccessful = Enum.TryParse(inputGender, out gender);
                    }
                    while (!conversionSuccessful);
                    #endregion

                    #region Street
                    do
                    {
                        Console.Write("Please enter your streetname: ");
                        street = Console.ReadLine();
                        Console.WriteLine();
                        street = ProcessUserDatas.firstCharToUpper(street);
                        conversionSuccessful = Person.CheckStreet(street);
                    }
                    while (!conversionSuccessful);

                    #endregion

                    #region House Number
                    do
                    {
                        Console.Write("Please enter your house number: ");
                        string houseNumberInput = Console.ReadLine();
                        Console.WriteLine();
                        conversionSuccessful = int.TryParse(houseNumberInput, out houseNumber);
                        if (!conversionSuccessful)
                        {
                            continue;
                        }
                        conversionSuccessful = Person.CheckHouseNumber(houseNumberInput);
                    }
                    while (!conversionSuccessful);

                    #endregion

                    #region Postal Code
                    do
                    {
                        Console.Write("Please enter your postal code: ");
                        string postalCodeInput = Console.ReadLine();
                        Console.WriteLine();
                        conversionSuccessful = int.TryParse(postalCodeInput, out postalCode);
                        if (!conversionSuccessful)
                        {
                            continue;
                        }
                        conversionSuccessful = Person.CheckPostalCode(postalCodeInput);
                    }
                    while (!conversionSuccessful);

                    #endregion

                    #region City Name
                    do
                    {
                        Console.Write("Please enter your city name: ");
                        cityName = Console.ReadLine();
                        Console.WriteLine();
                        cityName = ProcessUserDatas.firstCharToUpper(cityName);
                        conversionSuccessful = Person.CheckCityName(cityName);
                    }
                    while (!conversionSuccessful);

                    #endregion

                    #region Password
                    do
                    {
                        Console.Write("Please enter your password: ");
                        Console.WriteLine();
                        Console.WriteLine("Your password must comply with the following conditions: \n 1) At least 8 chars long \n 2) One char to upper \n 3) One char to lower \n 4) One integer  ");
                        password = Console.ReadLine();
                        Console.WriteLine();

                        conversionSuccessful = Person.CheckPassword(password);
                    }
                    while (!conversionSuccessful);

                    #endregion

                    #region Create User

                    try
                    {
                        newUser = new Person(firstName, surname, birthdate, gender, street, houseNumber, postalCode, cityName, password, 0);
                        createNewUser = true;
                        ProcessUserDatas.StreamWriterExcelRegisteredPerson(filePath, newUser, seperator);
                    }
                    catch
                    {
                        createNewUser = false;
                        Console.WriteLine("Sorry there was something wrong, please try again!");
                        newUser = new Person();
                    }

                    #endregion
                }
                while (!createNewUser);
            }
            #region catches
            catch (ArgumentOutOfRangeException)
            {
                error = 15;
            }
            catch (ArgumentNullException)
            {
                error = 1;
            }
            catch (ArgumentException)
            {
                error = 2;
            }
            catch (OutOfMemoryException)
            {
                error = 14;
            }
            catch (FormatException)
            {
                error = 9;
            }
            catch (OverflowException)
            {
                error = 10;
            }
            catch (IndexOutOfRangeException)
            {
                error = 11;
            }
            catch (NotSupportedException)
            {
                error = 12;
            }
            catch (DirectoryNotFoundException)
            {
                error = 3;
            }
            catch (PathTooLongException)
            {
                error = 4;
            }
            catch (UnauthorizedAccessException)
            {
                error = 5;
            }
            catch (System.Security.SecurityException)
            {
                error = 13;
            }
            catch (FileNotFoundException)
            {
                error = 6;
            }
            catch (IOException)
            {
                error = 7;
            }
            catch (Exception)
            {
                error = 8;
            }

            Program.Exeptions(error);
            #endregion

            return newUser;

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
        public static void Exeptions(int errorCode)
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
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
        }
    }
}
