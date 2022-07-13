using DatabaseLayer.NoteModels;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        private readonly string connectionString;
        public NoteRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("fundonote");
        }

        // Method to Add New Note To Database
        public async Task AddNote(int UserId, AddNoteModel addNoteModel)
        {

            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("spAddNote", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", addNoteModel.Title);
                    cmd.Parameters.AddWithValue("@Description", addNoteModel.Description);
                    cmd.Parameters.AddWithValue("@Bgcolor", addNoteModel.Bgcolor);
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }

        }
        public async Task<List<GetNoteModel>> GetAllNote(int UserId)
        {
            List<GetNoteModel> listOfUsers = new List<GetNoteModel>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("spGetAllNote", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    await cmd.ExecuteNonQueryAsync();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GetNoteModel getAllNotes = new GetNoteModel();
                        getAllNotes.UserId = reader["UserId"] == DBNull.Value ? default : reader.GetInt32("UserId");
                        getAllNotes.NoteId = reader["NoteId"] == DBNull.Value ? default : reader.GetInt32("NoteId");
                        getAllNotes.Title = reader["Title"] == DBNull.Value ? default : reader.GetString("Title");
                        getAllNotes.Description = reader["Description"] == DBNull.Value ? default : reader.GetString("Description");
                        getAllNotes.Bgcolor = reader["Bgcolor"] == DBNull.Value ? default : reader.GetString("Bgcolor");
                        getAllNotes.IsPin = reader["IsPin"] == DBNull.Value ? default : reader.GetBoolean("IsPin");
                        getAllNotes.IsArchive = reader["IsArchive"] == DBNull.Value ? default : reader.GetBoolean("IsArchive");
                        getAllNotes.IsRemainder = reader["IsRemainder"] == DBNull.Value ? default : reader.GetBoolean("IsRemainder");
                        getAllNotes.IsTrash = reader["IsTrash"] == DBNull.Value ? default : reader.GetBoolean("IsTrash");
                        getAllNotes.RegisteredDate = reader["RegisteredDate"] == DBNull.Value ? default : reader.GetDateTime("RegisteredDate");
                        getAllNotes.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? default : reader.GetDateTime("ModifiedDate");

                        listOfUsers.Add(getAllNotes);
                    }
                    return listOfUsers;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public async Task UpdateNote(int UserId, int NoteId, UpdateNoteModel updateNoteModel)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            var result = 0;
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateNote", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", updateNoteModel.Title);
                    cmd.Parameters.AddWithValue("@Description", updateNoteModel.Description);
                    cmd.Parameters.AddWithValue("@Bgcolor", updateNoteModel.Bgcolor);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@NoteId", NoteId);
                    cmd.Parameters.AddWithValue("@IsPin", updateNoteModel.IsPin);
                    cmd.Parameters.AddWithValue("@IsArchive", updateNoteModel.IsArchive);
                    cmd.Parameters.AddWithValue("@IsRemainder", updateNoteModel.IsRemainder);
                    cmd.Parameters.AddWithValue("@IsTrash", updateNoteModel.IsTrash);
                    result=await cmd.ExecuteNonQueryAsync();
                    if (result<= 0)
                    {
                        throw new Exception("Note Does Not Exist!!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }
        public async Task DeleteNote(int UserId, int NoteId)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            var result = 0;
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    //Creating a stored Procedure for adding Users into database
                    SqlCommand com = new SqlCommand("spDeleteNote", sqlconnection); ;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@UserId", UserId);
                    com.Parameters.AddWithValue("@NoteId", NoteId);
                    result = await com.ExecuteNonQueryAsync();
                    if (result <= 0)
                    {
                        throw new Exception("Note Does not Exists");
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}