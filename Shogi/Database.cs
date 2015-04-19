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
           // bool createFile = !File.Exists(DBNAME);
            bool createFile = true;
            if (createFile)
            {
                SQLiteConnection.CreateFile(DBNAME);
            }
            connection = new SQLiteConnection("Data Source=" + DBNAME + ";Version=3;");
            connection.Open();

            // Create Tables
            if (createFile)
            {
                createTables();
            }

        }

        public static Database instance
        {
            get
            {
                if (inst == null)
                {
                    inst = new Database();
                }
                return inst;
            }
        }

        // Methode zum ausführen von update, insert, delete und create
        public int executeNonQuery(String sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            return cmd.ExecuteNonQuery();
        }

        // Methode für select
        public LinkedList<Object[]> executeQuery(String sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            LinkedList<Object[]> lines = new LinkedList<Object[]>();
            while (reader.Read())
            {
                Object[] line = new Object[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    line[i] = reader.GetValue(i);
                }
                lines.AddLast(line);
            }
            return lines;
        }

        private void createTables()
        {
            String USER_TBL = @"CREATE TABLE USER (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                name VARCHAR(128), 
                                pass VARCHAR(128)
                                );";
            executeNonQuery(USER_TBL);
            executeNonQuery("INSERT INTO USER (name, pass) VALUES ('Alex', '123456')");
        }

        public int pruefeSpielerDaten(String benutzername, String passwort)
        {
            String sql = "SELECT ID FROM USER WHERE name='" + benutzername + "' and pass='" + passwort + "'";
            LinkedList<Object[]> result = executeQuery(sql);
            if (result.Count() == 0)
            {
                // Keine Übereinstimmung 
                return -1;
            }
            else
            {
                // Gib die ID des Benutzers zurück
                return Convert.ToInt32(result.ElementAt(0)[0]);
            }
        }

        public Spieler ladeSpieler(int spielerid)
        {
            String sql = "SELECT * FROM USER WHERE ID='" + Convert.ToString(spielerid) + "'";
            LinkedList<Object[]> result = executeQuery(sql);
            if (result.Count() == 0)
            {
                return null;
            }
            else
            {
                return new Spieler("a", "a", "b");
            }
        }

        public void speichereSpieler(Spieler spieler)
        {

        }

        public Statistik ladeStatistik(Spieler spieler)
        {
            return null;
        }

        public String ladeRegelwerk()
        {
            return "";
        }

    }
}
