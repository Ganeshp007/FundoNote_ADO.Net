using BusinessLayer.Interface;
using DatabaseLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public void AddUser(UserModel user)
        {
            try
            {
              this.userRL.AddUser(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<GetAllUserModel> GetAllUser()
        {
            try
            {
                return this.userRL.GetAllUser();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string UserLogin(UserLoginModel userLogin)
        {
            try
            {
                return this.userRL.UserLogin(userLogin);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool UserForgetPassword(string Email)
        {
            try
            {
                return this.userRL.UserForgetPassword(Email);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool ResetPassword(string Email, PasswordModel passwordModel)
        {
            try
            {
                return this.userRL.ResetPassword(Email,passwordModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
