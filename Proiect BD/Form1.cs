using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;



namespace Proiect_BD
{
    public partial class Form1 : Form
    {

        bool logat_administrator = false;
        bool logat_client = false;
        bool apasat_total = false;
        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;

        //initializare obiecte utilizate pentru salvarea datelor in baza de date (sau alte medii de stocare...daca exista implementare corespunzatoare)

        IStocareAdministrator stocareAdministratori = (IStocareAdministrator)new StocareFactory().GetTipStocare(typeof(Administrator));
        IStocareClienti stocareClienti = (IStocareClienti)new StocareFactory().GetTipStocare(typeof(Clienti));
        IStocareElectrocasnice stocareElectrocasnice = (IStocareElectrocasnice)new StocareFactory().GetTipStocare(typeof(Electrocasnice));
        IStocareCumparaturi stocareCumparaturi= (IStocareCumparaturi)new StocareFactory().GetTipStocare(typeof(Cumparaturi));
        public List<Electrocasnice> listaElectrocasnice;
        public List<Cumparaturi> listaCumparaturi;
        private Electrocasnice electrocasnicSelectat;
        //private Clienti clientLogat;
        string nume_logat;
        public Form1()
        {
            InitializeComponent();
            //listaElectrocasnice = stocareElectrocasnice.GetElectrocasnice();
        }

        
        private void panel_universal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDBHelper.ExecuteNonQuery("truncate table cumparaturi_sga",CommandType.Text);
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_login.Visible = false;
            panel_produse.Visible = false;
            panel_vanzari.Visible = false;
            panel_login_client.Visible = false;
            panel_sign_up_client.Visible = false;
            panel__afisare_admini.Visible = false;
            panel_afisare_clienti.Visible = false;
            panel_cumparare.Visible = false;
            //panel_cos.Visible = false;

            btn_add.Visible = false;
            btn_delete.Visible = false;
            btn_update.Visible = false;
            btn_buy.Visible = false;
            //enabled butoane
            btn_admins.Enabled = false;
            btn_clients.Enabled = false;
            btn_cart.Enabled = false;

            //
            label_id_cumparare.Visible = false;
            
        }

        private void shop_interf_Click(object sender, EventArgs e)
        {
            
            if(logat_administrator)
            {
                btn_add.Visible = true;
                btn_delete.Visible = true;
                btn_update.Visible = true;
                btn_buy.Visible = true;
            }
            if(logat_client)
            {
                btn_add.Visible = false;
                btn_delete.Visible = false;
                btn_update.Visible = false;
                btn_buy.Visible = true;
            }
            panel_update.Visible = false;
            label_id.Visible = false;
            AfiseazaElectrocasnice();
            panel_login.Visible = false;
            panel_produse.Visible = true;
            panel_vanzari.Visible = false;
            panel_login_client.Visible = false;
            panel_sign_up_client.Visible = false;
            panel__afisare_admini.Visible = false;
            panel_afisare_clienti.Visible = false;
            panel_cumparare.Visible = false;
            

        }

        //afiseaza electrocasnicele

