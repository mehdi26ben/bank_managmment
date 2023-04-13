using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client client = new client();
            client.TopLevel = true;
            client.Show();
        }

        private void operationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operation operation = new operation();
            operation.TopLevel = true;
            operation.Show();
        }

        private void reperotDesTousClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report_all report_all = new report_all();
            report_all.TopLevel = true;
            report_all.Show();
        }

        private void reporotDeChaqueClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crys_report crys_report = new crys_report();
            crys_report.TopLevel = true;
            crys_report.Show();
        }
    }
}
