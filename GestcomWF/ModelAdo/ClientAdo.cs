using Gestcom.Models;
using GestcomWF.DataAccess;
using GestcomWF.Models;
using System;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Security.Claims;
using GestcomWF.Views;
using Microsoft.VisualBasic.Logging;

namespace GestcomWF.ModelAdo
{
    public class ClientAdo : DataAdo
    {
        public static List<Client> GetClients()
        {
            try
            {
                // Initialisation de la liste pour stocker les articles récupérés.
                List<Client> clients = new List<Client>();

                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données (héritée de DataAdo).
                open();

                // Création de la commande SQL pour sélectionner tous les articles.
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT CLNUM, CLNOM FROM TB_Clients");

                // Liaison de la commande à la connexion.
                oleDbCommand.Connection = connection;

                // Exécution de la commande et récupération du résultat dans le reader.
                reader = oleDbCommand.ExecuteReader();

                // Parcours du résultat ligne par ligne.
                while (reader.Read())
                {
                    // Création d'un objet Article à partir des données de la ligne actuelle.
                    Client client = new Client((Decimal)reader["CLNUM"], (String)reader["CLNOM"]);

                    // Ajout de l'article à la liste.
                    clients.Add(client);
                }

                // Ce WriteLine semble inutile. Il affichera simplement le type d'objet OleDbDataReader.
                Console.WriteLine(reader);

                // Fermeture du reader.
                reader.Close();

                // Retour de la liste d'articles.
                return clients;
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

        public static Client GetClientDetails(string numeroClient)
        {
            try
            {
                // Initialisation de la liste pour stocker les fromageries récupérées.
                Client client = null;

                OleDbDataReader reader;

                // Ouverture de la connexion à la base de données.
                open();

                // Création de la commande SQL pour sélectionner les fromageries actives.
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM TB_Clients WHERE CLNUM = @CLNUM");
                oleDbCommand.Connection = connection;
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@CLNUM", numeroClient);
                reader = oleDbCommand.ExecuteReader();

                // Parcours du résultat ligne par ligne.
                while (reader.Read())
                {
                    decimal defaultDecimal = 0m;
                    string defaultString = "";
                    bool defaultBool = true;
                    // Création d'un objet Client à partir du numéro récupéré.
                    client = new Client(
                           reader.IsDBNull(reader.GetOrdinal("CLNUM")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLNUM")),
    reader.IsDBNull(reader.GetOrdinal("CLNOM")) ? defaultString : reader.GetString(reader.GetOrdinal("CLNOM")),
    reader.IsDBNull(reader.GetOrdinal("CLMTDI")) ? defaultString : reader.GetString(reader.GetOrdinal("CLMTDI")),
   reader.IsDBNull(reader.GetOrdinal("CLADR1")) ? defaultString : reader.GetString(reader.GetOrdinal("CLADR1")),
    reader.IsDBNull(reader.GetOrdinal("CLADR2")) ? defaultString : reader.GetString(reader.GetOrdinal("CLADR2")),
    reader.IsDBNull(reader.GetOrdinal("CLCPOS")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLCPOS")),
    reader.IsDBNull(reader.GetOrdinal("CLVILL")) ? defaultString : reader.GetString(reader.GetOrdinal("CLVILL")),
    reader.IsDBNull(reader.GetOrdinal("CLREGL")) ? defaultString : reader.GetString(reader.GetOrdinal("CLREGL")),
    reader.IsDBNull(reader.GetOrdinal("CLBASE")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLBASE")),
    reader.IsDBNull(reader.GetOrdinal("CLDEPA")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLDEPA")),
    reader.IsDBNull(reader.GetOrdinal("CLECHE")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLECHE")),
    reader.IsDBNull(reader.GetOrdinal("CLARRI")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLARRI")),
    reader.IsDBNull(reader.GetOrdinal("CLBQUE")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLBQUE")),
    reader.IsDBNull(reader.GetOrdinal("CLGUI")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLGUI")),
    reader.IsDBNull(reader.GetOrdinal("CLCPTE")) ? defaultString : reader.GetString(reader.GetOrdinal("CLCPTE")),
    reader.IsDBNull(reader.GetOrdinal("CLRIB")) ? defaultString : reader.GetString(reader.GetOrdinal("CLRIB")),
    reader.IsDBNull(reader.GetOrdinal("CLDOM")) ? defaultString : reader.GetString(reader.GetOrdinal("CLDOM")),
    reader.IsDBNull(reader.GetOrdinal("CLREP")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLREP")),
    reader.IsDBNull(reader.GetOrdinal("CLEDIT")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLEDIT")),
    reader.IsDBNull(reader.GetOrdinal("CLFAMI")) ? defaultString : reader.GetString(reader.GetOrdinal("CLFAMI")),
    reader.IsDBNull(reader.GetOrdinal("CLTRAN")) ? defaultString : reader.GetString(reader.GetOrdinal("CLTRAN")),
    reader.IsDBNull(reader.GetOrdinal("CLLIVR")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLLIVR")),
    reader.IsDBNull(reader.GetOrdinal("CLFACT")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLFACT")),
    reader.IsDBNull(reader.GetOrdinal("CLCOMP")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLCOMP")),
    reader.IsDBNull(reader.GetOrdinal("CLRIST")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLRIST")),
    reader.IsDBNull(reader.GetOrdinal("CLREMI")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLREMI")),
    reader.IsDBNull(reader.GetOrdinal("CLCODE")) ? defaultString : reader.GetString(reader.GetOrdinal("CLCODE")),
    reader.IsDBNull(reader.GetOrdinal("CLTVA")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLTVA")),
    reader.IsDBNull(reader.GetOrdinal("CLENSE")) ? defaultDecimal : reader.GetDecimal(reader.GetOrdinal("CLENSE")),
    reader.IsDBNull(reader.GetOrdinal("CLDIV")) ? defaultString : reader.GetString(reader.GetOrdinal("CLDIV")),
    reader.IsDBNull(reader.GetOrdinal("CLINTRA")) ? defaultString : reader.GetString(reader.GetOrdinal("CLINTRA")),
    reader.IsDBNull(reader.GetOrdinal("CLSUPP")) ? defaultString : reader.GetString(reader.GetOrdinal("CLSUPP"))

                         );

                }

                // Affichage inutile du reader. À supprimer si non nécessaire.
                Console.WriteLine(reader);

                reader.Close();

                return client;
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
        public static void CreateClient(Client cl)
        {
            try
            {
                // Initialisation de la liste pour stocker les fromageries récupérées.

                Client client = null;
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Ouverture de la connexion à la base de données.


                // Création de la commande SQL pour sélectionner les fromageries actives.
                oleDbCommand.CommandText = "INSERT INTO TB_Clients(CLNUM, CLNOM, CLMTDI, CLADR1, CLADR2, CLCPOS, CLVILL, CLREGL, CLBASE, CLDEPA, CLECHE, CLARRI, CLBQUE, CLGUI, CLCPTE, CLRIB, CLDOM, CLREP, CLEDIT, CLFAMI, CLTRAN, CLLIVR, CLFACT, CLCOMP, CLRIST, CLREMI, CLCODE, CLTVA, CLENSE, CLDIV, CLINTRA, CLSUPP) VALUES (@CLNUM, @CLNOM, @CLMTDI, @CLADR1, @CLADR2, @CLCPOS, @CLVILL, @CLREGL, @CLBASE, @CLDEPA, @CLECHE, @CLARRI, @CLBQUE, @CLGUI, @CLCPTE, @CLRIB, @CLDOM, @CLREP, @CLEDIT, @CLFAMI, @CLTRAN, @CLLIVR, @CLFACT, @CLCOMP, @CLRIST, @CLREMI, @CLCODE, @CLTVA, @CLENSE, @CLDIV, @CLINTRA, @CLSUPP);";
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@CLNUM", cl.CLNUM);
                oleDbCommand.Parameters.AddWithValue("@CLNOM", cl.CLNOM);
                oleDbCommand.Parameters.AddWithValue("@CLMTDI", cl.CLMTDI);
                oleDbCommand.Parameters.AddWithValue("@CLADR1", cl.CLADR1);
                oleDbCommand.Parameters.AddWithValue("@CLADR2", cl.CLADR2);
                oleDbCommand.Parameters.AddWithValue("@CLCPOS", cl.CLCPOS);
                oleDbCommand.Parameters.AddWithValue("@CLVILL", cl.CLVILL);
                oleDbCommand.Parameters.AddWithValue("@CLREGL", cl.CLREGL);
                oleDbCommand.Parameters.AddWithValue("@CLBASE", cl.CLBASE);
                oleDbCommand.Parameters.AddWithValue("@CLDEPA", cl.CLDEPA);
                oleDbCommand.Parameters.AddWithValue("@CLECHE", cl.CLECHE);
                oleDbCommand.Parameters.AddWithValue("@CLARRI", cl.CLARRI);
                oleDbCommand.Parameters.AddWithValue("@CLBQUE", cl.CLBQUE);
                oleDbCommand.Parameters.AddWithValue("@CLGUI", cl.CLGUI);
                oleDbCommand.Parameters.AddWithValue("@CLCPTE", cl.CLCPTE);
                oleDbCommand.Parameters.AddWithValue("@CLRIB", cl.CLRIB);
                oleDbCommand.Parameters.AddWithValue("@CLDOM", cl.CLDOM);
                oleDbCommand.Parameters.AddWithValue("@CLREP", cl.CLREP);
                oleDbCommand.Parameters.AddWithValue("@CLEDIT", cl.CLEDIT);
                oleDbCommand.Parameters.AddWithValue("@CLFAMI", cl.CLFAMI);
                oleDbCommand.Parameters.AddWithValue("@CLTRAN", cl.CLTRAN);
                oleDbCommand.Parameters.AddWithValue("@CLLIVR", cl.CLLIVR);
                oleDbCommand.Parameters.AddWithValue("@CLFACT", cl.CLFACT);
                oleDbCommand.Parameters.AddWithValue("@CLCOMP", cl.CLCOMP);
                oleDbCommand.Parameters.AddWithValue("@CLRIST", cl.CLRIST);
                oleDbCommand.Parameters.AddWithValue("@CLREMI", cl.CLREMI);
                oleDbCommand.Parameters.AddWithValue("@CLCODE", cl.CLCODE);
                oleDbCommand.Parameters.AddWithValue("@CLTVA", cl.CLTVA);
                oleDbCommand.Parameters.AddWithValue("@CLENSE", cl.CLENSE);
                oleDbCommand.Parameters.AddWithValue("@CLDIV", cl.CLDIV);
                oleDbCommand.Parameters.AddWithValue("@CLINTRA", cl.CLINTRA);
                oleDbCommand.Parameters.AddWithValue("@CLSUPP", cl.CLSUPP);
                oleDbCommand.ExecuteNonQuery();
                Console.WriteLine("Client créé");
                MessageBox.Show("Client crée");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur de communication avec la base de données!" + ex);
            }
            finally { close(); }
        }
        public static void updateClient(Client client, decimal ancienneValeurId)
        {
            try
            {
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;
                oleDbCommand.CommandText = "UPDATE TB_Clients SET CLNUM = @CLNUM, CLNOM = @CLNOM, CLMTDI = @CLMTDI, CLADR1 = @CLADR1, CLADR2 = @CLADR2, CLCPOS = @CLCPOS, CLVILL = @CLVILL, CLREGL = @CLREGL, CLBASE = @CLBASE, CLDEPA = @CLDEPA, CLECHE = @CLECHE, CLARRI = @CLARRI, CLBQUE = @CLBQUE, CLGUI = @CLGUI, CLCPTE = @CLCPTE, CLRIB = @CLRIB, CLDOM = @CLDOM, CLREP = @CLREP, CLEDIT = @CLEDIT, CLFAMI = @CLFAMI, CLTRAN = @CLTRAN, CLLIVR = @CLLIVR, CLFACT = @CLFACT, CLCOMP = @CLCOMP, CLRIST = @CLRIST, CLREMI = @CLREMI, CLCODE = @CLCODE, CLTVA = @CLTVA, CLENSE = @CLENSE, CLDIV = @CLDIV, CLINTRA = @CLINTRA WHERE CLNUM = " + ancienneValeurId;
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@CLNUM", client.CLNUM);
                oleDbCommand.Parameters.AddWithValue("@CLNOM", client.CLNOM);
                oleDbCommand.Parameters.AddWithValue("@CLMTDI", client.CLMTDI);
                oleDbCommand.Parameters.AddWithValue("@CLADR1", client.CLADR1);
                oleDbCommand.Parameters.AddWithValue("@CLADR2", client.CLADR2);
                oleDbCommand.Parameters.AddWithValue("@CLCPOS", client.CLCPOS);
                oleDbCommand.Parameters.AddWithValue("@CLVILL", client.CLVILL);
                oleDbCommand.Parameters.AddWithValue("@CLREGL", client.CLREGL);
                oleDbCommand.Parameters.AddWithValue("@CLBASE", client.CLBASE);
                oleDbCommand.Parameters.AddWithValue("@CLDEPA", client.CLDEPA);
                oleDbCommand.Parameters.AddWithValue("@CLECHE", client.CLECHE);
                oleDbCommand.Parameters.AddWithValue("@CLARRI", client.CLARRI);
                oleDbCommand.Parameters.AddWithValue("@CLBQUE", client.CLBQUE);
                oleDbCommand.Parameters.AddWithValue("@CLGUI", client.CLGUI);
                oleDbCommand.Parameters.AddWithValue("@CLCPTE", client.CLCPTE);
                oleDbCommand.Parameters.AddWithValue("@CLRIB", client.CLRIB);
                oleDbCommand.Parameters.AddWithValue("@CLDOM", client.CLDOM);
                oleDbCommand.Parameters.AddWithValue("@CLREP", client.CLREP);
                oleDbCommand.Parameters.AddWithValue("@CLEDIT", client.CLEDIT);
                oleDbCommand.Parameters.AddWithValue("@CLFAMI", client.CLFAMI);
                oleDbCommand.Parameters.AddWithValue("@CLTRAN", client.CLTRAN);
                oleDbCommand.Parameters.AddWithValue("@CLLIVR", client.CLLIVR);
                oleDbCommand.Parameters.AddWithValue("@CLFACT", client.CLFACT);
                oleDbCommand.Parameters.AddWithValue("@CLCOMP", client.CLCOMP);
                oleDbCommand.Parameters.AddWithValue("@CLRIST", client.CLRIST);
                oleDbCommand.Parameters.AddWithValue("@CLREMI", client.CLREMI);
                oleDbCommand.Parameters.AddWithValue("@CLCODE", client.CLCODE);
                oleDbCommand.Parameters.AddWithValue("@CLTVA", client.CLTVA);
                oleDbCommand.Parameters.AddWithValue("@CLENSE", client.CLENSE);
                oleDbCommand.Parameters.AddWithValue("@CLDIV", client.CLDIV);
                oleDbCommand.Parameters.AddWithValue("@CLINTRA", client.CLINTRA);

                // oleDbCommand.Parameters.AddWithValue("@FACTURATION", fromagerie.FACTURATION);

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

        public static Client ExisteNumClient(decimal clnum)
        {
            try
            {
                // Initialisation de l'objet Lot
                Client client = new Client();
                OleDbDataReader reader;

                // Ouverture de la connexion
                open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = connection;

                // Requête SQL pour vérifier l'existence d'un lot
                oleDbCommand.CommandText = "SELECT CLNUM FROM TB_Clients WHERE  CLNUM = @CLNUM";

                // Préparation et exécution de la requête
                oleDbCommand.Prepare();
                oleDbCommand.Parameters.AddWithValue("@CLNUM", lofrom);
                oleDbCommand.ExecuteNonQuery();
                reader = oleDbCommand.ExecuteReader();

                if (reader.Read())
                {
                    // Si la requête a retourné des résultats, créez un objet Lot
                    client = new Client
                    {
                        // Assurez-vous de récupérer les valeurs appropriées depuis le reader
                        CLNUM = reader.GetDecimal(0)
                    };
                    return client;
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
    }
}
