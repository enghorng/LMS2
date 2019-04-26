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
    public partial class frmBook : Form
    {
        public static int m;
        public frmBook()
        {
            InitializeComponent();
            txtBookCode.Text = "BC0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastCodeBook")) + 1).ToString("00");
            txtTitle.Focus();
            m = 1;
        }

        private void frmBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
        }

        private void frmBook_Load(object sender, EventArgs e)
        {

            SQLDB.DB.SQL_String_CBO_SQL(cboCatagoryID, "select CategoryID,CategoryType from tblCategory", "CategoryID", "CategoryType");
            SQLDB.DB.SQL_String_CBO_SQL(cboSupplierID, "select SupplierID,Name from tblSupplier", "SupplierID", "Name");
            SQLDB.DB.SQL_Grid(dgvBook, "Select * from v_Book");
            dgvBook.Columns["CategoryID"].Visible = false;
            dgvBook.Columns["SupplierID"].Visible = false;
            this.MaximizeBox = false;
            dgvBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }
        void clear()
        {
            txtBookCode.Text = "";
            txtAuthor.Text = "";
            txtQty.Text = "";
            txtTitle.Text = "";
            txtYOP.Text = "";
            txtBookCode.Text = "BC0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastCodeBook")) + 1).ToString("00");
            txtTitle.Focus();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Enter File Title");
                txtTitle.Focus();
                return;
            }
            if (txtAuthor.Text == "")
            {
                MessageBox.Show("Enter File Author");
                txtAuthor.Focus();
                return;
            }
            if (txtQty.Text == "")
            {
                MessageBox.Show("Enter File QTY");
                txtQty.Focus();
                return;
            }
            if (txtYOP.Text == "")
            {
                MessageBox.Show("Enter File Year Of Printing");
                txtYOP.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_InsertBook";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@CID", SqlDbType.VarChar).Value = cboCatagoryID.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@SID", SqlDbType.VarChar).Value = cboSupplierID.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtBookCode.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@title", SqlDbType.NVarChar).Value = txtTitle.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@qty", SqlDbType.Int).Value = txtQty.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@author", SqlDbType.NVarChar).Value = txtAuthor.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@YOP", SqlDbType.Int).Value = txtYOP.Text;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvBook, "Select * from v_Book");
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

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    cboCatagoryID.SelectedValue = dgvBook["CategoryID", e.RowIndex].Value.ToString();
                    cboSupplierID.SelectedValue = dgvBook["SupplierID", e.RowIndex].Value.ToString();
                    txtBookCode.Text = dgvBook["Code", e.RowIndex].Value.ToString();
                    txtTitle.Text = dgvBook["Title", e.RowIndex].Value.ToString();
                    txtAuthor.Text = dgvBook["Author", e.RowIndex].Value.ToString();
                    txtQty.Text = dgvBook["QTY", e.RowIndex].Value.ToString();
                    txtYOP.Text = dgvBook["Year Of Printing", e.RowIndex].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Enter File Titel");
                txtTitle.Focus();
                return;
            }
            if (txtAuthor.Text == "")
            {
                MessageBox.Show("Enter File Author");
                txtAuthor.Focus();
                return;
            }
            if (txtQty.Text == "")
            {
                MessageBox.Show("Enter File QTY");
                txtQty.Focus();
                return;
            }
            if (txtYOP.Text == "")
            {
                MessageBox.Show("Enter File Year Of Printing");
                txtYOP.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_UpdateBook";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@CID", SqlDbType.VarChar).Value = cboCatagoryID.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@SID", SqlDbType.VarChar).Value = cboSupplierID.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtBookCode.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@title", SqlDbType.NVarChar).Value = txtTitle.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@qty", SqlDbType.Int).Value = txtQty.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@author", SqlDbType.NVarChar).Value = txtAuthor.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@YOP", SqlDbType.Int).Value = txtYOP.Text;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvBook, "Select * from v_Book");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboSearchBook_KeyUp(object sender, KeyEventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvBook, "SELECT * FROM f_SearchBookTitle (N'%" + cboSearchBook.Text + "%')");
        }

        private void dgvBook_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
