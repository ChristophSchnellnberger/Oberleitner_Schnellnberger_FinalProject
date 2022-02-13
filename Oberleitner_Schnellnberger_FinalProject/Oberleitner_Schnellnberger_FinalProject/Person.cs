using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oberleitner_Schnellnberger_FinalProject
{
    class Person
    {
        #region private members
        private string _firstName;
        private string _surname;
        private DateTime _dateOfBirth;
        private Gender _gender;
        private string _street;
        private int _houseNumber;
        private int _postalCode;
        private string _cityName;
        private string _password;
        #endregion

        #region properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                int error = 0;
                try
                {
                    bool validInput = CheckName(value);
                    if (validInput == true)
                    {
                        _firstName = value;
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
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                int error = 0;
                try
                {
                    bool validInput = CheckName(value);
                    if (validInput == true)
                    {
                        _surname = value;
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
        }
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                int error = 0;
                try
                {
                    bool validInputYear = CheckBirthdayYear((value.Year).ToString());
                    bool validInputMonth = CheckBirthdateMonth((value.Month).ToString());
                    bool validInputDay = CheckBirthdateDay((value.Day).ToString());

                    if (validInputYear && validInputMonth && validInputDay == true)
                    {
                        _dateOfBirth = value;
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
        }
        public Gender PersonGender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                int error = 0;
                try
                {
                    bool validInput = CheckStreet(value);
                    if (validInput == true)
                    {
                        _street = value;
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
        }
        public int HouseNumber
        {
            get
            {
                return _houseNumber;
            }

            set
            {
                int error = 0;
                try
                {
                    bool validInput = CheckHouseNumber(value.ToString());
                    if (validInput == true)
                    {
                        _houseNumber = value;
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
        }
        public int PostalCode
        {
            get
            {
                return _postalCode;

            }
            set
            {
                int error = 0;
                try
                {
                    bool validInput = CheckPostalCode(value.ToString());
                    if (validInput == true)
                    {
                        _postalCode = value;
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
        }
        public string CityName
        {
            get
            {
                return _cityName;
            }
            set
            {
                int error = 0;
                try
                {
                    bool validInput = CheckCityName(value);
                    if (validInput == true)
                    {
                        _cityName = value;
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
        }
        public string Password
        {
            get { return _password; }
            set
            {
                int error = 0;
                try
                {
                    bool validInput = CheckPassword(value);
                    if (validInput == true)
                    {
                        _password = value;
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
                #endregion }
            }
        }
        #endregion

        #region constructor
        public Person() : this("fistName", "surname", DateTime.Today, Gender.male, "Musterstrasse", 01, 4811, "Musterstadt","Pas§word123")
        {
        }
        public Person(string firstName, string surname, DateTime dateOfBirth, Gender gender, string street,
                      int houseNumber, int postalCode, string cityName,string password)
        {
            FirstName = firstName;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            PersonGender = gender;
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            CityName = cityName;
            Password = password;
        }
        #endregion

        #region checking methods
        public static bool CheckName(string newName)
        {
            bool validInput = false;
            int conditionsTrue = 2;
            int counter = 0;

            if (!(string.IsNullOrWhiteSpace(newName)))
            {
                counter++;
            }

            if (newName.All(char.IsLetter))
            {
                counter++;
            }

            if (counter == conditionsTrue)
            {
                validInput = true;
            }

            return validInput;
        }
        public static bool CheckBirthdayYear(string inputYear)
        {
            bool checkbirthday = false;
            int minValue = DateTime.Now.Year - 120;
            int maxValue = DateTime.Now.Year;
            int yearInteger;
            int conditionsTrue = 4;
            int counter = 0;

            if (int.TryParse(inputYear, out yearInteger))
            {
                counter++;
            }
            if (inputYear.Length == 4)
            {
                counter++;
            }
            if (yearInteger > minValue)
            {
                counter++;
            }
            if (yearInteger < maxValue)
            {
                counter++;
            }
            if (conditionsTrue == counter)
            {
                checkbirthday = true;
            }
            return checkbirthday;
        }
        public static bool CheckBirthdateMonth(string inputMonth)
        {
            bool checkbirthday = false;
            int monthInteger;
            int conditionsTrue = 2;
            int counter = 0;

            if (int.TryParse(inputMonth, out monthInteger))
            {
                counter++;
            }
            if (inputMonth.Length == 2)
            {
                counter++;
            }
            if (conditionsTrue == counter)
            {
                checkbirthday = true;
            }
            return checkbirthday;
        }
        public static bool CheckBirthdateDay(string inputDay)
        {
            bool checkbirthday = false;
            int dayInteger;
            int conditionsTrue = 2;
            int counter = 0;

            if (int.TryParse(inputDay, out dayInteger))
            {
                counter++;
            }
            if (inputDay.Length == 2)
            {
                counter++;
            }
            if (conditionsTrue == counter)
            {
                checkbirthday = true;
            }
            return checkbirthday;
        }
        public static bool CheckStreet(string street)
        {
            bool validInput = false;
            int conditionsTrue = 2;
            int counter = 0;

            if (!(string.IsNullOrWhiteSpace(street)))
            {
                counter++;
            }

            if (street.All(char.IsLetter))
            {
                counter++;
            }

            if (counter == conditionsTrue)
            {
                validInput = true;
            }

            return validInput;


        }
        public static bool CheckHouseNumber(string houseNumber)
        {
            bool validInput = false;
            int conditionsTrue = 2;
            int counter = 0;

            if (!(string.IsNullOrWhiteSpace(houseNumber)))
            {
                counter++;
            }

            if (houseNumber.All(char.IsDigit))
            {
                counter++;
            }

            if (counter == conditionsTrue)
            {
                validInput = true;
            }

            return validInput;

        }
        public static bool CheckPostalCode(string postalCode)
        {
            bool validInput = false;
            int conditionsTrue = 2;
            int counter = 0;

            if (!(string.IsNullOrWhiteSpace(postalCode)))
            {
                counter++;
            }

            if (postalCode.All(char.IsDigit))
            {
                counter++;
            }

            if (counter == conditionsTrue)
            {
                validInput = true;
            }

            return validInput;

        }
        public static bool CheckCityName(string cityName)
        {
            bool validInput = false;
            int conditionsTrue = 2;
            int counter = 0;

            if (!(string.IsNullOrWhiteSpace(cityName)))
            {
                counter++;
            }

            if (cityName.All(char.IsLetter))
            {
                counter++;
            }

            if (counter == conditionsTrue)
            {
                validInput = true;
            }

            return validInput;

        }
        public static bool CheckPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            if (password.Length <= 7)
            {
                return false;
            }
            if (password.All(Char.IsLetter))
            {
                return false;
            }
            if (password.All(Char.IsUpper))
            {
                return false;
            }
            if (password.All(Char.IsLower))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Enum Gender
        public enum Gender
        {
            male = 1,
            female = 2,
            diverse = 3,
            noAnswer = 4
        }
        #endregion
    }
    
    
}
