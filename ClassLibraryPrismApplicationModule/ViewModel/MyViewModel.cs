using ClassLibraryPrismApplicationModule.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ClassLibraryPrismApplicationModule.ViewModel
{
    sealed class MyViewModel : INotifyPropertyChanged
    {        
        private User _user;
        public ICommand MyCommand { get; set; }

        public MyViewModel()
        {
            _user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-30)
            };

            MyCommand = new RelayCommand(ExecuteMyMethod, CanExecuteMyMethod);
        }

        #region Data


        public string FirstName
        {
            get { return _user.FirstName; }
            set
            {
                if (_user.FirstName != value)
                {
                    _user.FirstName = value;
                    OnPropertyChange("FirstName");
                    // If the first name has changed, the FullName property needs to be udpated as well.
                    OnPropertyChange("FullName");
                }
            }
        }

        public string LastName
        {
            get { return _user.LastName; }
            set
            {
                if (_user.LastName != value)
                {
                    _user.LastName = value;
                    OnPropertyChange("LastName");
                    // If the first name has changed, the FullName property needs to be udpated as well.
                    OnPropertyChange("FullName");
                }
            }
        }

        // This property is an example of how model properties can be presented differently to the View.
        // In this case, we transform the birth date to the user's age, which is read only.
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - _user.BirthDate.Year;
                if (_user.BirthDate > today.AddYears(-age)) age--;
                return age;
            }
        }

        // This property is just for display purposes and is a composition of existing data.
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        #endregion

        #region ICommand
        private bool CanExecuteMyMethod(object parameter)
        {
            if (string.IsNullOrEmpty(LastName))
            {
                return false;
            }
            else
            {
                if (LastName != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ExecuteMyMethod(object parameter)
        {
            MessageBox.Show("Hello...  " + LastName);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}