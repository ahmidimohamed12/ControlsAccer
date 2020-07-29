using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        controlsEntities db = new controlsEntities();
        private void Registration_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.users.ToList();
            dataGridView2.DataSource = db.codebars.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user us = new user();
            us.nom = textBox1.Text;
            us.prenom = textBox2.Text;
            us.email = textBox3.Text;
            us.passwords = textBox4.Text;
            db.users.Add(us);
            db.SaveChanges();
            dataGridView1.DataSource = db.users.ToList();
        }
    }
}
