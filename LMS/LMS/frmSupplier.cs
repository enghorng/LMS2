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
    public partial class frmSupplier : Form
    {
        public static int m;
        public frmSupplier()
        {
            InitializeComponent();
            txtSiD.Text = "S0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDSuppiler")) + 1).ToString("00");
            txtSName.Focus();            
            this.MaximizeBox = false;
            m = 1;
        }

        private void frmSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvSupplier, "SELECT * FROM v_Supplier");
            dgvSupplier.Columns["SupplierID"].Visible = false;
            
            this.MaximizeBox = false;
            dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void clear()
        {
            txtSName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtSiD.Text = "S0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDSuppiler")) + 1).ToString("00");
            txtSName.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtSName.Text == "")
            {
                MessageBox.Show("Enter File Supplier");
                txtSName.Focus();
                return;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter File Address");
                txtAddress.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter File Email");
                txtEmail.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_InsertSupplier";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtSiD.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtSName.Text;  
                SQLDB.DB.cmdSQL.Parameters.Add("@address", SqlDbType.NVarChar).Value = txtAddress.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtPhone.Text;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvSupplier, "SELECT * FROM v_Supplier");
                clear();
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

        private void dgvSupplier_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    
                    txtSiD.Text = dgvSupplier["SupplierID", e.RowIndex].Value.ToString();
                    txtSName.Text = dgvSupplier["Name", e.RowIndex].Value.ToString();
                    txtAddress.Text = dgvSupplier["Address", e.RowIndex].Value.ToString();
                    txtPhone.Text = dgvSupplier["Phone", e.RowIndex].Value.ToString();
                    txtEmail.Text = dgvSupplier["Email", e.RowIndex].Value.ToString();              

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSName.Text == "")
            {
                MessageBox.Show("Enter File Supplier");
                txtSName.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_UpdateSupplier";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtSiD.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtSName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@address", SqlDbType.NVarChar).Value = txtAddress.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtPhone.Text;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvSupplier, "SELECT * FROM v_Supplier");
                clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboSupplier_KeyUp(object sender, KeyEventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvSupplier, "SELECT * FROM f_SearchSupplierName (N'%" + cboSupplier.Text + "%')");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsLogout.Logout();
        }
    }
}
