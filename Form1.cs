using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DA;
using BL;

namespace _3layer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ticketDataSet tds = new ticketDataSet();
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ticketDataSet1.ticket' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'ticketDataSet.ticket' table. You can move, or remove it, as needed.

            ticket tc = new ticket();
            ticketBindingSource.DataSource = tc.select();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmAdd fa = new frmAdd();
            fa.txtid.Visible = false;
            fa.ShowDialog();
            Form1_Load(null, null);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {


            string v = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            ticket tc = new ticket();
            tc.id = Int32.Parse(v);
            DataTable dt = tc.selectone();
            frmAdd fa = new frmAdd();
            fa.txtid.Visible = true;
            fa.txtid.Text = dt.Rows[0]["id"].ToString();
            fa.txtname.Text = dt.Rows[0]["name"].ToString();
            fa.txtfamily.Text = dt.Rows[0]["family"].ToString();
            fa.txttel.Text = dt.Rows[0]["tel"].ToString();
            fa.txtborn.Text = dt.Rows[0]["born"].ToString();
            fa.ShowDialog();
            Form1_Load(null, null);

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string v = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            DialogResult dr = MessageBox.Show("آیا مطمئن به حذف هستید؟","هشدار",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                ticket tc = new ticket();
                tc.id = Int32.Parse(v);
                tc.delete();
                Form1_Load(null, null);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            ticketBindingSource.Filter =string.Format("name like '%{0}%', txtsearch.Text");
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
