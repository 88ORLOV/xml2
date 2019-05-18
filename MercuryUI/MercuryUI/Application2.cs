using System;
using Mercury;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercuryUI
{
    public partial class Application2 : Form
    {
        public Application2()
        {
            InitializeComponent();
        }

        public Customer Customer { get; set; }

        private void  Application_Load(object sender, EventArgs e)
        {
            textBox1.Text = Customer.Adress;
            comboBox1.Text = Customer.Tariffs;
            dateTimePicker1.Text = Customer.DateOfApplication.ToLongDateString();
            textBox2.Text = Customer.Cost;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer.Adress = textBox1.Text;
            Customer.Tariffs = comboBox1.Text;
            Customer.DateOfApplication = dateTimePicker1.Value;
            Customer.Cost = textBox2.Text;
        }
    }
}
