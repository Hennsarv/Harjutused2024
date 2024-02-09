using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAken2
{
    public partial class Form1 : Form
    {
        NWDataContext db = new NWDataContext();

        public Form1()
        {
            InitializeComponent();

            this.comboBox1.DataSource = null; 
            var Maad = 
                db.Customers
                .Select(x => x.Country)
                .Distinct()
                .ToList();
            Maad.Add("All Countries");
            this.comboBox1.DataSource = Maad;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = db.Customers

                //.Where(x => x.Country == this.textBox1.Text)
                .Where(x =>
                x.Country == this.comboBox1.Text
                ||
                this.comboBox1.Text == "All Countries"
                )

                .ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SubmitChanges();
        }
    }
}
