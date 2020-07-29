using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        controlsEntities db = new controlsEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var f = (from a in db.users
                     where a.email == textBox1.Text && a.passwords == textBox2.Text
                     select a).FirstOrDefault();
            user u = db.users.Find(f.id);
            u.timelogin = DateTime.Now;
            db.Entry(u).State = EntityState.Modified;
            db.SaveChanges();


            if (f != null)
            {
                Form1 fr = new Form1();
                fr.Show();
            }
        }
    }
}
