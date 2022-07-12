using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.NoteModels
{
    public class GetNoteModel
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Bgcolor { get; set; }
        public int UserId { get; set; }
    }
}
