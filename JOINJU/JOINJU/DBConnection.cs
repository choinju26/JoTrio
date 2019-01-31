using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.Storage;
using Xamarin.Forms;

namespace JOINJU
{
    class DBConnection
    {
        public SQLiteConnection db = null;
        public bool ConnectionYn = true;
        public DBConnection()
        {
            var platform = Device.RuntimePlatform;

            string dbPath = null;

            switch (platform)
            {
                case Device.iOS:
                    // iOS
                    break;
                case Device.Android:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ScoreDB");
                    break;
                case Device.UWP:
                    dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ScoreDB");
                    break;
            }

            var db = new SQLiteConnection(dbPath);

            if (db != null)
            {
                this.db = db;
            }
            else
            {
                ConnectionYn = false;
            }
        }

        [Table("ScoreTable")]
        public class ScoreTable
        {
            [PrimaryKey, AutoIncrement, Column("id")]
            public int Id { get; set; }
            [MaxLength(20), Indexed]
            public int seq { get; set; }
            [MaxLength(20)]
            public DateTime insDate { get; set; }
            [MaxLength(3)]
            public int redTeamScore { get; set; }
            [MaxLength(3)]
            public int blueTeamScore { get; set; }
            [MaxLength(3)]
            public int redTeamSetScore { get; set; }
            [MaxLength(3)]
            public int blueTeamSetScore { get; set; }
            [MaxLength(4)]
            public string winTeam { get; set; }
            [MaxLength(1)]
            public string delYn { get; set; }
        }
    }

}
