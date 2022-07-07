﻿using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public void AddUser(UserModel user);
        public List<GetAllUserModel> GetAllUser();
    }
}
