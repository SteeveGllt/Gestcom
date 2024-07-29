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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
                    return lot;
                }
                else
                {
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

        // Méthode pour mettre à jour un lot dans la base de données
        public static void updateLot(decimal lofrom, decimal loanne, decimal lomois, decimal nbPains, decimal poidsBrut, decimal poidsNet)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour mettre à jour un lot
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOCEM1 = LOCEM1 + @LOCEM1, LOCEB1 = LOCEB1 + @LOCEB1, LOCEN1 = LOCEN1 + @LOCEN1 WHERE LOFACO = 1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP = 0";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande avec les nouvelles valeurs
                oleDbCommand.Parameters.AddWithValue("@LOCEM1", nbPains);
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", (double)poidsBrut);
                oleDbCommand.Parameters.AddWithValue("@LOCEN1", poidsNet);
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                // Exécution de la commande
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour mettre à jour un lot et son montant dans la base de données
        public static void updateLotAffine(decimal lofrom, decimal loanne, decimal lomois, decimal nbPains, decimal poidsBrut, decimal poidsNet, decimal montant)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour mettre à jour un lot et son montant
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOCEM1 = LOCEM1 + @LOCEM1, LOCEB1 = LOCEB1 + @LOCEB1, LOCEN1 = LOCEN1 + @LOCEN1, MONTANT = MONTANT + @MONTANT WHERE LOFACO = 1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP = 0";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande avec les nouvelles valeurs
                oleDbCommand.Parameters.AddWithValue("@LOCEM1", nbPains);
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", (double)poidsBrut);
                oleDbCommand.Parameters.AddWithValue("@LOCEN1", poidsNet);
                oleDbCommand.Parameters.AddWithValue("@MONTANT", (double)montant);
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                // Exécution de la première commande
                oleDbCommand.ExecuteNonQuery();

                // Définition de la requête SQL pour mettre à jour le prix unitaire après la mise à jour du lot
                oleDbCommand.CommandText = "UPDATE TB_Lots SET TB_Lots.LOPUAC = ROUND(TB_Lots.MONTANT / TB_Lots.LOCEN1, 2) WHERE LOFACO = 1 AND LOFROM = " + lofrom + " AND LOANNE =" + loanne + " AND LOMOIS =" + lomois + " AND LODEP = 0";

                // Exécution de la deuxième commande
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour tester la mise à jour des lots et calculer le prix unitaire
        public static void test(decimal lofrom, decimal loanne, decimal lomois)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Étape 1: Récupérer le montant global et le poids net global
                oleDbCommand.CommandText = "SELECT MONTANT, LOCEN1 FROM TB_Lots WHERE LOFACO = 1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP = 0";
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                OleDbDataReader reader = oleDbCommand.ExecuteReader();
                if (reader.Read())
                {
                    // Lecture des valeurs de montant global et poids net global
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

                    // Exécution de la commande de mise à jour
                    oleDbCommand.ExecuteNonQuery();
                }
                else
                {
                    // Message d'erreur si aucune correspondance trouvée dans la base de données
                    MessageBox.Show("Aucune correspondance trouvée dans la base de données.");
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour créer un lot dans la base de données
        public static void createLot(Lot lot)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour insérer un nouveau lot
                oleDbCommand.CommandText = @"
INSERT INTO TB_Lots(
    LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, LOCEM1, LOCEB1, LOCEN1, 
    LOCPES, LOCC1, LOC11, LOC12, LOC13, LOC14, LOPUAC, LOCACO, LOPU1, 
    LOPU2, LOPU3, LOPU4, LOCDEF, LOC21, LOC22, LOC23, LOC24, LOVM1, 
    LOVM2, LOVM3, LOVM4, LOVV1, LOVV2, LOVV3, LOVV4, LOVP1, LOVP2, 
    LOVP3, LOVP4, LOSM1, LOSM2, LOSM3, LOSM4, LOSP1, LOSP2, LOSP3, 
    LOSP4, LOTCON, DATC1, DATC2, LOCC2N, DATACO, LOFR1, LOFR2, LOFR3, 
    LOFR4, LOFV1, LOFV2, LOFV3, LOFV4, LOPSTK, MONTANT
) VALUES (
    1, @LOFROM, @LOANNE, @LOMOIS, 0, @LOCEM1, @LOCEB1, @LOCEN1, 
    0, 0, 0, 0, 0, 0, 0, 0, 0, 
    0, 0, 0, 0, 0, 0, 0, 0, 0, 
    0, 0, 0, 0, 0, 0, 0, 0, 0, 
    0, 0, 0, 0, 0, 0, 0, 0, 0, 
    0, 1, 0, 0, 0, 0, 0, 0, 0, 
    0, 0, 0, 0, 0, 0, 0
)";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande avec les valeurs du lot
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lot.LOFROM);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", lot.LOANNE);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lot.LOMOIS);
                oleDbCommand.Parameters.AddWithValue("@LOCEM1", lot.LOCEM1);
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", (double)lot.LOCEB1);
                oleDbCommand.Parameters.AddWithValue("@LOCEN1", lot.LOCEN1);

                // Exécution de la commande
                oleDbCommand.ExecuteNonQuery();
                Console.WriteLine("Lot créé");
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour créer un lot affine dans la base de données
        public static void createLotAffine(Lot lot)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour insérer un nouveau lot affine
                oleDbCommand.CommandText = @"
INSERT INTO TB_Lots(
    LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, LOCEM1, LOCEB1, LOCEN1, 
    LOCPES, LOCC1, LOC11, LOC12, LOC13, LOC14, LOPUAC, LOCACO, LOPU1, 
    LOPU2, LOPU3, LOPU4, LOCDEF, LOC21, LOC22, LOC23, LOC24, LOVM1, 
    LOVM2, LOVM3, LOVM4, LOVV1, LOVV2, LOVV3, LOVV4, LOVP1, LOVP2, 
    LOVP3, LOVP4, LOSM1, LOSM2, LOSM3, LOSM4, LOSP1, LOSP2, LOSP3, 
    LOSP4, LOTCON, DATC1, DATC2, LOCC2N, DATACO, LOFR1, LOFR2, LOFR3, 
    LOFR4, LOFV1, LOFV2, LOFV3, LOFV4, LOPSTK, MONTANT
) VALUES (
    1, @LOFROM, @LOANNE, @LOMOIS, 0, @LOCEM1, @LOCEB1, @LOCEN1, 
    0, 0, 0, 0, 0, 0, @LOPUAC, 0, 0, 
    0, 0, 0, 0, 0, 0, 0, 0, 0, 
    0, 0, 0, 0, 0, 0, 0, 0, 0, 
    0, 0, 0, 0, 0, 0, 0, 0, 0, 
    0, 1, 0, 0, 0, 0, 0, 0, 0, 
    0, 0, 0, 0, 0, 0, @MONTANT
)";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande avec les valeurs du lot affine
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lot.LOFROM);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", lot.LOANNE);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lot.LOMOIS);
                oleDbCommand.Parameters.AddWithValue("@LOCEM1", lot.LOCEM1);
                oleDbCommand.Parameters.AddWithValue("@LOCEB1", (double)lot.LOCEB1);
                oleDbCommand.Parameters.AddWithValue("@LOCEN1", lot.LOCEN1);
                oleDbCommand.Parameters.AddWithValue("@LOPUAC", Convert.ToDouble(lot.LOPUAC));
                oleDbCommand.Parameters.AddWithValue("@MONTANT", Math.Round(Convert.ToDouble(lot.LOPUAC) / 1000 * Convert.ToDouble(lot.LOCEN1), 2));

                // Exécution de la commande
                oleDbCommand.ExecuteNonQuery();
                Console.WriteLine("Lot créé");
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour créer une entrée de lot dans la base de données
        public static void createEntreeLot(EntreeLot entreeLot)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour insérer une nouvelle entrée de lot
                oleDbCommand.CommandText = "INSERT INTO TB_Entrée_Lots(LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, Date_Entrée, Date_Début, DAte_Fin, LOCENM, LOCENB, LOCPES, LOCENN, LOTAUX) VALUES(1, @LOFROM, @LOANNE, @LOMOIS, 0, @Date_Entrée, @Date_Début, @DAte_Fin, @LOCENM, @LOCENB, 0, @LOCENN, @LOTAUX)";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande avec les valeurs de l'entrée de lot
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

                // Exécution de la commande
                oleDbCommand.ExecuteNonQuery();
                Console.WriteLine("Lot créé dans entrée lot");
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!" + ex);
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour créer une entrée de lot affine dans la base de données
        public static void createEntreeLotAffine(EntreeLot entreeLot)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour insérer une nouvelle entrée de lot affine
                oleDbCommand.CommandText = "INSERT INTO TB_Entrée_Lots(LOFACO, LOFROM, LOANNE, LOMOIS, LODEP, Date_Entrée, LOCENM, LOCENB, LOCPES, LOCENN, LOTAUX, PRIX) VALUES(1, @LOFROM, @LOANNE, @LOMOIS, 0, @Date_Entrée, @LOCENM, @LOCENB, 0, LOCENN, LOTAUX, @PRIX)";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande avec les valeurs de l'entrée de lot affine
                oleDbCommand.Parameters.AddWithValue("@LOFROM", entreeLot.LOFROM);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", entreeLot.LOANNE);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", entreeLot.LOMOIS);
                oleDbCommand.Parameters.AddWithValue("@Date_Entrée", entreeLot.Date_Entrée.ToString("dd/MM/yyyy"));
                oleDbCommand.Parameters.AddWithValue("@LOCENM", entreeLot.LOCENM); // Pains
                oleDbCommand.Parameters.AddWithValue("@LOCENB", entreeLot.LOCENB); // Brut
                oleDbCommand.Parameters.AddWithValue("@LOCENN", entreeLot.LOCENN); // Net
                oleDbCommand.Parameters.AddWithValue("@LOTAUX", entreeLot.LOTAUX); // Freinte
                oleDbCommand.Parameters.AddWithValue("@PRIX", Convert.ToDouble(entreeLot.PRIX)); // Prix

                // Exécution de la commande
                oleDbCommand.ExecuteNonQuery();
                Console.WriteLine("Lot créé dans entrée lot");
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour récupérer toutes les entrées de lots en fonction du mois et de l'année
        public static List<EntreeLotFrom> allEntreeEnFonctionDuMoisEtDeLannee(decimal mois, decimal annee)
        {
            try
            {
                // Création d'une liste pour stocker les résultats
                List<EntreeLotFrom> entreeLotFroms = new List<EntreeLotFrom>();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb avec jointure pour récupérer les données
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT TB_Entrée_Lots.LOFROM, TB_Entrée_Lots.LOANNE, TB_Entrée_Lots.LOMOIS, TB_Entrée_Lots.Date_Entrée, " +
                    "TB_Entrée_Lots.LOCENM, TB_Entrée_Lots.LOCENB, TB_Entrée_Lots.LOCENN, TB_Entrée_Lots.LOTAUX, TB_Fromageries.FRNUM, TB_Fromageries.FRNOM, " +
                    "TB_Fromageries.FRADR, TB_Fromageries.FRCPOS, TB_Fromageries.FRVILL, TB_Fromageries.FRNDIR, TB_Fromageries.FRCOOP FROM TB_Entrée_Lots INNER JOIN TB_Fromageries ON " +
                    "TB_Entrée_Lots.LOFROM = TB_Fromageries.FRNUM WHERE LOMOIS = @LOMOIS AND LOANNE = @LOANNE ORDER BY TB_Entrée_Lots.LOFROM, TB_Entrée_Lots.Date_Entrée;");

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", mois);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", annee);

                // Exécution de la commande et lecture des résultats
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    // Création d'un objet EntreeLotFrom et ajout à la liste
                    EntreeLotFrom entreeLotFrom = new EntreeLotFrom(
                        (decimal)reader["LOFROM"], (decimal)reader["LOANNE"],
                        (decimal)reader["LOMOIS"], (DateTime)reader["Date_Entrée"],
                        (decimal)reader["LOCENM"], (decimal)reader["LOCENB"],
                        (decimal)reader["LOCENN"], (decimal)reader["LOTAUX"],
                        (decimal)reader["FRNUM"], (string)reader["FRNOM"],
                        (string)reader["FRADR"], (decimal)reader["FRCPOS"],
                        (string)reader["FRVILL"], (string)reader["FRNDIR"],
                        (string)reader["FRCOOP"]
                    );
                    entreeLotFroms.Add(entreeLotFrom);
                }
                reader.Close();
                return entreeLotFroms;
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return null;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour récupérer tous les lots en fonction de l'année et du mois
        public static List<Lot> allLot(decimal loanne, decimal lomois)
        {
            try
            {
                // Création d'une liste pour stocker les résultats
                List<Lot> lots = new List<Lot>();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb pour récupérer les données
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "SELECT LOFROM, LOCEM1, LOC11, LOC12, LOC13 FROM TB_Lots INNER JOIN TB_Fromageries ON TB_Lots.LOFROM = TB_Fromageries.FRNUM WHERE ((TB_Fromageries.FRACTIF)=True) AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS ";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                // Exécution de la commande et lecture des résultats
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    // Création d'un objet Lot et ajout à la liste
                    Lot lot = new Lot(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? 0m : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ? 0m : reader.GetDecimal(reader.GetOrdinal("LOCEM1")),
                        reader.IsDBNull(reader.GetOrdinal("LOC11")) ? 0m : reader.GetDecimal(reader.GetOrdinal("LOC11")),
                        reader.IsDBNull(reader.GetOrdinal("LOC12")) ? 0m : reader.GetDecimal(reader.GetOrdinal("LOC12")),
                        reader.IsDBNull(reader.GetOrdinal("LOC13")) ? 0m : reader.GetDecimal(reader.GetOrdinal("LOC13"))
                    );
                    lots.Add(lot);
                }
                reader.Close();
                return lots;
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!" + ex);
                return null;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }


        // Méthode pour mettre à jour le classement d'un lot dans la base de données
        public static void updateLotClassement(decimal lofrom, decimal loanne, decimal lomois, decimal a, decimal b, decimal c)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour mettre à jour le classement d'un lot
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOCC1 = 1, LOC11 = @LOC11, LOC12 = @LOC12, LOC13 = @LOC13 WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande avec les valeurs de classement
                oleDbCommand.Parameters.AddWithValue("@LOC11", a);
                oleDbCommand.Parameters.AddWithValue("@LOC12", b);
                oleDbCommand.Parameters.AddWithValue("@LOC13", c);
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                // Exécution de la commande
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour générer un fichier Excel de classement en fonction du mois et de l'année
        public static List<LotFrom> generationFichierExcelClassement(decimal mois, decimal annee)
        {
            try
            {
                // Création d'une liste pour stocker les résultats
                List<LotFrom> lots = new List<LotFrom>();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb avec jointure pour récupérer les données
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT TB_Lots.LOFROM, TB_Fromageries.FRCOOP, TB_Fromageries.FRNOM, TB_Fromageries.FRNDIR, TB_Fromageries.FRADR, TB_Fromageries.FRCPOS, TB_Lots.LOCEM1, TB_Lots.LOC11, TB_Lots.LOC12, TB_Lots.LOC13, " +
                    " TB_Lots.LOANNE, TB_Lots.LOMOIS, TB_Fromageries.FRVILL, TB_Fromageries.FRNUM FROM TB_Fromageries INNER JOIN TB_Lots ON TB_Fromageries.FRNUM = TB_Lots.LOFROM" +
                    " WHERE ((TB_Fromageries.FRACTIF)=True) AND LOMOIS = @LOMOIS AND LOANNE = @LOANNE AND TB_Lots.LODEP = 0 ORDER BY TB_Lots.LOFROM;");

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", mois);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", annee);

                // Exécution de la commande et lecture des résultats
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    decimal defaultDecimal = 0m;
                    string defaultString = "";

                    // Création d'un objet LotFrom et ajout à la liste
                    LotFrom lot = new LotFrom(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("FRCOOP")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOOP")),
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
                reader.Close();
                return lots;
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return null;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour récupérer tous les lots à acompte en fonction de l'année et du mois
        public static List<Lot> allLotAcompte(decimal loanne, decimal lomois)
        {
            try
            {
                // Création d'une liste pour stocker les résultats
                List<Lot> lots = new List<Lot>();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb pour récupérer les données
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "SELECT LOFROM, LOCEM1, LOPUAC FROM TB_Lots INNER JOIN TB_Fromageries ON TB_Lots.LOFROM = TB_Fromageries.FRNUM WHERE ((TB_Fromageries.FRAFFINE)=False) AND ((TB_Fromageries.FRACTIF)=True) AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                // Exécution de la commande et lecture des résultats
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    decimal defaultDecimal = 0m;

                    // Création d'un objet Lot et ajout à la liste
                    Lot lot = new Lot(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEM1")),
                        reader.IsDBNull(reader.GetOrdinal("LOPUAC")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOPUAC"))
                    );
                    lots.Add(lot);
                }
                reader.Close();
                return lots;
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!" + ex);
                return null;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour vérifier si une commande existe dans la base de données
        public static bool CheckCMCOMNExists(string cmcomn, int annee, int mois)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour vérifier l'existence d'une commande
                oleDbCommand.CommandText = "SELECT COUNT(*) FROM TB_Fact_Lig WHERE CMCOMN = @CMCOMN AND CMAA = @ANNEE AND CMMM = @MOIS";

                // Ajout des paramètres à la commande
                oleDbCommand.Parameters.AddWithValue("@CMCOMN", cmcomn);
                oleDbCommand.Parameters.AddWithValue("@ANNEE", annee);
                oleDbCommand.Parameters.AddWithValue("@MOIS", mois);

                // Exécution de la commande et récupération du résultat
                int count = (int)oleDbCommand.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!" + ex);
                return false;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour vérifier l'existence d'une commande dans la base de données
        public static FactLig ExisteCMCOMN(decimal cmcomn, decimal loanne, decimal lomois)
        {
            try
            {
                // Initialisation de l'objet FactLig
                FactLig factLig = new FactLig();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour vérifier l'existence d'une commande
                oleDbCommand.CommandText = "SELECT TB_Fact_Lig.CMCOMN FROM TB_Fact_Lig WHERE CMCOMN = @CMCOMN AND CMAA = @ANNEE AND CMMM = @MOIS";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande
                oleDbCommand.Parameters.AddWithValue("@CMCOMN", cmcomn);
                oleDbCommand.Parameters.AddWithValue("@ANNEE", loanne);
                oleDbCommand.Parameters.AddWithValue("@MOIS", lomois);

                // Exécution de la commande et lecture des résultats
                oleDbCommand.ExecuteNonQuery();
                reader = oleDbCommand.ExecuteReader();

                if (reader.Read())
                {
                    // Si la requête a retourné des résultats, création de l'objet FactLig
                    factLig = new FactLig
                    {
                        CMCOMN = reader.GetDecimal(0)
                    };
                    return factLig;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return null;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }


        // Méthode pour obtenir les données d'une ligne de facture
        public static FactLig GetFactLigData(decimal cmcomn, decimal annee, decimal mois)
        {
            try
            {
                // Initialisation de l'objet FactLig
                FactLig factLig = new FactLig();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour obtenir les données de la ligne de facture
                oleDbCommand.CommandText = @"
            SELECT TB_Fact_Lig.CMCOMN, TB_Fact_Lig.CMDATE, TB_Fact_Lig.NUMFAC, 
                   Round([CMPDSU]*[CMPRIU]*IIf([CMCDFA]='F' Or [CMCDFA]='G',1,-1)*IIf([CMCODE]='P',1-[CMREMI]/100,1)*1.055,2) AS CA
            FROM TB_Fact_Lig
            WHERE TB_Fact_Lig.CMCOMN = @CMCOMN AND TB_Fact_Lig.CMAA = @ANNEE AND TB_Fact_Lig.CMMM = @MOIS
            GROUP BY TB_Fact_Lig.CMCOMN, TB_Fact_Lig.CMDATE, TB_Fact_Lig.NUMFAC, 
                     Round([CMPDSU]*[CMPRIU]*IIf([CMCDFA]='F' Or [CMCDFA]='G',1,-1)*IIf([CMCODE]='P',1-[CMREMI]/100,1)*1.055,2), 
                     TB_Fact_Lig.CMAA, TB_Fact_Lig.CMMM";

                // Ajout des paramètres à la commande
                oleDbCommand.Parameters.AddWithValue("@CMCOMN", cmcomn);
                oleDbCommand.Parameters.AddWithValue("@ANNEE", annee);
                oleDbCommand.Parameters.AddWithValue("@MOIS", mois);

                // Exécution de la commande et lecture des résultats
                reader = oleDbCommand.ExecuteReader();

                if (reader.Read())
                {
                    // Remplissage de l'objet FactLig avec les valeurs lues
                    factLig = new FactLig
                    {
                        CMCOMN = reader.GetDecimal(0),
                        CMDATE = Convert.ToDateTime(reader["CMDATE"]),
                        NUMFAC = reader.GetDecimal(2),
                        CA = Convert.ToDecimal(reader["CA"])
                    };
                    return factLig;
                }

                return null;
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!" + ex);
                return null;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour mettre à jour le prix d'un lot dans la base de données
        public static void updateLotPrix(decimal lofrom, decimal loanne, decimal lomois, double newPrix)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour mettre à jour le prix d'un lot
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOPUAC = @LOPUAC WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande avec la nouvelle valeur du prix
                oleDbCommand.Parameters.AddWithValue("@LOPUAC", newPrix);
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                // Exécution de la commande
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour mettre à jour le prix de tous les lots dans la base de données
        public static void updateLotPrixAll(decimal newPrix)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour mettre à jour le prix de tous les lots
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOPUAC = @LOPUAC WHERE LOFACO=1 AND LODEP=0";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout du paramètre à la commande avec la nouvelle valeur du prix
                oleDbCommand.Parameters.AddWithValue("@LOPUAC", newPrix);

                // Exécution de la commande
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour récupérer tous les lots pour un rappel en fonction de l'année et du mois
        public static List<Lot> allLotRappel(decimal loanne, decimal lomois)
        {
            try
            {
                // Création d'une liste pour stocker les résultats
                List<Lot> lots = new List<Lot>();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb pour récupérer les données
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "SELECT LOFROM, LOCEM1, LOCEN1, LOC11, LOC12, LOC13, LOPU1, LOPU2, LOPU3, MONTANT, FRPRIME  FROM TB_Lots INNER JOIN TB_Fromageries ON TB_Lots.LOFROM = TB_Fromageries.FRNUM WHERE ((TB_Fromageries.FRAFFINE)=False) AND ((TB_Fromageries.FRACTIF)=True) AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                // Exécution de la commande et lecture des résultats
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    // Définissez les valeurs par défaut pour chaque champ qui pourrait être null.
                    decimal defaultDecimal = 0m; // Vous pouvez définir une autre valeur par défaut si nécessaire.

                    // Créez un objet Lot, en utilisant les valeurs par défaut si les champs de la base de données sont DBNull.
                    Lot lot = new Lot(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("LOCEM1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEM1")),
                        reader.IsDBNull(reader.GetOrdinal("LOCEN1")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOCEN1")),
                        reader.IsDBNull(reader.GetOrdinal("LOC11")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC11")),
                        reader.IsDBNull(reader.GetOrdinal("LOC12")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC12")),
                        reader.IsDBNull(reader.GetOrdinal("LOC13")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOC13")),
                        reader.IsDBNull(reader.GetOrdinal("LOPU1")) ? defaultDecimal : Math.Round(reader.GetDecimal(reader.GetOrdinal("LOPU1")), 5),
                        reader.IsDBNull(reader.GetOrdinal("LOPU2")) ? defaultDecimal : Math.Round(reader.GetDecimal(reader.GetOrdinal("LOPU2")), 5),
                        reader.IsDBNull(reader.GetOrdinal("LOPU3")) ? defaultDecimal : Math.Round(reader.GetDecimal(reader.GetOrdinal("LOPU3")), 5),
                        reader.IsDBNull(reader.GetOrdinal("MONTANT")) ? defaultDecimal : Math.Round(reader.GetDecimal(reader.GetOrdinal("MONTANT")), 2),
                        reader.IsDBNull(reader.GetOrdinal("FRPRIME")) ? defaultDecimal : Math.Round(reader.GetDecimal(reader.GetOrdinal("FRPRIME")), 2)
                    );

                    lots.Add(lot);
                }

                return lots;
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!" + ex);
                return null;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour mettre à jour le rappel de prix d'un lot dans la base de données
        public static void updateLotRappel(decimal lofrom, decimal loanne, decimal lomois, double a, double b, double c, double montant)
        {
            try
            {
                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Définition de la requête SQL pour mettre à jour le rappel de prix d'un lot
                oleDbCommand.CommandText = "UPDATE TB_Lots SET LOPU1 = @LOPU1, LOPU2 = @LOPU2, LOPU3 = @LOPU3, MONTANT = @MONTANT WHERE LOFACO=1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP=0";

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande avec les nouvelles valeurs de prix et de montant
                oleDbCommand.Parameters.AddWithValue("@LOPU1", a);
                oleDbCommand.Parameters.AddWithValue("@LOPU2", b);
                oleDbCommand.Parameters.AddWithValue("@LOPU3", c);
                oleDbCommand.Parameters.AddWithValue("@MONTANT", montant);
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);

                // Exécution de la commande
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }


        // Méthode pour générer un fichier Excel de rappel en fonction du mois, de l'année et d'une date
        public static List<LotFrom> generationFichierExcelRappel(decimal mois, decimal annee, DateTime date)
        {
            try
            {
                // Création d'une liste pour stocker les résultats
                List<LotFrom> lots = new List<LotFrom>();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Calcul de la date 5 mois après la date donnée
                DateTime date5 = date.AddMonths(5);
                MessageBox.Show(date5.ToString("MM/dd/yyyy"));

                // Définition de la requête SQL pour récupérer les données des lots
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT TB_Lots.LOFROM, TB_Fromageries.FRCOOP,  TB_Fromageries.FRNOM, TB_Fromageries.FRNDIR, TB_Fromageries.FRADR, TB_Fromageries.FRCPOS, TB_Fromageries.FRPRIME, TB_Lots.LOCEN1, TB_Lots.LOCEM1, TB_Lots.LOC11, TB_Lots.LOC12, TB_Lots.LOC13, " +
                    " TB_Lots.LOPUAC, TB_Lots.LOPU1, TB_Lots.LOPU2, TB_Lots.LOPU3, TB_Lots.LOANNE, TB_Lots.LOMOIS, TB_Fromageries.FRVILL, TB_Fromageries.FRNUM, TB_Fromageries.FRRAP, TB_Fromageries.FRDOMI, TB_Fromageries.FRBANQ, TB_Fromageries.FRGUIC, TB_Fromageries.FRCOM1, TB_Fromageries.FRCOM2 FROM TB_Fromageries INNER JOIN TB_Lots ON TB_Fromageries.FRNUM = TB_Lots.LOFROM" +
                    " WHERE ((TB_Fromageries.FRAFFINE)=False) AND ((TB_Fromageries.FRACTIF)=True) AND ((TB_Lots.LOANNE)=Year(DateAdd(\"m\",[TB_Fromageries].[FRRAP], #" + date5.ToString("yyyy-MM-dd") + "#))-2000) AND ((TB_Lots.LOMOIS)=Month(DateAdd(\"m\",[TB_Fromageries].[FRRAP], #" + date5.ToString("yyyy-MM-dd") + "#))) AND TB_Lots.LODEP = 0 ORDER BY TB_Lots.LOFROM; ");

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Exécution de la commande et lecture des résultats
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    // Définissez les valeurs par défaut pour chaque champ qui pourrait être null.
                    decimal defaultDecimal = 0m;
                    int defaultInt = 0;
                    string defaultString = "";

                    // Création d'un objet LotFrom et ajout à la liste
                    LotFrom lot = new LotFrom(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("FRCOOP")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOOP")),
                        reader.IsDBNull(reader.GetOrdinal("FRNOM")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNOM")),
                        reader.IsDBNull(reader.GetOrdinal("FRNDIR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRNDIR")),
                        reader.IsDBNull(reader.GetOrdinal("FRADR")) ? defaultString : reader.GetString(reader.GetOrdinal("FRADR")),
                        reader.IsDBNull(reader.GetOrdinal("FRCPOS")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRCPOS")),
                        reader.IsDBNull(reader.GetOrdinal("FRPRIME")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRPRIME")),
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
                        reader.IsDBNull(reader.GetOrdinal("FRRAP")) ? defaultInt : reader.GetInt16(reader.GetOrdinal("FRRAP")),
                        reader.IsDBNull(reader.GetOrdinal("FRDOMI")) ? defaultString : reader.GetString(reader.GetOrdinal("FRDOMI")),
                        reader.IsDBNull(reader.GetOrdinal("FRBANQ")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRBANQ")),
                        reader.IsDBNull(reader.GetOrdinal("FRGUIC")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("FRGUIC")),
                        reader.IsDBNull(reader.GetOrdinal("FRCOM1")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOM1")),
                        reader.IsDBNull(reader.GetOrdinal("FRCOM2")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOM2"))
                    );
                    lots.Add(lot);
                }
                reader.Close();
                return lots;
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return null;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour générer un fichier Excel d'acompte en fonction du mois et de l'année
        public static List<LotFrom> generationFichierExcelAcompte(decimal mois, decimal annee)
        {
            try
            {
                // Création d'une liste pour stocker les résultats
                List<LotFrom> lots = new List<LotFrom>();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Définition de la requête SQL pour récupérer les données des lots
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT TB_Lots.LOFROM, TB_Fromageries.FRCOOP, TB_Fromageries.FRNOM, TB_Fromageries.FRNDIR, TB_Fromageries.FRADR, TB_Fromageries.FRCPOS, TB_Lots.LOCEN1, TB_Lots.LOCEM1," +
                    " TB_Lots.LOPUAC, TB_Lots.LOANNE, TB_Lots.LOMOIS, TB_Fromageries.FRVILL, TB_Fromageries.FRNUM, TB_Fromageries.FRDOMI, TB_Fromageries.FRBANQ, TB_Fromageries.FRGUIC, TB_Fromageries.FRCOM1, TB_Fromageries.FRCOM2 FROM TB_Fromageries INNER JOIN TB_Lots ON TB_Fromageries.FRNUM = TB_Lots.LOFROM" +
                    " WHERE ((TB_Fromageries.FRAFFINE)=False) AND ((TB_Fromageries.FRACTIF)=True) AND LOMOIS = @LOMOIS AND LOANNE = @LOANNE AND TB_Lots.LODEP = 0 ORDER BY TB_Lots.LOFROM;");

                // Attribution de la connexion à la commande
                oleDbCommand.Connection = connection;

                // Préparation de la commande
                oleDbCommand.Prepare();

                // Ajout des paramètres à la commande
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", mois);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", annee);

                // Exécution de la commande et lecture des résultats
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    // Définissez les valeurs par défaut pour chaque champ qui pourrait être null.
                    decimal defaultDecimal = 0m;
                    string defaultString = "";

                    // Création d'un objet LotFrom et ajout à la liste
                    LotFrom lot = new LotFrom(
                        reader.IsDBNull(reader.GetOrdinal("LOFROM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("LOFROM")),
                        reader.IsDBNull(reader.GetOrdinal("FRCOOP")) ? defaultString : reader.GetString(reader.GetOrdinal("FRCOOP")),
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
                reader.Close();
                return lots;
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return null;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }

        // Méthode pour obtenir le montant d'un lot dans la base de données
        public static Decimal MontantLot(decimal lofrom, decimal loanne, decimal lomois)
        {
            try
            {
                // Initialisation du montant
                decimal montant = 0m;
                Lot lot = new Lot();
                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données
                open();

                // Création d'une commande OleDb
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Requête SQL pour obtenir le montant d'un lot
                oleDbCommand.CommandText = "SELECT MONTANT FROM TB_Lots WHERE LOFACO = 1 AND LOFROM = @LOFROM AND LOANNE = @LOANNE AND LOMOIS = @LOMOIS AND LODEP = 0";

                // Préparation et exécution de la requête
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@LOFROM", lofrom);
                oleDbCommand.Parameters.AddWithValue("@LOANNE", loanne);
                oleDbCommand.Parameters.AddWithValue("@LOMOIS", lomois);
                oleDbCommand.ExecuteNonQuery();
                reader = oleDbCommand.ExecuteReader();

                if (reader.Read())
                {
                    // Si la requête a retourné des résultats, obtenir le montant
                    lot = new Lot
                    {
                        MONTANT = reader.GetDecimal(0)
                    };
                    montant = lot.MONTANT;
                    return montant;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!");
                return 0;
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                close();
            }
        }


    }
}
