using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PenerimaManfaatAPI
{
    public class APIPenerimaManfaat
    {
        KategoriDAO kt = new KategoriDAO();
        AsessorDAO a = new AsessorDAO();
        public DataSet getKategori()
        {
            return kt.getKategori();
        }
        public void tambahKategori(String kategori, String nominalPaket)
        {
            kt.TambahKategori(kategori, nominalPaket);
        }
        public void ubahKatgori(String kategori, String nominalPaket, int id)
        {
            kt.UbahKategori(kategori, nominalPaket, id);
        }
        public void hapusKategori(int id)
        {
            kt.DeleteKategori(id);
        }
        public void getAsessor()
        {
            a.getAsessor();
        }
        public void tambahAsessor(String nama, String jenis_kelamin, string nomor_telpon)
        {
            a.TambahAsessor(nama, jenis_kelamin, nomor_telpon);
        }
        public void ubahAsessor(String nama, String jenis_kelamin, string nomor_telpon, int id)
        {
            a.UbahAsessor(nama, jenis_kelamin, nomor_telpon, id);
        }
        public void hapusAsessor(int id)
        {
            a.HapusAsessor(id);
        }
    }
}
