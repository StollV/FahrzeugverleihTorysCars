using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using NPoco;

namespace FahrzeugverleihTorysCars
{
    public partial class TorysCars : Form
    {

        List<Contact> lstContact = new List<Contact>();
       // List<Car> 1stCar = new List<Car>();
        string ConnectionString { get; } =
        ConfigurationManager.ConnectionStrings["mariadb"].ConnectionString;
        
        int angezeigteContactID;

        public TorysCars()
        {
            InitializeComponent();
        }
        public void TorysCar_Load(object sender, EventArgs e)
        {
            DatenLaden();
            AnzeigeAktualisieren();
        }
        private void ContactHinzufügen(Contact c)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                using (IDatabase db = new Database(connection))
                {
                    db.Connection.Open();
                    db.Insert(c);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        public void AnzeigeAktualisieren()
        {
            // Liste anzeigen
            dataGridView.DataSource = null;
            dataGridView.DataSource = lstContact;

        }
        public void DatenLaden()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                using (IDatabase db = new Database(connection))
                {
                    db.Connection.Open();
                    lstContact.Clear();
                    lstContact = db.Fetch<Contact>();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        private void ContactBearbeiten(Contact c)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                using (IDatabase db = new Database(connection))
                {
                    db.Connection.Open();
                    db.Update(c);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        private void ContactLöschen(Contact c)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                using (IDatabase db = new Database(connection))
                {
                    db.Connection.Open();
                    db.Delete(c);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        private void ContactAnzeigen(Contact c)
        {
            if (c == null)
                return;

            angezeigteContactID = c.ID;
            txtKontaktNachname.Text = c.Name;
            txtKontaktVorname.Text = c.Vorname;
            txtGeburtstag.Text = c.Geburtstag;
            txtKontaktAnschrift.Text = c.Anschrift;
            txtKontaktTelefon.Text = c.Telefon;
            txtKontaktMobil.Text = c.Mobil;
            txtKontaktEmail.Text = c.Email;
            txtPersNr.Text = c.PersonalausweisNr;
            c.AngelegtAm = DateTime.Now;    

        }
        private Contact sucheContact(int ID)
        {
            Contact c = null;
            foreach (Contact cc in lstContact)
            {
                if (cc.ID == ID)
                {
                    c = cc;
                }
            }
            return c;
        }
       

        //
        //_______________________________________________________BuTToNS_______________________________________________________
        //
        public void btnHinzufügen_Click(object sender, EventArgs e)
        {
            if (txtKontaktNachname.Text.Length == 0)
            {
                MessageBox.Show("Bitte Nachnamen eingeben");
            }
            else if (txtKontaktVorname.Text.Length == 0)
            {
                MessageBox.Show("Bitte Vorname eingeben");
            }
            else if (txtGeburtstag.Text.Length == 0)
            {
                MessageBox.Show("Bitte Geburtsdatum eingeben");
            }
            else if (txtKontaktAnschrift.Text.Length == 0)
            {
                MessageBox.Show("Bitte Adresse eingeben");
            }
            else if (txtKontaktTelefon.Text.Length == 0)
            {
                MessageBox.Show("Bitte Telefonnummer eingeben");
            }
            else if (txtKontaktMobil.Text.Length == 0)
            {
                MessageBox.Show("Bitte Handynummer eingeben");
            }
            else if (txtKontaktEmail.Text.Length == 0)
            {
                MessageBox.Show("Bitte Email eingeben");
            }
            else if (txtPersNr.Text.Length == 0)
            {
                MessageBox.Show("Bitte Personalausweisnummer eingeben");
            }    

            else
            {
                Contact c = new Contact (0, txtKontaktNachname.Text, txtKontaktVorname.Text, txtGeburtstag.Text, txtKontaktAnschrift.Text, txtKontaktTelefon.Text, txtKontaktMobil.Text, txtKontaktEmail.Text, txtPersNr.Text);

                txtKontaktNachname.Clear();
                txtKontaktVorname.Clear();
                txtGeburtstag.Clear();
                txtKontaktAnschrift.Clear();
                txtKontaktTelefon.Clear();
                txtKontaktMobil.Clear();
                txtKontaktEmail.Clear();
                txtPersNr.Clear();
                

                ContactHinzufügen(c);
                DatenLaden();
                AnzeigeAktualisieren();
               
            }

        }

        private void btnÖffnen_Click(object sender, EventArgs e)
        {
            Object o = dataGridView;
            Contact contact = o as Contact;
            if (c == 0)
                return;
            ContactAnzeigen(sucheContact(c));

        }
      

        public void btnUpate_Click(object sender, EventArgs e)
        {
            Object o = dataGridView;
            Contact contact = o as Contact;

            if (txtKontaktID.Text.Length == 0)
            {
                MessageBox.Show("Bitte eine ID eingeben");
                txtKontaktID.Clear();
            }

            else
            {
                string cc = txtKontaktID.Text;
                int ID = Convert.ToInt32(cc);

                ContactAnzeigen(sucheContact(ID));
                //PersonLöschen(person);
                DatenLaden();
                AnzeigeAktualisieren();

                txtKontaktID.Clear();
            }
        }

        public void btnLöschen_Click(object sender, EventArgs e)
        {
            Object o = dataGridView;
            Contact person = o as Contact;

            //int IDpl = Convert.ToInt32(pl);

            if (txtKontaktID.Text.Length == 0)
            {

                MessageBox.Show("Bitte die zu löschende ID eingeben");
                txtKontaktID.Clear();
            }

            else
            {
                string pp = txtKontaktID.Text;
                int ID = Convert.ToInt32(pp);


                //PersonAnzeigen(suchePerson(ID));
                ContactLöschen(sucheContact(ID));
                //DatenLaden();
                AnzeigeAktualisieren();

                txtKontaktID.Clear();
            }



            DatenLaden();
            AnzeigeAktualisieren();

            txtKontaktID.Clear();
        }

        //
        //___________________________________________________________TeXTBoX___CoNTaCT___________________________________
        //
        public void txtKontaktID_TextChanged(object sender, EventArgs e)
        {
            if (txtKontaktID.Text == "")
            {

            }
            else
            {
                try
                {
                    UInt16 Variable = Convert.ToUInt16(txtKontaktID.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unbekannte ID-Nr.");
                    txtKontaktID.Clear();
                }
            }
        }

        public void txtKontaktVorname_TextChanged(object sender, EventArgs e)
        {
            if ((txtKontaktVorname.Text == ""))
            {

            }
            else if (txtKontaktVorname.Text.Length > 15)
            {
                MessageBox.Show("Name zu lang");
                txtKontaktVorname.Text = txtKontaktVorname.Text.Remove(txtKontaktVorname.Text.Length - 1, 1);
                txtKontaktVorname.SelectionStart = txtKontaktVorname.Text.Length; //Setzt Selection ans Ende des Textes
            }
            else if (new[] { "a", "b", "c", "d", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ä", "ö", "ü", "ß", ",", "-", "_", ".", "e" }.Contains(txtKontaktVorname.Text.Substring(txtKontaktVorname.Text.Length - 1, 1).ToLower()))
            {

                string Variable = txtKontaktVorname.Text;

            }

            else
            {
                MessageBox.Show("keine Sonderzeichen und Zahlen erlaubt");
                txtKontaktVorname.Text = txtKontaktVorname.Text.Remove(txtKontaktVorname.Text.Length - 1, 1);
                txtKontaktVorname.SelectionStart = txtKontaktVorname.Text.Length; //Setzt Selection ans Ende des Textes
            }
        }

        public void txtKontaktNachname_TextChanged(object sender, EventArgs e)
        {
            if ((txtKontaktNachname.Text == ""))
            {

            }
            else if (txtKontaktNachname.Text.Length > 15)
            {
                MessageBox.Show("Name zu lang");
                txtKontaktNachname.Text = txtKontaktNachname.Text.Remove(txtKontaktNachname.Text.Length - 1, 1);
                txtKontaktNachname.SelectionStart = txtKontaktNachname.Text.Length; //Setzt Selection ans Ende des Textes
            }
            else if (new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ä", "ö", "ü", "ß", ",", "-", "_", "." }.Contains(txtKontaktNachname.Text.Substring(txtKontaktNachname.Text.Length - 1, 1).ToLower()))
            {

                string Variable = txtKontaktNachname.Text;

            }

            else
            {
                MessageBox.Show("keine Sonderzeichen und Zahlen erlaubt");
                txtKontaktNachname.Text = txtKontaktNachname.Text.Remove(txtKontaktNachname.Text.Length - 1, 1);
                txtKontaktNachname.SelectionStart = txtKontaktNachname.Text.Length; //Setzt Selection ans Ende des Textes
            }
        }

        public void txtKontaktTelefon_TextChanged(object sender, EventArgs e)
        {
            if ((txtKontaktTelefon.Text == ""))
            {

            }
            else if (txtKontaktTelefon.Text.Length > 15)
            {
                MessageBox.Show("Name zu lang");
                txtKontaktTelefon.Text = txtKontaktTelefon.Text.Remove(txtKontaktTelefon.Text.Length - 1, 1);
                txtKontaktTelefon.SelectionStart = txtKontaktTelefon.Text.Length; //Setzt Selection ans Ende des Textes
            }
            else if (new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "/", "-"}.Contains(txtKontaktTelefon.Text.Substring(txtKontaktTelefon.Text.Length - 1, 1).ToLower()))
            {

                string Variable = txtKontaktTelefon.Text;

            }

            else
            {
                MessageBox.Show("Erlaubte Zeichen: 0-9, - , + , / ");
                txtKontaktNachname.Text = txtKontaktNachname.Text.Remove(txtKontaktNachname.Text.Length - 1, 1);
                txtKontaktNachname.SelectionStart = txtKontaktNachname.Text.Length; //Setzt Selection ans Ende des Textes
            }
        }

        public void txtKontaktMobil_TextChanged(object sender, EventArgs e)
        {
            if ((txtKontaktMobil.Text == ""))
            {

            }
            else if (txtKontaktMobil.Text.Length > 16)
            {
                MessageBox.Show("Nummer zu lang");
                txtKontaktMobil.Text = txtKontaktMobil.Text.Remove(txtKontaktMobil.Text.Length - 1, 1);
                txtKontaktMobil.SelectionStart = txtKontaktMobil.Text.Length; //Setzt Selection ans Ende des Textes
            }
            else if (new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "/", "-" }.Contains(txtKontaktMobil.Text.Substring(txtKontaktMobil.Text.Length - 1, 1).ToLower()))
            {

                string Variable = txtKontaktMobil.Text;

            }

            else
            {
                MessageBox.Show("Erlaubte Zeichen: 0-9, - , + , / ");
                txtKontaktMobil.Text = txtKontaktMobil.Text.Remove(txtKontaktMobil.Text.Length - 1, 1);
                txtKontaktMobil.SelectionStart = txtKontaktMobil.Text.Length; //Setzt Selection ans Ende des Textes
            }
        }

        public void txtGeburtstag_TextChanged(object sender, EventArgs e)
        {
            if ((txtGeburtstag.Text == ""))
            {

            }
            else if (txtGeburtstag.Text.Length > 15)
            {
                MessageBox.Show("Datum ungenau");
                txtGeburtstag.Text = txtGeburtstag.Text.Remove(txtGeburtstag.Text.Length - 1, 1);
                txtGeburtstag.SelectionStart = txtGeburtstag.Text.Length; //Setzt Selection ans Ende des Textes
            }
            else if (new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "." }.Contains(txtGeburtstag.Text.Substring(txtGeburtstag.Text.Length - 1, 1).ToLower()))
            {

                string Variable = txtKontaktMobil.Text;

            }

            else
            {
                MessageBox.Show("falsches Datum (tt.mm.jjjj) ");
                txtGeburtstag.Text = txtGeburtstag.Text.Remove(txtGeburtstag.Text.Length - 1, 1);
                txtGeburtstag.SelectionStart = txtGeburtstag.Text.Length; //Setzt Selection ans Ende des Textes
            }
        }

        public void txtKontaktAnschrift_TextChanged(object sender, EventArgs e)
        {

        }

        //
        //________________________________________________TeXTBoX_____________________CaR_________________________________________
        //

        public void cboFahrzeugModell_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void txtKennzeichen_TextChanged(object sender, EventArgs e)
        {

        }

        public void txtVonDate_TextChanged(object sender, EventArgs e)
        {

        }

        public void txtBisDate_TextChanged(object sender, EventArgs e)
        {

        }

        public void txtSonstiges_TextChanged(object sender, EventArgs e)
        {

        }

        public void txtPersNr_TextChanged(object sender, EventArgs e)
        {

        }

        //
        //________________________________________________GRiDVieW___________________________________
        //

        public void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
