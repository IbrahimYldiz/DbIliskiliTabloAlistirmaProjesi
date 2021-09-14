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
    public partial class FrmSatis : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbIliskiliTabloAlistirma;Integrated Security=True");
        public FrmSatis()
        {
            InitializeComponent();
        }
        void CmbsShow()
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("select ID,ProductName from TblProduct", baglanti);
            DataTable dt6 = new DataTable();
            dt6.Load(komut.ExecuteReader());
            baglanti.Close();

            CmbProductName.DataSource = dt6;
            CmbProductName.DisplayMember = "ProductName";
            CmbProductName.ValueMember = "ID";
            

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select ID,CustomerNameSurname from TblCustomer", baglanti);
            DataTable dt1 = new DataTable();
            dt1.Load(komut1.ExecuteReader());
            baglanti.Close();

            CmbCustomer.DataSource = dt1;
            CmbCustomer.DisplayMember = "CustomerNameSurname";
            CmbCustomer.ValueMember = "ID";


            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select ID,PersonelName from TblPersonel", baglanti);
            DataTable dt2 = new DataTable();
            dt2.Load(komut2.ExecuteReader());
            baglanti.Close();

            CmbPersonel.DataSource = dt2;
            CmbPersonel.DisplayMember = "PersonelName";
            CmbPersonel.ValueMember = "ID";
           
        }
        
        void getir()
        {
            SqlDataAdapter da = new SqlDataAdapter("execute ProductShow ", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        string fiyat;
        private void BtnSell_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("update TblProduct set ProductStock=ProductStock-1 where ID=@p1", baglanti);
            SqlCommand komut3 = new SqlCommand("insert into TblHareket (Product,CustomerName,Personel,Fiyat) values(@p1,@p2,@p3,@p4)",baglanti);
            komut3.Parameters.AddWithValue("@p1", CmbProductName.SelectedValue);
            komut2.Parameters.AddWithValue("@p1", CmbProductName.SelectedValue);
            komut3.Parameters.AddWithValue("@p2", CmbCustomer.SelectedValue);
            komut3.Parameters.AddWithValue("@p3", CmbPersonel.SelectedValue);
            
        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            getir();
            CmbsShow();
            MessageBox.Show("Bu Program İbrahim Yıldız Tarafından 14.09.2021 Tarihinde Kodlanmıştır.");
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmUrunEklemeEkrani fr = new FrmUrunEklemeEkrani();
            fr.Show();
            
        }

        private void CmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
           
        }

        private void BtnSell_Click_1(object sender, EventArgs e)
        {
            if(CmbProductName.Text.Trim()!="")
            {
                if (CmbCustomer.Text.Trim() != "")
                {
                    baglanti.Open();
                    
                    SqlCommand komut2 = new SqlCommand("update TblProduct set ProductStock=ProductStock-1 where ID=@p1", baglanti);
                    
                    SqlCommand komut3 = new SqlCommand("insert into TblHareket (Product,CustomerName,Personel,Fiyat) values(@p1,@p2,@p3,@p4)", baglanti);
                    
                    komut3.Parameters.AddWithValue("@p1", a);
                    komut2.Parameters.AddWithValue("@p1", a);
                    komut3.Parameters.AddWithValue("@p2", CmbCustomer.SelectedValue);
                    komut3.Parameters.AddWithValue("@p3", CmbPersonel.SelectedValue);
                    komut3.Parameters.AddWithValue("@p4", label10.Text);

                    
                    
                    
                    

                    komut2.ExecuteNonQuery();
                    komut3.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Satış Gerçekleşti");
                    getir();

                }
                else
                {
                    MessageBox.Show("Lütfen Satış değerlerini giriniz");
                }
            }
            else 
            {
                MessageBox.Show("Lütfen Satış değerlerini giriniz");
            }
            
        }
        void fiyatgetir()
        {
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select SatisFiyat from TblProduct where ID=@p5", baglanti);
            komut4.Parameters.AddWithValue("@p5", label9.Text);
            SqlDataReader dr10 = komut4.ExecuteReader();

            while (dr10.Read())
            {
                label10.Text = dr10[0].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
           
        }
        private string a;
        private void CmbProductName_SelectedValueChanged(object sender, EventArgs e)
        {
            
            a = CmbProductName.SelectedValue.ToString();
            label9.Text = a.ToString();
        }

        private void label9_TextChanged(object sender, EventArgs e)
        {
            fiyatgetir();
        }

        private void BtnStokUpdate_Click(object sender, EventArgs e)
        {
            if(TxtStock.Text.Trim()!="")
            {
                baglanti.Open();
                SqlCommand komut8 = new SqlCommand("update TblProduct SET ProductStock=ProductStock+@p2 where ID=@p1", baglanti);
                komut8.Parameters.AddWithValue("@p1", label9.Text);
                komut8.Parameters.AddWithValue("@p2", TxtStock.Text);
                komut8.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(CmbProductName.Text+ " Stok Güncellendi");
                getir();
            }
            else
            {
                MessageBox.Show("Stok miktarını giriniz");
            }

        }

        private void FrmSatis_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Exit();
        }
    }
}
