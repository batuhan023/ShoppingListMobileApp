
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingListMobileApp1
{
    public class RegisterPageViewModel : BindableObject
    {
        public RegisterPageViewModel()
        {
            Registers = new ObservableCollection<Register> { };
            SignupRegisterCommand = new Command(OnSignupRegister);
        }

        //Registerlar Koleksiyonu
        public ObservableCollection<Register> Registers { get; set; }

        //Komutlar
        public ICommand SignupRegisterCommand { get; }

        // Yeni eklenen Register
        private string newName;
        public string NewName
        {
            get { return newName; }
            set
            {
                newName = value;
                OnPropertyChanged();
            }
        }

        private string newSurname;
        public string NewSurname
        {
            get { return newSurname; }
            set
            {
                newSurname = value;
                OnPropertyChanged();
            }
        }

        private string newEmail;
        public string NewEmail
        {
            get { return newEmail; }
            set
            {
                newEmail = value;
                OnPropertyChanged();
            }
        }

        private string newUsername;
        public string NewUsername
        {
            get { return newUsername; }
            set
            {
                newUsername = value;
                OnPropertyChanged();
            }
        }

        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                OnPropertyChanged();
            }
        }

        private string newRepassword;
        public string NewRepassword
        {
            get { return newRepassword; }
            set
            {
                newRepassword = value;
                OnPropertyChanged();
            }
        }

        private string newBirthdate;
        public string NewBirthdate
        {
            get { return newBirthdate; }
            set
            {
                newBirthdate = value;
                OnPropertyChanged();
            }
        }

        // Gender Male mi seçildi
        private bool isGenderMale;
        public bool IsGenderMale
        {
            get { return isGenderMale; }
            set
            {
                isGenderMale = value;
                OnPropertyChanged();
            }
        }

        // Gender Female mi seçildi
        private bool isGenderFemale;
        public bool IsGenderFemale
        {
            get { return isGenderFemale; }
            set
            {
                isGenderFemale = value;
                OnPropertyChanged();
            }
        }

        private string newGender;
        public string NewGender
        {
            get { return newGender; }
            set
            {
                newGender = value;
                OnPropertyChanged();
            }
        }

        private string newCity;
        public string NewCity
        {
            get { return newCity; }
            set
            {
                newCity = value;
                OnPropertyChanged();
            }
        }

        private string newCountry;
        public string NewCountry
        {
            get { return newCountry; }
            set
            {
                newCountry = value;
                OnPropertyChanged();
            }
        }

        private string newTown;
        public string NewTown
        {
            get { return newTown; }
            set
            {
                newTown = value;
                OnPropertyChanged();
            }
        }

        private string newDistrict;
        public string NewDistrict
        {
            get { return newDistrict; }
            set
            {
                newDistrict = value;
                OnPropertyChanged();
            }
        }

        private void OnSignupRegister()
        {
            if (IsGenderMale)
            {
                NewGender = "Male";
            }
            else if (IsGenderFemale)
            {
                NewGender = "Female";
            }

            // Uyarı verilmesi gerek.
            if (NewRepassword != NewPassword)
            {
                //NewPassword = string.Empty;
            }

            Registers.Add(new Register
            {
                Name = NewName,
                Surname = NewSurname,
                Email = NewEmail,
                Username = NewUsername,
                Password = NewPassword,
                City = NewCity,
                Country = NewCountry,
                Town = NewTown,
                District = NewDistrict,
                Gender = NewGender,
                Birthdate = NewBirthdate,
            });

            NewName = string.Empty;
            NewSurname = string.Empty;
            NewEmail = string.Empty;
            NewUsername = string.Empty;
            NewPassword = string.Empty;
            NewRepassword = string.Empty;
            newBirthdate = string.Empty;
            newCity = string.Empty;
            NewCountry = string.Empty;
            NewTown = string.Empty;
            NewDistrict = string.Empty;
            NewBirthdate = (DateTime.Today).ToString();
            IsGenderMale = false;
            IsGenderFemale = false;
        }
    }

    public class Register : BindableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private string birthdate;
        public string Birthdate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                OnPropertyChanged();
            }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged();
            }
        }

        private string town;
        public string Town
        {
            get { return town; }
            set
            {
                town = value;
                OnPropertyChanged();
            }
        }

        private string district;
        public string District
        {
            get { return district; }
            set
            {
                district = value;
                OnPropertyChanged();
            }
        }
    }
}
