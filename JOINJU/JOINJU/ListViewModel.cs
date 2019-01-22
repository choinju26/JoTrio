using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JOINJU
{
    public class ListViewModel
    {
        public ObservableCollection<Score> ScoreList { get; set; }

        public ListViewModel()
        {
            ScoreList = new ObservableCollection<Score> {
                new Score(){ ScoreA = "5" , Date = "2019-01-22-18:00", Team = "A : B", ScoreB ="26"},
                new Score(){ ScoreA = "50" , Date = "2019-01-22-18:00", Team = "A : B", ScoreB ="26"}
            };
        }
    }

    public class Score
    {
        public String ScoreA { get; set; }  //A Score
        public String Date { get; set; }    //기록된 날짜
        public String Team { get; set; }    // 팀명
        public String ScoreB { get; set; }  //B Score
    }
}
