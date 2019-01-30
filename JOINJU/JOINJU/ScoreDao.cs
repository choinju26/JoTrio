using ValueObject_Class;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static JOINJU.DBConnection;

namespace JOINJU
{

    class ScoreDao
    {
        DBConnection DBConnect =null;
        SQLiteConnection db = null;

        public void insertScore(ValueObject inputData )
        {
            //DB연결 및 연결체크. *필수코드
            if (DBConnectionFnc()) { 
                Debug.Print("insertScore - DBConnection Error");
                return;
            }
            string winTeam = "draw";
            if(inputData.getInt("") > inputData.getInt(""))
            {
                winTeam = "red";
            }
            else if (inputData.getInt("") < inputData.getInt(""))
            {
                winTeam = "blue";
            }
            else
            {
                winTeam = "draw";
            }
            //db.DropTable<ScoreTable>();
            db.CreateTable<ScoreTable>();

            int seq = 1;
            var Maxtable = db.Query<ScoreTable>("SELECT * FROM ScoreTable where seq = (select max(seq) from ScoreTable) ");
            
            if (Maxtable.Count != 0)
            {
                var test= Maxtable.GetEnumerator();
                foreach (var s in Maxtable)
                {
                    seq = s.seq + 1;
                }
            }
            
            for (int i = 1; i <= inputData.getInt("setIndex"); i++)
            {
                var insSTrow = new ScoreTable();
                insSTrow.seq = seq;
                insSTrow.insDate = DateTime.Now;
                insSTrow.redTeamScore = inputData.getInt(string.Format("redTeamScore{0}", i));    // 적팀 한 세트 스코어
                insSTrow.blueTeamScore = inputData.getInt(string.Format("blueTeamScore{0}", i));   // 청팀 한 세트 스코어 
                insSTrow.redTeamSetScore = inputData.getInt("redTeamSetScore");   // 적팀 세트 스코어
                insSTrow.blueTeamSetScore = inputData.getInt("blueTeamSetScore");  // 청팀 세트 스코어

                insSTrow.winTeam = winTeam;
                insSTrow.delYn = "N";

                db.Insert(insSTrow);
            }
            //Debug.Print("Test ::Data Count " + (db.Table<ScoreTable>().Count()));
            
            //Debug.Print("Reading data");
            var table = db.Table<ScoreTable>();
            foreach (var s in table)
            {
                Debug.Print(s.Id + ":Seq" + s.seq);
            }

            db.Close();
        }

        public bool DBConnectionFnc()
        {
            DBConnection DBConnect = new DBConnection();
            if (DBConnect != null)
            {
                this.db = DBConnect.db;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
