using BusinessLayer.Interface;
using DatabaseLayer.NoteModels;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }
        public async Task AddNote(int UserId, AddNoteModel addNoteModel)
        {
            try
            {
                await this.noteRL.AddNote(UserId, addNoteModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GetNoteModel>> GetAllNote(int UserId)
        {
            try
            {
                return await this.noteRL.GetAllNote(UserId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateNote(int UserId, int NoteId, UpdateNoteModel updateNoteModel)
        {
            try
            {
                await this.noteRL.UpdateNote(UserId, NoteId, updateNoteModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteNote(int UserId, int NoteId)
        {
            try
            {
                await this.noteRL.DeleteNote(UserId, NoteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
