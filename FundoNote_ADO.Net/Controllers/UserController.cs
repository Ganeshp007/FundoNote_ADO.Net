using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FundoNote_ADO.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost("Register")]
        public IActionResult AddUser(UserModel user)
        {
            try
            {
                this.userBL.AddUser(user);
                return this.Ok(new { success = true, Message = "User Registration Sucessfull" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            try
            {
                List<GetAllUserModel> listOfUser = new List<GetAllUserModel>();
                listOfUser = this.userBL.GetAllUser();
                return Ok(new { sucess = true ,Message="Data Fetched Successfully...",data=listOfUser});
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
