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

namespace StudentAttendance
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        Connectiondb db = new Connectiondb();
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(db.GetConnection());
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                int ImportedRecord = 0, inValidItem = 0;
                string SourceURl = "";
                if (dialog.FileName != "")
                {
                    if (dialog.FileName.EndsWith(".csv"))
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = GetDataTabletFromCSVFile(dialog.FileName);
                        if (Convert.ToString(dtNew.Columns[0]).ToLower() != "internalstudentid")
                        {
                            MessageBox.Show("Invalid Items File");
                            Save.Enabled = false;
                            return;
                        }
                        txtFile.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            dgItems.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dgItems.Rows)
                        {
                            if (Convert.ToString(row.Cells["internalstudentid"].Value) == "" || row.Cells["internalstudentid"].Value == null 
                                || Convert.ToString(row.Cells["FirstName"].Value) == "" || row.Cells["FirstName"].Value == null
                                || Convert.ToString(row.Cells["LastName"].Value) == "" || row.Cells["LastName"].Value == null
                                || Convert.ToString(row.Cells["DOB"].Value) == "" || row.Cells["DOB"].Value == null
                                || Convert.ToString(row.Cells["SSN"].Value) == "" || row.Cells["SSN"].Value == null
                                || Convert.ToString(row.Cells["Adddress"].Value) == "" || row.Cells["Adddress"].Value == null
                                || Convert.ToString(row.Cells["City"].Value) == "" || row.Cells["City"].Value == null
                                || Convert.ToString(row.Cells["State"].Value) == "" || row.Cells["State"].Value == null
                                || Convert.ToString(row.Cells["Email"].Value) == "" || row.Cells["Email"].Value == null
                                || Convert.ToString(row.Cells["MaritalStatus"].Value) == "" || row.Cells["MaritalStatus"].Value == null)

                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                        if (dgItems.Rows.Count == 0)
                        {
                            Save.Enabled = false;
                          // MessageBox.Show("There is no data in this file", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected File is Invalid, Please Select valid csv file.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }
        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                if (csv_file_path.EndsWith(".csv"))
                {
                    using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column  
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exce " + ex);
            }
            return csvData;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            
            
                for (int i = 0; i < dgItems.Rows.Count - 1; i++)
                {
                    conn.Open();
                    cmd = new SqlCommand("Insert into student11(internalstudentid,FirstName,LastName,DOB,SSN,Adddress,City,State,Email,MaritalStatus) values(@internalstudentid,@FirstName,@LastName,@DOB,@SSN,@Adddress,@City,@State,@Email,@MaritalStatus)", conn);
                    cmd.Parameters.AddWithValue("@internalstudentid", dgItems.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@FirstName", dgItems.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@LastName", dgItems.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@DOB", dgItems.Rows[i].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@SSN", dgItems.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@Adddress", dgItems.Rows[i].Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("@City", dgItems.Rows[i].Cells[6].Value.ToString());
                    cmd.Parameters.AddWithValue("@State", dgItems.Rows[i].Cells[7].Value.ToString());
                    cmd.Parameters.AddWithValue("@Email", dgItems.Rows[i].Cells[8].Value.ToString());
                    cmd.Parameters.AddWithValue("@MaritalStatus", dgItems.Rows[i].Cells[9].Value.ToString());
                    cmd.ExecuteNonQuery();
                      conn.Close();

                
            }
            

           this.Close();

            
        }



        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
