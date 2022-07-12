using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public void AddUser(UserModel user);
        public List<GetAllUserModel> GetAllUser();
        public string UserLogin(UserLoginModel userLogin);
        public bool UserForgetPassword(string email);
        public bool ResetPassword(string Email, PasswordModel Password);


    }
}
