using BusinessLayer.Interface;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

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
                return Ok(new { sucess = true, Message = "Data Fetched Successfully...", data = listOfUser });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("UserLogin")]
        public IActionResult UserLogin(UserLoginModel userLogin)
        {
            try
            {
                string result = this.userBL.UserLogin(userLogin);
                return Ok(new { success = true, Message = "Token Generated successfully", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("ForgetPassword")]
        public IActionResult UserForgetPassword(string email)
        {
            try
            {
                this.userBL.UserForgetPassword(email);
                return Ok(new { sucess = true, Message = "Password Reset Link sent Successfully..." });            
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(PasswordModel passwordModel)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var email = claims.Where(p => p.Type == @"Email").FirstOrDefault()?.Value;
                //var currentUser = HttpContext.User;
                //var email = Convert.ToString(currentUser.Claims.FirstOrDefault(c => c.Type == "Email"));
                bool result = this.userBL.ResetPassword(email,passwordModel);
                return Ok(new { success = true, Message = $"{email} your Password Updated successfully!" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
