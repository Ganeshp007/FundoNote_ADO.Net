using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public void AddUser(UserModel user);
        public List<GetAllUserModel> GetAllUser();
        public string UserLogin(UserLoginModel userLogin);
        public bool UserForgetPassword(string Email);
    }
}
