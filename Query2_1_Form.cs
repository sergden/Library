using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controller;

namespace WindowsFormsApp1
{
    public partial class Query2_1_Form : Form
    {
        Query2_1 controller;

        public Query2_1_Form()
        {
            InitializeComponent();

            controller = new Query2_1(ConnectionString.Connstr);

            dataGridView1.DataSource = controller.Select_from_table();
        }
    }
}
