using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantManager.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrameButton
    {
        private const double DEFAULT_FONT_SIZE = 20;
        private const float DEFAULT_CORNER_RADIUS_SIZE = 15;
        
        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color),
            typeof(FrameButton), Color.Default);
        
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), 
            typeof(Color), typeof(FrameButton), Color.Default);
        
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), 
            typeof(Color), typeof(FrameButton), Color.Default);
        
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), 
            typeof(string), typeof(FrameButton));

        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), 
            typeof(string), typeof(FrameButton), string.Empty);
        
        public static readonly BindableProperty IconFontFamilyProperty = BindableProperty.Create(nameof(IconFontFamily), 
            typeof(string), typeof(FrameButton));

        public static readonly BindableProperty FrameTappedCommandProperty =
            BindableProperty.Create(nameof(FrameTappedCommand), typeof(ICommand), typeof(FrameButton));
        
        public static readonly BindableProperty FrameTappedCommandParameterProperty =
            BindableProperty.Create(nameof(FrameTappedCommandParameter), typeof(object), typeof(FrameButton));
        
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), 
            typeof(float), typeof(FrameButton), DEFAULT_CORNER_RADIUS_SIZE);
        
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), 
            typeof(double), typeof(FrameButton), DEFAULT_FONT_SIZE);
        
        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }
        
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        
        public string IconFontFamily
        {
            get { return (string)GetValue(IconFontFamilyProperty); }
            set { SetValue(IconFontFamilyProperty, value); }
        }
        
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ICommand FrameTappedCommand
        {
            get { return (ICommand)GetValue(FrameTappedCommandProperty); }
            set { SetValue(FrameTappedCommandProperty, value); }
        }
        public object FrameTappedCommandParameter
        {
            get { return GetValue(FrameTappedCommandParameterProperty); }
            set { SetValue(FrameTappedCommandParameterProperty, value); }
        }
        
        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        
        public FrameButton()
        {
            InitializeComponent();
        }
    }
}