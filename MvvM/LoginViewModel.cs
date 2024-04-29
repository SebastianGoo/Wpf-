using MvvM;
using System.Windows.Input;

namespace LoginViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private string _password;
        private string resultMsg;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(() => Password);
            }
        }
        public string ResultMsg
        {
            get { return resultMsg; }
            set
            {
                resultMsg = value;
                OnPropertyChanged(() => ResultMsg);
            }
        }
        public void CheckUser()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                resultMsg = "ÓÃ»§Îª¿Õ";
            }
        }
        public ICommand LoginCommand => new RelayCommand(obj =>
        {
            if (UserName == "admin" &&Password == "admin")
            {
                resultMsg = "dadadad";
            }
        });
        // add any other logic or methods for login here
    }
}
