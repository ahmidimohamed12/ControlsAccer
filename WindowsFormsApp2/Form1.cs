using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Timer t = new Timer();
        controlsEntities db = new controlsEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
                tm();
        }

        public string   getrandom()
        {
            Random r = new Random();
            string gh = r.Next(1, 10000).ToString();


            return gh;
        }


        public void tm()
        {
            var ss = getrandom();
            QRCodeGenerator q = new QRCodeGenerator();
            QRCodeData s = q.CreateQrCode(ss, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(s);
            pictureBox1.Image = code.GetGraphic(5);
            codebar b = new codebar();
            b.code = ss;
            b.timecode = DateTime.Now;
            db.codebars.Add(b);
            db.SaveChanges();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tm();
        }
    }
}
