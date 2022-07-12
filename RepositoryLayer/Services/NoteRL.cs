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
    public class NoteRL: INoteRL
    {
        private readonly string connectionString;
        public NoteRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("fundonote");
        }

        // Method to Add New Note To Database
        public async Task AddNote(int UserId,AddNoteModel addNoteModel)
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
    }
}
