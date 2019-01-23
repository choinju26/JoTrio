using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace JOINJU
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var tappedPage = new TabbedPage();
            tappedPage.Children.Add(new MainPage());
            tappedPage.Children.Add(new MatchRecordList());
            tappedPage.Children.Add(new Setting());

            MainPage = new TabbedPage();
            MainPage = tappedPage;

            //MainPage = new NavigationPage(new MainPage());


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
