using System;
using System.Windows;
using System.Data.OleDb;

namespace GestcomWF.DataAccess
{
    // Déclaration d'une classe abstraite DataAdo
    public abstract class DataAdo
    {
        // Déclaration d'une variable de connexion statique
        public static OleDbConnection connection;

        // Méthode protégée et statique pour ouvrir une connexion à la base de données
        protected static void open()
        {
            // Chaînes de connexion (commentées) pour différentes bases de données
            //string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=E:\Dossier Dev\Informatique\Bases\TB_Gestcom_Bis_1.accdb;Persist Security Info=False;";
            //string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\steev\Desktop\Informatique\Bases\TB_Gestcom_Bis_Serveur.accdb;Persist Security Info=False;";

            // Chaîne de connexion active
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=E:\Dossier Dev\Informatique\Bases\TB_Gestcom_Bis_Lig.accdb;Persist Security Info=False;";

            // Autres chaînes de connexion possibles (commentées)
            //string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=F:\Projets\Informatique\Bases\TB_GestCom_Bis.accdb;Persist Security Info=False;";
            //string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=\\SRVBRUN-files\Bases\TB_GestCom_Bis.accdb;Persist Security Info=False;";

            try
            {
                // Initialisation de la connexion avec la chaîne de connexion spécifiée
                connection = new OleDbConnection(connectionString);

                // Ouverture de la connexion
                connection.Open();

                // Affichage d'un message de confirmation dans la console
                Console.WriteLine("Connexion ouverte");
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);

                // Affichage d'une boîte de dialogue avec un message d'erreur
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
        }

        // Méthode protégée et statique pour fermer la connexion à la base de données
        protected static void close()
        {
            // Vérification si la connexion n'est pas nulle
            if (connection != null)
            {
                // Fermeture de la connexion
                connection.Close();

                // Affichage d'un message de confirmation dans la console
                Console.WriteLine("Connexion fermée");
            }
        }
    }
}

