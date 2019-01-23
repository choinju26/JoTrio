using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JOINJU
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScoreBoard : ContentPage
	{
		public ScoreBoard ()
		{
            InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "allowLandScapePortrait");

            //Debug.Print("스코어보드 진입");
        }
        //during page close setting back to portrait
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Send(this, "preventLandScape");

            //Debug.Print("스코어보드 나가기");
        }
    }
}