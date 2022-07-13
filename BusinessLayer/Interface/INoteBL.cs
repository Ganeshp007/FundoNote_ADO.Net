using DatabaseLayer.NoteModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        Task AddNote(int UserId, AddNoteModel addNoteModel);
        Task<List<GetNoteModel>> GetAllNote(int UserId);

        Task UpdateNote(int UserId, int NoteId, UpdateNoteModel updateNoteModel);
    }
}