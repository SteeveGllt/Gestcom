using System;
using System.Windows;
using System.Data.OleDb;

namespace GestcomWF.DataAccess
{
    public abstract class DataAdo
    {
        public static OleDbConnection connection;
        protected static void open()
        {
            //string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\steev\Desktop\Informatique\Bases\TB_GestCom_Bis.accdb;Persist Security Info=False;";
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=F:\Projets\Informatique\Bases\TB_GestCom_Bis.accdb;Persist Security Info=False;";
            try
            {
                connection = new OleDbConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connexion ouverte");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
        }
        protected static void close()
        {
            if (connection != null)
            {
                connection.Close();
                Console.WriteLine("Connexion fermée");
            }
        }


    }
}
