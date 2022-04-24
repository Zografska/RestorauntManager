using System;
using System.Collections.ObjectModel;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Pages.Base;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages
{
    public class NotesViewModel : PageViewModelBase
    {
        private ObservableCollection<Note> _items = new ObservableCollection<Note>();
        public Command<object> ItemTappedCommand { get; set; }
        public ObservableCollection<Note> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        
        public NotesViewModel(INavigationService navigationService, IPopupService popupService) : base(navigationService, popupService)
        {
            Title = "Notes";
            Items = new ObservableCollection<Note>
            {
                new Note { Title="Steve", Description="USA", LastModified = RandomDay()},
                new Note { Title="John", Description="USA", LastModified = RandomDay()},
                new Note { Title="Tom", Description="UK", LastModified = RandomDay()},
                new Note { Title="Lucas", Description="Germany", LastModified = RandomDay()},
                new Note { Title="Tariq", Description="UK", LastModified = RandomDay()},
                new Note { Title="Jane", Description="USA", LastModified = RandomDay()},
            };
            ItemTappedCommand = new Command<object>(ShowNotePopup);
        }
        
        private async void ShowNotePopup(object tappedNote)
        {
            var note = tappedNote as Note;
            
            IPopupResult result = await PopupService.ShowPopupAsync("NotePopup", new PopupParameters {{"Item", note}});

        }
        
        //For mocking data only
        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;           
            return start.AddDays(gen.Next(range));
        }
    }
}