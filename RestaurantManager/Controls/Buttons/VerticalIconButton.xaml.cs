using System.Windows.Input;
using RestaurantManager.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerticalIconButton
    {
        public VerticalIconButton()
        {
            InitializeComponent();
        }
         public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), 
                typeof(string), 
                typeof(VerticalIconButton),
                string.Empty);
        
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), 
                typeof(string), 
                typeof(VerticalIconButton),
                string.Empty);
        
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        
        public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create(nameof(TappedCommand), 
                typeof(ICommand), 
                typeof(VerticalIconButton),
                null);
        
        public ICommand TappedCommand
        {
            get => (ICommand)GetValue(TappedCommandProperty);
            set => SetValue(TappedCommandProperty, value);
        }
        
        public static readonly BindableProperty NavigationPageProperty =
            BindableProperty.Create(nameof(NavigationPage), 
                typeof(string), 
                typeof(VerticalIconButton),
                string.Empty);
        
        public string NavigationPage
        {
            get => (string)GetValue(NavigationPageProperty);
            set => SetValue(NavigationPageProperty, value);
        }

        private static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create(nameof(IconSize), 
                typeof(double), 
                typeof(VerticalIconButton),
                (double)12);
        
        public double IconSize
        {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        private static readonly BindableProperty TitleSizeProperty =
            BindableProperty.Create(nameof(TitleSize), 
                typeof(double), 
                typeof(VerticalIconButton),
                (double)12);
        
        public double TitleSize
        {
            get => (double)GetValue(TitleSizeProperty);
            set => SetValue(TitleSizeProperty, value);
        }
        
        private static readonly BindableProperty TitleColorProperty =
            BindableProperty.Create(nameof(TitleColor), 
                typeof(Color), 
                typeof(VerticalIconButton),
                Color.Black);
        
        public Color TitleColor
        {
            get => (Color)GetValue(TitleColorProperty);
            set => SetValue(TitleColorProperty, value);
        }
        
        private static readonly BindableProperty IconColorProperty =
            BindableProperty.Create(nameof(IconColor), 
                typeof(Color), 
                typeof(VerticalIconButton),
                Color.Black);
        
        public Color IconColor
        {
            get => (Color)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }
        
        private static readonly BindableProperty FrameColorProperty =
            BindableProperty.Create(nameof(FrameColor), 
                typeof(Color), 
                typeof(VerticalIconButton));
        
        public Color FrameColor
        {
            get => (Color)GetValue(FrameColorProperty);
            set => SetValue(FrameColorProperty, value);
        }

        private static readonly BindableProperty IconFontFamilyProperty = BindableProperty.Create(nameof(IconFontFamily), 
            typeof(string), typeof(FrameButton));
        public string IconFontFamily
        {
            get { return (string)GetValue(IconFontFamilyProperty); }
            set { SetValue(IconFontFamilyProperty, value); }
        }
    }
}