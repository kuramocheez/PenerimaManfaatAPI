using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace PenerimaManfaatAPI
{
    public class KategoriDAO
    {
        private MySqlCommand cmd = null;
        MySqlConnection conn = new MySqlConnection();
        string ServerConf = "Server = localhost; userid = root; password =; Database = penerima_manfaat";
        public KategoriDAO()
        {
            conn.ConnectionString = ServerConf;
        }
        private DataSet getData()
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM kategori_jenispaket";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(ds, "dataKategori");
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when get data: " + e.Message);
            }
            return ds;
        }
        private bool InsertData(String kategori, String nominalPaket)
        {
            Boolean status = false;
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO kategori_jenispaket (kategori, nominal_paket) VALUES ('" + kategori + "', '" + nominalPaket + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                status = true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when get data: " + e.Message);
            }
            return status;
        }
        private bool UpdateData(String kategori, String nominalPaket, int id)
        {
            Boolean status = false;
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE kategori_jenispaket SET kategori = '" + kategori + "', nominal_paket = '" + nominalPaket + "' WHERE id = '" + id + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                status = true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when get data: " + e.Message);
            }
            return status;
        }
        private bool DeleteData(int id)
        {
            Boolean status = false;
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM kategori_jenispaket WHERE id = '" + id + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                status = true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when get data: " + e.Message);
            }
            return status;
        }
        public DataSet getKategori()
        {
            return getData();
        }
        public void TambahKategori(String kategori, String nominalPaket)
        {
            InsertData(kategori, nominalPaket);
        }
        public void UbahKategori(String kategori, String nominalPaket, int idU)
        {
            UpdateData(kategori, nominalPaket, idU);
        }
        public void DeleteKategori(int idH)
        {
            DeleteData(idH);
        }
    }
}
