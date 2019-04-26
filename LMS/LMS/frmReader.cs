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

namespace LMS
{
    public partial class frmReader : Form
    {
        public static int m;
        public frmReader()
        {
            InitializeComponent();
            txtRID.Text = "B0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDBook")) + 1).ToString("00");
            txtRName.Focus();
            m = 1;
        }

        private void frmReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
        }
        void clear()
        {
            txtAddress.Text = "";
            txtPE.Text = "";
            txtPlace.Text = "";
            txtPosition.Text = "";
            txtRID.Text = "";
            txtRName.Text = "";
            txtRID.Text = "B0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDBook")) + 1).ToString("00");
            txtRName.Focus();
        }
        private void frmReader_Load(object sender, EventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvReader, "SELECT * FROM v_Reader");
            dgvReader.Columns["ReaderID"].Visible = false;
            dgvReader.Columns["Photo"].Visible = false;
            this.MaximizeBox = false;
            dgvReader.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtRName.Text == "")
            {
                MessageBox.Show("Enter File Name");
                txtRName.Focus();
                return;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter File Address");
                txtRName.Focus();
                return;
            }
            if (txtPosition.Text == "")
            {
                MessageBox.Show("Enter File Position");
                txtRName.Focus();
                return;
            }
            if (txtPlace.Text == "")
            {
                MessageBox.Show("Enter File Place");
                txtRName.Focus();
                return;
            }
            if (txtPE.Text == "")
            {
                MessageBox.Show("Enter File Phone Or Email");
                txtRName.Focus();
                return;
            }
            try
            {

                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_InsertReader";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtRID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtRName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@Gender", SqlDbType.Char).Value = cboGender.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@DOB", SqlDbType.Date).Value = dTPDob.Value;
                SQLDB.DB.cmdSQL.Parameters.Add("@positon", SqlDbType.NVarChar).Value = txtPosition.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@place", SqlDbType.NVarChar).Value = txtPlace.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtPE.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@address", SqlDbType.NVarChar).Value = txtAddress.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@Photo", SqlDbType.VarChar).Value = pBReader.ImageLocation;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();              
                SQLDB.DB.SQL_Grid(dgvReader, "SELECT * FROM v_Reader");
                clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pBReader_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image File(*.jpg; *.jpeg; *.png; *.gif; *.bmp)| *.jpg;*.jpeg; *.png; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pBReader.Image = new Bitmap(open.FileName);
                pBReader.ImageLocation = open.FileName;
            }
        }

        private void dgvReader_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvReader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {

                    txtRID.Text = dgvReader["ReaderID", e.RowIndex].Value.ToString();
                    txtRName.Text = dgvReader["Name", e.RowIndex].Value.ToString();
                    txtAddress.Text = dgvReader["Address", e.RowIndex].Value.ToString();
                    cboGender.Text = dgvReader["Gender", e.RowIndex].Value.ToString();
                    txtPosition.Text = dgvReader["Positon", e.RowIndex].Value.ToString();
                    txtPlace.Text = dgvReader["Place", e.RowIndex].Value.ToString();
                    txtPE.Text = dgvReader["Phone/Email", e.RowIndex].Value.ToString();
                    dTPDob.Value = Convert.ToDateTime(dgvReader["DOB", e.RowIndex].Value.ToString());
                    pBReader.ImageLocation = dgvReader["Photo", e.RowIndex].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRName.Text == "")
            {
                MessageBox.Show("Enter File Name");
                txtRName.Focus();
                return;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter File Address");
                txtRName.Focus();
                return;
            }
            if (txtPosition.Text == "")
            {
                MessageBox.Show("Enter File Position");
                txtRName.Focus();
                return;
            }
            if (txtPlace.Text == "")
            {
                MessageBox.Show("Enter File Place");
                txtRName.Focus();
                return;
            }
            if (txtPE.Text == "")
            {
                MessageBox.Show("Enter File Phone Or Email");
                txtRName.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_UpdateReader";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtRID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtRName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@Gender", SqlDbType.Char).Value = cboGender.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@DOB", SqlDbType.Date).Value = dTPDob.Value;
                SQLDB.DB.cmdSQL.Parameters.Add("@positon", SqlDbType.NVarChar).Value = txtPosition.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@place", SqlDbType.NVarChar).Value = txtPlace.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtPE.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@address", SqlDbType.NVarChar).Value = txtAddress.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@Photo", SqlDbType.VarChar).Value = pBReader.ImageLocation;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();                
                SQLDB.DB.SQL_Grid(dgvReader, "SELECT * FROM v_Reader");
                clear();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void cboSearchReader_KeyUp(object sender, KeyEventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvReader, "SELECT * FROM f_SearchReader (N'%" + cboSearchReader.Text + "%')");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsLogout.Logout();
        }
    }
}
