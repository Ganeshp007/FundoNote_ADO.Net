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

        // Method to Add/Register User 
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

        //Method to Get User Records from DB
        public List<GetAllUserModel> GetAllUser()
        {
            List<GetAllUserModel> listOfUsers = new List<GetAllUserModel>();
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            try
            {
                using(sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("spGetAllUser", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        GetAllUserModel getAllUser = new GetAllUserModel();
                        getAllUser.UserId = reader["UserId"] == DBNull.Value ? default : reader.GetInt32("UserId");
                        getAllUser.Firstname = Convert.ToString(reader["Firstname"]);
                        getAllUser.Lastname = Convert.ToString(reader["Lastname"]);
                        getAllUser.Email = Convert.ToString(reader["Email"]);
                        getAllUser.Password=Convert.ToString(reader.ToString());
                        getAllUser.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                        getAllUser.MoidifyDate = Convert.ToDateTime(reader["MoidifyDate"]);

                        listOfUsers.Add(getAllUser);
                    }
                    return listOfUsers;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
