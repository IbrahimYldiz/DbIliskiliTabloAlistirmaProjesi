using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DbIliskiliTabloAlistirmaProjesi
{
    public partial class FrmUrunEklemeEkrani : Form
    {
        public FrmUrunEklemeEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbIliskiliTabloAlistirma;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtProductName.Text.Trim() != "")
            {
                baglanti.Open();
                SqlCommand komut1 = new SqlCommand("insert into TblProduct (ProductName,SatisFiyat) values (@p1,@p2)", baglanti);
                komut1.Parameters.AddWithValue("@p1", TxtProductName.Text);
                komut1.Parameters.AddWithValue("@p2", textBox1.Text);
                komut1.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı");
            }
            else
            {
                MessageBox.Show("Lütfen Ürün Adını Doldurunuz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSatis fr = new FrmSatis();
            fr.Show();
            this.Close();
        }
    }
}
