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

namespace LMS
{
    public partial class frmUser : Form
    {
        public static int m;
        //int count;
        public frmUser()
        {
            InitializeComponent();
            
            SQLDB.DB.SQL_String_CBO_SQL(cboLbrarianID, "select LibrarianID,LibrarianName from tblLibrarian", "LibrarianID", "LibrarianName");
           
            txtUserID.Text = "U0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDUser")) + 1).ToString("00");
            txtUserName.Focus();
            m = 1;
            
            
        }

        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
        }
        void ShowUserName()
        {
            SQLDB.DB.SQL_Grid(dgvUser, "SELECT * FROM v_User");
           
            dgvUser.Columns["LibrarianID"].Visible = false;
            dgvUser.Columns["UserID"].Visible = false;
            dgvUser.Columns["Password"].Visible = false;
            dgvUser.Columns["UserType"].Visible = false;
            dgvUser.Columns["DateStart"].Visible = false;
            // dgvUser.Columns["ExprieDate"].Visible = false;
            //dgvUser.Columns["Photo"].Visible = false;
            this.MaximizeBox = false;
            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            SQLDB.DB.SQL_String_CBO_SQL(cboLbrarianID, "select LibrarianID,LibrarianName from tblLibrarian", "LibrarianID", "LibrarianName");
            ShowUserName();          
           
            txtUserName.Focus();
            



        }
        void clear()
        {
            checkBoxMain.Checked = false;
            checkBoxSecurity.Checked = false;
            checkBoxInformation.Checked = false;
            checkBoxAction.Checked = false;
            checkBoxReport.Checked = false;
        }
       
        void Cleartext()
        {
            
            txtUserName.Text = "";
            txtPass.Text = "";
            txtCompass.Text = "";
            checkBoxInformation.Checked = false;
            checkBoxMain.Checked = false;
            checkBoxReport.Checked = false;
            checkBoxAction.Checked = false;
            checkBoxSecurity.Checked = false;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "U0" + (Convert.ToInt32(SQLDB.DB.Get1Record("SELECT *FROM v_LastIDUser")) + 1).ToString("00");
            Cleartext();
            txtUserName.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "") { MessageBox.Show("Enter UserName!"); txtUserName.Focus();return; }
            if (txtPass.Text == "") { MessageBox.Show("Enter Password!"); txtPass.Focus(); return; }
            if (txtCompass.Text == "") { MessageBox.Show("Enter ComfromPassword"); txtCompass.Focus(); return; }

            string chackBox = "";

            if (checkBoxMain.Checked == true)
            {
                chackBox = "MA";
            }
            if (checkBoxSecurity.Checked == true)
            {
                chackBox = chackBox + "ST";
            }
            if (checkBoxInformation.Checked == true)
            {
                chackBox = chackBox + "IN";
            }
            if (checkBoxAction.Checked == true)
            {
                chackBox = chackBox + "AC";
            }
            if (checkBoxReport.Checked == true)
            {
                chackBox = chackBox + "RP";
            }
            if (chackBox == "") { MessageBox.Show("Enter UserType!");return; }

            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_InsertUser";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@LID", SqlDbType.VarChar).Value = cboLbrarianID.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@UID", SqlDbType.VarChar).Value = txtUserID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtUserName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@pass", SqlDbType.Char).Value = txtPass.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@UType", SqlDbType.VarChar).Value = chackBox;
                SQLDB.DB.cmdSQL.Parameters.Add("@DS", SqlDbType.Date).Value = dTPDateStart.Value;
               
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                ShowUserName();
                Cleartext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
          
        }

        private void dgvUser_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        
        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    cboLbrarianID.SelectedValue = dgvUser["LibrarianID", e.RowIndex].Value.ToString();
                    txtUserID.Text = dgvUser["UserID", e.RowIndex].Value.ToString();
                    txtUserName.Text = dgvUser["UserName", e.RowIndex].Value.ToString();
                    txtPass.Text = dgvUser["Password", e.RowIndex].Value.ToString();
                    dTPDateStart.Value = Convert.ToDateTime(dgvUser["DateStart", e.RowIndex].Value.ToString());

                    string ur = dgvUser["UserType", e.RowIndex].Value.ToString();

                    for (int i = 0; i < ur.Length; i++)
                    {
                        SQLDB.DB.Role = (ur.Substring(i, 2));
                        i++;
                        if (SQLDB.DB.Role == "MA")
                        {
                            checkBoxMain.Checked = true;
                        }
                        if (SQLDB.DB.Role == "ST")
                        {
                            checkBoxSecurity.Checked = true;
                        }
                        if (SQLDB.DB.Role == "IN")
                        {
                            checkBoxInformation.Checked = true;
                        }
                        if (SQLDB.DB.Role == "AC")
                        {
                            checkBoxAction.Checked = true;
                        }
                        if (SQLDB.DB.Role == "RP")
                        {
                            checkBoxReport.Checked = true;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void txtCompass_Leave(object sender, EventArgs e)
        {
            if (txtCompass.Text != txtPass.Text)
            MessageBox.Show(" Password not confirmed!!");
          
        }

        private void chackBoxshow_CheckedChanged(object sender, EventArgs e)
        {
            txtCompass.UseSystemPasswordChar = !chackBoxshow.Checked;
            txtPass.UseSystemPasswordChar = !chackBoxshow.Checked;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string chackBox = "";

            if (checkBoxMain.Checked == true)
            {
                chackBox = "MA";
            }
            if (checkBoxSecurity.Checked == true)
            {
                chackBox = chackBox + "ST";
            }
            if (checkBoxInformation.Checked == true)
            {
                chackBox = chackBox + "IN";
            }
            if (checkBoxAction.Checked == true)
            {
                chackBox = chackBox + "AC";
            }
            if (checkBoxReport.Checked == true)
            {
                chackBox = chackBox + "RP";
            }

            try
            {
                SQLDB.DB.cmdSQL = new SqlCommand();
                SQLDB.DB.cmdSQL.Connection = SQLDB.DB.conn;
                SQLDB.DB.cmdSQL.CommandText = "SP_UpdateUser";
                SQLDB.DB.cmdSQL.CommandType = CommandType.StoredProcedure;
                SQLDB.DB.cmdSQL.Parameters.Add("@LID", SqlDbType.VarChar).Value = cboLbrarianID.SelectedValue;
                SQLDB.DB.cmdSQL.Parameters.Add("@UID", SqlDbType.VarChar).Value = txtUserID.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtUserName.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@pass", SqlDbType.Char).Value = txtPass.Text;
                SQLDB.DB.cmdSQL.Parameters.Add("@UType", SqlDbType.VarChar).Value = chackBox;
                SQLDB.DB.cmdSQL.Parameters.Add("@DS", SqlDbType.Date).Value = dTPDateStart.Value;
                SQLDB.DB.cmdSQL.ExecuteNonQuery();
                ShowUserName();
                Cleartext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void cboSearchUserName_KeyUp(object sender, KeyEventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvUser, "SELECT * FROM f_SearchUserName1 (N'%" + cboSearchUserName.Text + "%')");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsLogout.Logout();
        }

        private void dgvUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgvUser_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvUser_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgvUser_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
          
        }

        private void dgvUser_CurrentCellChanged(object sender, EventArgs e)
        {
            checkBoxMain.Checked = false;
            checkBoxSecurity.Checked = false;
            checkBoxInformation.Checked = false;
            checkBoxAction.Checked = false;
            checkBoxReport.Checked = false;
        }
    }
}
