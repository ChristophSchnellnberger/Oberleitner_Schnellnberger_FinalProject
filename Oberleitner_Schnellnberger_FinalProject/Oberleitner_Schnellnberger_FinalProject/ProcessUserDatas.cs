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

            Program.Exeptions(error);
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

            Program.Exeptions(error);
            #endregion


            #endregion
        }

    }
}
