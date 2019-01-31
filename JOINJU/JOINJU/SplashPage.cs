using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;


namespace JOINJU
{
    public class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "welcomepage.png",
                WidthRequest = 950,
                HeightRequest = 950
            };

            AbsoluteLayout.SetLayoutFlags(splashImage,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.Content = sub;

        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 4000);
            //await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            //await splashImage.ScaleTo(150, 1200, Easing.Linear);

            var tappedPage = new TabbedPage();
            tappedPage.Children.Add(new MainPage());
            tappedPage.Children.Add(new MatchRecordList());
            tappedPage.Children.Add(new Setting());

            //MainPage = tappedPage;
            Application.Current.MainPage = tappedPage;
        }
    }
}
