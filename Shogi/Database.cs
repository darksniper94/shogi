using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace Shogi
{
    class Database
    {
        private SQLiteConnection connection;
        private const String DBNAME = "data.dat";
        private static Database inst = null;

        private Database()
        {
            // Create of Open Database
            bool createFile = !File.Exists(DBNAME);
            if (createFile)
            {
                SQLiteConnection.CreateFile(DBNAME);
            }
            connection = new SQLiteConnection("Data Source="+DBNAME+";Version=3;");
            connection.Open();

            // Create Tables
            if(createFile)
            {
                createTables();
            }
            
        }

        private void createTables()
        {

        }

        public static Database instance
        {
            get
            {
                if(inst==null)
                {
                    inst = new Database();
                }
                return instance;
            }
        }
    }
}
