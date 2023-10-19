using Gestcom.Models;
using System.Collections.Generic;
using System.Data.OleDb;
using System;
using System.Windows;
using GestcomWF.DataAccess;

namespace Gestcom.ModelAdo
{
    // Cette classe représente le Data Access Object (DAO) pour la table TB_Articles.
    // Elle hérite de DataAdo pour utiliser ses méthodes d'accès à la base de données.
    public class ArticleAdo : DataAdo
    {
        // Méthode pour récupérer tous les articles de la base de données.
        public static List<Article> all()
        {
            try
            {
                // Initialisation de la liste pour stocker les articles récupérés.
                List<Article> articles = new List<Article>();

                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données (héritée de DataAdo).
                open();

                // Création de la commande SQL pour sélectionner tous les articles.
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM TB_Articles");

                // Liaison de la commande à la connexion.
                oleDbCommand.Connection = connection;

                // Exécution de la commande et récupération du résultat dans le reader.
                reader = oleDbCommand.ExecuteReader();

                // Parcours du résultat ligne par ligne.
                while (reader.Read())
                {
                    // Création d'un objet Article à partir des données de la ligne actuelle.
                    Article article = new Article((Decimal)reader["ARNUM"], (String)reader["ARDESI"], (String)reader["ARFAMI"],
                        (String)reader["ARUNIT"], (Decimal)reader["ARPRIX"], (Decimal)reader["ARTVA"], (Decimal)reader["ARPOID"], (String)reader["ARCEC"], (String)reader["ARDIV"], (String)reader["ARSUPP"]);

                    // Ajout de l'article à la liste.
                    articles.Add(article);
                }

                // Ce WriteLine semble inutile. Il affichera simplement le type d'objet OleDbDataReader.
                Console.WriteLine(reader);

                // Fermeture du reader.
                reader.Close();

                // Retour de la liste d'articles.
                return articles;
            }
            catch (Exception ex) // En cas d'erreur lors de l'exécution.
            {
                // Affichage du message d'erreur dans la console.
                Console.WriteLine(ex.Message);

                // Affichage d'une boîte de message avec un message d'erreur générique pour l'utilisateur.
                MessageBox.Show("Erreur de communication avec la base de données!");

                // Retour null en cas d'erreur.
                return null;
            }
            finally
            {
                // Assure que la connexion à la base de données est fermée, quelle que soit l'issue de la méthode.
                close();
            }
        }
    }
}
