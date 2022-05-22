using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestaurantManager.Model;


namespace RestaurantManager.Services
{
    public class NoteService : INoteService
    {
        public List<Note> Notes { get; set; }
        
        public NoteService()
        {
            Notes = new List<Note>
            {
                new Note { Title="Steve", Description="USA", LastModified = RandomDay()},
                new Note { Title="John", Description="USA", LastModified = RandomDay()},
                new Note { Title="Tom", Description="UK", LastModified = RandomDay()},
                new Note { Title="Lucas", Description="Germany", LastModified = RandomDay()},
                new Note { Title="Tariq", Description="UK", LastModified = RandomDay()},
                new Note { Title="Jane", Description="USA", LastModified = RandomDay()},
            };
        }
        public Note GetById(int id)
        {
            var result = Notes.FirstOrDefault(x => x.Id.Equals(id));
            return result;
        }

        public bool Update(Note updatedNote)
        {
            var oldNote = GetById(updatedNote.Id);
            if (updatedNote.Equals(oldNote))
            {
                return true;
            }

            if (Notes.Remove(oldNote))
            {
                Add(updatedNote);
                return true;
            }

            return false;
        }

        public ObservableCollection<Note> GetAll()
        {
            return new ObservableCollection<Note>(Notes);
        }

        public bool RemoveById(int id)
        {
            var note = GetById(id);
            return Remove(note);
        }

        public bool Remove(Note note)
        {
            return Notes.Remove(note);
        }

        public Note Add(Note note)
        {
            // If note is saved for the first time add creator
            note.LastModified = DateTime.Now;
            Notes.Add(note);
            return note;
        }

        public Note Save(Note note)
        {
            var updateComplete = Update(note);
            if (!updateComplete)
            {
                Add(note);
            }

            return note;
        }

        //For mocking data only
        //TODO: Remove this when integration with API is done
        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;           
            return start.AddDays(gen.Next(range));
        }
    }
}