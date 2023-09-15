using Gestcom.Models;
using System.Collections.Generic;
using System.Data.OleDb;
using Gestcom.DataAccess;
using System;
using System.Windows;

namespace Gestcom.ModelAdo
{
    public class ArticleAdo : DataAdo
    {
        public static List<Article> all()
        {
            try
            {
         
                List<Article> articles = new List<Article>();
                OleDbDataReader reader;
                open();
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM TB_Articles");
                oleDbCommand.Connection = connection;
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    Article article = new Article((Decimal)reader["ARNUM"], (String)reader["ARDESI"], (String)reader["ARFAMI"],
                        (String)reader["ARUNIT"], (Decimal)reader["ARPRIX"], (Decimal)reader["ARTVA"], (Decimal)reader["ARPOID"], (String)reader["ARCEC"], (String)reader["ARDIV"], (String)reader["ARSUPP"]);
                    articles.Add(article);
                }
                Console.WriteLine(reader);
                reader.Close();
                return articles;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return null;
            }
            finally
            {
                close();
            }
        }
    }
}
