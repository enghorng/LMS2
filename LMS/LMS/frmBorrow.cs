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
    public partial class frmBorrow : Form
    {
        public static int m;
        public frmBorrow()
        {
            InitializeComponent();
            txtLName.Text = FormLogin.u;
            m = 1;
        }

        private void frmBorrow_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
        }

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            //  SQLDB.DB.SQL_Grid(dgvBorrow, "SELECT * FROM v_BorrowBook");
            this.MaximizeBox = false;
            dgvBorrow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtBorrowID.Text = "B0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastInvoiceID")) + 1).ToString("00");
            txtRName.Focus();



        }
        void Clear()
        {
            txtBookCode.Text = "";
            txtBorrowID.Text = "B0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastInvoiceID")) + 1).ToString("00");
            txtRName.Focus();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }
        void clearSubmit()
        {

            txtTotalAmount.Text = "";
            txtBookCode.Text = "";
            txtBookCode.Focus();
            txtBorrowID.Text = "B0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastInvoiceID")) + 1).ToString("00");
            txtRName.Focus();
            txtRName.Text = "";
            txtTotalAmount.Text = "";

        }
     

        private void txtBookCode_KeyUp(object sender, KeyEventArgs e)
        {

           
            string BookCode;            
            string BorrowID;
            string BookName;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBookCode.Text.Trim() == "" || txtBookCode.Text.Trim() == null) return;
                BookCode = SQLDB.DB.Get1Record("select BookCode from tblBook where BookCode='" + txtBookCode.Text + "'");
                if (txtBookCode.Text.Trim() == BookCode)
                {
                    BorrowID = txtBorrowID.Text;
                    BookName = SQLDB.DB.Get1Record("select Titel from tblBook where BookCode='" + txtBookCode.Text + "'");
                    BookCode = txtBookCode.Text;
                    dgvBorrow.Rows.Add(BorrowID, BookCode, BookName, 1, 500,1);
                    txtBookCode.Text = null;
                    txtBookCode.Select();
                }               
                //if(txtBookCode.Text.Trim() != BookCode)
                //{
                //    MessageBox.Show("Not Found Book Code!!!");
                //    txtBookCode.Text = "";
                //    txtBookCode.Focus();
                //    return;
                //}
            }
            double total = 0;
            total = 0;
            for (int index = 0; index < dgvBorrow.Rows.Count; index++)
            {
                total += Convert.ToDouble(dgvBorrow.Rows[index].Cells["Price"].Value);
            }
            txtTotalAmount.Text = total.ToString() + "R";

        }
        double NewQty = 0;
        double qty = 0;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtLName.Text == "" || txtRName.Text == "" || dgvBorrow.Rows.Count<0) return;
            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_InsertInvoice";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@BID", SqlDbType.VarChar).Value = txtBorrowID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@LID", SqlDbType.VarChar).Value = SQLDB.DB.Get1Record("select LibrarianID from v_login where UserName=N'" + txtLName.Text + "'");
                SQLDB.DB.cmdSQL.Parameters.Add("@RID", SqlDbType.VarChar).Value = txtRName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@Sdate", SqlDbType.Date).Value = dTPBorrow.Value;
                //SQLDB.DB.cmdSQL.Parameters.Add("@Edate", SqlDbType.Date).Value = 
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                //clearSubmit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (int i = 0; i < dgvBorrow.Rows.Count; i++)
            {
                qty = Double.Parse(SQLDB.DB.Get1Record("select Qty from tblBook where BookCode='" + dgvBorrow.Rows[i].Cells["BCID"].Value + "'"));
                if (qty > 0)
                {
                    NewQty = qty - 1;
                    SQLDB.DB.Get1Record("Update tblBook set  Qty=" + NewQty + " where BookCode='" + dgvBorrow.Rows[i].Cells["BCID"].Value + "'");
                }
                else
                {
                    MessageBox.Show("Out of Stock=" + dgvBorrow.Rows[i].Cells["BT"].Value + "");
                    //txtCode_KeyUp = "";
                }


            }

            try
            {
                for (int i = 0; i < dgvBorrow.Rows.Count; i++)
                {
                    SQLDB.DB.cmdSQL = new SqlCommand();
                    SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                    SQLDB.DB.cmdSQL.CommandText = "SP_InsertBorrow";
                    SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                    SQLDB.DB.cmdSQL.Parameters.Add("@BID", SqlDbType.VarChar).Value = dgvBorrow.Rows[i].Cells["BID"].Value.ToString();
                    SQLDB.DB.cmdSQL.Parameters.Add("@BC", SqlDbType.VarChar).Value = SQLDB.DB.Get1Record("select BookCode from tblBook where Titel=N'" + dgvBorrow.Rows[i].Cells["BT"].Value + "'");
                    SQLDB.DB.cmdSQL.Parameters.Add("@qty", SqlDbType.Int).Value = dgvBorrow.Rows[i].Cells["q"].Value;
                    SQLDB.DB.cmdSQL.Parameters.Add("@deposit", SqlDbType.Real).Value = dgvBorrow.Rows[i].Cells["Price"].Value;
                    SQLDB.DB.cmdSQL.Parameters.Add("@Status", SqlDbType.Int).Value = dgvBorrow.Rows[i].Cells["Status"].Value;
                    SQLDB.DB.cmdSQL.ExecuteNonQuery();
                }
                clearSubmit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvBorrow.Rows.Clear();
            txtTotalAmount.Text = "";
        }

        private void txtRName_KeyUp(object sender, KeyEventArgs e)
        {
           // String ReaderName;
            if (e.KeyCode == Keys.Enter)
            {
                string Status = SQLDB.DB.Get1Record("select Status from v_InvoiceDetail where ReaderID='" + txtRName.Text + "'");
                if (Status == "1")
                {
                    MessageBox.Show("This Reader Code=" + txtRName.Text + "is borrowing books");
                    txtRName.Text = "";
                    return;
                }
            }


        }


        private void dgvBorrow_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {                   
                    txtBookCode.Text = dgvBorrow["BCID", e.RowIndex].Value.ToString();
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsLogout.Logout();
        }
    }
}
