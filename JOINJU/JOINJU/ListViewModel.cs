using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using Windows.Storage;
using Xamarin.Forms.PlatformConfiguration;
using static JOINJU.DBConnection;

namespace JOINJU
{
    public class ListViewModel
    {
        public ObservableCollection<Score> ScoreList { get; set; }

        public ListViewModel()
        {

            DBConnection DBConnect = new DBConnection();
            SQLiteConnection list_db = null;

            if (DBConnect != null)
            {
                list_db = DBConnect.db;                
            }

            list_db.CreateTable<ScoreTable>();

            if (list_db.Table<ScoreTable>().Count() != 0)
            {              
                var table = list_db.Query<ScoreTable>("SELECT * FROM ScoreTable GROUP BY seq ");

                ScoreList = new ObservableCollection<Score>();
                foreach (var list in table)
                {
                    ScoreList.Add(new Score()
                    {
                        redTeamSetScore = list.redTeamSetScore,
                        insDate = list.insDate,
                        // Team = order.Team,
                        blueTeamSetScore = list.blueTeamSetScore
                    });
                }

            }
        }
        
        [Table("Score")]
        public class Score
        {
            public int redTeamSetScore { get; set; }  //Red Team SetScore
            public DateTime insDate { get; set; }    //Date
           // public String Team { get; set; }    // 팀명
            public int blueTeamSetScore { get; set; }  //Blue Team SetScore
        }
    }
}
