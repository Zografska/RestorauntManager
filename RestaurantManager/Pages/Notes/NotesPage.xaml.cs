using System;
using System.Collections.ObjectModel;
using RestaurantManager.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Pages.Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage
    {
        public static readonly BindableProperty NotesTypeProperty =
            BindableProperty.Create(nameof(NotesType), typeof(string),
                typeof(NotesPage), default(string));

        public static readonly BindableProperty IsButtonVisibleProperty =
            BindableProperty.Create(nameof(IsButtonVisible), typeof(bool),
                typeof(NotesPage), true);
     
        public string NotesType
        {
            get => (string)GetValue(NotesTypeProperty);
            set
            {
                SetValue(NotesTypeProperty, value);
                OnPropertyChanged(nameof(NotesType));
            }
        }

        public bool IsButtonVisible
        {
            get => (bool)GetValue(IsButtonVisibleProperty);
            set
            {
                SetValue(IsButtonVisibleProperty, value);
                OnPropertyChanged(nameof(IsButtonVisible));
            }
        }

        public string Texty
        {
            get => _texty;
            set
            {
                _texty = value;
                OnPropertyChanged(nameof(_texty));
            }
        }

        private ObservableCollection<Note> _shmotes;
        private string _texty;

        public ObservableCollection<Note> Shmotes
        {
            get => _shmotes;
            set
            {
                _shmotes = value;
                OnPropertyChanged(nameof(Shmotes));
            }
        }

        public NotesPage()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext is NotesViewModel notesPageViewModel)
            {
                notesPageViewModel.PopulateItems(NotesType);
            }
        }
    }
}