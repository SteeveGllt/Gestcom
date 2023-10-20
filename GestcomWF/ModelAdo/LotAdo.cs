using Gestcom.Classes;
using Gestcom.Models;
using GestcomWF.Classes;
using GestcomWF.DataAccess;
using Microsoft.VisualBasic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Gestcom.ModelAdo
{
    public class LotAdo : DataAdo
    {
        /// <summary>
        /// Vérifie si un lot existe déjà dans la base de données.
        /// </summary>
        /// <param name="lofrom">Paramètre LOFROM.</param>
        /// <param name="loanne">Paramètre LOANNE.</param>
        /// <param name="lomois">Paramètre LOMOIS.</param>
        /// <returns>Retourne un objet Lot si le lot existe, sinon null.</returns>
        public static Lot ExisteLot(decimal lofrom, decimal loanne, decimal lomois)
        {
            try
            {
                // Initialisation de l'objet Lot
                Lot lot = new Lot();
                OleDbDataReader reader;

                // Ouverture de la connexion
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Requête SQL pour vérifier l'existence d'un lot
                oleDbCommand.CommandText = "SELECT LOFACO, LOFROM, LOANNE, LOMOIS, LODEP FROM TB_Lots WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";

                // Préparation et exécution de la requête
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
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOCEM1 = LOCEM1 + @LOCEM1, LOCEB1 = LOCEB1 + @LOCEB1, LOCEN1 = LOCEN1 + @LOCEN1 WHERE LOFACO = 1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP = 0";
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
                oleDbCommand.CommandText = "INSERT INTO TB_Lots(LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, LOCEM1, LOCEB1, LOCEN1, LOCPES, LOCC1, LOC11, LOC12, LOC13) VALUES(1, @LOFROM, @LOANNE, @LOMOIS, 0, @LOCEM1, @LOCEB1, @LOCEN1, 0, 0, 0, 0, 0)";
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
                oleDbCommand.CommandText = "INSERT INTO TB_Entrée_Lots(LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, Date_Entrée, Date_Début, DAte_Fin, LOCENM, LOCENB, LOCPES, LOCENN, LOTAUX) VALUES(1, @LOFROM, @LOANNE, @LOMOIS, 0, @Date_Entrée, @Date_Début, @DAte_Fin, @LOCENM, @LOCENB, 0, @LOCENN, @LOTAUX)";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOFROM", entreeLot.LOFROM);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", entreeLot.LOANNE);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", entreeLot.LOMOIS);
                oleDbCommand.Parameters.AddWithValue("@Date_Entrée", entreeLot.Date_Entrée.ToString("dd/MM/yyyy"));
                oleDbCommand.Parameters.AddWithValue("@Date_Début", entreeLot.Date_Début.ToString("dd/MM/yyyy"));
                oleDbCommand.Parameters.AddWithValue("@DAte_Fin", entreeLot.DAte_Fin.ToString("dd/MM/yyyy"));

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
                MessageBox.Show("Erreur de communication avec la base de données!" + ex);
            }
            finally { close(); }
        }
        public static void createEntreeLotAffine(EntreeLot entreeLot)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "INSERT INTO TB_Entrée_Lots(LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, Date_Entrée, LOCENM, LOCENB, LOCPES, LOCENN, LOTAUX) VALUES(1, @LOFROM, @LOANNE, @LOMOIS, 0, @Date_Entrée, @LOCENM, @LOCENB, 0, LOCENN, LOTAUX)";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOFROM", entreeLot.LOFROM);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", entreeLot.LOANNE);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", entreeLot.LOMOIS);
                oleDbCommand.Parameters.AddWithValue("@Date_Entrée", entreeLot.Date_Entrée.ToString("dd/MM/yyyy"));

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
        public static List<EntreeLotFrom> allEntreeEnFonctionDuMoisEtDeLannee(decimal mois, decimal annee)
        {
            try
            {

                List<EntreeLotFrom> entreeLotFroms = new List<EntreeLotFrom>();
                OleDbDataReader reader;
                open();
                //OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM TB_Entrée_Lots WHERE LOMOIS = @LOMOIS AND LOANNE = @LOANNE");
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT TB_Entrée_Lots.LOFROM, TB_Entrée_Lots.LOANNE, TB_Entrée_Lots.LOMOIS, TB_Entrée_Lots.Date_Entrée, " +
                    "TB_Entrée_Lots.LOCENM, TB_Entrée_Lots.LOCENB, TB_Entrée_Lots.LOCENN, TB_Entrée_Lots.LOTAUX, TB_Fromageries.FRNUM, TB_Fromageries.FRNOM, " +
                    "TB_Fromageries.FRADR, TB_Fromageries.FRCPOS, TB_Fromageries.FRVILL, TB_Fromageries.FRNDIR FROM TB_Entrée_Lots INNER JOIN TB_Fromageries ON " +
                    "TB_Entrée_Lots.LOFROM = TB_Fromageries.FRNUM WHERE LOMOIS = @LOMOIS AND LOANNE = @LOANNE");
                oleDbCommand.Connection = connection;
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", mois);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", annee);
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    EntreeLotFrom entreeLotFrom = new EntreeLotFrom((Decimal)reader["LOFROM"], (Decimal)reader["LOANNE"],
                        (Decimal)reader["LOMOIS"], (DateTime)reader["Date_Entrée"],
                        (Decimal)reader["LOCENM"], (Decimal)reader["LOCENB"], (Decimal)reader["LOCENN"], (Decimal)reader["LOTAUX"], (Decimal)reader["FRNUM"],
                        (String)reader["FRNOM"], (String)reader["FRADR"], (Decimal)reader["FRCPOS"],
                        (String)reader["FRVILL"], (String)reader["FRNDIR"]);
                    entreeLotFroms.Add(entreeLotFrom);
                }
                Console.WriteLine(reader);
                reader.Close();
                return entreeLotFroms;
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
        public static List<Lot> allLot(decimal loanne, decimal lomois)
        {
            try
            {
                Lot lot = new Lot();
                List<Lot> lots = new List<Lot>();
                OleDbDataReader reader;
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "SELECT LOFROM, LOCEM1, LOC11, LOC12, LOC13 FROM TB_Lots WHERE LOANNE = @LOANNE AND LOMOIS = @LOMOIS";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);
                oleDbCommand.ExecuteNonQuery();
                reader = oleDbCommand.ExecuteReader();

                while (reader.Read())
                {
                    // Vérifiez si l'une des colonnes est null
                    if (reader.IsDBNull(reader.GetOrdinal("LOFROM")) ||
                        reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ||
                        reader.IsDBNull(reader.GetOrdinal("LOC11")) ||
                        reader.IsDBNull(reader.GetOrdinal("LOC12")) ||
                        reader.IsDBNull(reader.GetOrdinal("LOC13")))
                    {
                        return null;
                    }

                    // Si toutes les colonnes contiennent des données, créez un objet Lot
                    lot = new Lot((Decimal)reader["LOFROM"], (Decimal)reader["LOCEM1"], (Decimal)reader["LOC11"], (Decimal)reader["LOC12"], (Decimal)reader["LOC13"]);
                    lots.Add(lot);
                }


                return lots;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!" + ex);
                return null;
            }
            finally
            {
                close();
            }
        }

        public static void updateLotClassement(decimal lofrom, decimal loanne, decimal lomois, decimal a, decimal b, decimal c)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOC11 = @LOC11, LOC12 = @LOC12, LOC13 = @LOC13 WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOC11", a);
                oleDbCommand.Parameters.AddWithValue("@LOC12", b);
                oleDbCommand.Parameters.AddWithValue("@LOC13", c);
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
        public static List<LotFrom> generationFichierExcelClassement(decimal mois, decimal annee)
        {
            try
            {

                List<LotFrom> lots = new List<LotFrom>();
                OleDbDataReader reader;
                open();
                //OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM TB_Entrée_Lots WHERE LOMOIS = @LOMOIS AND LOANNE = @LOANNE");
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT TB_Lots.LOFROM, TB_Fromageries.FRNOM, TB_Fromageries.FRNDIR, TB_Fromageries.FRADR, TB_Fromageries.FRCPOS, TB_Lots.LOCEM1, TB_Lots.LOC11, TB_Lots.LOC12, TB_Lots.LOC13, " +
                    " TB_Lots.LOANNE, TB_Lots.LOMOIS, TB_Fromageries.FRVILL, TB_Fromageries.FRNUM FROM TB_Fromageries INNER JOIN TB_Lots ON TB_Fromageries.FRNUM = TB_Lots.LOFROM" +
                    " WHERE LOMOIS = @LOMOIS AND LOANNE = @LOANNE AND TB_Lots.LODEP = 0 ORDER BY TB_Lots.LOFROM; ");
                oleDbCommand.Connection = connection;
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", mois);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", annee);
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    LotFrom lot = new LotFrom((Decimal)reader["LOFROM"], (String)reader["FRNOM"], (String)reader["FRNDIR"], (String)reader["FRADR"], (Decimal)reader["FRCPOS"], (Decimal)reader["LOCEM1"], (Decimal)reader["LOC11"], (Decimal)reader["LOC12"], (Decimal)reader["LOC13"],
                        (Decimal)reader["LOANNE"],
                        (Decimal)reader["LOMOIS"],
                        (String)reader["FRVILL"],
                        (Decimal)reader["FRNUM"]);
                    lots.Add(lot);
                }
                Console.WriteLine(reader);
                reader.Close();
                return lots;
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
    }
    
}
