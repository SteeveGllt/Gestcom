using Gestcom.Models;
using GestcomWF.DataAccess;
using GestcomWF.Models;
using System;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Security.Claims;

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

    }
}
