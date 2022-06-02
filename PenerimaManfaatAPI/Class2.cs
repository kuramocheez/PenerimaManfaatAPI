using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace PenerimaManfaatAPI
{
    class AsessorDAO
    {
        private MySqlCommand cmd = null;
        MySqlConnection conn = new MySqlConnection();
        string ServerConf = "Server = localhost; userid = root; password =; Database = penerima_manfaat";
        public AsessorDAO()
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
                cmd.CommandText = "SELECT * FROM asessor";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(ds, "dataGrid");
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when get data: " + e.Message);
            }
            return ds;
        }
        private bool InsertData(String nama, String jenis_kelamin, string nomor_telpon)
        {
            Boolean status = false;
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO asessor (nama, jenis_kelamin, nomor_telpon) VALUES ('" + nama + "', '" + jenis_kelamin + "', '" + nomor_telpon + "')";
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
        private bool UpdateData(String nama, String jenis_kelamin, string nomor_telpon, int id)
        {
            Boolean status = false;
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE asessor SET nama = '" + nama + "', jenis_kelamin '" + jenis_kelamin + "', nomor_telpon = '" + nomor_telpon + "' WHERE id = '" + id + "'";
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
                cmd.CommandText = "DELETE FROM asessor WHERE id = '" + id + "'";
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
        public void getAsessor()
        {
            getData();
        }
        public void TambahAsessor(String nama, String jenis_kelamin, string nomor_telpon)
        {
            InsertData(nama, jenis_kelamin, nomor_telpon);
        }
        public void UbahAsessor(String nama, String jenis_kelamin, string nomor_telpon, int id)
        {
            UpdateData(nama, jenis_kelamin, nomor_telpon, id);
        }
        public void HapusAsessor(int id)
        {
            DeleteData(id);
        }
    }
}
