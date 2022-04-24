using System;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.PopUps;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class NotePopupViewModel : BasePopupViewModel
    {
        private Note _note;
        public Note Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }
        
        public ICommand SaveCommand;
        
    
        public NotePopupViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        public override void OnPopupOpened(IPopupParameters parameters)
        { 
            base.OnPopupOpened(parameters);
            InitPopup(parameters);
            SaveCommand = new Command<string>(SaveNote);
        }
        private void InitPopup(IPopupParameters parameters)
        {
            Note note;
            parameters.TryGetValue("Item", out note);
            Note = note;
        }
        
        private void SaveNote(string description)
        {
            
        }
    }
    
}