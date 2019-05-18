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
    public partial class Manager1 : Form
    {
        public Manager1()
        {
            InitializeComponent();
        }

        public Manager Manager { get; set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Manager.Surname;
            textBox2.Text = Manager.Name;
            textBox3.Text = Manager.Patronymic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.Surname = textBox1.Text;
            Manager.Name = textBox2.Text;
            Manager.Patronymic = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manager1_Load(object sender, EventArgs e)
        {

        }
    }
}
