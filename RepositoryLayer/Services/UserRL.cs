using DatabaseLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly string connetionString;
        public UserRL(IConfiguration configuration)
        {
            connetionString = configuration.GetConnectionString("fundonote");
        }
        public void AddUser(UserModel user)
        {
            SqlConnection sqlconnection = new SqlConnection(connetionString);
           try
           {
             using(sqlconnection)
               {
                  sqlconnection.Open();
                  SqlCommand cmd = new SqlCommand("spAddUser",sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@Email",user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.ExecuteNonQuery();
               }
           }
           catch(Exception ex)
           {
                throw ex;
           }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}
