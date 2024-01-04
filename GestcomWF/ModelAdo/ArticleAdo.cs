using Gestcom.Models;
using System.Collections.Generic;
using System.Data.OleDb;
using System;
using System.Windows;
using GestcomWF.DataAccess;
using Microsoft.VisualBasic.Logging;
using GestcomWF.Views;
using GestcomWF.Models;

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
                Article article = new Article();
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
                    decimal defaultDecimal = 0m;
                    string defautString = "";


                    // Si toutes les colonnes contiennent des données, créez un objet Lot
                    //lot = new Lot((Decimal)reader["LOFROM"], (Decimal)reader["LOCEM1"], (Decimal)reader["LOC11"], (Decimal)reader["LOC12"], (Decimal)reader["LOC13"]);
                    article = new Article(
                         reader.IsDBNull(reader.GetOrdinal("ARNUM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("ARNUM")),
                        reader.IsDBNull(reader.GetOrdinal("ARDESI")) ? defautString : reader.GetString(reader.GetOrdinal("ARDESI")),
                        reader.IsDBNull(reader.GetOrdinal("ARFAMI")) ? defautString : reader.GetString(reader.GetOrdinal("ARFAMI")),
                        reader.IsDBNull(reader.GetOrdinal("ARUNIT")) ? defautString : reader.GetString(reader.GetOrdinal("ARUNIT")),
                        reader.IsDBNull(reader.GetOrdinal("ARPRIX")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("ARPRIX")),
                        reader.IsDBNull(reader.GetOrdinal("ARTVA")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("ARTVA")),
                        reader.IsDBNull(reader.GetOrdinal("ARPOID")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("ARPOID")),
                        reader.IsDBNull(reader.GetOrdinal("ARCEC")) ? defautString : reader.GetString(reader.GetOrdinal("ARCEC")),
                        reader.IsDBNull(reader.GetOrdinal("ARDIV")) ? defautString : reader.GetString(reader.GetOrdinal("ARDIV")),
                        reader.IsDBNull(reader.GetOrdinal("ARSUPP")) ? defautString : reader.GetString(reader.GetOrdinal("ARSUPP"))
                        );

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

        public static void createArticle(Article article)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "INSERT INTO TB_Articles(ARNUM, ARDESI, ARFAMI, ARUNIT, ARPRIX, ARTVA, ARPOID, ARCEC, ARDIV, ARSUPP) VALUES(@ARNUM, @ARDESI, @ARFAMI, @ARUNIT, @ARPRIX, @ARTVA, @ARPOID, @ARCEC, @ARDIV, @ARSUPP)";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@ARNUM", article.ARNUM);
                oleDbCommand.Parameters.AddWithValue("@ARDESI", article.ARDESI);
                oleDbCommand.Parameters.AddWithValue("@ARFAMI", article.ARFAMI);
                oleDbCommand.Parameters.AddWithValue("@ARUNIT", article.ARUNIT);
                oleDbCommand.Parameters.AddWithValue("@ARPRIX", article.ARPRIX);
                oleDbCommand.Parameters.AddWithValue("@ARTVA", article.ARTVA);
                oleDbCommand.Parameters.AddWithValue("@ARPOID", article.ARPOID);
                oleDbCommand.Parameters.AddWithValue("@ARCEC", article.ARCEC);
                oleDbCommand.Parameters.AddWithValue("@ARDIV", article.ARDIV);
                oleDbCommand.Parameters.AddWithValue("@ARSUPP", article.ARSUPP);
                oleDbCommand.ExecuteNonQuery();
                Console.WriteLine("Article créé");
                MessageBox.Show("Article créé");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally { close(); }
        }

        public static void updateArticle(decimal arnum, string ardesi, string arfami, string arunit, decimal arprix, decimal artva, decimal arpoid, string arcec, string ardiv, string arsupp)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "UPDATE TB_Articles SET ARDESI = @ARDESI, ARFAMI = @ARFAMI, ARUNIT = @ARUNIT, ARPRIX = @ARPRIX, ARTVA = @ARTVA, ARPOID = @ARPOID, ARCEC = @ARCEC, ARDIV = @ARDIV, ARSUPP = @ARSUPP WHERE ARNUM = @ARNUM;";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@ARNUM", arnum);
                oleDbCommand.Parameters.AddWithValue("@ARDESI", ardesi);
                oleDbCommand.Parameters.AddWithValue("@ARFAMI", arfami);
                oleDbCommand.Parameters.AddWithValue("@ARUNIT", arunit);
                oleDbCommand.Parameters.AddWithValue("@ARPRIX", arprix);
                oleDbCommand.Parameters.AddWithValue("@ARTVA", artva);
                oleDbCommand.Parameters.AddWithValue("@ARPOID", arpoid);
                oleDbCommand.Parameters.AddWithValue("@ARCEC", arcec);
                oleDbCommand.Parameters.AddWithValue("@ARDIV", ardiv);
                oleDbCommand.Parameters.AddWithValue("@ARSUPP", arsupp);
                oleDbCommand.ExecuteNonQuery();
                MessageBox.Show("Article Modifié");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally { close(); }
        }

        public static void deleteArticle(decimal arnum)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "DELETE FROM TB_Articles WHERE ARNUM = @ARNUM";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@ARNUM", arnum);
                oleDbCommand.ExecuteNonQuery();
                Console.WriteLine("Article supprimé");
                MessageBox.Show("Article supprimé");
                close();

            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur !");

            }

        }

        public static Article GetArticletDetails(string numeroArticle)
        {
            try
            {
                // Initialisation de la liste pour stocker les fromageries récupérées.
                Article article = null;

                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données.
                open();

                // Création de la commande SQL pour sélectionner les fromageries actives.
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM TB_Articles WHERE ARNUM = @ARNUM");
                oleDbCommand.Connection = connection;
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@ARNUM", numeroArticle);
                reader = oleDbCommand.ExecuteReader();

                // Parcours du résultat ligne par ligne.
                while (reader.Read())
                {
                    // Création d'un objet Client à partir du numéro récupéré.
                    decimal defaultDecimal = 0m;
                    string defautString = "";


                    // Si toutes les colonnes contiennent des données, créez un objet Lot
                    //lot = new Lot((Decimal)reader["LOFROM"], (Decimal)reader["LOCEM1"], (Decimal)reader["LOC11"], (Decimal)reader["LOC12"], (Decimal)reader["LOC13"]);
                    article = new Article(
                         reader.IsDBNull(reader.GetOrdinal("ARNUM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("ARNUM")),
                        reader.IsDBNull(reader.GetOrdinal("ARDESI")) ? defautString : reader.GetString(reader.GetOrdinal("ARDESI")),
                        reader.IsDBNull(reader.GetOrdinal("ARFAMI")) ? defautString : reader.GetString(reader.GetOrdinal("ARFAMI")),
                        reader.IsDBNull(reader.GetOrdinal("ARUNIT")) ? defautString : reader.GetString(reader.GetOrdinal("ARUNIT")),
                        reader.IsDBNull(reader.GetOrdinal("ARPRIX")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("ARPRIX")),
                        reader.IsDBNull(reader.GetOrdinal("ARTVA")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("ARTVA")),
                        reader.IsDBNull(reader.GetOrdinal("ARPOID")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("ARPOID")),
                        reader.IsDBNull(reader.GetOrdinal("ARCEC")) ? defautString : reader.GetString(reader.GetOrdinal("ARCEC")),
                        reader.IsDBNull(reader.GetOrdinal("ARDIV")) ? defautString : reader.GetString(reader.GetOrdinal("ARDIV")),
                        reader.IsDBNull(reader.GetOrdinal("ARSUPP")) ? defautString : reader.GetString(reader.GetOrdinal("ARSUPP"))
                        );

                }

                // Affichage inutile du reader. À supprimer si non nécessaire.
                Console.WriteLine(reader);

                reader.Close();

                return article;
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
