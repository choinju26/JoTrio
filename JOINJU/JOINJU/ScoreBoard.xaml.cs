using System;
using System.Diagnostics;
using Common_ValueObject;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JOINJU
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScoreBoard : ContentPage
	{
        //lbRedTeam = this.FindByName<Label>("lbRedTeam");
        ValueObject scoreVo =new ValueObject();
        private int redScore = 0;
        private int blueScore = 0;
        private int setRedScore =0;
        private int setBlueScore = 0;
        private int setIndex = 0;
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

            //Debug.Print("적팀 스코어 업"+ redScore);
        }

        //적팀 스코어 Down 이벤트
        public void RedTeam_ScoreDown(object sender, EventArgs e)
        {
            if (redScore - 1 >= 0)
            {
                redScore--;
            }
            lbRedTeam.Text = string.Format("{0}",redScore);

            //Debug.Print("적팀 스코어 업"+ redScore);
        }

        //청팀 스코어 UP 이벤트
        public void BlueTeam_ScoreUp(object sender, EventArgs e)
        {
            if (blueScore + 1 <= 100)
            {
                blueScore++;
            }
            lbBlueTeam.Text = string.Format("{0}",blueScore);

            //Debug.Print("적팀 스코어 업" +blueScore);
        }

        //청팀 스코어 Down 이벤트
        public void BlueTeam_ScoreDown(object sender, EventArgs e)
        {
            if (blueScore - 1 >= 0)
            {
                blueScore--;
            }
            lbBlueTeam.Text = string.Format("{0}",blueScore);
            //Debug.Print("적팀 스코어 업" +blueScore);
        }

        private void BtnEndOfSet_Clicked(object sender, EventArgs e)
        {
            if (redScore > blueScore)
            {
                setRedScore++;
            }
            else if(redScore < blueScore)
            {
                setBlueScore++;
            }
            else
            {
                setRedScore++;
                setBlueScore++;
            }
            redScore = 0;
            blueScore = 0;

            lbRedTeam.Text = string.Format("{0}", redScore);
            lbBlueTeam.Text = string.Format("{0}", blueScore);
            scoreVo.set(string.Format("redTeamScore{0}", setIndex + 1), redScore);
            scoreVo.set(string.Format("blueTeamScore{0}", setIndex + 1), blueScore);
            lbRedTeamSetScore.Text = string.Format("{0}", setRedScore);
            lbBlueTeamSetScore.Text = string.Format("{0}", setBlueScore);

            scoreVo.set("redTeamSetScore", setRedScore);
            scoreVo.set("blueTeamSetScore", setBlueScore);
            setIndex++;

            Debug.Print("Test -------------- \n" + scoreVo.ToString());
            Debug.Print("Test -------------- \n" );
        }
        //lbRedTeamSetScore, lbBlueTeamSetScore
    }
}