using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Vous devez remplir tout les champs");
                x = 1;
            }
            if (x==0 && textBox3.Text == "admin" && textBox4.Text == "admin")
            {
                MessageBox.Show("bienvenue");
                var menu = new menu();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            if (x == 0 && textBox3.Text != "admin" || textBox4.Text != "admin")
            {
                MessageBox.Show("infomations incorrect!");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
