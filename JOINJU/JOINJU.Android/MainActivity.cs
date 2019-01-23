using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

namespace JOINJU.Droid
{
    [Activity(Label = "JOINJU", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //스코어보드 진입 시 가로고정
            MessagingCenter.Subscribe<ScoreBoard>(this, "allowLandScapePortrait", sender =>
            {
                Window.SetFlags(WindowManagerFlags.LayoutInScreen, WindowManagerFlags.LayoutInOverscan);
                RequestedOrientation = ScreenOrientation.Landscape;
                //RequestedOrientation = ScreenOrientation.Unspecified; // 장치 회전에 따라 화면 회전하도록 변경
            });

            //스코어보드 닫기 시 세로 설정
            MessagingCenter.Subscribe<ScoreBoard>(this, "preventLandScape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            });

            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

        }
    }
}