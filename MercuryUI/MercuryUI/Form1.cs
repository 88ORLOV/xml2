using System;
using Mercury;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MercuryUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //private void SaveInformation(object sender, EventArgs e)
        //{
        //    comboBox1.Text = Information.Tariffs;
        //    textBox1.Text = Information.SNP;
        //    dateTimePicker1.Text = Information.Data;
        //    pictureBox1.Image = Information.Photo;
        //}
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (Information.Tariff)
            //{
            //    case Tariff.Light:
            //        comboBox1.Text = "100 мбит/сек.";
            //        break;
            //    case Tariff.Medium:
            //        comboBox1.Text = "250 мбит/сек.";
            //        break;
            //    case Tariff.High:
            //        comboBox1.Text = "500 мбит/сек.";
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Application2 = new Application2() { Customer = new Customer() };
            if (Application2.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(Application2.Customer);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Manager1 = new Manager1() { Manager = new Manager() };
            if (Manager1.ShowDialog(this) == DialogResult.OK)
            {
                listBox2.Items.Add(Manager1.Manager);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is Manager)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button5.Enabled = listBox2.SelectedItem is Manager;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Customer)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = listBox1.SelectedItem is Customer;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Меркурий|*.merc" };

            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(Information));
            var file = File.OpenRead(ofd.FileName);
            var inf = (Information)xs.Deserialize(file);
            file.Close();

            textBox1.Text = inf.Phonenumber;

            var ms = new MemoryStream(inf.Photo);
            pictureBox1.Image = Image.FromStream(ms);

            textBox2.Text = inf.SNP;

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (var customer in inf.Customer)
            {
                listBox1.Items.Add(customer);
            }
            foreach (var manager in inf.Manager)
            {
                listBox2.Items.Add(manager);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Меркурий|*.merc" };

            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;

            var inf = new Information()

            {
                Phonenumber = textBox1.Text,
                SNP = textBox2.Text,
                Customer = listBox1.Items.OfType<Customer>().ToList(),
                Manager = listBox2.Items.OfType<Manager>().ToList()
            };

            var stream = new MemoryStream();
            pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
            inf.Photo = stream.ToArray();
            var xs = new XmlSerializer(typeof(Information));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, inf);
            file.Close();
        }
    }
}
