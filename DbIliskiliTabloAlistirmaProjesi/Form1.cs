using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbIliskiliTabloAlistirmaProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbIliskiliTabloAlistirmaDataSet.getir' table. You can move, or remove it, as needed.
            this.getirTableAdapter.Fill(this.dbIliskiliTabloAlistirmaDataSet.getir);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            FrmSatis fr = new FrmSatis();
            fr.Show();
            this.Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrmSatis fr = new FrmSatis();
            fr.Show();
            this.Close();
        }
    }
}
