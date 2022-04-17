using System;
using System.Collections.ObjectModel;
using Prism.Navigation;
using RestaurantManager.Model;

namespace RestaurantManager.Pages
{
    public class ToDoViewModel : ViewModelBase
    {
        private ObservableCollection<ToDo> _items = new ObservableCollection<ToDo>();

        public ObservableCollection<ToDo> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        
        public ToDoViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "ToDo";
            Items = new ObservableCollection<ToDo>
            {
                new ToDo { Title="Steve", Description="USA", DueDate = RandomDay()},
                new ToDo { Title="John", Description="USA", DueDate = RandomDay()},
                new ToDo { Title="Tom", Description="UK", DueDate = RandomDay()},
                new ToDo { Title="Lucas", Description="Germany", DueDate = RandomDay()},
                new ToDo { Title="Tariq", Description="UK", DueDate = RandomDay()},
                new ToDo { Title="Jane", Description="USA", DueDate = RandomDay()},
            };
            
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