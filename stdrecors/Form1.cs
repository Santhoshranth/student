using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stdrecors
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        dbaccess db = new dbaccess();
    
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(db.GetConnection());
        }

        

        private void btnparse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();   
            txtfile_path.Text = ofd.FileName;
            BindDAtaCSV(txtfile_path.Text);

        }
        private void BindDAtaCSV(string filepath)
        {
            DataTable dt= new DataTable();
            string[] lines=System.IO.File.ReadAllLines(filepath);
            if(lines.Length > 0)
            {
                string firstline = lines[0];
                string[] headerlabels = firstline.Split(',');
                foreach(string headerword in headerlabels)
                {
                    dt.Columns.Add(new DataColumn(headerword));
                }
                for(int r=1;r<lines.Length;r++)
                {
                    string[] datawords = lines[r].Split(',');
                    DataRow dr=dt.NewRow();
                    int columnIndex = 0;
                    foreach(string headerword in headerlabels)
                    {
                        
                        dr[headerword] = datawords[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if(dt.Rows.Count > 0) 
            {
                dgvstd.DataSource = dt;
            }

        }

        private void submit_click_Click_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dgvstd.Rows.Count - 1; i++)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("Insert into attendance2(externalstudentid,attendancedate,status) values(@externalstudentid,@attendancedate,@status)", conn);
                    cmd.Parameters.AddWithValue("@externalstudentid", dgvstd.Rows[i].Cells[0].Value);

                    cmd.Parameters.AddWithValue("@attendancedate", dgvstd.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@status", dgvstd.Rows[i].Cells[2].Value.ToString());


                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch(Exception ex) 
                {
                    textBox1.Text = "Duplicate Entry";
                }


            }


        }
    }
}

