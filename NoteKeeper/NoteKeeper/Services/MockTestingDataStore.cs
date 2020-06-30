using NoteKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteKeeper.Services
{
    public class MockTestingDataStore : IPluralSightDataStore
    {
        private static readonly List<String> mockCourses;
        private static readonly List<Note> mockNotes;
        static MockTestingDataStore()
        {
            mockCourses = new List<string>
            {
                "Introduction to Xamarin.Forms",
                "Android Apps with Kotlin: First App",
                "Managing Android App Data with SQLite"
            };

            mockNotes = new List<Note>
            {
                new Note {Id = "0", Heading = "UI Code", Text = "Xamarin.Forms allows UI code to be shared", Course = mockCourses.ElementAtOrDefault(1)},
                new Note {Id = "1", Heading = "Sharing Code", Text = "Xamarin.Forms allows UI code to be shared", Course = mockCourses.ElementAtOrDefault(2)},
                new Note {Id = "2", Heading = "Cross-Platform Database", Text = "Xamarin.Forms allows UI code to be shared", Course = mockCourses.ElementAtOrDefault(3)},
            };
        }
        public async Task<string> AddNoteAsync(Note courseNote)
        {
            mockNotes.Add(courseNote);
            return await Task.FromResult("Added");
        }

        public async Task<IList<string>> GetCousesAsync()
        {
            return await Task.FromResult(mockCourses.ToList());
        }

        public async Task<Note> GetNoteAsync(string id)
        {
            return await Task.FromResult(
              mockNotes.Find(p => p.Id == id)
            );
        }

        public async Task<IList<Note>> GetNotesAsync()
        {
            return await Task.FromResult(mockNotes.ToList());
        }

        public async Task<bool> UpdateNoteAsync(Note courseNote)
        {
            var oldItem = mockNotes.Where(p => p.Id == courseNote.Id).FirstOrDefault();
            mockNotes.Remove(oldItem);
            mockNotes.Add(courseNote);
            return await Task.FromResult(true);
        }
                 
    }
}
