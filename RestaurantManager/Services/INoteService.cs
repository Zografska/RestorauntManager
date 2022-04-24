using System.Collections.ObjectModel;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public interface INoteService
    {
        Note GetById(int id);
        bool UpdateNote(Note note);
        ObservableCollection<Note> GetAllNotes();
        bool RemoveNoteById(int id);
        bool RemoveNote(Note note);
        void AddNote(Note note);
    }
}