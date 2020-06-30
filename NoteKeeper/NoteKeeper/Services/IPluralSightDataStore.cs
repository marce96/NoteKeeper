using NoteKeeper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeper.Services
{
    public interface IPluralSightDataStore
    {
        Task<String> AddNoteAsync(Note courseNote);
        Task<bool> UpdateNoteAsync(Note courseNote);
        Task<Note> GetNoteAsync(string id);
        Task<IList<Note>> GetNotesAsync();
        Task<IList<string>> GetCousesAsync();
    }
}
