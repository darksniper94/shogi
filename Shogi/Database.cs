using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace Shogi
{
    /// <summary>
    /// Diese Klasse realisiert die Datenhaltung von PandaShogi
    /// Folgende Daten werden verwaltet:
    /// Benutzer
    /// Statistik
    /// Spieldaten pro Benutzer
    /// </summary>
    public class Database
    {
        private SQLiteConnection connection;
        private readonly String DBNAME = "data.dat";
        private static Database inst = null;

        /// <summary>
        /// Privater Konstruktor für Singelton
        /// </summary>
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

            String GAMEDATA_TBL = @"CREATE TABLE `GAMEDATA` (
	                                                        `ID`	INTEGER PRIMARY KEY AUTOINCREMENT,
	                                                        `game`	INTEGER,
	                                                        `figurtyp`	TEXT NOT NULL,
	                                                        `befoerdert`	INTEGER NOT NULL,
	                                                        `spieler`	INTEGER,
	                                                        `x`	INTEGER NOT NULL,
	                                                        `y`	INTEGER NOT NULL,
	                                                        FOREIGN KEY(`game`) REFERENCES GAME ( ID ) ON DELETE CASCADE
                                                        );";

            String GAME_TBL = @"CREATE TABLE `GAME` (
	                                                    `ID`	INTEGER PRIMARY KEY AUTOINCREMENT,
	                                                    `user_a`	INTEGER NOT NULL,
	                                                    `user_b`	INTEGER NOT NULL,
	                                                    `user_active`	INTEGER,
	                                                    FOREIGN KEY(`user_a`) REFERENCES USER ( ID ),
	                                                    FOREIGN KEY(`user_b`) REFERENCES USER ( ID )
                                                    );";

            ExecuteNonQuery(USER_TBL);
            ExecuteNonQuery(STATISTIC_TBL);
            ExecuteNonQuery(GAME_TBL);
            ExecuteNonQuery(GAMEDATA_TBL);
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
        public void LoescheSpieler(Spieler spieler)
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
        /// Aktualisiert das Design des Spielers
        /// </summary>
        /// <param name="spieler">Spieler</param>

        public void DesignAktualisieren(Spieler spieler)
        {
            string sql = "UPDATE USER SET design = '" + spieler.design + "' WHERE ID=" + spieler.id;
            this.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Aktualisiert das die Farbe des Spielfeldes vom Spielers
        /// </summary>
        /// <param name="spieler">Spieler</param>

        public void FarbeAktualisieren(Spieler spieler)
        {
            string sql = "UPDATE USER SET color = '" + spieler.farbe + "' WHERE ID=" + spieler.id;
            this.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// Aktualisiert den Benutzernamen des Spielers
        /// </summary>
        /// <param name="spieler">Spieler</param>

        public void BenutzernameAktualisieren(Spieler spieler)
        {
            string sql = "UPDATE USER SET name = '" + spieler.benutzername + "' WHERE ID=" + spieler.id;
            this.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// Aktualisiert das Passwort des Spielers
        /// </summary>
        /// <param name="spieler">Spieler</param>

        public void PasswortAktualisieren(Spieler spieler)
        {
            string sql = "UPDATE USER SET pass = '" + spieler.passwort + "' WHERE ID=" + spieler.id;
            this.ExecuteNonQuery(sql);
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
            String sql = @"INSERT INTO STATISTIK (user_id, spiel_gewonnen, spiel_beendet, zuege, zeit)
                           VALUES (" + spieler.id + ", "
                                    + Convert.ToInt32(gewonnen) + ", "
                                    + Convert.ToInt32(beendet) + ", "
                                    + zuege + ", "
                                    + zeit + ");";
            this.ExecuteNonQuery(sql);
                                                        
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
            int spieler = 0;
            if (Spielleiter_Spiellogik.instance.AktiverSpieler == sp2)
            {
                spieler = 1;
            }

            String sql = @"INSERT INTO GAME (user_a, user_b, user_active) 
                           VALUES
                           (" + sp1.id + ", " + sp2.id + ", "+ spieler+");";
            this.ExecuteNonQuery(sql);
            game_id = GetLastInsertId();

            // Speichere Spielfiguren
            foreach(Spielfigur sp in feld.Feld)
            {
                int befoerdert = 0;
                spieler = 0;
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
                                  + sp.Position.Spalte + ", "
                                  + sp.Position.Zeile + ");";

                this.ExecuteNonQuery(subsql);
            }

        }

        /// <summary>
        /// Lädt das Spielfeld
        /// </summary>
        /// <param name="spielid">Spielid als int</param>
        /// <returns>Gibt das Spielfeld zurück</returns>
        private Spielfeld LadeSpielfeld(int spielid, Spieler sp1, Spieler sp2)
        {
            String figsql = @"SELECT figurtyp, befoerdert, spieler, x, y
                              FROM GAMEDATA
                              WHERE game = " + spielid + ";";

            LinkedList<Object[]> resfiguren = this.ExecuteQuery(figsql);

            // Reinstanziere Spielfiguren
            List<Spielfigur> figuren = new List<Spielfigur>();
            foreach(var figur in resfiguren)
            {
                Spieler owner = sp2;
                if(Convert.ToInt32(figur[2]) == 1)
                {
                    owner = sp1;
                }

                Spielfigur tmpFigur = new Spielfigur(
                                                     FigurTyp.FigurtypVomNamen(Convert.ToString(figur[0])), 
                                                     owner, 
                                                     new Position(Convert.ToInt32(figur[3]), Convert.ToInt32(figur[4])));

                figuren.Add(tmpFigur);
            }


            return new Spielfeld(figuren, Spielleiter_Spiellogik.SHOGI_DIM, Spielleiter_Spiellogik.SHOGI_FIGUREN);
        }
        /// <summary>
        /// Lädt das letzte vom Benutzer gespeicherte Einzelspiel
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public Spielfeld LadeLetztesEinzelSpiel(Spieler sp1, Spieler sp2)
        {
            String sql = @"SELECT ID FROM GAME " +
                           "WHERE user_a = "+ sp1.id +
                           " ORDER BY ID DESC " +
                           " LIMIT 1";

            LinkedList<Object[]> result = this.ExecuteQuery(sql);
            if(result.Count == 0)
            {
                return null;
            }
            int game_id = Convert.ToInt32(result.ElementAt(0)[0]);

            return LadeSpielfeld(game_id, sp1, sp2);

        }

        /// <summary>
        /// Gibt den aktiven Spieler aus dem letzten geladenen Spiel zurück
        /// </summary>
        /// <param name="sp1">spAngemeldet</param>
        /// <param name="sp2">spAngemeldet2</param>
        /// <returns></returns>
        public Spieler LadeAktivenSpielerLeztesSpiel(Spieler sp1, Spieler sp2)
        {
            String sql = @"SELECT user_active FROM GAME " +
               "WHERE user_a = " + sp1.id + " AND " +
               " user_b = " +sp2.id +
               " ORDER BY ID DESC " +
               " LIMIT 1";

            LinkedList<Object[]> result = this.ExecuteQuery(sql);
            if (result.Count == 0)
            {
                return null;
            }
            int aktiver = Convert.ToInt32(result.ElementAt(0)[0]);
            if(aktiver == 1)
            {
                return sp1;
            }
            else
            {
                return sp2;
            }
        }


    }
}
