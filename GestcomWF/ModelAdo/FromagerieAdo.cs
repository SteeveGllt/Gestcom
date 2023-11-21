using Gestcom.Models;
using GestcomWF.DataAccess;
using System.Data.OleDb;

namespace Gestcom.ModelAdo
{
    // Cette classe représente le Data Access Object (DAO) pour la table TB_Fromageries.
    // Elle hérite de DataAdo pour utiliser ses méthodes d'accès à la base de données.
    public class FromagerieAdo : DataAdo
    {
        // Récupère tous les éléments actifs de la table TB_Fromageries.
        public static List<Fromagerie> all()
        {
            try
            {
                // Initialisation de la liste pour stocker les fromageries récupérées.
                List<Fromagerie> fromageries = new List<Fromagerie>();

                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données.
                open();

                // Création de la commande SQL pour sélectionner les fromageries actives.
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT FRNUM FROM TB_Fromageries WHERE ((FRACTIF)=True) ORDER BY FRNUM");
                oleDbCommand.Connection = connection;

                reader = oleDbCommand.ExecuteReader();

                // Parcours du résultat ligne par ligne.
                while (reader.Read())
                {
                    // Création d'un objet Fromagerie à partir du numéro récupéré.
                    Fromagerie fromagerie = new Fromagerie((Decimal)reader["FRNUM"]);

                    fromageries.Add(fromagerie);
                }

                // Affichage inutile du reader. À supprimer si non nécessaire.
                Console.WriteLine(reader);

                reader.Close();

                return fromageries;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return null;
            }
            finally
            {
                // Assure que la connexion est fermée après l'exécution.
                close();
            }
        }

        // Récupère tous les éléments non actifs de la table TB_Fromageries.
        public static List<Fromagerie> allNonActif()
        {
            try
            {
                // Initialisation de la liste pour stocker les fromageries récupérées.
                List<Fromagerie> fromageries = new List<Fromagerie>();

                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données.
                open();

                // Création de la commande SQL pour sélectionner les fromageries non actives.
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT FRNUM FROM TB_Fromageries WHERE ((FRACTIF)=False) ORDER BY FRNUM");
                oleDbCommand.Connection = connection;

                reader = oleDbCommand.ExecuteReader();

                // Parcours du résultat ligne par ligne.
                while (reader.Read())
                {
                    // Création d'un objet Fromagerie à partir du numéro récupéré.
                    Fromagerie fromagerie = new Fromagerie((Decimal)reader["FRNUM"]);

                    fromageries.Add(fromagerie);
                }

                // Affichage inutile du reader. À supprimer si non nécessaire.
                Console.WriteLine(reader);

                reader.Close();

                return fromageries;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return null;
            }
            finally
            {
                // Assure que la connexion est fermée après l'exécution.
                close();
            }
        }

