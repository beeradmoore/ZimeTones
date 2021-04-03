using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZimeTones
{
    public partial class App : Application
    {
        //public DateTime TargetTime { get; } = DateTime.Now;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
