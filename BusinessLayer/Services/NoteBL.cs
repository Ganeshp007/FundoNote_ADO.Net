﻿using BusinessLayer.Interface;
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
        public  async Task AddNote(int UserId,AddNoteModel addNoteModel)
        {
            try
            {
                 await this.noteRL.AddNote(UserId, addNoteModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
