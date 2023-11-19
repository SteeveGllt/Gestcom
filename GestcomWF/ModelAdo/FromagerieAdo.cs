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

        public static List<Fromagerie> allData()
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
    }
}
