using System;
using System.Diagnostics;
using ValueObject_Class;

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
            setIndex++;

            ScoreTestSet();

            scoreVo.set(string.Format("redTeamScore{0}", setIndex), redScore);
            scoreVo.set(string.Format("blueTeamScore{0}", setIndex), blueScore);
            scoreVo.set("redTeamSetScore", setRedScore);
            scoreVo.set("blueTeamSetScore", setBlueScore);
            scoreVo.set("setIndex", setIndex);

            
        }
        private void ScoreTestSet()
        {
            lbRedTeam.Text = string.Format("{0}", redScore);
            lbBlueTeam.Text = string.Format("{0}", blueScore);
            lbRedTeamSetScore.Text = string.Format("{0}", setRedScore);
            lbBlueTeamSetScore.Text = string.Format("{0}", setBlueScore);
        }
        private async void BtnEndOfGame_Clicked(object sender, EventArgs e)
        {
            //DB에 데이터 넣기
            /*
            ScoreDao scoreDao = new ScoreDao();
            scoreDao.insertScore(scoreVo);
            */
            var answer = await DisplayAlert("게임종료", "게임을 종료하시겠습니까?", "아니오", "네");
            //아니오 클릭 시 false 반환
            if (!answer)
            {
                //DB에 데이터 넣기
                ScoreDao scoreDao = new ScoreDao();
                scoreDao.insertScore(scoreVo);
            }
            redScore = 0;
            blueScore = 0;
            setRedScore = 0;
            setBlueScore = 0;
            setIndex = 0;
            ScoreTestSet();
        }
    }
}