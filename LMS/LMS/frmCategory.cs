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
    public partial class frmCategory : Form
    {
        public static int m;
        public frmCategory()
        {
            InitializeComponent();
            txtCID.Text = "C0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDCategory")) + 1).ToString("00");
            txtCName.Focus();
            m = 1;
        }

        private void frmCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
        }
        void clear()
        {
            txtCID.Text = "";
            txtCName.Text = "";
            cboSearchCategoryType.SelectedIndex = -1;

            txtCID.Text = "C0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDCategory")) + 1).ToString("00");
            txtCName.Focus();
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvCategory, "SELECT * FROM v_Category");
            this.MaximizeBox = false;
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtCName.Text == "")
            {
                MessageBox.Show("Enter File Category Type");
                txtCName.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_InsertCategory";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtCID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtCName.Text;                
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvCategory, "SELECT * FROM v_Category");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    txtCID.Text = dgvCategory["Category ID", e.RowIndex].Value.ToString();
                    txtCName.Text = dgvCategory["Category Type", e.RowIndex].Value.ToString();
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

        private void dgvCategory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCName.Text == "")
            {
                MessageBox.Show("Enter File Category Type");
                txtCName.Focus();
                return;
            }
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_UpdateCategory";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtCID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtCName.Text;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                SQLDB.DB.SQL_Grid(dgvCategory, "SELECT * FROM v_Category");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboSearchCategoryType_KeyUp(object sender, KeyEventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvCategory, "SELECT * FROM f_SearchCategoryType (N'%" + cboSearchCategoryType.Text + "%')");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsLogout.Logout();
        }
    }
}
