using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenagerApp
{
    public partial class menagerapp : Form
    {
        List<Person> pracownicy = new List<Person>();
        public menagerapp()
        {
            InitializeComponent();

            UpdateList();
        }

        private void buttonDodajPrac_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            db.DodajPracownika(textBoxNazwisko.Text, textBoxImie.Text);

            textBoxImie.Text = "";
            textBoxNazwisko.Text = "";

            UpdateList();
        }

        private void buttonZ2_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            db.AktPracownika(textBoxZ2SN.Text, textBoxZ2N.Text, textBoxZ2ID.Text);

            textBoxZ2SN.Text = "";
            textBoxZ2N.Text = "";
            textBoxZ2ID.Text = "";

            UpdateList();
        }

        private void buttonZ3_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            db.UsunPracownika(textBoxZ3ID.Text);

            textBoxZ3ID.Text = "";

            UpdateList();
        }

      
        private void UpdateList()
        {
            DataAccess db = new DataAccess();
            pracownicy = db.WysPracownikow();
            listBoxZ4.DataSource = pracownicy;
            listBoxZ4.DisplayMember = "FullInfoPracownika";
        }
    }
}
