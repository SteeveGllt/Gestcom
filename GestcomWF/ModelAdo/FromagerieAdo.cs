
using Gestcom.Models;
using GestcomWF.DataAccess;
using System.Data.OleDb;


namespace Gestcom.ModelAdo
{
    public class FromagerieAdo : DataAdo
    {
        public static List<Fromagerie> all()
        {
            try
            {

                List<Fromagerie> fromageries = new List<Fromagerie>();
                OleDbDataReader reader;
                open();
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT FRNUM FROM TB_Fromageries WHERE ((FRACTIF)=True) ORDER BY FRNUM");
                oleDbCommand.Connection = connection;
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    /*Fromagerie fromagerie = new Fromagerie((Decimal)reader["FRNUM"], (String)reader["FRNOM"], (String)reader["FRADR"], (Decimal)reader["FRCPOS"],
                        (String)reader["FRVILL"], (String)reader["FRNDIR"], (Decimal)reader["FRTYPE"], (Decimal)reader["FRTCON"], (Decimal)reader["FRCMEU"], 
                        (Decimal)reader["FRCPOI"], (String)reader["FRMODR"], (String)reader["FRDOMI"], (Decimal)reader["FRBANQ"], (Decimal)reader["FRGUIC"], 
                        (String)reader["FRCOM1"], (String)reader["FRCOM2"], (Decimal)reader["COE1"], (Decimal)reader["COE2"], (Decimal)reader["COE3"], 
                        (Decimal)reader["COE4"], (Decimal)reader["FRREFA"], (Decimal)reader["FRPUAC"], (Decimal)reader["FRETRE"], (String)reader["FRHIVE"], 
                        (String)reader["FRCVER"], (Decimal)reader["FRVVER"], (String)reader["FREVER"], (Boolean)reader["FRACTIF"]);*/
                    Fromagerie fromagerie = new Fromagerie((Decimal)reader["FRNUM"]);

                    fromageries.Add(fromagerie);
                }
                Console.WriteLine(reader);
                reader.Close();
                return fromageries;
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
        public static List<Fromagerie> allNonActif()
        {
            try
            {

                List<Fromagerie> fromageries = new List<Fromagerie>();
                OleDbDataReader reader;
                open();
                OleDbCommand oleDbCommand = new OleDbCommand("SELECT FRNUM FROM TB_Fromageries WHERE ((FRACTIF)=False) ORDER BY FRNUM");
                oleDbCommand.Connection = connection;
                reader = oleDbCommand.ExecuteReader();
                while (reader.Read())
                {
                    /*Fromagerie fromagerie = new Fromagerie((Decimal)reader["FRNUM"], (String)reader["FRNOM"], (String)reader["FRADR"], (Decimal)reader["FRCPOS"],
                        (String)reader["FRVILL"], (String)reader["FRNDIR"], (Decimal)reader["FRTYPE"], (Decimal)reader["FRTCON"], (Decimal)reader["FRCMEU"], 
                        (Decimal)reader["FRCPOI"], (String)reader["FRMODR"], (String)reader["FRDOMI"], (Decimal)reader["FRBANQ"], (Decimal)reader["FRGUIC"], 
                        (String)reader["FRCOM1"], (String)reader["FRCOM2"], (Decimal)reader["COE1"], (Decimal)reader["COE2"], (Decimal)reader["COE3"], 
                        (Decimal)reader["COE4"], (Decimal)reader["FRREFA"], (Decimal)reader["FRPUAC"], (Decimal)reader["FRETRE"], (String)reader["FRHIVE"], 
                        (String)reader["FRCVER"], (Decimal)reader["FRVVER"], (String)reader["FREVER"], (Boolean)reader["FRACTIF"]);*/
                    Fromagerie fromagerie = new Fromagerie((Decimal)reader["FRNUM"]);

                    fromageries.Add(fromagerie);
                }
                Console.WriteLine(reader);
                reader.Close();
                return fromageries;
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
