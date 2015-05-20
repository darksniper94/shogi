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
        private readonly String DBNAME = "data.dat";
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
                CreateTables();
            }

        }

        /// <summary>
        /// Database singleton
        /// </summary>
        public static Database Instance
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

        /// <summary>
        /// Methode zum ausführen von update, insert, delete und create
        /// </summary>
        /// <param name="sql">Der SQL Befehl als String</param>
        /// <returns>Anzahl der betroffenen Zeilen als int</returns>
        public int ExecuteNonQuery(String sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Methode für Select
        /// </summary>
        /// <param name="sql">Der SQL Befehl als String</param>
        /// <returns>Eine Liste der Ergebnisse als Linked List</returns>
        public LinkedList<Object[]> ExecuteQuery(String sql)
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

        private void CreateTables()
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


            ExecuteNonQuery(USER_TBL);
            ExecuteNonQuery(STATISTIC_TBL);
        }

        /// <summary>
        /// Prüft die Spielerdaten
        /// </summary>
        /// <param name="benutzername">Benutzername als String</param>
        /// <param name="passwort">Passwort als String</param>
        /// <returns>Gibt die BenutzerID zurück. // kein Fund = -1</returns>
        public int PruefeSpielerDaten(String benutzername, String passwort)
        {
            String sql = "SELECT ID FROM USER WHERE name='" + benutzername + "' and pass='" + passwort + "'";
            LinkedList<Object[]> result = ExecuteQuery(sql);
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

        /// <summary>
        /// Prüft ob ein Benutzername bereits in der Datenbank existiert
        /// </summary>
        /// <param name="benutzername">Benutzername als String</param>
        /// <returns>Bool ob der Benutzer vohanden ist. // true = vorhanden</returns>
        public bool PruefeBenutzerVorhanden(String benutzername)
        {
            String sql = "SELECT ID FROM USER WHERE name='" + benutzername + "'";
            LinkedList<Object[]> result = ExecuteQuery(sql);
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

        /// <summary>
        /// Lädt den Spieler
        /// </summary>
        /// <param name="spielerid">Die Datenbank ID des Spielers, der geladen werden soll als int</param>
        /// <returns>Den geladenen Spieler als Spieler</returns>
        public Spieler LadeSpieler(int spielerid)
        {
            String sql = "SELECT * FROM USER WHERE ID='" + Convert.ToString(spielerid) + "'";
            LinkedList<Object[]> result = ExecuteQuery(sql);
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
        /// Hat der Spieler eine bekannte ID, dann wird ein Update ausgeführt
        /// </summary>
        /// <param name="spieler">Der Spieler als Spieler</param>
        public void SpeichereSpieler(Spieler spieler)
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
            this.ExecuteNonQuery(sql);

        }
        
        /// <summary>
        /// Löscht den Spieler samt Statistik. Die Statistik wird über on delete cascade realisiert.
        /// </summary>
        /// <param name="spieler">Der Spieler als Spieler</param>
        public void loescheSpieler(Spieler spieler)
        {
            String sql = "DELETE FROM USER WHERE ID = " + spieler.id;
            this.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Lädt die Statistik
        /// </summary>
        /// <param name="spieler">Spieler als Spieler</param>
        /// <returns>Gibt die Statistik als Statistik zurück</returns>
        public Statistik LadeStatistik(Spieler spieler)
        {
            String sql = @"SELECT SUM(spiel_gewonnen), SUM(spiel_beendet), AVG(zuege), AVG(zeit)
                           FROM STATISTIK
                           WHERE user_id = " + spieler.id;

            LinkedList<Object[]> result = this.ExecuteQuery(sql);
            Object[] data = result.ElementAt(0);
            // Check we have any NULL value in result
            foreach(var field in data)
            {
                if (field.GetType() == typeof(DBNull)) return null;
            }
            return new Statistik(Convert.ToInt32(data[0]),Convert.ToInt32(data[1]), Convert.ToDouble(data[2]), Convert.ToDouble(data[3]));
        }

        /// <summary>
        /// Löscht die Statistik
        /// </summary>
        /// <param name="spieler">Spieler als Spieler</param>
        public void LoescheStatistik(Spieler spieler)
        {
            String sql = "DELETE FROM STATISTIK WHERE user_id = " + spieler.id;
            this.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Sucht zum Benutzernamen die SpielerID raus
        /// </summary>
        /// <param name="spieler">Spieler als Spieler</param>
        /// <returns>ID</returns>

        private int GetSpielerID(Spieler spieler)
        {
            String sql = "SELECT ID FROM USER WHERE name = '" + spieler.benutzername + "'";
            LinkedList<Object[]> result = this.ExecuteQuery(sql);
            return Convert.ToInt32(result.ElementAt(0)[0]);
        }

        /// <summary>
        /// Erstellt einen neuen Statistik Eintrag im der Datenbank
        /// </summary>
        /// <param name="spieler">Spieler als Spieler</param>
        /// <param name="gewonnen">Gewonnen als Bool // True = Spiel gewonnen</param>
        /// <param name="beendet">Beendet als Bool // True = Beendet</param>
        /// <param name="zuege">Anzahl der Züge als int</param>
        /// <param name="zeit">Anzahl der Zeit als int</param>

        public void StatistikErweitern(Spieler spieler, bool gewonnen, bool beendet, int zuege, int zeit)
        {
            if(gewonnen) beendet = true;
            String sql = @"INSERT INTO STATISTIK (spieler_id, spiel_gewonnen, spiel_beendet, zuege, zeit)
                           VALUES (" + this.GetSpielerID(spieler) + ", "
                                    + Convert.ToInt32(gewonnen) + ", "
                                    + Convert.ToInt32(beendet) + ", "
                                    + zuege + ", "
                                    + zeit + ");";
            this.ExecuteNonQuery(sql);
                                                        
        }

        /// <summary>
        /// Lädt das Regelwerk
        /// </summary>
        /// <returns>Gibt das Regelwerk als String zurück</returns>
        public String ladeRegelwerk()
        {
            return "";
        }
        /// <summary>
        /// Gibt die ID des letzten eingefügten Datensatzes in der Datenbank zurück
        /// </summary>
        /// <returns>ID als int</returns>
        private int GetLastInsertId()
        {
            String sql = "SELECT last_insert_rowid();";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        /// <summary>
        /// Speichert das Spiel
        /// </summary>
        /// <param name="feld">Das Spielfeld als Spielfeld</param>
        /// <param name="sp1">Der erste Spieler als Spieler</param>
        /// <param name="sp2">Der zweite Spieler als Spieler</param>
        public void SpeichereSpiel(Spielfeld feld, Spieler sp1, Spieler sp2)
        {
            // Speichere Spiel
            int game_id;
            String sql = @"INSERT INTO GAME (user_a, user_b) 
                           VALUES
                           (" + sp1.id + ", " + sp2.id + ");";
            this.ExecuteNonQuery(sql);
            game_id = GetLastInsertId();

            // Speichere Spielfiguren
            foreach(Spielfigur sp in feld.Feld)
            {
                int befoerdert = 0;
                int spieler = 0;
                if(sp.IstBefoerdert)
                {
                    befoerdert = 1;
                }
                if (sp.Besitzer == sp2)
                {
                    spieler = 1;
                }
                
                //Build SQL
                String subsql = @"INSERT INTO GAMEDATA (game, figurtyp, befoerdert, spieler, x, y)
                                  VALUES ( "
                                  + game_id + ", '"
                                  + sp.Typ.getName() + "', "
                                  + befoerdert + ", "
                                  + spieler + ", "
                                  + sp.Position.Zeile + ", "
                                  + sp.Position.Spalte + ");";

                this.ExecuteNonQuery(subsql);
            }

        }

        /// <summary>
        /// Lädt das Spielfeld
        /// </summary>
        /// <param name="spielid">Spielid als int</param>
        /// <returns>Gibt das Spielfeld zurück</returns>
        public Spielfeld LadeSpielfeldEinzelSpiel(int spielid)
        {
            String figsql = @"SELECT figurtyp, befoerdert, spieler, x, y
                           FROM GAMEDATA
                           WHERE game = " + spielid + ";";
            LinkedList<Object[]> resfiguren = this.ExecuteQuery(figsql);

            // Spieler abfragen
            String datasql = @"SELECT user_a, user_b FROM GAME WHERE ID="+spielid;
            LinkedList<Object[]> users = this.ExecuteQuery(datasql);
            int spieler1_id = Convert.ToInt32(users.ElementAt(0)[0]);
            int spieler2_id = Convert.ToInt32(users.ElementAt(0)[1]);     
            
            // Spieler instanzieren
            Spieler sp1 = this.LadeSpieler(spieler1_id);
            Spieler sp2 = this.LadeSpieler(spieler2_id);

            // Reinstanziere Spielfiguren
            List<Spielfigur> figuren = new List<Spielfigur>();
            foreach(var figur in resfiguren)
            {
                Spieler owner = sp1;
                if(Convert.ToInt32(figur[2]) == 1)
                {
                    owner = sp2;
                }

                Spielfigur tmpFigur = new Spielfigur(
                                                     FigurTyp.FigurtypVomNamen(figur[0].ToString()), 
                                                     owner, 
                                                     new Position(Convert.ToInt32(figur[3]), Convert.ToInt32(figur[4])));

                figuren.Add(tmpFigur);
            }

            Spielfeld tmpFeld = new Spielfeld(figuren, Spielleiter_Spiellogik.SHOGI_DIM);
            return tmpFeld;
        }

    }
}
