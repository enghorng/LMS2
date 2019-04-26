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
    public partial class FrmImport : Form
    {
        public static int m;
        public FrmImport()
        {
            InitializeComponent();
            txtLName.Text = FormLogin.u;
            m = 1;
        }

        private void FrmImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
        }

      

        private void FrmImport_Load(object sender, EventArgs e)
        {
            //SQLDB.DB.SQL_String_CBO_SQL(cboLName, "select LibrarianID,LibrarianName from tblLibrarian", "LibrarianID", "LibrarianName");
            SQLDB.DB.SQL_String_CBO_SQL(cboSName, "select SupplierID,Name from tblSupplier", "SupplierID", "Name");
            SQLDB.DB.SQL_String_CBO_SQL(cboCName, "select CategoryID,CategoryType from tblCategory", "CategoryID", "CategoryType");
            txtImportID.Text = "I0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastCodeImport")) + 1).ToString("00");
            txtQty.Focus();
            SQLDB.DB.SQL_Grid(dgvImport, "Select * from v_Import");
            dgvImport.Columns["CategoryID"].Visible = false;
            dgvImport.Columns["SupplierID"].Visible = false;
            dgvImport.Columns["LibrarianID"].Visible = false;
            this.MaximizeBox = false;
            dgvImport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void clear()
        {
            txtAmount.Text = "";
            txtQty.Text = "";
            txtImportID.Text = "I0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastCodeImport")) + 1).ToString("00");
            txtQty.Focus();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtLName.Text = FormLogin.u;
            clear();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
            {
                MessageBox.Show("Enter File Qty");
                txtQty.Focus();
                return;
            }
            if (txtAmount.Text == "")
            {
                MessageBox.Show("Enter File Amount");
                txtAmount.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_InsertImport";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@IMID", SqlDbType.VarChar).Value = txtImportID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@LID", SqlDbType.VarChar).Value = txtLName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@SID", SqlDbType.VarChar).Value = cboSName.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@CID", SqlDbType.VarChar).Value = cboCName.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@qty", SqlDbType.Int).Value = txtQty.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@date", SqlDbType.Date).Value = dtpImport.Value;
                SQLDB.DB.cmdSQL.Parameters.Add("@amount", SqlDbType.Real).Value = txtAmount.Text;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvImport, "Select * from v_Import");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
            {
                MessageBox.Show("Enter File Qty");
                txtQty.Focus();
                return;
            }
            if (txtAmount.Text == "")
            {
                MessageBox.Show("Enter File Amount");
                txtAmount.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_UpdateImport";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@IMID", SqlDbType.VarChar).Value = txtImportID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@LID", SqlDbType.VarChar).Value = txtLName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@SID", SqlDbType.VarChar).Value = cboSName.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@CID", SqlDbType.VarChar).Value = cboCName.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@qty", SqlDbType.Int).Value = txtQty.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@date", SqlDbType.Date).Value = dtpImport.Value;
                SQLDB.DB.cmdSQL.Parameters.Add("@amount", SqlDbType.Real).Value = txtAmount.Text;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvImport, "Select * from v_Import");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    cboCName.SelectedValue = dgvImport["CategoryID", e.RowIndex].Value.ToString();
                    cboSName.SelectedValue = dgvImport["SupplierID", e.RowIndex].Value.ToString();
                    txtLName.Text = dgvImport["LibrarianID", e.RowIndex].Value.ToString();
                    txtImportID.Text= dgvImport["Import ID", e.RowIndex].Value.ToString();
                    txtQty.Text = dgvImport["Qty", e.RowIndex].Value.ToString();
                    dtpImport.Value = Convert.ToDateTime(dgvImport["Import Date", e.RowIndex].Value.ToString());
                    txtAmount.Text = dgvImport["Amount", e.RowIndex].Value.ToString();
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvImport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsLogout.Logout();
        }
    }
}
