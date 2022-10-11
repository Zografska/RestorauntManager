using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InteractiveList
    {
        public static readonly BindableProperty CellHeightProperty = BindableProperty.Create(nameof(CellHeight), 
            typeof(int), typeof(InteractiveList), 100);
        
        public static readonly BindableProperty ItemCellTypeProperty =
            BindableProperty.Create(nameof(ItemCellType), typeof(Type), typeof(InteractiveList), propertyChanged:ChangeListTemplate);

        private static void ChangeListTemplate(BindableObject bindable, object oldValue, object newValue)
        {
            if(!(bindable is InteractiveList list))
                return;

            if(!(newValue is Type viewCellType))
                return;

            list.CustomListView.ItemTemplate = new DataTemplate(viewCellType);
        }

        public int CellHeight
        {
            get { return (int)GetValue(CellHeightProperty); }
            set { SetValue(CellHeightProperty, value); }
        }
        
        public Type ItemCellType
        {
            get => (Type)GetValue(ItemCellTypeProperty);
            set => SetValue(ItemCellTypeProperty, value);
        }
        
        public InteractiveList()
        {
            InitializeComponent();
        }
    }
}