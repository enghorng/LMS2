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
using System.Diagnostics;

namespace LMS
{
    public partial class FrmLibrarian : Form
    {
        public static int m;
        public FrmLibrarian()
        {
            InitializeComponent();
            txtLID.Text = "L0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDLibrarain")) + 1).ToString("00");
            txtLName.Focus();
            m = 1;
        }
        
        private void FrmLibrarian_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
          
           
        }

        private void FrmLibrarian_Load(object sender, EventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvLibrarain, "SELECT * FROM v_Librarian");
            this.MaximizeBox = false;
            dgvLibrarain.Columns["Photo"].Visible = false;
            dgvLibrarain.Columns["Librarian ID"].Visible = false;
            dgvLibrarain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void clear()
        {
            txtLAddress.Text = "";
            txtLID.Text = "";
            txtLPhone.Text = "";
            txtLName.Text = "";
            cboGender.Text ="";
            pBLbrarain.ImageLocation = "";
        }
        void autoID()
        {
            txtLID.Text = "L0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDLibrarain")) + 1).ToString("00");
            txtLName.Focus();
        }
        public static int hide = 0;
        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsLogout.Logout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            autoID();
        }

        private void dgvLibrarain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat()
            {
                //right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtLName.Text == "")
            {
                MessageBox.Show("Enter File Librarian");
                txtLName.Focus();
                return;
                
            }
            if (txtLPhone.Text == "") {
                MessageBox.Show("Enter File Phon/Email");
                txtLPhone.Focus();
                return;
            }
            if(txtLAddress.Text == "")
            {
                MessageBox.Show("Enter File Address");
                txtLAddress.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_InsertLibrarian";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtLID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtLName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@Gender", SqlDbType.Char).Value = cboGender.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@DOB", SqlDbType.Date).Value = dTPLibrarain.Value;
                SQLDB.DB.cmdSQL.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtLPhone.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@address", SqlDbType.NVarChar).Value = txtLAddress.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@Photo", SqlDbType.VarChar).Value = pBLbrarain.ImageLocation;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvLibrarain, "SELECT * FROM v_Librarian");
                clear();
                autoID();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }

        private void pBLbrarain_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image File(*.jpg; *.jpeg; *.png; *.gif; *.bmp)| *.jpg;*.jpeg; *.png; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pBLbrarain.Image = new Bitmap(open.FileName);
                pBLbrarain.ImageLocation = open.FileName;
            }
        }

        private void dgvLibrarain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    txtLID.Text = dgvLibrarain["Librarian ID", e.RowIndex].Value.ToString();
                    txtLName.Text = dgvLibrarain["Librarian Name", e.RowIndex].Value.ToString();
                    cboGender.Text = dgvLibrarain["Gender", e.RowIndex].Value.ToString();
                    dTPLibrarain.Value = Convert.ToDateTime(dgvLibrarain["DOB", e.RowIndex].Value.ToString());
                    txtLPhone.Text = dgvLibrarain["Phone", e.RowIndex].Value.ToString();
                    txtLAddress.Text = dgvLibrarain["Address", e.RowIndex].Value.ToString();
                    pBLbrarain.ImageLocation = dgvLibrarain["Photo", e.RowIndex].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtLName.Text == "") { MessageBox.Show(" Enter File Librarian");  return; }
            try
            {

                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_UpdateLibrarian";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtLID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtLName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@Gender", SqlDbType.Char).Value = cboGender.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@DOB", SqlDbType.Date).Value = dTPLibrarain.Value;
                SQLDB.DB.cmdSQL.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtLPhone.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@address", SqlDbType.NVarChar).Value = txtLAddress.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@Photo", SqlDbType.VarChar).Value = pBLbrarain.ImageLocation;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvLibrarain, "SELECT * FROM v_Librarian");
                clear();
                autoID();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
           // SQLDB.DB.SQL_Grid(dgvLibrarain, "SELECT * FROM P_SearchLibrarianName('%" + txtLName.Text + "%')");
        }

        private void cboSearchN_KeyUp(object sender, KeyEventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvLibrarain, "SELECT * FROM f_SearchLibrarianName (N'%" + cboSearchN.Text + "%')");
            
        }
    }
}
