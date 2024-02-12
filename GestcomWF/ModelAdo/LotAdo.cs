using Gestcom.Classes;
using Gestcom.Models;
using GestcomWF.Classes;
using GestcomWF.DataAccess;
using Microsoft.VisualBasic;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text.RegularExpressions;
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
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", ((double)poidsBrut));
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
        public static void updateLotAffine(decimal lofrom, decimal loanne, decimal lomois, decimal nbPains, decimal poidsBrut, decimal poidsNet, decimal montant)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOCEM1 = LOCEM1 + @LOCEM1, LOCEB1 = LOCEB1 + @LOCEB1, LOCEN1 = LOCEN1 + @LOCEN1, MONTANT = MONTANT + @MONTANT WHERE LOFACO = 1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP = 0";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOCEM1", nbPains);
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", ((double)poidsBrut));
                oleDbCommand.Parameters.AddWithValue("@LOCEN1", poidsNet);
                oleDbCommand.Parameters.AddWithValue("@MONTANT", (double)montant);
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);
                oleDbCommand.ExecuteNonQuery();

                oleDbCommand.CommandText = "UPDATE TB_Lots SET TB_Lots.LOPUAC = ROUND(TB_Lots.MONTANT / TB_Lots.LOCEN1, 2) WHERE LOFACO = 1 AND LOFROM = " + lofrom + "AND LOANNE =" + loanne + "AND LOMOIS =" + lomois + "AND LODEP = 0";
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

        public static void test(decimal lofrom, decimal loanne, decimal lomois)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Étape 1: Récupérer le montant global et le poids net global
                oleDbCommand.CommandText = "SELECT MONTANT, LOCEN1 FROM TB_Lots WHERE LOFACO = 1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP = 0";
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                OleDbDataReader reader = oleDbCommand.ExecuteReader();
                if (reader.Read())
                {
                    decimal montantGlobal = reader.GetDecimal(0);
                    decimal locen1Global = reader.GetDecimal(1);
                    reader.Close();

                    // Étape 2: Mettre à jour les champs, y compris LOPUAC
                    oleDbCommand.CommandText = "UPDATE TB_Lots SET LOPUAC = @LOPUAC WHERE LOFACO = 1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP = 0";
                    var test = Math.Round(montantGlobal / locen1Global, 2);
                    oleDbCommand.Parameters.AddWithValue("@LOPUAC", (double)test);
                    oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                    oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                    oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                    oleDbCommand.ExecuteNonQuery();
                    MessageBox.Show("Lot Modifié");
                }
                else
                {
                    MessageBox.Show("Aucune correspondance trouvée dans la base de données.");
                }
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
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", ((double)lot.LOCEB1));
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
        public static void createLotAffine(Lot lot)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "INSERT INTO TB_Lots(LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, LOCEM1, LOCEB1, LOCEN1, LOCPES, LOCC1, LOC11, LOC12, LOC13, LOPUAC, MONTANT) VALUES(1, @LOFROM, @LOANNE, @LOMOIS, 0, @LOCEM1, @LOCEB1, @LOCEN1, 0, 0, 0, 0, 0, @LOPUAC, @MONTANT)";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lot.LOFROM);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", lot.LOANNE);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lot.LOMOIS);
                oleDbCommand.Parameters.AddWithValue("@LOCEM1", lot.LOCEM1);
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", ((double)lot.LOCEB1));
                oleDbCommand.Parameters.AddWithValue("@LOCEN1", lot.LOCEN1);
                oleDbCommand.Parameters.AddWithValue("@LOPUAC", Convert.ToDouble(lot.LOPUAC));
                oleDbCommand.Parameters.AddWithValue("@MONTANT", Convert.ToDouble(lot.LOPUAC) * Convert.ToDouble(lot.LOCEN1));
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
                oleDbCommand.CommandText = "INSERT INTO TB_Entrée_Lots(LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, Date_Entrée, LOCENM, LOCENB, LOCPES, LOCENN, LOTAUX, PRIX) VALUES(1, @LOFROM, @LOANNE, @LOMOIS, 0, @Date_Entrée, @LOCENM, @LOCENB, 0, LOCENN, LOTAUX, @PRIX)";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOFROM", entreeLot.LOFROM);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", entreeLot.LOANNE);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", entreeLot.LOMOIS);
                oleDbCommand.Parameters.AddWithValue("@Date_Entrée", entreeLot.Date_Entrée.ToString("dd/MM/yyyy"));

                oleDbCommand.Parameters.AddWithValue("@LOCENM", entreeLot.LOCENM); // Pains
                oleDbCommand.Parameters.AddWithValue("@LOCENB", entreeLot.LOCENB); // Brut
                oleDbCommand.Parameters.AddWithValue("@LOCENN", entreeLot.LOCENN); // Net
                oleDbCommand.Parameters.AddWithValue("@LOTAUX", entreeLot.LOTAUX); // Freinte
                oleDbCommand.Parameters.AddWithValue("@PRIX", Convert.ToDouble(entreeLot.PRIX)); // Freinte
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
                    "TB_Entrée_Lots.LOFROM = TB_Fromageries.FRNUM WHERE LOMOIS = @LOMOIS AND LOANNE = @LOANNE ORDER BY TB_Entrée_Lots.LOFROM,TB_Entrée_Lots.Date_Entrée;");
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
                oleDbCommand.CommandText = "SELECT LOFROM, LOCEM1, LOC11, LOC12, LOC13 FROM TB_Lots INNER JOIN TB_Fromageries ON TB_Lots.LOFROM = TB_Fromageries.FRNUM WHERE ((TB_Fromageries.FRACTIF)=True) AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS ";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);
                oleDbCommand.ExecuteNonQuery();
                reader = oleDbCommand.ExecuteReader();

                while (reader.Read())
                {
                    decimal defaultDecimal = 0m;


                    // Si toutes les colonnes contiennent des données, créez un objet Lot
                    //lot = new Lot((Decimal)reader["LOFROM"], (Decimal)reader["LOCEM1"], (Decimal)reader["LOC11"], (Decimal)reader["LOC12"], (Decimal)reader["LOC13"]);
                    lot = new Lot(
                         reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEM1")),
                        reader.IsDBNull(reader.GetOrdinal("LOC11")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC11")),
                        reader.IsDBNull(reader.GetOrdinal("LOC12")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC12")),
                        reader.IsDBNull(reader.GetOrdinal("LOC13")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC13")));
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
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOCC1 = 1, LOC11 = @LOC11, LOC12 = @LOC12, LOC13 = @LOC13 WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";
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
                    " WHERE ((TB_Fromageries.FRACTIF)=True) AND LOMOIS = @LOMOIS AND LOANNE = @LOANNE AND TB_Lots.LODEP = 0 ORDER BY TB_Lots.LOFROM; ");
                oleDbCommand.Connection = connection;
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", mois);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", annee);
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    decimal defaultDecimal = 0m;
                    string defaultString = "";
                    /* LotFrom lot = new LotFrom((Decimal)reader["LOFROM"], (String)reader["FRNOM"], (String)reader["FRNDIR"], (String)reader["FRADR"], (Decimal)reader["FRCPOS"], (Decimal)reader["LOCEM1"], (Decimal)reader["LOC11"], (Decimal)reader["LOC12"], (Decimal)reader["LOC13"],
                         (Decimal)reader["LOANNE"],
                         (Decimal)reader["LOMOIS"],
                         (String)reader["FRVILL"],
                         (Decimal)reader["FRNUM"]);*/
                    LotFrom lot = new LotFrom(
                         reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                         reader.IsDBNull(reader.GetOrdinal("FRNOM")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNOM")),
                         reader.IsDBNull(reader.GetOrdinal("FRNDIR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNDIR")),
                         reader.IsDBNull(reader.GetOrdinal("FRADR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRADR")),
                         reader.IsDBNull(reader.GetOrdinal("FRCPOS")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRCPOS")),
                        reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEM1")),
                        reader.IsDBNull(reader.GetOrdinal("LOC11")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC11")),
                        reader.IsDBNull(reader.GetOrdinal("LOC12")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC12")),
                        reader.IsDBNull(reader.GetOrdinal("LOC13")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC13")),
                        reader.IsDBNull(reader.GetOrdinal("LOANNE")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOANNE")),
                        reader.IsDBNull(reader.GetOrdinal("LOMOIS")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOMOIS")),
                         reader.IsDBNull(reader.GetOrdinal("FRVILL")) ? defaultString : reader.GetString(reader.GetOrdinal("FRVILL")),
                         reader.IsDBNull(reader.GetOrdinal("FRNUM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRNUM"))
                        );
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
        public static List<Lot> allLotAcompte(decimal loanne, decimal lomois)
        {
            try
            {
                Lot lot = new Lot();
                List<Lot> lots = new List<Lot>();
                OleDbDataReader reader;
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "SELECT LOFROM, LOCEM1, LOPUAC FROM TB_Lots INNER JOIN TB_Fromageries ON TB_Lots.LOFROM = TB_Fromageries.FRNUM WHERE ((TB_Fromageries.FRAFFINE)=False) AND ((TB_Fromageries.FRACTIF)=True) AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);
                oleDbCommand.ExecuteNonQuery();
                reader = oleDbCommand.ExecuteReader();

                while (reader.Read())
                {
                    decimal defaultDecimal = 0m;
                    // Si toutes les colonnes contiennent des données, créez un objet Lot
                    //lot = new Lot((Decimal)reader["LOFROM"], (Decimal)reader["LOCEM1"], (Decimal)reader["LOPUAC"]);
                    lot = new Lot(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEM1")),
                        reader.IsDBNull(reader.GetOrdinal("LOPUAC")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOPUAC"))
                        );
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


        public static void updateLotPrix(decimal lofrom, decimal loanne, decimal lomois, double newPrix)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOPUAC = @LOPUAC WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOPUAC", newPrix);
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally { close(); }
        }
        public static void updateLotPrixAll(decimal newPrix)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOPUAC = @LOPUAC WHERE LOFACO=1 AND LODEP=0";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOPUAC", newPrix);
                oleDbCommand.ExecuteNonQuery();
                MessageBox.Show("Prix de tous les lots modifiés");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally { close(); }
        }

        public static List<Lot> allLotRappel(decimal loanne, decimal lomois)
        {
            try
            {
                List<Lot> lots = new List<Lot>();
                OleDbDataReader reader;
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "SELECT LOFROM, LOCEM1, LOCEN1, LOC11, LOC12, LOC13, LOPU1, LOPU2, LOPU3, MONTANT FROM TB_Lots INNER JOIN TB_Fromageries ON TB_Lots.LOFROM = TB_Fromageries.FRNUM WHERE ((TB_Fromageries.FRAFFINE)=False) AND ((TB_Fromageries.FRACTIF)=True) AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);
                oleDbCommand.ExecuteNonQuery();
                reader = oleDbCommand.ExecuteReader();

                while (reader.Read())
                {
                    // Définissez les valeurs par défaut pour chaque champ qui pourrait être null.
                    decimal defaultDecimal = 0m; // Vous pouvez définir une autre valeur par défaut si nécessaire.

                    // Créez un objet Lot, en utilisant les valeurs par défaut si les champs de la base de données sont DBNull.
                    Lot lot = new Lot(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEM1")),
                        // Répétez pour les autres champs en vérifiant pour chacun s'ils sont null
                        reader.IsDBNull(reader.GetOrdinal("LOCEN1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEN1")),
                        reader.IsDBNull(reader.GetOrdinal("LOC11")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC11")),
                        reader.IsDBNull(reader.GetOrdinal("LOC12")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC12")),
                        reader.IsDBNull(reader.GetOrdinal("LOC13")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC13")),
                        reader.IsDBNull(reader.GetOrdinal("LOPU1")) ? defaultDecimal : Math.Round(reader.GetDecimal(reader.GetOrdinal("LOPU1")), 2),
                        reader.IsDBNull(reader.GetOrdinal("LOPU2")) ? defaultDecimal : Math.Round(reader.GetDecimal(reader.GetOrdinal("LOPU2")), 2),
                        reader.IsDBNull(reader.GetOrdinal("LOPU3")) ? defaultDecimal : Math.Round(reader.GetDecimal(reader.GetOrdinal("LOPU3")), 2),
                        reader.IsDBNull(reader.GetOrdinal("MONTANT")) ? defaultDecimal : Math.Round(reader.GetDecimal(reader.GetOrdinal("MONTANT")), 2)
                    // Ajoutez tous les champs nécessaires pour le constructeur de Lot ici.
                    );

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

        public static void updateLotRappel(decimal lofrom, decimal loanne, decimal lomois, double a, double b, double c, double montant)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOPU1 = @LOPU1, LOPU2 = @LOPU2, LOPU3 = @LOPU3, MONTANT = @MONTANT WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOPU1", a);
                oleDbCommand.Parameters.AddWithValue("@LOPU2", b);
                oleDbCommand.Parameters.AddWithValue("@LOPU3", c);
                oleDbCommand.Parameters.AddWithValue("@MONTANT", montant);
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

        public static List<LotFrom> generationFichierExcelRappel(decimal mois, decimal annee)
        {
            try
            {

                List<LotFrom> lots = new List<LotFrom>();
                OleDbDataReader reader;
                open();
                //OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM TB_Entrée_Lots WHERE LOMOIS = @LOMOIS AND LOANNE = @LOANNE");
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT TB_Lots.LOFROM, TB_Fromageries.FRNOM, TB_Fromageries.FRNDIR, TB_Fromageries.FRADR, TB_Fromageries.FRCPOS, TB_Lots.LOCEN1, TB_Lots.LOCEM1, TB_Lots.LOC11, TB_Lots.LOC12, TB_Lots.LOC13, " +
                    " TB_Lots.LOPUAC, TB_Lots.LOPU1, TB_Lots.LOPU2, TB_Lots.LOPU3, TB_Lots.LOANNE, TB_Lots.LOMOIS, TB_Fromageries.FRVILL, TB_Fromageries.FRNUM, TB_Fromageries.FACTURATION, TB_Fromageries.FRDOMI, TB_Fromageries.FRBANQ, TB_Fromageries.FRGUIC, TB_Fromageries.FRCOM1, TB_Fromageries.FRCOM2 FROM TB_Fromageries INNER JOIN TB_Lots ON TB_Fromageries.FRNUM = TB_Lots.LOFROM" +
                    " WHERE ((TB_Fromageries.FRAFFINE)=False) AND ((TB_Fromageries.FRACTIF)=True) AND LOMOIS = @LOMOIS AND LOANNE = @LOANNE AND TB_Lots.LODEP = 0 ORDER BY TB_Lots.LOFROM; ");
                oleDbCommand.Connection = connection;
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", mois);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", annee);
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    /*LotFrom lot = new LotFrom((Decimal)reader["LOFROM"], (String)reader["FRNOM"], (String)reader["FRNDIR"], (String)reader["FRADR"], (Decimal)reader["FRCPOS"], (Decimal)reader["LOCEN1"], (Decimal)reader["LOCEM1"], (Decimal)reader["LOC11"], (Decimal)reader["LOC12"], (Decimal)reader["LOC13"],
                        (Decimal)reader["LOPUAC"],
                        (Decimal)reader["LOPU1"],
                        (Decimal)reader["LOPU2"],
                        (Decimal)reader["LOPU3"],²
                        (Decimal)reader["LOANNE"],
                        (Decimal)reader["LOMOIS"],
                        (String)reader["FRVILL"],
                        (Decimal)reader["FRNUM"]);*/
                    decimal defaultDecimal = 0m;
                    string defaultString = "";
                    LotFrom lot = new LotFrom(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("FRNOM")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNOM")),
                        reader.IsDBNull(reader.GetOrdinal("FRNDIR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNDIR")),
                        reader.IsDBNull(reader.GetOrdinal("FRADR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRADR")),
                        reader.IsDBNull(reader.GetOrdinal("FRCPOS")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRCPOS")),
                       reader.IsDBNull(reader.GetOrdinal("LOCEN1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEN1")),
                       reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEM1")),
                       reader.IsDBNull(reader.GetOrdinal("LOC11")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC11")),
                       reader.IsDBNull(reader.GetOrdinal("LOC12")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC12")),
                       reader.IsDBNull(reader.GetOrdinal("LOC13")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC13")),
                       reader.IsDBNull(reader.GetOrdinal("LOPUAC")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOPUAC")),
                        reader.IsDBNull(reader.GetOrdinal("LOPU1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOPU1")),
                       reader.IsDBNull(reader.GetOrdinal("LOPU2")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOPU2")),
                       reader.IsDBNull(reader.GetOrdinal("LOPU3")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOPU3")),
                       reader.IsDBNull(reader.GetOrdinal("LOANNE")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOANNE")),
                       reader.IsDBNull(reader.GetOrdinal("LOMOIS")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOMOIS")),
                        reader.IsDBNull(reader.GetOrdinal("FRVILL")) ? defaultString : reader.GetString(reader.GetOrdinal("FRVILL")),
                        reader.IsDBNull(reader.GetOrdinal("FRNUM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRNUM")),
                        reader.IsDBNull(reader.GetOrdinal("FACTURATION")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FACTURATION")),
                        reader.IsDBNull(reader.GetOrdinal("FRDOMI")) ? defaultString : reader.GetString(reader.GetOrdinal("FRDOMI")),
                        reader.IsDBNull(reader.GetOrdinal("FRBANQ")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRBANQ")),
                        reader.IsDBNull(reader.GetOrdinal("FRGUIC")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRGUIC")),
                        reader.IsDBNull(reader.GetOrdinal("FRCOM1")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOM1")),
                        reader.IsDBNull(reader.GetOrdinal("FRCOM2")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOM2"))
                       );
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

        public static List<LotFrom> generationFichierExcelAcompte(decimal mois, decimal annee)
        {
            try
            {

                List<LotFrom> lots = new List<LotFrom>();
                OleDbDataReader reader;
                open();
                //OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM TB_Entrée_Lots WHERE LOMOIS = @LOMOIS AND LOANNE = @LOANNE");
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT TB_Lots.LOFROM, TB_Fromageries.FRNOM, TB_Fromageries.FRNDIR, TB_Fromageries.FRADR, TB_Fromageries.FRCPOS, TB_Lots.LOCEN1, TB_Lots.LOCEM1," +
                    " TB_Lots.LOPUAC, TB_Lots.LOANNE, TB_Lots.LOMOIS, TB_Fromageries.FRVILL, TB_Fromageries.FRNUM, TB_Fromageries.FRDOMI, TB_Fromageries.FRBANQ, TB_Fromageries.FRGUIC, TB_Fromageries.FRCOM1, TB_Fromageries.FRCOM2 FROM TB_Fromageries INNER JOIN TB_Lots ON TB_Fromageries.FRNUM = TB_Lots.LOFROM" +
                    " WHERE ((TB_Fromageries.FRAFFINE)=False) AND ((TB_Fromageries.FRACTIF)=True) AND LOMOIS = @LOMOIS AND LOANNE = @LOANNE AND TB_Lots.LODEP = 0 ORDER BY TB_Lots.LOFROM; ");
                oleDbCommand.Connection = connection;
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", mois);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", annee);
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    /*LotFrom lot = new LotFrom((Decimal)reader["LOFROM"], (String)reader["FRNOM"], (String)reader["FRNDIR"], (String)reader["FRADR"], (Decimal)reader["FRCPOS"], (Decimal)reader["LOCEN1"], (Decimal)reader["LOCEM1"],
                        (Decimal)reader["LOPUAC"],
                        (Decimal)reader["LOANNE"],
                        (Decimal)reader["LOMOIS"],
                        (String)reader["FRVILL"],
                        (Decimal)reader["FRNUM"]);*/
                    decimal defaultDecimal = 0m;
                    string defaultString = "";

                    LotFrom lot = new LotFrom(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("FRNOM")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNOM")),
                        reader.IsDBNull(reader.GetOrdinal("FRNDIR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNDIR")),
                        reader.IsDBNull(reader.GetOrdinal("FRADR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRADR")),
                        reader.IsDBNull(reader.GetOrdinal("FRCPOS")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRCPOS")),
                       reader.IsDBNull(reader.GetOrdinal("LOCEN1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEN1")),
                       reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEM1")),
                       reader.IsDBNull(reader.GetOrdinal("LOPUAC")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOPUAC")),
                       reader.IsDBNull(reader.GetOrdinal("LOANNE")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOANNE")),
                       reader.IsDBNull(reader.GetOrdinal("LOMOIS")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOMOIS")),
                        reader.IsDBNull(reader.GetOrdinal("FRVILL")) ? defaultString : reader.GetString(reader.GetOrdinal("FRVILL")),
                        reader.IsDBNull(reader.GetOrdinal("FRNUM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRNUM")),
                        reader.IsDBNull(reader.GetOrdinal("FRDOMI")) ? defaultString : reader.GetString(reader.GetOrdinal("FRDOMI")),
                        reader.IsDBNull(reader.GetOrdinal("FRBANQ")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRBANQ")),
                        reader.IsDBNull(reader.GetOrdinal("FRGUIC")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRGUIC")),
                        reader.IsDBNull(reader.GetOrdinal("FRCOM1")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOM1")),
                        reader.IsDBNull(reader.GetOrdinal("FRCOM2")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOM2"))
                       );
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
