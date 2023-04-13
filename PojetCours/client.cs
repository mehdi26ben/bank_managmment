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
    public partial class client : Form
    {
        private SqlConnection con = new SqlConnection();
        private SqlDataAdapter da = new SqlDataAdapter();
        private SqlDataAdapter dasolde = new SqlDataAdapter();
        private SqlDataAdapter daoper = new SqlDataAdapter();
        private SqlCommandBuilder cmb = new SqlCommandBuilder();
        private DataSet ds = new DataSet();
        public client()
        {
            InitializeComponent();
        }

        private void combo() {
            for (int i = 0; i < ds.Tables["Client"].Rows.Count; i++) {
                comboBox1.Items.Add(ds.Tables["Client"].Rows[i][0]);
            }
        }
        private void client_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=DESKTOP-P6NTU2V;Initial Catalog=projetcours1;Integrated Security=True";
            con.Open();
            da = new SqlDataAdapter("select * from Client", con);
            da.Fill(ds,"Client");
            dasolde =new  SqlDataAdapter("select * from Solde", con);
            dasolde.Fill(ds, "Solde");
            dataGridView1.DataSource = ds.Tables["Client"];
            con.Close();
            combo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0, exist = 0, i;
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(dateTimePicker1.Text) || String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("vous devez remplir tous les champs");
                x = 1;
            }
            if (x == 0) {
                for (i = 0; i < ds.Tables["Client"].Rows.Count; i++) {
                    if (textBox1.Text == ds.Tables["Client"].Rows[i][0].ToString())
                    {
                        MessageBox.Show("ce client deja exist");
                        exist = 1;
                    }
                }
                if (x==0 && exist == 0) { 
                    DataRow l= ds.Tables["Client"].NewRow();
                    l[0] = int.Parse(textBox1.Text);
                    l[1] = textBox2.Text;
                    l[2] = textBox3.Text;
                    l[3] = textBox4.Text;
                    l[4] = dateTimePicker1.Text;
                    l[5] = Double.Parse(textBox5.Text);
                    ds.Tables["Client"].Rows.Add(l);
                    cmb = new SqlCommandBuilder(da);
                    da.Update(ds,"Client");
                    DataRow sl = ds.Tables["Solde"].NewRow();
                    sl[1] = int.Parse(textBox1.Text);
                    sl[2] = Double.Parse(textBox5.Text);
                    ds.Tables["Solde"].Rows.Add(sl); 
                    cmb = new SqlCommandBuilder(dasolde);
                    dasolde.Update(ds, "Solde");
                    comboBox1.Items.Add(textBox1.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0, exist = 0, i;

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("vous devez choisir un numéro de compte");
                x = 1;
            }
            if (x == 0)
            {
                for (i = 0; i < ds.Tables["Client"].Rows.Count; i++)
                {
                    if (textBox1.Text == ds.Tables["Client"].Rows[i][0].ToString())
                    {
                        ds.Tables["Client"].Rows[i][1] = textBox2.Text;
                        ds.Tables["Client"].Rows[i][2] = textBox3.Text;
                        ds.Tables["Client"].Rows[i][3] = textBox4.Text;
                        ds.Tables["Client"].Rows[i][4] = dateTimePicker1.Text;
                        ds.Tables["Client"].Rows[i][5] = textBox5.Text;
                        cmb = new SqlCommandBuilder(da);
                        da.Update(ds, "Client");
                        MessageBox.Show("Modification effectuer");
                        exist = 1;
                    }
                }
                if (x == 0 && exist == 0)
                {
                    MessageBox.Show("ce client n'exist pas!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = 0, exist = 0, i;

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("vous devez choisir un numéro de compte");
                x = 1;
            }
            if (x == 0)
            {
                for (i = 0; i < ds.Tables["Client"].Rows.Count; i++)
                {
                    if (textBox1.Text == ds.Tables["Client"].Rows[i][0].ToString())
                    {
                        ds.Tables["Client"].Rows[i].Delete();
                        cmb = new SqlCommandBuilder(da);
                        da.Update(ds, "Client");
                        MessageBox.Show("Enregistrement Supprimer avec success");
                        exist = 1;
                    }
                }
                if (x == 0 && exist == 0)
                {
                    MessageBox.Show("ce client n'exist pas!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ds.Tables["Client"].Rows.Count; i++)
            {
                if (comboBox1.Text == ds.Tables["Client"].Rows[i][0].ToString()){
                    textBox1.Text = ds.Tables["Client"].Rows[i][0].ToString();
                    textBox2.Text = ds.Tables["Client"].Rows[i][1].ToString();
                    textBox3.Text = ds.Tables["Client"].Rows[i][2].ToString();
                    textBox4.Text = ds.Tables["Client"].Rows[i][3].ToString();
                    dateTimePicker1.Text = ds.Tables["Client"].Rows[i][4].ToString();
                    textBox5.Text = ds.Tables["Client"].Rows[i][5].ToString();
                 }
                //if (comboBox1.Text == ds.Tables["Solde"].Rows[i][1].ToString())
                //{
                //    textBox6.Text = ds.Tables["Solde"].Rows[i][2].ToString();
                //}
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var operation = new operation();
            this.Hide();
            operation.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow ligne = dataGridView1.Rows[index];
            textBox1.Text = ligne.Cells[0].Value.ToString();
            textBox2.Text = ligne.Cells[1].Value.ToString();
            textBox3.Text = ligne.Cells[2].Value.ToString();
            textBox4.Text = ligne.Cells[3].Value.ToString();
            dateTimePicker1.Text = ligne.Cells[4].Value.ToString();
            textBox5.Text = ligne.Cells[5].Value.ToString();
            dasolde.Fill(ds, "Solde");
            for (int i = 0; i < ds.Tables["Solde"].Rows.Count; i++) {
                if (textBox1.Text == ds.Tables["Solde"].Rows[i][1].ToString())
                {
                    textBox6.Text = ds.Tables["Solde"].Rows[i][2].ToString();
                }
            }          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ds.Tables["Client"].Rows.Count; i++) {
                if (comboBox1.Text == ds.Tables["Client"].Rows[i][0].ToString()) {
                    textBox1.Text = ds.Tables["Client"].Rows[i][0].ToString();
                    textBox2.Text = ds.Tables["Client"].Rows[i][1].ToString();
                    textBox3.Text = ds.Tables["Client"].Rows[i][2].ToString();
                    textBox4.Text = ds.Tables["Client"].Rows[i][3].ToString();
                    dateTimePicker1.Text = ds.Tables["Client"].Rows[i][4].ToString();
                    textBox5.Text = ds.Tables["Client"].Rows[i][5].ToString();
                   }
                if (comboBox1.Text == ds.Tables["Solde"].Rows[i][1].ToString()) {
                    textBox6.Text = ds.Tables["Solde"].Rows[i][2].ToString() + " DH";
                }
             }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var menu = new menu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }
    }
}