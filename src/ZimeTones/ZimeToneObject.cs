using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace ZimeTones
{
    public class ZimeToneObject : ObservableObject
    {
        DateTime _localTime = DateTime.MinValue;
        public DateTime LocalTime
        {
            get { return _localTime; }
            set { SetProperty(ref _localTime, value); }
        }

        Color _color = Color.White;
        public Color Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        string _country = String.Empty;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }

        string _location = String.Empty;
        public string Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }


        TimeZoneInfo _timeZoneInfo;

        public ZimeToneObject(TimeZoneInfo timezoneInfo)
        {
            _timeZoneInfo = timezoneInfo;

            var timezoneNameParts = timezoneInfo.DisplayName.Split('/');

            Country = (timezoneNameParts.FirstOrDefault() ?? String.Empty).Replace('_', ' ');
            Location = (timezoneNameParts.LastOrDefault() ?? String.Empty).Replace('_', ' ');


            LocalTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timezoneInfo);


            // Based on timezone info ID we get an int and then use it as the random seed
            // https://stackoverflow.com/a/43235
            int seed = timezoneInfo.Id.GetHashCode();
            var rand = new Random(seed);
            var red = (rand.NextDouble() + 1.0) * 0.5;
            var green = (rand.NextDouble() + 1.0) * 0.5;
            var blue = (rand.NextDouble() + 1.0) * 0.5;

            Color = new Color(red, green, blue);
        }
    }
}
