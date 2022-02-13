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
            string filePathCasino = "CasinoDatas.csv";
            char seperator = ';';
            #endregion

            #region WelcomeGraphics
            //#region WelcomeGraphics
            //do
            //{
            //    ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            //    string welcome = "Welcome to the world of gaming";
            //    string enjoy = "Lean back and enjoy the welcome graphics";
            //    string enter = "Press enter to get to main menu";
            //    for (int i = 0; i < 3; i++)
            //    {
            //        foreach (var colour in colors)
            //        {
            //            Console.Clear();
            //            Console.ForegroundColor = colour;
            //            Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
            //            Console.WriteLine(welcome);
            //            Console.WriteLine();
            //            Console.SetCursorPosition((Console.WindowWidth - enjoy.Length) / 2, Console.CursorTop);
            //            Console.WriteLine(enjoy);
            //            Thread.Sleep(20);
            //        }
            //    }               
            //    Console.WriteLine();
            //    Console.ForegroundColor = ConsoleColor.Magenta;
            //    Console.SetCursorPosition((Console.WindowWidth - enter.Length) / 2, Console.CursorTop);
            //    Console.WriteLine(enter);
            //    Console.ResetColor();
            //    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            //    {
            //        conversionSuccessful = false;
            //        Console.Clear();
            //    }
            //} while (conversionSuccessful);
            //#endregion

            #endregion

            #region Call Methods
            Person[] allPersonsfromCsv = ProcessUserDatas.ReadPersonsFromCsv(filePathPerson, seperator);
            MainMenue(filePathPerson, allPersonsfromCsv, seperator);
            #endregion
        }
        private static void MainMenue(string filePath, Person[] allUsers, char seperator)
        {
            bool conversionSuccessful = true;
            int userinput = 0;

            Person actualPlayer = UserLoginOrRegister(filePath, allUsers, seperator);
            GamesAccountCredit(actualPlayer,allUsers);

            #region Games
            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose the game you want to play");
                Console.WriteLine();
                Console.WriteLine("Press: \n \"1\" Slot machine \n \"2\" Shell game \"3\" BlackJack");
                Console.WriteLine();

                userinput = CheckDatasFromMainMenue();
                switch (userinput)
                {
                    case 1:
                        {
                            //Slotmachine starten
                            break;
                        }
                    case 2:
                        {
                            //Shellgame starten
                            break;
                        }
                    case 3:
                        {
                            //BlackJack starten
                            break;
                        }
                    default:
                        {
                            conversionSuccessful = false;
                            break;
                        }
                }
            } while (!conversionSuccessful);

            Console.Clear();
            #endregion
        }
        private static Person UserLoginOrRegister(string filePath, Person[] allUsers, char seperator)
        {
            bool conversionSuccessful = true;
            int userinput = 0;
            Person loggedinPerson = new Person();

            #region Login/Register
            do
            {
                string loginfile = "actualPlayer.csv";

                if (File.Exists(loginfile))
                {
                    File.Delete(loginfile);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press: \n \"1\" for Login \n \"2\" for Register\n \"3\" to play as a guest");
                Console.WriteLine();

                userinput = CheckDatasFromMainMenue();

                switch (userinput)
                {
                    case 1:
                        {
                            int arrayPlace = SearchPerson(allUsers);
                            loggedinPerson = allUsers[arrayPlace];
                            do
                            {
                                bool loginSucessfull = false;
                                loginSucessfull = Login(loggedinPerson);
                                if (loginSucessfull == false)
                                {
                                    loginSucessfull = CancelInformation();
                                    if (loginSucessfull == true)
                                    {
                                        conversionSuccessful = false;
                                        break;
                                    }
                                }
                            }
                            while (false);
                            ProcessUserDatas.StreamWriterExcelRegisteredPerson(loginfile, loggedinPerson, seperator);
                            break;
                        }
                    case 2:
                        {
                            loggedinPerson = AskUserForInput(filePath, seperator);
                            ProcessUserDatas.StreamWriterExcelRegisteredPerson(loginfile, loggedinPerson, seperator);
                            conversionSuccessful = true;
                            break;
                        }
                    case 3:
                        {
                            Person musterMann = new Person("fistName", "surname", DateTime.MinValue, Person.Gender.male, "Musterstrasse", 01, 4811, "Musterstadt", "Pas§word123", 0);
                            ProcessUserDatas.StreamWriterExcelRegisteredPerson("actualPlayer.csv", loggedinPerson, seperator);
                            ProcessUserDatas.StreamWriterExcelRegisteredPerson(filePath, loggedinPerson, seperator);
                            break;

                        }

                    default:
                        {
                            conversionSuccessful = false;
                            break;
                        }
                }
            } while (!conversionSuccessful);

            Console.Clear();
            #endregion
            return loggedinPerson;
        }
        private static void GamesAccountCredit(Person actualPlayer,Person[] allUsers)
        {
            int userinput;
            bool conversionSuccessful = false;

            #region Games/Account/Credit
            do
            {
                Console.WriteLine();
                Console.WriteLine("Press: \n \"1\" Play games \n \"2\" Show your Account \n \"3\" Top out your credit \n \"4\" Pay out your credit");
                Console.WriteLine();

                userinput = CheckDatasFromMainMenue();

                switch (userinput)
                {
                    case 1:
                        {
                            SlotMachine.PlayGame(actualPlayer);
                            break;
                        }
                    case 2:
                        {
                            PrintPerson(actualPlayer);

                            break;
                        }
                    case 3:
                        {
                            double inputData;
                            do
                            {
                                Console.Write("Please type in how much money you want to load up: ");
                                bool conSuc = double.TryParse(Console.ReadLine(),out inputData);
                                if (!conSuc)
                                {
                                    Console.WriteLine("Please enter a valid integer >0 and <100");
                                }
                            }
                            while (false);
                           
                            Bank.ChargeBalance(actualPlayer,inputData);
                            break;
                        }
                    case 4:
                        {
                            double inputData;
                            do
                            {
                                Console.Write("Please type in how much money you want to load out: ");
                                bool conSuc = double.TryParse(Console.ReadLine(), out inputData);
                                if (!conSuc)
                                {
                                    Console.WriteLine("Please enter a valid integer >0 and <100");
                                }
                            }
                            while (false);

                            Bank.ReduceBalance(actualPlayer, inputData);

                            break;
                        }
                    default:
                        {
                            conversionSuccessful = false;
                            break;
                        }
                }
            } while (!conversionSuccessful);

            Console.Clear();
            #endregion

        }
        private static bool CancelInformation()
        {
            string userInput;
            do
            {
                Console.WriteLine("Do you want to try again?");
                Console.WriteLine("If yes, type \"y\" ; if not type \"n\" ");
                userInput = Console.ReadLine();
                if (userInput.ToLower().Trim() == "y")
                {
                    return false;
                }
                if (userInput.ToLower().Trim() == "n")
                {
                    return true;
                }
            }
            while (userInput != "n" && userInput != "y");
            return false;
        }
        private static bool Login(Person user)
        {
            int counter = 3;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("You can try it " + counter + " times");
                Console.Write("Please enter your password: ");
                string password = Console.ReadLine();
                if (password == user.Password)
                {
                    return true;
                }
                counter--;
            }
            return false;

        }
        private static int CheckDatasFromMainMenue()
        {
            int choosennumber = 0;

            try
            {
                string userinput = Console.ReadLine();
                userinput = userinput.ToLower();
                userinput = userinput.Trim();
                bool conversionSuccessful = int.TryParse(userinput, out choosennumber);
                if (!conversionSuccessful)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your input is not a number \n \nPlease try again");
                    Console.ResetColor();
                    choosennumber = -1;
                }
            }
            #region catches
            catch (Exception ex)
            {
                int error = GetErrorCodeFromExeption(ex);
                Program.PrintErrorMessage(error);
            }

            #endregion

            return choosennumber;
        }
        private static Person AskUserForInput(string filePath, char seperator)
        {
            #region values
            int error = 0;
            string surname = default;
            string firstName = default;
            DateTime birthdate = default;
            string street = default;
            int houseNumber = default;
            int postalCode = default;
            string cityName = default;
            string password = default;
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
                        surname = firstCharToUpper(surname);
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
                        firstName = firstCharToUpper(firstName);
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
                        street = firstCharToUpper(street);
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
                        Console.Write("Please enter your postal code ");
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
                        cityName = firstCharToUpper(cityName);
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
        public static string firstCharToUpper(string value)
        {
            int error = 0;
            string first = value;
            try
            {
                char firstChar = value.First();
                first = firstChar.ToString();
                first = first.ToUpper();
                firstChar = first.First();
                char[] array = new char[value.Length];
                array = value.ToCharArray();
                array[0] = firstChar;
                value = String.Concat(array);
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

            return value;
        }
        public static int SearchPerson(Person[] allPersons)
        {
            int error = 0;
            int placeInArray = 0;
            do
            {
                try
                {
                    Console.WriteLine("Please type in your first Name!");
                    string inputFirstName = Console.ReadLine();
                    inputFirstName = firstCharToUpper(inputFirstName);
                    Console.WriteLine("Please type in your surname");
                    string inputSurname = Console.ReadLine();
                    inputSurname = firstCharToUpper(inputSurname);

                    placeInArray = NumberOfPersonInArray(inputFirstName, inputSurname, allPersons);
                    if (placeInArray == -1)
                    {
                        Console.WriteLine("This name cannot be found");
                        Console.WriteLine("Please try again or register a new person");
                    }
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
            }

            while (placeInArray == -1);
            return placeInArray;
        }
        public static int NumberOfPersonInArray(string personToLookForFirstName, string personToLookForSurname, Person[] allUser)
        {
            int placeOfPerson;

            for (placeOfPerson = 0; placeOfPerson < allUser.Length; placeOfPerson++)
            {
                if (allUser[placeOfPerson] != null)
                {
                    Person currentPerson = allUser[placeOfPerson];
                    if (personToLookForFirstName == currentPerson.FirstName && personToLookForSurname == currentPerson.Surname)
                    {
                        return placeOfPerson;
                    }


                }
            }
            placeOfPerson = -1;

            return placeOfPerson;
        }
        public static void PrintPerson(Person actualUser)
        {

            {
                Console.WriteLine();
                Console.WriteLine("Here is the Data of the Person you look for");
                Console.WriteLine();
                Console.WriteLine(actualUser.FirstName);
                Console.WriteLine(actualUser.Surname);
                Console.WriteLine(actualUser.DateOfBirth);
                Console.WriteLine(actualUser.PersonGender);
                Console.WriteLine(actualUser.Street);
                Console.WriteLine(actualUser.HouseNumber);
                Console.WriteLine(actualUser.PostalCode);
                Console.WriteLine(actualUser.CityName);
                if (actualUser.Credit < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else { Console.ForegroundColor = ConsoleColor.Red; }

                Console.WriteLine(actualUser.Credit);

                Console.ResetColor();
            }



        }

    }
}
