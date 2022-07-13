using DatabaseLayer.NoteModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {
        Task AddNote(int UserId, AddNoteModel addNoteModel);
        Task< List<GetNoteModel>> GetAllNote(int UserId);

        Task UpdateNote(int UserId, int NoteId, UpdateNoteModel updateNoteModel);
    }
}