        public void AfiseazaElectrocasnice()
        {
            try
            {
                        //var vanzari = stocareCumparaturi.GetCumparaturi();
                        //listaElectrocasnice = stocareElectrocasnice.GetElectrocasnice();
                        //data_grid_vanzari.DataSource = vanzari.Select(a => new { a.nume_utilizator_client, a.denumire, a.marca, a.model, a.stoc, a.descriere, a.culoare, a.pret, a.total, a.plata }).ToList();

                        
                    var electrocasnice = stocareElectrocasnice.GetElectrocasnice();
                    data_grid_produse.DataSource = electrocasnice.Select(a => new {a.idprodus, a.denumire, a.marca, a.model, a.stoc, a.descriere, a.culoare, a.pret }).ToList();
                
                    //data_grid_produse.Columns["idprodus"].HeaderText = "Id produs";
                    data_grid_produse.Columns["idprodus"].Visible = false;
                    data_grid_produse.Columns["denumire"].HeaderText = "Denumire";
                    data_grid_produse.Columns["marca"].HeaderText = "Marca";
                    data_grid_produse.Columns["model"].HeaderText = "Model";
                    data_grid_produse.Columns["stoc"].HeaderText = "Stoc";
                    data_grid_produse.Columns["descriere"].HeaderText = "Descriere";
                    data_grid_produse.Columns["culoare"].HeaderText = "Culoare";
                    data_grid_produse.Columns["pret"].HeaderText = "Pret";
                
                    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void cart_interf_Click(object sender, EventArgs e)
        {
            AfiseazaCumparaturi();
            panel_login.Visible = false;
            panel_produse.Visible = false;
            panel_vanzari.Visible = true;
            panel_login_client.Visible = false;
            panel_sign_up_client.Visible = false;
            panel__afisare_admini.Visible = false;
            panel_afisare_clienti.Visible = false;
            panel_cumparare.Visible = false;
            
        }

        public void AfiseazaCumparaturi()
        {
            try
            {
                
                    var vanzari = stocareCumparaturi.GetCumparaturi();
                    listaElectrocasnice = stocareElectrocasnice.GetElectrocasnice();
                    data_grid_vanzari.DataSource = vanzari.Select(a => new { a.nume_utilizator_client, a.denumire, a.marca, a.model, a.stoc, a.descriere, a.culoare, a.pret, a.total, a.plata }).ToList();

                    //listaCumparaturi = stocareCumparaturi.GetCumparaturi();
                    //if (listaCumparaturi.Count != null)
                    //{
                    //data_grid_vanzari.DataSource = listaCumparaturi;
                    data_grid_vanzari.Columns["nume_utilizator_client"].HeaderText = "Nume utilizator";
                    // data_grid_vanzari.Columns["idprodus"].HeaderText = "Id produs";
                    data_grid_vanzari.Columns["denumire"].HeaderText = "Denumire";
                    data_grid_vanzari.Columns["marca"].HeaderText = "Marca";
                    data_grid_vanzari.Columns["model"].HeaderText = "Model";
                    data_grid_vanzari.Columns["stoc"].HeaderText = "Numar produse";
                    data_grid_vanzari.Columns["descriere"].HeaderText = "Descriere";
                    data_grid_vanzari.Columns["culoare"].HeaderText = "Culoare";
                    data_grid_vanzari.Columns["pret"].HeaderText = "Pret";
                    data_grid_vanzari.Columns["total"].HeaderText = "Total";
                    data_grid_vanzari.Columns["plata"].HeaderText = "Plata";

                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void log_interf_Click(object sender, EventArgs e)
        {
            txt_username.Text = "Enter Username";
            txt_password.Text = "Enter Password";
            panel_login.Visible = true;
            panel_produse.Visible = false;
            panel_vanzari.Visible = false;
            panel_login_client.Visible = false;
            panel_sign_up_client.Visible = false;
            panel__afisare_admini.Visible = false;
            panel_afisare_clienti.Visible = false;
            panel_cumparare.Visible = false;
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void txt_username_MouseClick(object sender, MouseEventArgs e)
        {
            txt_username.Text = "";
        }

        private void txt_password_MouseClick(object sender, MouseEventArgs e)
        {
            txt_password.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_username_client.Text = "Enter Username";
            txt_password_client.Text = "Enter Password";
            txt_email_client.Text = "Enter Email";
            txt_phone_number_client.Text = "Enter Phone Number";
            panel_login.Visible = false;
            panel_produse.Visible = false;
            panel_vanzari.Visible = false;
            panel_login_client.Visible = true;
            panel_sign_up_client.Visible = false;
            panel__afisare_admini.Visible = false;
            panel_afisare_clienti.Visible = false;
            panel_cumparare.Visible = false;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = data_grid_produse.CurrentCell.RowIndex;
            string idElectrocasnic = data_grid_produse[PRIMA_COLOANA, currentRowIndex].Value.ToString();
            
            try
            {
                //Electrocasnice electro = stocareElectrocasnice.GetElectrocasnic(Int32.Parse(idElectrocasnic));
                electrocasnicSelectat = stocareElectrocasnice.GetElectrocasnic(Int32.Parse(idElectrocasnic));
                //incarcarea datelor in controalele de pe forma
                
                if (electrocasnicSelectat != null)
                {
                    txt_denumire.Text = electrocasnicSelectat.denumire;
                    txt_marca.Text = electrocasnicSelectat.marca;
                    txt_model.Text = electrocasnicSelectat.model;
                    txt_stoc.Text = electrocasnicSelectat.stoc.ToString();
                    txt_descriere.Text = electrocasnicSelectat.descriere;
                    txt_culoare.Text = electrocasnicSelectat.culoare;
                    txt_pret.Text = electrocasnicSelectat.pret.ToString();
                    label_id.Text = electrocasnicSelectat.idprodus.ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void panel_login_client_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_login_client_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_sign_up_Click(object sender, EventArgs e)
        {
            
            txt_sign_up_username.Text = "Enter Username";
            txt_sign_up_password.Text = "Enter Password";
            txt_sign_up_email.Text = "Enter Email";
            txt_sign_up_phone_number.Text = "Enter Phone Number";

            panel_login_client.Visible = false;
            panel_sign_up_client.Visible = true;
            panel__afisare_admini.Visible = false;
            panel_afisare_clienti.Visible = false;
            panel_cumparare.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form_add = new Form_Add();
            form_add.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form_add = new Form_Add();
            form_add.ShowDialog();
            AfiseazaElectrocasnice();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            txt_username_client.Text = "Enter Username";
            txt_password_client.Text = "Enter Password";
            panel_sign_up_client.Visible = false;
            panel_login_client.Visible = true;
            panel__afisare_admini.Visible = false;
            panel_afisare_clienti.Visible = false;
            panel_cumparare.Visible = false;
            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string nume_utilizator = txt_username.Text;
            string parola = txt_password.Text;

            var dsAdministratori = SqlDBHelper.ExecuteDataSet("select * from administrator_sga", CommandType.Text);
            String value;
            foreach (DataRow linieDB in dsAdministratori.Tables[0].Rows)
            {
                Administrator administrator = new Administrator(linieDB);
                if (nume_utilizator == administrator.nume_utilizator && parola == administrator.parola)
                {
                    var form_login_success = new Login_success();
                    form_login_success.Show();
                    logat_administrator = true;
                    panel_login.Visible = false;
                    lbl_log.Text = "Logged as administrator";
                    lbl_log2.Text = "Name:"+nume_utilizator;

                    //activare butoane
                    btn_cart.Enabled = true;
                    btn_clients.Enabled = true;
                    btn_admins.Enabled = true;
                    //
                    //vizibil butn buy

                    btn_buy.Enabled = false;
                }
            }
            if (logat_administrator == false)
            {
                var form_wrong_login = new Login_wrong();
                form_wrong_login.Show();
            }
            //logat_administrator = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_sign_up_password_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_sign_up_username_Click(object sender, EventArgs e)
        {
            //txt_sign_up_username.Text = "";
        }

        private void txt_sign_up_password_Click(object sender, EventArgs e)
        {
            txt_sign_up_password.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new Clienti(txt_sign_up_username.Text,txt_sign_up_email.Text, txt_sign_up_password.Text, txt_sign_up_phone_number.Text);

                var rezultat = stocareClienti.AddClient(client);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Te-ai inregistrat cu succes.");
                }

                else
                {
                    MessageBox.Show("Eroare la inregistrare");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void txt_username_client_Click(object sender, EventArgs e)
        {
            txt_username_client.Text = "";
            
        }

        private void txt_username_client_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_client_Click(object sender, EventArgs e)
        {
            txt_password_client.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AfiseazaAdmini();
            
            panel__afisare_admini.Visible = true;   
            panel_login.Visible = false;
            panel_produse.Visible = false;
            panel_vanzari.Visible = false;
            panel_login_client.Visible = false;
            panel_sign_up_client.Visible = false;
            panel_afisare_clienti.Visible = false;
            panel_cumparare.Visible = false;
            
        }

        // afiseaza adminii in tabelul de admini

        private void AfiseazaAdmini()
        {
            try
            {
                var administratori = stocareAdministratori.GetAdministratori();
                //data_grid_clienti.DataSource = clienti.Select(a => new { a.nume_utilizator_client,a.email_client,a.parola_client,a.numar_de_telefon_client }).ToList();
                if (administratori != null && administratori.Any())
                {
                    data_grid_admini.DataSource = administratori.Select(a => new { a.nume_utilizator, a.parola}).ToList();
                    data_grid_admini.Columns["nume_utilizator"].HeaderText = "Nume utilizator";
                    data_grid_admini.Columns["parola"].HeaderText = "Parola";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void panel_sign_up_client_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_log_in_client_Click(object sender, EventArgs e)
        {
            string nume_utilizator_client = txt_username_client.Text;
            string email_client = txt_email_client.Text;
            string parola_client = txt_password_client.Text;
            string numar_de_telefon_client = txt_phone_number_client.Text;

            var dsClienti = SqlDBHelper.ExecuteDataSet("select * from clienti_sga", CommandType.Text);
            String value;
            foreach (DataRow linieDB in dsClienti.Tables[0].Rows)
            {
                Clienti client = new Clienti(linieDB);
                if (nume_utilizator_client == client.nume_utilizator_client && parola_client == client.parola_client && email_client==client.email_client && numar_de_telefon_client==client.numar_de_telefon_client) 
                {
                    nume_logat = nume_utilizator_client;
                    var form_login_success = new Login_success();
                    form_login_success.Show();
                    logat_client = true;
                    panel_login_client.Visible = false;
                    lbl_log.Text = "Logged as client";
                    lbl_log2.Text = "Name:" + nume_utilizator_client;
                    btn_cart.Enabled = true;
                    btn_buy.Enabled = true;
                }
            }
            if (logat_client == false)
            {
                var form_wrong_login = new Login_wrong();
                form_wrong_login.Show();
            }
            //logat_client = false;
        }

        private void panel_produse_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_email_client_Click(object sender, EventArgs e)
        {
            txt_email_client.Text = "";
            
        }

        private void txt_phone_number_client_Click(object sender, EventArgs e)
        {
            txt_phone_number_client.Text = "";
        }

        private void txt_sign_up_username_Click_1(object sender, EventArgs e)
        {
            txt_sign_up_username.Text = "";
            
        }

        private void txt_sign_up_email_Click(object sender, EventArgs e)
        {
            txt_sign_up_email.Text = "";
        }

        private void txt_sign_up_phone_number_Click(object sender, EventArgs e)
        {
            txt_sign_up_phone_number.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AfiseazaClienti();
            panel_afisare_clienti.Visible = true;
            panel_login.Visible = false;
            panel_produse.Visible = false;
            panel_vanzari.Visible = false;
            panel_login_client.Visible = false;
            panel_sign_up_client.Visible = false;
            panel__afisare_admini.Visible = false;
            panel_cumparare.Visible = false;
            
        }

        private void AfiseazaClienti()
        {
            try
            {
                var clienti = stocareClienti.GetClienti();
                if (clienti != null && clienti.Any())
                {
                    data_grid_clienti.DataSource = clienti.Select(a => new { a.nume_utilizator_client,a.email_client,a.parola_client,a.numar_de_telefon_client }).ToList();
                    data_grid_clienti.Columns["nume_utilizator_client"].HeaderText = "Nume utilizator";
                    data_grid_clienti.Columns["email_client"].HeaderText = "Email";
                    data_grid_clienti.Columns["parola_client"].HeaderText = "Parola";
                    data_grid_clienti.Columns["numar_de_telefon_client"].HeaderText = "Numar de telefon";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            try
            {
                //label10.Text = idprodus.ToString();
                var rez = stocareElectrocasnice.DeleteElectrocasnic(electrocasnicSelectat);
                MessageBox.Show("Produsul a fost sters cu succes!");
                AfiseazaElectrocasnice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel_update.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bool validat = true;

            int stoc = 0;
            bool succes_stoc = Int32.TryParse(txt_stoc.Text, out stoc);
            int pret = 0;
            bool succes_pret = Int32.TryParse(txt_pret.Text, out pret);

            if (txt_denumire.Text == "" || txt_marca.Text == "" || txt_model.Text == "" || txt_stoc.Text == "" || txt_descriere.Text == "" || txt_culoare.Text == "" || txt_pret.Text == "")
            {
                MessageBox.Show("Editare esuata!!! Nu ati completat toate datele !!!");
                txt_pret.BackColor = Color.FromArgb(192, 64, 0);
                txt_stoc.BackColor = Color.FromArgb(192, 64, 0);
                validat = false;
                return;
            }
            if (!succes_pret || !succes_stoc)
            {

                if (!succes_pret)
                {
                    txt_pret.BackColor = Color.Red;
                    MessageBox.Show("Editare esuata!!! Nu ati introdus o valoare numerica pentru pret !!!");
                }
                else
                    txt_pret.BackColor = Color.FromArgb(192, 64, 0);
                if (!succes_stoc)
                {
                    txt_stoc.BackColor = Color.Red;
                    MessageBox.Show("Editare esuata!!! Nu ati introdus o valoare numerica pentru stoc !!!");
                }

                else
                    txt_stoc.BackColor = Color.FromArgb(192, 64, 0);
                validat = false;
            }


            if(validat)
            {
                try
                {
                    var electrocasnic = new Electrocasnice(
                        txt_denumire.Text,
                        txt_marca.Text,
                        txt_model.Text,
                        Int32.Parse(txt_stoc.Text),
                        txt_descriere.Text,
                        txt_culoare.Text,
                        Int32.Parse(txt_pret.Text),
                        Int32.Parse(label_id.Text)
                        );
                    label_id.Text = txt_model.Text + " " + txt_stoc.Text + " ";
                    var rez = stocareElectrocasnice.UpdateElectrocasnic(electrocasnic);
                    if (rez == SUCCES)
                    {
                        MessageBox.Show("Produs actualizat cu succes!");
                        AfiseazaElectrocasnice();
                    }
                    else
                    {
                        MessageBox.Show("Eroare actualizare produs!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exceptie" + ex.Message);
                }
            }
            
        }

        private void AfiseazaPentruCumparaturi()
        {
            try
            {
                /* listaElectrocasnice = stocareElectrocasnice.GetElectrocasnice();
                 if (listaElectrocasnice.Count != null)
                 {
                     data_grid_cumparare.DataSource = listaElectrocasnice;
                     // data_grid_admini.Columns["nume_utilizator"].HeaderText = "Nume utilizator";
                     //data_grid_admini.Columns["email"].HeaderText = "Email";
                     //data_grid_admini.Columns["parola"].HeaderText = "Parola";
                     //data_grid_admini.Columns["numar_telefon"].HeaderText = "Numar telefon";
                 }*/

                var electrocasnice = stocareElectrocasnice.GetElectrocasnice();
                data_grid_cumparare.DataSource = electrocasnice.Select(a => new { a.idprodus, a.denumire, a.marca, a.model, a.stoc, a.descriere, a.culoare, a.pret }).ToList();

                //data_grid_produse.Columns["idprodus"].HeaderText = "Id produs";
                data_grid_cumparare.Columns["idprodus"].Visible = false;
                data_grid_cumparare.Columns["denumire"].HeaderText = "Denumire";
                data_grid_cumparare.Columns["marca"].HeaderText = "Marca";
                data_grid_cumparare.Columns["model"].HeaderText = "Model";
                data_grid_cumparare.Columns["stoc"].HeaderText = "Stoc";
                data_grid_cumparare.Columns["descriere"].HeaderText = "Descriere";
                data_grid_cumparare.Columns["culoare"].HeaderText = "Culoare";
                data_grid_cumparare.Columns["pret"].HeaderText = "Pret";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btn_buy_Click(object sender, EventArgs e)
        {
            AfiseazaPentruCumparaturi();
            
            panel_produse.Visible = false;
            panel_cumparare.Visible = true;
        }

        private void data_grid_cumparare_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = data_grid_cumparare.CurrentCell.RowIndex;
            string idElectrocasnic = data_grid_cumparare[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                //Electrocasnice electro = stocareElectrocasnice.GetElectrocasnic(Int32.Parse(idElectrocasnic));
                electrocasnicSelectat = stocareElectrocasnice.GetElectrocasnic(Int32.Parse(idElectrocasnic));
                //incarcarea datelor in controalele de pe forma

                if (electrocasnicSelectat != null)
                {
                    lbl_denumire.Text = electrocasnicSelectat.denumire;
                    lbl_marca.Text = electrocasnicSelectat.marca;
                    lbl_model.Text = electrocasnicSelectat.model;
                    textbox_stoc.Text = electrocasnicSelectat.stoc.ToString();
                    lbl_descriere.Text = electrocasnicSelectat.descriere;
                    lbl_culoare.Text = electrocasnicSelectat.culoare;
                    lbl_pret.Text = electrocasnicSelectat.pret.ToString();
                    label_id_cumparare.Text = electrocasnicSelectat.idprodus.ToString();
                    label_total.Text = (Convert.ToInt32(lbl_pret.Text) * Convert.ToInt32(textbox_stoc.Text)).ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_calculeaza_total_Click(object sender, EventArgs e)
        {
            apasat_total = true;
            label_total.Text = (Convert.ToInt32(lbl_pret.Text) * Convert.ToInt32(textbox_stoc.Text)).ToString();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btn_pay_Click(object sender, EventArgs e)
        {

            

            Electrocasnice elec_modificare = electrocasnicSelectat;
            elec_modificare.stoc = electrocasnicSelectat.stoc - Convert.ToInt32(textbox_stoc.Text);
            string erori = "";
            bool validare_plata = true;
            bool validat = true;
            int nr_produs = 0;

            bool succes_stoc = Int32.TryParse(textbox_stoc.Text, out nr_produs);

            
            if (!succes_stoc)
            {
                MessageBox.Show("Format incorect numar produse");
                validare_plata = false;
            }
            if (apasat_total == false)
            {
                MessageBox.Show("Nu ati apasat butonul caluculeaza total pentru a efectua o plata corecta");
                validare_plata = false;
                
            }
            if (elec_modificare.stoc < 0)
            {
                MessageBox.Show("Nu exista suficiente produse pe stoc !! Plata nu a fost efectuata !!");
                validare_plata = false;
                
            }
            if(Convert.ToInt32(textbox_stoc.Text)<=0)
            {
                MessageBox.Show("Numar de produse invalid");
                validare_plata = false;
                
            }
            if(cmbPlati.SelectedItem==null)
            {
                MessageBox.Show("Nu ati selectat o metoda de plata!");
                validare_plata = false;
            }
            
            if (validare_plata)
            {
                try
                {


                    var cumparatura = new Cumparaturi(nume_logat, lbl_denumire.Text, lbl_marca.Text, lbl_model.Text, Convert.ToInt32(textbox_stoc.Text), lbl_descriere.Text, lbl_culoare.Text, Convert.ToInt32(lbl_pret.Text), Convert.ToInt32(label_total.Text), cmbPlati.SelectedItem.ToString(), Convert.ToInt32(label_id_cumparare.Text));
                    //MessageBox.Show(electrocasnicSelectat.stoc.ToString());

                    var rezultat = stocareCumparaturi.AddCumparatura(cumparatura);


                    //MessageBox.Show(elec_modificare.stoc.ToString());
                    var rez = stocareElectrocasnice.UpdateElectrocasnicLaCumparare(elec_modificare);

                    if (rezultat == SUCCES)
                    {
                        //MessageBox.Show("Produsul a fost cumparat !! Puteti vedea plata dumneavoastra efectuata in istoric");
                        SqlDBHelper.ExecuteNonQuery("Commit", CommandType.Text);
                        AfisarePlatacs afisare = new AfisarePlatacs();
                        afisare.ShowDialog();
                        AfiseazaPentruCumparaturi();
                    }

                    else
                    {
                        MessageBox.Show("Eroare la cumparare");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exceptie" + ex.Message);
                }
            }
            lbl_denumire.Text = "";
            lbl_marca.Text = "";
            lbl_model.Text = "";
            textbox_stoc.Text = "";
            lbl_descriere.Text = "";
            lbl_culoare.Text = "";
            lbl_pret.Text = "";
            label_total.Text = "";

        }

        private void data_grid_clienti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //butoane form produse
            btn_buy.Visible = false;
            btn_delete.Visible = false;
            btn_add.Visible = false;
            btn_update.Visible = false;

            ///butoane principale

            btn_admins.Enabled = false;
            btn_cart.Enabled = false;
            btn_clients.Enabled = false;
             
            ///

            logat_administrator = false;
            logat_client = false;
            lbl_log.Text = "";
            lbl_log2.Text = "";
        }
    }
}
