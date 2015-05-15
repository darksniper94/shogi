using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace Shogi
{
    public class Database
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
            try
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
            catch(SQLiteException ex)
            {
                Console.WriteLine("METHODE executeQuery Exeption:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("in SQL Query:");
                Console.WriteLine(sql);
                return new LinkedList<Object[]>();
            }

        }

        /// <summary>
        /// Tabellen für eine neue Datenbank anlegen
        /// </summary>

        private void createTables()
        {
            String USER_TBL = @"CREATE TABLE `USER` (
	                                                    `ID`	INTEGER PRIMARY KEY AUTOINCREMENT,
	                                                    `name`	VARCHAR(128) NOT NULL UNIQUE,
	                                                    `pass`	VARCHAR(128) NOT NULL,
	                                                    `design`	VARCHAR(128) DEFAULT "",
	                                                    `color`	VARCHAR(128) DEFAULT ""
                                                    );";

            String STATISTIC_TBL = @"CREATE TABLE `STATISTIK` (
	                                                            `ID`	INTEGER PRIMARY KEY AUTOINCREMENT,
	                                                            `user_id`	INTEGER,
	                                                            `spiel_gewonnen`	INTEGER DEFAULT 0,
	                                                            `spiel_beendet`	INTEGER DEFAULT 0,
	                                                            `zuege`	INTEGER DEFAULT 0,
	                                                            `zeit`	INTEGER DEFAULT 0,
	                                                            FOREIGN KEY(`user_id`) REFERENCES USER ( ID ) ON DELETE CASCADE
                                                            );";


            executeNonQuery(USER_TBL);
            executeNonQuery(STATISTIC_TBL);
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

        public bool pruefeBenutzerVorhanden(String benutzername)
        {
            String sql = "SELECT ID FROM USER WHERE name='" + benutzername + "'";
            LinkedList<Object[]> result = executeQuery(sql);
            if (result.Count() == 0)
            {
                // Keine Übereinstimmung 
                return false;
            }
            else
            {
                return true;
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
                Object[] data = result.ElementAt(0);
                return new Spieler(
                    Convert.ToInt32(data[0]),   // ID
                    Convert.ToString(data[1]),  // Name 
                    Convert.ToString(data[2]),  // Passwort
                    Convert.ToString(data[3]),  // Design
                    Convert.ToString(data[4])   // Farbe
                    );
            }
        }
        /// <summary>
        /// Speichert einen Spieler in die Datenbank
        /// Hat der Spieler eine bekannte ID, dann wird 
        /// </summary>
        /// <param name="spieler"></param>
        public void speichereSpieler(Spieler spieler)
        {
            String sql = "";
            if(spieler.id == Spieler.NEUER_SPIELER)
            {
                // Neuen SPieler erstellen
                sql = @"INSERT INTO USER (name, pass, design, color) 
                        VALUES
                        ('"+spieler.benutzername+"', '"+spieler.passwort+"','"+spieler.design+"','"+spieler.farbe+"');";

                
            }
            else
            {
                // Spieler aktualisieren
                sql = @"UPDATE USER SET name="+spieler.benutzername+", "+
                        "pass = '"+spieler.passwort+"', "+
                        "design = '"+spieler.design+"', "+
                        "color = '"+spieler.farbe+"', "+
                        "WHERE id = "+spieler.id+";";                
            }
            this.executeNonQuery(sql);

        }

        /// <summary>
        /// Löscht den Spieler samt Statistik. Die Statistik wird über on delete cascade realisiert.
        /// </summary>
        /// <param name="?"></param>
        public void loescheSpieler(Spieler spieler)
        {
            String sql = "DELETE FROM USER WHERE ID = " + getSpielerID(spieler);
            this.executeNonQuery(sql);
        }

        public Statistik ladeStatistik(Spieler spieler)
        {
            String sql = @"SELECT SUM(spiel_gewonnen), SUM(spiel_beendet), AVG(zuege), AVG(zeit)
                           FROM STATISTIK
                           WHERE user_id = " + this.getSpielerID(spieler);

            LinkedList<Object[]> result = this.executeQuery(sql);
            Object[] data = result.ElementAt(0);
            // Check we have any NULL value in result
            foreach(var field in data)
            {
                if (field.GetType() == typeof(DBNull)) return null;
            }
            return new Statistik(Convert.ToInt32(data[0]),Convert.ToInt32(data[1]), Convert.ToDouble(data[2]), Convert.ToDouble(data[3]));
        }

        public void loescheStatistik(Spieler spieler)
        {
            String sql = "DELETE FROM STATISTIK WHERE user_id = " + getSpielerID(spieler);
            this.executeNonQuery(sql);
        }

        /// <summary>
        /// Sucht zum Benutzernamen die SpielerID raus
        /// </summary>
        /// <param name="spieler"></param>
        /// <returns>ID</returns>

        private int getSpielerID(Spieler spieler)
        {
            String sql = "SELECT ID FROM USER WHERE name = '" + spieler.benutzername + "'";
            LinkedList<Object[]> result = this.executeQuery(sql);
            return Convert.ToInt32(result.ElementAt(0)[0]);
        }

        /// <summary>
        /// Erstellt einen neuen Statistik Eintrag im der Datenbank
        /// </summary>
        /// <param name="spieler"></param>
        /// <param name="gewonnen"></param>
        /// <param name="beendet"></param>
        /// <param name="zuege"></param>
        /// <param name="zeit"></param>

        public void statistikErweitern(Spieler spieler, bool gewonnen, bool beendet, int zuege, int zeit)
        {
            if(gewonnen) beendet = true;
            String sql = @"INSERT INTO STATISTIK (spieler_id, spiel_gewonnen, spiel_beendet, zuege, zeit)
                           VALUES (" + this.getSpielerID(spieler) + ", "
                                    + Convert.ToInt32(gewonnen) + ", "
                                    + Convert.ToInt32(beendet) + ", "
                                    + zuege + ", "
                                    + zeit + ");";
            this.executeNonQuery(sql);
                                                        
        }

        public String ladeRegelwerk()
        {
            return "";
        }

        public void speichereSpiel(Spielfeld feld)
        {

        }

    }
}
