using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using Xamarin.Forms;

namespace JOINJU
{
	public class SQLite_Sample : ContentPage
	{
        public SQLite_Sample()
        {
            //orademo.db3에 items테이블 첫 생성 및 샘플데이터 insert 
            DoSomeDataAccess();
            //Select 쿼리를 이용하여 모든 데이터 출력 ( 현재는 Symbol 데이터중 "MSFT" 값이 있으면 출력")
            DBFullScan();
        }

        public static void DBFullScan()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            if (db.Table<Stock>().Count() != 0)
            {
                //var table = db.Table<Stock>();
                // 쿼리작성 후 결과 출력
                var table = db.Query<Stock>("SELECT * FROM Items WHERE Symbol like 'MSFT%'");
                // 조회된 값을 table 에 저장. foreach 문으로 var s에 1행씩 저장 후 출력 
                foreach (var s in table)
                {
                    Debug.Print(s.Id + " " + s.Symbol);
                }
            }
        }
        public static void DoSomeDataAccess()
        {
            Debug.Print("Creating database, if it doesn't already exist");
            //onsole.WriteLine("Creating database, if it doesn't already exist");

            //ormdemo.db3 이라는 데이터베이스를 찾아 Connect함.
            //데이터베이스에는 여러 테이블을 넣을 수 있음. 
            //(ormdemo.db3 폴더안에 Items 파일(테이블)이 있다고 생각.) 
            string dbPath = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                 "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            //데이터베이스에 items 테이블 생성
            db.CreateTable<Stock>();

            //데이터가 존재하지 않으면 데이터 넣어줌. 
            if (db.Table<Stock>().Count() == 0)
            {
                // only insert the data if it doesn't already exist

                //insert into items(Symbol) value("AAPL") 
                var newStock = new Stock();
                newStock.Symbol = "AAPL";
                db.Insert(newStock);

                //insert into items(Symbol) value("GOOG") 
                newStock = new Stock();
                newStock.Symbol = "GOOG";
                db.Insert(newStock);

                //insert into items(Symbol) value("MSFT") 
                newStock = new Stock();
                newStock.Symbol = "MSFT";
                db.Insert(newStock);
            }
            else
            {
                //데이터가 존재하면 추가로 MSFT_ 데이터를 하나만 넣음.
                var newStock = new Stock();
                newStock = new Stock();
                newStock.Symbol = "MSFT_" + db.Table<Stock>().Count();
                db.Insert(newStock);
                Debug.Print("Data Count " + (db.Table<Stock>().Count()));
            }
            Debug.Print("Reading data");
            var table = db.Table<Stock>();
            foreach (var s in table)
            {
                Debug.Print(s.Id + " " + s.Symbol);
            }
            Debug.Print("Test" + table);
        }

        //테이블명 생성 및 클래스 생성(Stock 이라는 클래스는 Items 테이블을 참조함)
        [Table("Items")]
        public class Stock
        {
            [PrimaryKey, AutoIncrement, Column("id")]
            public int Id { get; set; }
            [MaxLength(8)]
            public string Symbol { get; set; }
        }
    }
}