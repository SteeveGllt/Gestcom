using Gestcom.DataAccess;
using Gestcom.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Gestcom.ModelAdo
{
    public class LotAdo : DataAdo
    {
        public static Lot ExisteLot(decimal lofrom, decimal loanne, decimal lomois)
        {
            try
            {

                Lot lot = new Lot();
                OleDbDataReader reader;
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "SELECT LOFACO, LOFROM, LOANNE, LOMOIS, LODEP FROM TB_Lots WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);
                oleDbCommand.ExecuteNonQuery();
                reader = oleDbCommand.ExecuteReader();

                if (reader.Read())
                {
                    // Si la requête a retourné des résultats, créez un objet Lot
                    lot = new Lot
                    {
                        // Assurez-vous de récupérer les valeurs appropriées depuis le reader
                        LOFACO = reader.GetDecimal(0),
                        LOFROM = reader.GetDecimal(1),
                        LOANNE = reader.GetDecimal(2),
                        LOMOIS = reader.GetDecimal(3),
                        LODEP = reader.GetDecimal(4)
                    };
                    MessageBox.Show("Le Lot Existe");
                    return lot;
                }
                else
                {
                    MessageBox.Show("Lot Nouveau");
                    return null;
                }

            }
            catch (Exception ex)
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

        public static void updateLot(decimal lofrom, decimal loanne, decimal lomois, decimal nbPains, decimal poidsBrut, decimal poidsNet)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOCEM1 = @LOCEM1, LOCEB1 = @LOCEB1, LOCEN1 = @LOCEN1 WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOCEM1", nbPains);
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", poidsBrut);
                oleDbCommand.Parameters.AddWithValue("@LOCEN1", poidsNet);
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);
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

        public static void createLot(Lot lot)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "INSERT INTO TB_Lots(LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, LOCEM1, LOCEB1, LOCEN1, LOCPES, LOCC1) VALUES(1, @LOFROM, @LOANNE, @LOMOIS, 0, @LOCEM1, @LOCEB1, @LOCEN1, 0, 0)";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lot.LOFROM);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", lot.LOANNE);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lot.LOMOIS);
                oleDbCommand.Parameters.AddWithValue("@LOCEM1", lot.LOCEM1);
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", lot.LOCEB1);
                oleDbCommand.Parameters.AddWithValue("@LOCEN1", lot.LOCEN1);
                oleDbCommand.ExecuteNonQuery();
                Console.WriteLine("Lot créé");
                MessageBox.Show("Lot créé");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally { close(); }
        }

        public static void createEntreeLot(EntreeLot entreeLot)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "INSERT INTO TB_Entrée_Lots(LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, Date_Entrée, Date_Début, DAte_Fin, LOCENM, LOCENB, LOCPES, LOCENN, LOTAUX) VALUES(1, @LOFROM, @LOANNE, @LOMOIS, 0, @Date_Entrée, @Date_Début, @DAte_Fin, @LOCENM, @LOCENB, 0, LOCENN, LOTAUX)";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOFROM", entreeLot.LOFROM);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", entreeLot.LOANNE);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", entreeLot.LOMOIS);
                oleDbCommand.Parameters.AddWithValue("@Date_Entrée", entreeLot.Date_Entrée.ToString("MM/dd/yyyy"));
                oleDbCommand.Parameters.AddWithValue("@Date_Début", entreeLot.Date_Début.ToString("MM/dd/yyyy"));
                oleDbCommand.Parameters.AddWithValue("@DAte_Fin", entreeLot.DAte_Fin.ToString("MM/dd/yyyy"));
         
                oleDbCommand.Parameters.AddWithValue("@LOCENM", entreeLot.LOCENM); // Pains
                oleDbCommand.Parameters.AddWithValue("@LOCENB", entreeLot.LOCENB); // Brut
                oleDbCommand.Parameters.AddWithValue("@LOCENN", entreeLot.LOCENN); // Net
                oleDbCommand.Parameters.AddWithValue("@LOTAUX", entreeLot.LOTAUX); // Freinte
                oleDbCommand.ExecuteNonQuery();
                Console.WriteLine("Lot créé dans entrée lot");
                MessageBox.Show("Lot créé dans entrée lot");
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
