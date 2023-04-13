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
    public partial class operation : Form
    {
        private SqlConnection con = new SqlConnection();
        private SqlDataAdapter da = new SqlDataAdapter();
        private SqlDataAdapter dasolde = new SqlDataAdapter();
        private SqlDataAdapter daoper = new SqlDataAdapter();
        private SqlCommandBuilder cmb = new SqlCommandBuilder();
        private DataSet ds = new DataSet();
        public operation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new client();
            this.Hide();
            client.ShowDialog();
            this.Close();
        }

        private void operation_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=DESKTOP-P6NTU2V;Initial Catalog=projetcours1;Integrated Security=True";
            con.Open();
            da = new SqlDataAdapter("select * from Client", con);
            da.Fill(ds, "Client");
            dasolde = new SqlDataAdapter("select * from Solde", con);
            dasolde.Fill(ds, "Solde");
            daoper = new SqlDataAdapter("select * from Operation", con);
            daoper.Fill(ds, "Operation");
            DataGridView1.DataSource = ds.Tables["Operation"];
            con.Close();
            combo();
            ComboBox2.Items.Add("Depot");
            ComboBox2.Items.Add("Retrait");
            label8.Visible = false;
            textBox5.Visible = false;
        }

        public int chercher(int ncompte) {
            int pos=-1,i;
            for (i = 0; i < ds.Tables["Solde"].Rows.Count; i++) {
                if (ncompte.ToString() == ds.Tables["Solde"].Rows[i][1].ToString())
                {
                    pos = i;
                }
            }
                return pos;
        }

        private void combo(){
            for(int i=0;i<ds.Tables["Client"].Rows.Count;i++){
                ComboBox1.Items.Add(ds.Tables["Client"].Rows[i][0].ToString());
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0;
            for (int i = 0; i < ds.Tables["Client"].Rows.Count; i++)
            {
                int p = i;
                if(ComboBox1.Text==ds.Tables["Client"].Rows[i][0].ToString()){
                    textBox2.Text = ds.Tables["Client"].Rows[i][1].ToString();
                    textBox3.Text = ds.Tables["Client"].Rows[i][2].ToString();
                    for (i = 0; i < ds.Tables["Operation"].Rows.Count; i++)
                    {
                        if (ComboBox1.Text == ds.Tables["operation"].Rows[i][0].ToString()) {
                            daoper.Fill(ds, "gridoperation");
                            ds.Tables["gridoperation"].Clear(); //supprimer le contenue du dataset car le centenue precedent s'ajoute au nouvau
                            SqlDataAdapter dagrid2 = new SqlDataAdapter(String.Concat("select * from operation where Ncompte =", ComboBox1.Text), con); //selection tout les operation du nCompte (combo1)
                            dagrid2.Fill(ds, "gridoperation");
                            DataGridView1.DataSource = ds.Tables["gridoperation"];
                            x++;
                        }
                    }
                }
                if(ComboBox1.Text==ds.Tables["Solde"].Rows[p][1].ToString()){
                    textBox4.Text = ds.Tables["Solde"].Rows[p][2].ToString();
                }
            }
            textBox5.Text = x.ToString();
            label8.Visible =true;
            textBox5.Visible =true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (ComboBox1.Text == "" && ComboBox2.Text == "" && DateTimePicker1.Text == "" && textBox1.Text == "")
            {
                MessageBox.Show("Vous devez remplir tout les champs");
                x = 1;
            }
            if (x==0 &&  ComboBox2.Text == "Depot")
            {
                DataRow l = ds.Tables["Operation"].NewRow();
                l[0] = int.Parse(ComboBox1.Text);
                l[1] = ComboBox2.Text;
                l[2] = DateTimePicker1.Text;
                l[3] = textBox1.Text;
                ds.Tables["Operation"].Rows.Add(l);
                cmb = new SqlCommandBuilder(daoper);
                daoper.Update(ds, "Operation");
                int pos=chercher(int.Parse(ComboBox1.Text));
                ds.Tables["Solde"].Rows[pos][2] = Convert.ToInt32(ds.Tables["Solde"].Rows[pos][2]) + Convert.ToInt32(textBox1.Text);
                textBox4.Text = (double.Parse(textBox4.Text) + Convert.ToInt32(textBox1.Text)).ToString();
                cmb = new SqlCommandBuilder(dasolde);
                dasolde.Update(ds, "Solde");
                textBox5.Text=Convert.ToString(int.Parse(textBox5.Text)+1);
            }
            if (x == 0 && ComboBox2.Text == "Retrait")
            {
                int pos1 = chercher(int.Parse(ComboBox1.Text));
                if (Convert.ToInt32(ds.Tables["Solde"].Rows[pos1][2]) < double.Parse(textBox1.Text))
                {
                    MessageBox.Show("montant insiffusant");
                }
                else { 
                     DataRow l = ds.Tables["Operation"].NewRow();
                    l[0] = int.Parse(ComboBox1.Text);
                    l[1] = ComboBox2.Text;
                    l[2] = DateTimePicker1.Text;
                    l[3] = textBox1.Text;
                    ds.Tables["Operation"].Rows.Add(l);
                    cmb = new SqlCommandBuilder(daoper);
                    daoper.Update(ds, "Operation");
                    //int pos1 = chercher(int.Parse(ComboBox1.Text));
                    ds.Tables["Solde"].Rows[pos1][2] = Convert.ToInt32(ds.Tables["Solde"].Rows[pos1][2]) - Convert.ToInt32(textBox1.Text);
                    textBox4.Text = (double.Parse(textBox4.Text) - Convert.ToInt32(textBox1.Text)).ToString();
                    cmb = new SqlCommandBuilder(dasolde);
                    dasolde.Update(ds, "Solde");
                    textBox5.Text = Convert.ToString(int.Parse(textBox5.Text) + 1);
                }
            }
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            ComboBox1.Text = ""; ComboBox2.Text = ""; DateTimePicker1.Text = ""; textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";
             textBox5.Visible=false;
             label8.Visible=false;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var menu = new menu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }
    }
}
