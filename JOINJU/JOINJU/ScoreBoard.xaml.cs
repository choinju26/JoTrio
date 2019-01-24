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
        //lbRedTeam = this.FindByName<Label>("lbRedTeam");
        int redScore = 0;
        int blueScore = 0;
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

        //적팀 스코어 UP 이벤트
        public void RedTeam_ScoreUp(object sender , EventArgs e)
        {
            if(redScore + 1 <= 100)
            {
                redScore++;
            }
            lbRedTeam.Text = string.Format("{0}",redScore);
            Debug.Print("적팀 스코어 업"+ redScore);
        }

        //적팀 스코어 Down 이벤트
        public void RedTeam_ScoreDown(object sender, EventArgs e)
        {
            if (redScore - 1 >= 0)
            {
                redScore--;
            }
            lbRedTeam.Text = string.Format("{0}",redScore);
            Debug.Print("적팀 스코어 다운" + redScore);
        }

        //청팀 스코어 UP 이벤트
        public void BlueTeam_ScoreUp(object sender, EventArgs e)
        {
            if (blueScore + 1 <= 100)
            {
                blueScore++;
            }
            lbBlueTeam.Text = string.Format("{0}",blueScore);
            Debug.Print("청팀 스코어 업" + redScore);
        }

        //청팀 스코어 Down 이벤트
        public void BlueTeam_ScoreDown(object sender, EventArgs e)
        {
            if (blueScore - 1 >= 0)
            {
                blueScore--;
            }
            lbBlueTeam.Text = string.Format("{0}",blueScore);
            Debug.Print("청팀 스코어 다운" + redScore);
        }
    }
}