using System;
using System.Data.OleDb;

namespace Gestcom.DataAccess
{
    public abstract class DataAdo
    {

        public static OleDbConnection connection;
        protected static void open()
        {
            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source=\Informatique\Bases\TB_GestCom_Bis.accdb;Persist Security Info=False;";
            try
            {
                connection = new OleDbConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connexion ouverte");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
