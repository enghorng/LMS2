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
    public partial class frmReturn : Form
    {
        public static int m;
        public frmReturn()
        {
            InitializeComponent();
            txtLName.Text = FormLogin.u;
            m = 1;
        }

        private void frmReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
        }

        private void txtRID_KeyUp(object sender, KeyEventArgs e)
        { 
            string Status;
            string ReaderID;
            string BorrowID;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBID.Text.Trim() == "" || txtRID.Text.Trim() == null) return;
                ReaderID = SQLDB.DB.Get1Record("select [ReaderID] from v_BorrowDetail where  ReaderID='" + txtRID.Text + "'");
                BorrowID = SQLDB.DB.Get1Record("select [BorrowID] from v_BorrowDetail where  BorrowID='" + txtBID.Text + "'");
                if (ReaderID != txtRID.Text || BorrowID != txtBID.Text) { txtBID.Text = ""; txtRID.Text = "";return; }
                Status = SQLDB.DB.Get1Record("select Status from v_BorrowDetail where  ReaderID='" + txtRID.Text+"'  and BorrowID='"+txtBID.Text+"'");
                if (Status=="1")                   
                {
                        SQLDB.DB.SQL_Grid(dgvReturn, "select BorrowID,ReaderID,BookCode,Titel,Qty,Status,Deposit,ReturnDate,AmountExpried from v_BorrowDetail where BorrowID='" + txtBID.Text+"' and ReaderID='"+txtRID.Text+"'");
                        dgvReturn.Columns["Status"].Visible = false;
                        dgvReturn.Columns["BookCode"].Visible = false;
                    dgvReturn.Columns["BorrowID"].Visible = false;
                    dgvReturn.Columns["ReaderID"].Visible = false;
                    this.MaximizeBox = false;
                        dgvReturn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
               }
            }
        }

        private void txtRID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {

                    txtAE.Text = dgvReturn["AmountExpried", e.RowIndex].Value.ToString();                 

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void frmReturn_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            dgvReturn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtReturnID.Text = "RT0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastInvoiceReturnID")) + 1).ToString("00");
            txtBID.Focus();
        }

        private void dgvReturn_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        void Clear()
        {
            txtBID.Text = "";
            txtReturnID.Text = "";
            txtTotalAmount.Text = "";
            txtAmount.Text = "";
            txtReturnID.Text = "RT0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastInvoiceReturnID")) + 1).ToString("00");
            txtBID.Focus();
            txtRID.Text = "";
          
        }
        double NewQty = 0;
        double qty = 0;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_InsertInvoiceReturn";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@RTID", SqlDbType.VarChar).Value = txtReturnID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@LID", SqlDbType.VarChar).Value = SQLDB.DB.Get1Record("select [LibrarianID] from tblUser where [UserName]='" + txtLName.Text + "'");
                SQLDB.DB.cmdSQL.Parameters.Add("@RID", SqlDbType.VarChar).Value = txtRID.Text;              
                SQLDB.DB.cmdSQL.Parameters.Add("@Rdate", SqlDbType.Date).Value = dTPReturn.Value;              
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          /////////////////////////////
            for (int i = 0; i < dgvReturn.Rows.Count; i++)
            {
                //string BookCode = SQLDB.DB.Get1Record("select BookCode from tblBook where Title='" + dgvReturn.Rows[i].Cells["Titel"].Value.ToString() + "'");
                string BookCode = dgvReturn.Rows[i].Cells["BookCode"].Value.ToString();
                qty = Double.Parse(SQLDB.DB.Get1Record("select Qty from tblBook where BookCode='" +BookCode+ "'"));
                NewQty = qty + 1;
                SQLDB.DB.Get1Record("Update tblBook set  Qty=" + NewQty + " where BookCode='" + BookCode + "'");

            }
            //////////
            try
            {
                for (int i = 0; i < dgvReturn.Rows.Count; i++)
                {
                    SQLDB.DB.cmdSQL = new SqlCommand();
                    SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                    SQLDB.DB.cmdSQL.CommandText = "SP_InsertReturn";
                    SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                    SQLDB.DB.cmdSQL.Parameters.Add("@RTID", SqlDbType.VarChar).Value = txtReturnID.Text;
                    // string Title = SQLDB.DB.Get1Record("select BookCode from tblBook where Title='" + dgvReturn.Rows[i].Cells["Title"].Value + "'");
                    string BookCode = dgvReturn.Rows[i].Cells["BookCode"].Value.ToString();
                    SQLDB.DB.cmdSQL.Parameters.Add("@BC", SqlDbType.VarChar).Value = BookCode;
                    SQLDB.DB.cmdSQL.Parameters.Add("@qty", SqlDbType.Int).Value = "1";
                    SQLDB.DB.cmdSQL.Parameters.Add("@Status", SqlDbType.Int).Value = "0";
                    SQLDB.DB.cmdSQL.Parameters.Add("@ExpriedDate", SqlDbType.Date).Value = dgvReturn.Rows[i].Cells["ReturnDate"].Value.ToString();
                    SQLDB.DB.cmdSQL.Parameters.Add("@AmountExpried", SqlDbType.Int).Value = txtAE.Text;
                    SQLDB.DB.cmdSQL.Parameters.Add("@Amount", SqlDbType.Real).Value = txtAmount.Text;
                    SQLDB.DB.cmdSQL.Parameters.Add("@TotalAmount", SqlDbType.Real).Value = txtTotalAmount.Text;
                    SQLDB.DB.cmdSQL.ExecuteNonQuery();
                    Clear();
                    dgvReturn.Rows.Clear();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text == "" || txtAmount.Text == null) { txtTotalAmount.Text = ""; return; }
            
            double a = 0;
            double amount = Convert.ToDouble(txtAmount.Text.Trim().ToString());
            double AE = Convert.ToDouble(txtAE.Text.Trim().ToString());
            a = amount * (-AE);
            txtTotalAmount.Text = a.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clsLogout.Logout();
        }
    }
}
