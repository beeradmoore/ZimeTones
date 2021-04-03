using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace ZimeTones
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ZimeToneObject> ZimeTomeObjects { get; } = new ObservableCollection<ZimeToneObject>();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

            var timezones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timezone in timezones)
            {
                if (timezone.DisplayName.StartsWith("Australia"))
                {
                    ZimeTomeObjects.Add(new ZimeToneObject(timezone));
                }
            }

            var toolbarItem = new ToolbarItem()
            {
                IconImageSource = new FontImageSource()
                {
                    Size = 18,
                    FontFamily = "FontAwesome-Solid",
                    Glyph = FontAwesome.FontAwesomeIcons.Plus,
                },

            };
            toolbarItem.Clicked += AddToolbarItem_Clicked;
            ToolbarItems.Add(toolbarItem);
        }

        void AddToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        void ChangeDateRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            SecretDatePicker.Focus();
        }

        void ChangeTimeRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (sender is Label label && label.BindingContext is ZimeToneObject zimeTone)
            {
                SecretTimePicker.Time = zimeTone.LocalTime.TimeOfDay;
                SecretTimePicker.Focus();
            }
        }

        void SecretTimePicker_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                var newTime = SecretTimePicker.Time;
            }
        }
    }
}