        public static Fromagerie allData(decimal frnum)
        {
            try
            {
                // Initialisation de la liste pour stocker les fromageries récupérées.
                Fromagerie fromagerie = null;

                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données.
                open();

                // Création de la commande SQL pour sélectionner les fromageries actives.
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM TB_Fromageries WHERE ((FRACTIF)=True) AND FRNUM = @FRNUM ORDER BY FRNUM");
                oleDbCommand.Connection = connection;
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@FRNUM", frnum);
                reader = oleDbCommand.ExecuteReader();

                // Parcours du résultat ligne par ligne.
                while (reader.Read())
                {
                    decimal defaultDecimal = 0m;
                    string defaultString = "";
                    bool defaultBool = true;
                    // Création d'un objet Fromagerie à partir du numéro récupéré.
                    fromagerie = new Fromagerie(
                         reader.IsDBNull(reader.GetOrdinal("FRNUM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRNUM")),
 reader.IsDBNull(reader.GetOrdinal("FRNOM")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNOM")),
 reader.IsDBNull(reader.GetOrdinal("FRADR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRADR")),
 reader.IsDBNull(reader.GetOrdinal("FRCPOS")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRCPOS")),
 reader.IsDBNull(reader.GetOrdinal("FRVILL")) ? defaultString : reader.GetString(reader.GetOrdinal("FRVILL")),
reader.IsDBNull(reader.GetOrdinal("FRNDIR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNDIR")),
reader.IsDBNull(reader.GetOrdinal("FRTYPE")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRTYPE")),
reader.IsDBNull(reader.GetOrdinal("FRTCON")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRTCON")),
reader.IsDBNull(reader.GetOrdinal("FRCMEU")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRCMEU")),
reader.IsDBNull(reader.GetOrdinal("FRCPOI")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRCPOI")),
reader.IsDBNull(reader.GetOrdinal("FRMODR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRMODR")),
 reader.IsDBNull(reader.GetOrdinal("FRDOMI")) ? defaultString : reader.GetString(reader.GetOrdinal("FRDOMI")),
reader.IsDBNull(reader.GetOrdinal("FRBANQ")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRBANQ")),
reader.IsDBNull(reader.GetOrdinal("FRGUIC")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRGUIC")),
reader.IsDBNull(reader.GetOrdinal("FRCOM1")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOM1")),
reader.IsDBNull(reader.GetOrdinal("FRCOM2")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOM2")),
 reader.IsDBNull(reader.GetOrdinal("COE1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("COE1")),
 reader.IsDBNull(reader.GetOrdinal("COE2")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("COE2")),
 reader.IsDBNull(reader.GetOrdinal("COE3")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("COE3")),
 reader.IsDBNull(reader.GetOrdinal("COE4")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("COE4")),
 reader.IsDBNull(reader.GetOrdinal("FRREFA")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRREFA")),
 reader.IsDBNull(reader.GetOrdinal("FRPUAC")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRPUAC")),
 reader.IsDBNull(reader.GetOrdinal("FRETRE")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRETRE")),
 reader.IsDBNull(reader.GetOrdinal("FRHIVE")) ? defaultString : reader.GetString(reader.GetOrdinal("FRHIVE")),
 reader.IsDBNull(reader.GetOrdinal("FRCVER")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCVER")),
 reader.IsDBNull(reader.GetOrdinal("FRVVER")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRVVER")),
 reader.IsDBNull(reader.GetOrdinal("FREVER")) ? defaultString : reader.GetString(reader.GetOrdinal("FREVER")),
 reader.IsDBNull(reader.GetOrdinal("FRACTIF")) ? defaultBool : reader.GetBoolean(reader.GetOrdinal("FRACTIF"))
                        );

                }

                // Affichage inutile du reader. À supprimer si non nécessaire.
                Console.WriteLine(reader);

                reader.Close();

                return fromagerie;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return null;
            }
            finally
            {
                // Assure que la connexion est fermée après l'exécution.
                close();
            }
        }

        public static void updateFromagerie(Fromagerie fromagerie)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "UPDATE TB_Fromageries SET FRNUM = @FRNUM, FRNOM = @FRNOM, FRADR = @FRADR, FRCPOS = @FRCPOS, FRVILL = @FRVILL, FRNDIR = @FRNDIR, FRTYPE = @FRTYPE, FRTCON = @FRTCON, FRCMEU = @FRCMEU, FRCPOI = @FRCPOI, FRMODR = @FRMODR, FRDOMI = @FRDOMI, FRBANQ = @FRBANQ, FRGUIC = @FRGUIC, FRCOM1 = @FRCOM1, FRCOM2 = @FRCOM2, COE1 = @COE1, COE2 = @COE2, COE3 = @COE3, COE4 = @COE4, FRREFA = @FRREFA, FRPUAC = @FRPUAC, FRETRE = @FRETRE, FRHIVE = @FRHIVE, FRCVER = @FRCVER, FRVVER = @FRVVER, FREVER = @FREVER, FRACTIF = @FRACTIF WHERE FRNUM = @FRNUM";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@FRNUM", fromagerie.FRNUM);
                oleDbCommand.Parameters.AddWithValue("@FRNOM", fromagerie.FRNOM);
                oleDbCommand.Parameters.AddWithValue("@FRADR", fromagerie.FRADR);
                oleDbCommand.Parameters.AddWithValue("@FRCPOS", fromagerie.FRCPOS);
                oleDbCommand.Parameters.AddWithValue("@FRVILL", fromagerie.FRVILL);
                oleDbCommand.Parameters.AddWithValue("@FRNDIR", fromagerie.FRNDIR);
                oleDbCommand.Parameters.AddWithValue("@FRTYPE", fromagerie.FRTYPE);
                oleDbCommand.Parameters.AddWithValue("@FRTCON", fromagerie.FRTCON);
                oleDbCommand.Parameters.AddWithValue("@FRCMEU", fromagerie.FRCMEU);
                oleDbCommand.Parameters.AddWithValue("@FRCPOI", fromagerie.FRCPOI);
                oleDbCommand.Parameters.AddWithValue("@FRMODR", fromagerie.FRMODR);
                oleDbCommand.Parameters.AddWithValue("@FRDOMI", fromagerie.FRDOMI);
                oleDbCommand.Parameters.AddWithValue("@FRBANQ", fromagerie.FRBANQ);
                oleDbCommand.Parameters.AddWithValue("@FRGUIC", fromagerie.FRGUIC);
                oleDbCommand.Parameters.AddWithValue("@FRCOM1", fromagerie.FRCOM1);
                oleDbCommand.Parameters.AddWithValue("@FRCOM2", fromagerie.FRCOM2);
                oleDbCommand.Parameters.AddWithValue("@COE1", fromagerie.COE1);
                oleDbCommand.Parameters.AddWithValue("@COE2", fromagerie.COE2);
                oleDbCommand.Parameters.AddWithValue("@COE3", fromagerie.COE3);
                oleDbCommand.Parameters.AddWithValue("@COE4", fromagerie.COE4);
                oleDbCommand.Parameters.AddWithValue("@FRREFA", fromagerie.FRREFA);
                oleDbCommand.Parameters.AddWithValue("@FRPUAC", fromagerie.FRPUAC);
                oleDbCommand.Parameters.AddWithValue("@FRETRE", fromagerie.FRETRE);
                oleDbCommand.Parameters.AddWithValue("@FRHIVE", fromagerie.FRHIVE);
                oleDbCommand.Parameters.AddWithValue("@FRCVER", fromagerie.FRCVER);
                oleDbCommand.Parameters.AddWithValue("@FRVVER", fromagerie.FRVVER);
                oleDbCommand.Parameters.AddWithValue("@FREVER", fromagerie.FREVER);
                oleDbCommand.Parameters.AddWithValue("@FRACTIF", fromagerie.FRACTIF);

                oleDbCommand.ExecuteNonQuery();
                MessageBox.Show("Lot Modifié");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally { close(); }
        }
    }
}
