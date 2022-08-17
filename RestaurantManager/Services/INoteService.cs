using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public interface INoteService : IServiceBase<Note>
    {
        Task<ObservableCollection<Note>> GetNotesByUser();
        Task<ObservableCollection<Note>> GetNotesSharedWithUser();

    }
}