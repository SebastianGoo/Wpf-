using MvvM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Models;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Wpf.ViewModels
{

    public class LoginViewModel : ObservableObject
    {
        private string _userName;
        private string _password;
        private string resultMsg;
        private string _sex;
        LoginModel _loginModel;
        public LoginViewModel()
        {
            _loginModel = new LoginModel();
        }
        public string UserName
        {
            get { return _loginModel.UserName; }
            set
            {
                if (_loginModel.UserName != value)
                {
                    _loginModel.UserName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }


        public string Password
        {
            get { return _loginModel.Password; }
            set
            {
                if (_loginModel.Password != value)
                {
                    _loginModel.Password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public string ResultMsg
        {
            get { return resultMsg; }
            set
            {
                if (resultMsg != value)
                {
                    resultMsg = value;
                    OnPropertyChanged(nameof(ResultMsg));
                }
            }
        }
        public void CheckUser()
        {

        }
        public ICommand LoginCommand => new RelayCommand(obj =>
        {
            if (UserName.ToLower() == "admin")
            {
                ResultMsg = "dadadad";
            }
            if (!string.IsNullOrEmpty(resultMsg))
            {
                Password = "用户为空";
            }
        });


    }
    //设计一个wpf的 xaml 
}
