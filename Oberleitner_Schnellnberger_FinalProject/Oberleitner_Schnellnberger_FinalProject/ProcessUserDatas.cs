using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    internal class ProcessUserDatas
    {
        public static Person[] ReadPersonsFromCsv(string csvString, char seperator)
        {
            int error = 0;
            Person readPerson = new Person();
            List<Person> readPersons = new List<Person>();
            int value = 0;
            try
            {
                using (StreamReader reader = new StreamReader(csvString))
                {
                    for (int i = value; i < 1; i++)
                    {
                        reader.ReadLine();
                    }

                    while (reader.Peek() != -1) 
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(seperator);

                        readPerson.FirstName = values[0];
                        readPerson.Surname = values[1];
                        readPerson.PersonGender = (Person.Gender)Enum.Parse(typeof(Person.Gender), values[2]);
                        readPerson.DateOfBirth = DateTime.Parse(values[3]);
                        readPerson.Street = values[4];
                        readPerson.HouseNumber = int.Parse(values[5]);
                        readPerson.PostalCode = int.Parse(values[6]);
                        readPerson.CityName = values[7];
                        readPerson.Password = values[8];
                        readPerson.Credit = double.Parse(values[9]);
                        readPersons.Add(readPerson);
                    }
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

            #region IF FILE ISNT AVAILABLE
            if (error == 6)
            {
                string firstLine = "first name" + seperator + "surname" + seperator + "gender" + seperator +
                                "date of birth" + seperator + "street" + seperator + "housenumber" +
                                seperator + "postal code" + seperator + "cityname" + seperator + "password" + seperator + "credit";

                File.WriteAllText(csvString, firstLine);
            }
            #endregion

            return readPersons.ToArray();
        }
        public static void StreamWriterExcelPerson(string filePath, Person[] allUser)
        {
            char seperator = ';';
            int error = 0;
            #region Streamwriter User
            try
            {
                #region IF FILE ISNT AVAILABLE
                if (File.Exists(filePath) == false)
                {
                    string firstLine = "first name" + seperator + "surname" + seperator + "gender" + seperator +
                                    "date of birth" + seperator + "street" + seperator + "housenumber" +
                                    seperator + "postal code" + seperator + "cityname" + seperator + "password" + seperator + "credit";

                    File.WriteAllText(filePath, firstLine);
                }
                #endregion

                File.AppendAllText(filePath, "\n");


                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var person in allUser)
                    {
                        if (person != null)
                        {
                            writer.Write(person.FirstName);
                            writer.Write(";");
                            writer.Write(person.Surname);
                            writer.Write(";");
                            writer.Write(person.PersonGender);
                            writer.Write(";");
                            writer.Write(person.DateOfBirth.Date.ToString());
                            writer.Write(";");
                            writer.Write(person.Street);
                            writer.Write(";");
                            writer.Write(person.HouseNumber.ToString());
                            writer.Write(";");
                            writer.Write(person.PostalCode.ToString());
                            writer.Write(";");
                            writer.Write(person.CityName);
                            writer.Write(";");
                            writer.Write(person.Password);
                            writer.Write(";");
                            writer.Write(person.Credit);
                            writer.WriteLine();
                            
                        }
                    }
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
            #endregion

            #endregion
        }
        public static void StreamWriterExcelRegisteredPerson(string filePath, Person newUser, char seperator)
        {
            int error = 0;
            #region Streamwriter User
            try
            {
                #region IF FILE ISNT AVAILABLE
                if (File.Exists(filePath) == false)
                {
                    string firstLine = "first name" + seperator + "surname" + seperator + "gender" + seperator +
                                    "date of birth" + seperator + "street" + seperator + "housenumber" +
                                    seperator + "postal code" + seperator + "cityname" + seperator + "password" + seperator + "credit";

                    File.WriteAllText(filePath, firstLine);
                }
                #endregion

                File.AppendAllText(filePath, "\n");

                string content = newUser.FirstName + seperator + newUser.Surname + seperator + newUser.PersonGender + seperator +
                             newUser.DateOfBirth.Date.ToString() + seperator + newUser.Street + seperator + newUser.HouseNumber.ToString() +
                             seperator + newUser.PostalCode.ToString() + seperator + newUser.CityName + seperator + newUser.Password+seperator+newUser.Credit;

                File.AppendAllText(filePath, content);
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
            #endregion


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
                    Console.Clear();
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
                        Console.ReadKey();
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

                #region color of text
                if (actualUser.Credit > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (actualUser.Credit == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else { Console.ForegroundColor = ConsoleColor.Red; }
                #endregion

                Console.WriteLine(actualUser.Credit);

                Console.ResetColor();
            }
        }
        public static void GamesAccountCredit(Person actualPlayer, Person[] allUsers, string filePathPerson, string filePathUser)
        {
            int userinput;
            bool conversionSuccessful = false;

            #region Games/Account/Credit
            do
            {
                Console.WriteLine();
                Console.WriteLine("Press: \n \"1\" Play games \n \"2\" Show your Account \n \"3\" Top up your credit \n \"4\" Pay out your credit");
                Console.WriteLine();
                string choosenValue = Console.ReadLine();
                choosenValue = choosenValue.ToLower();
                choosenValue = choosenValue.Trim();
                int value;
                userinput = Program.CheckDatasFromMainMenue(choosenValue);

                switch (userinput)
                {
                    case 1:
                        {
                            do
                            {
                                Console.WriteLine("Choose the gam you want to play: \n 1) Slotmachine \n2) Shellgame");
                                int.TryParse(Console.ReadLine(), out value);
                            }
                            while (false);
                            
                            Casino.ChoosenGame(actualPlayer, filePathPerson, filePathUser, value);
                            break;
                        }
                    case 2:
                        {
                            ProcessUserDatas.PrintPerson(actualPlayer);
                            break;
                        }

                    #region Load up money
                    case 3:
                        {
                            double inputData;
                            do
                            {
                                Console.Write("Please type in how much money you want to load up: ");
                                bool conversionSuccessfull = double.TryParse(Console.ReadLine(), out inputData);

                                if (!conversionSuccessfull)
                                {
                                    Console.WriteLine("Please enter a valid integer >0 and <1000");
                                }
                            }
                            while (false);

                            Bank.ChargeBalance(actualPlayer, inputData);
                            break;
                        }
                    #endregion

                    #region Pay out money
                    case 4:
                        {
                            double inputData;
                            do
                            {
                                Console.Write("Please type in how much money you want to pay out: ");
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
                    #endregion

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
        public static bool Login(Person user)
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


    }
}
