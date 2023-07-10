using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using NivelAccesDate;

namespace Proiect_BD
{
    public partial class Form_Add : Form
    {

        IStocareElectrocasnice stocareElectrocasnice = (IStocareElectrocasnice)new StocareFactory().GetTipStocare(typeof(Electrocasnice));
        private const bool SUCCES = true;
        public Form_Add()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool validat = true;

            int stoc = 0;
            bool succes_stoc = Int32.TryParse(txt_stoc.Text, out stoc);
            int pret = 0;
            bool succes_pret = Int32.TryParse(txt_pret.Text, out pret);

            if (txt_denumire.Text == "" || txt_marca.Text == "" || txt_model.Text == "" || txt_stoc.Text == "" || txt_descriere.Text == "" || txt_culoare.Text == "" || txt_pret.Text == "")
            {
                MessageBox.Show("Adaugare esuata!!! Nu ati completat toate datele !!!");
                validat = false;
                return;
            }
            if (!succes_pret || !succes_stoc)
            {
                
                if (!succes_pret)
                {
                    txt_pret.BackColor = Color.Red;
                    MessageBox.Show("Adaugare esuata!!! Nu ati introdus o valoare numerica pentru pret !!!");
                }  
                else
                    txt_pret.BackColor = Color.FromArgb(192, 64, 0);
                if (!succes_stoc)
                {
                    txt_stoc.BackColor = Color.Red;
                    MessageBox.Show("Adaugare esuata!!! Nu ati introdus o valoare numerica pentru stoc !!!");
                }
                    
                else
                    txt_stoc.BackColor = Color.FromArgb(192, 64, 0);
                validat = false;
            }
            


            if(validat)
            {

                try
                {

                    var electrocasnic = new Electrocasnice(txt_denumire.Text, txt_marca.Text, txt_model.Text, Convert.ToInt32(txt_stoc.Text), txt_descriere.Text, txt_culoare.Text, Convert.ToInt32(txt_pret.Text));

                    var rezultat = stocareElectrocasnice.AddElectrocasnic(electrocasnic);
                    if (rezultat == SUCCES)
                    {

                        MessageBox.Show("adaugare cu succes");
                        SqlDBHelper.ExecuteNonQuery("Commit", CommandType.Text);
                    }

                    else
                    {
                        MessageBox.Show("Eroare la adaugare");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exceptie" + ex.Message);
                }
            }
            
        }

        private void Form_Add_Load(object sender, EventArgs e)
        {

        }
    }
}
