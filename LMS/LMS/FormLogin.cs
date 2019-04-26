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
    public partial class FormLogin : Form
    {
        public static string u;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
           // Application.Exit();
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            RbfMain.m = 2;
            if (txtPassword.Text == "" && txtUser.Text == "")
            {
                txtUser.Text = "Input User Name";               
                txtPassword.Text = "Enter Password";
                return;
            }

            SqlDataAdapter da = new SqlDataAdapter("select * from v_User where UserName='" + txtUser.Text + "' and [Password] ='" + txtPassword.Text + "'"
                    , SQLDB.DB.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToDateTime(dt.Rows[0]["ExprieDate"]) > DateTime.Now)
                {
                    RbfMain frm = new RbfMain();
                    int i = 0;
                    u = dt.Rows[0]["LibrarianID"].ToString();
                    string ur = dt.Rows[0]["UserType"].ToString();
                    for (i = 0; i < ur.Length; i++)
                    {
                        SQLDB.DB.Role = (ur.Substring(i, 2));
                        i++;
                        if (SQLDB.DB.Role == "MA")
                        {
                            frm.ribbonPageMain.Visible = true;
                        }
                        if (SQLDB.DB.Role == "ST")
                        {
                            frm.ribbonPageSecurity.Visible = true;
                        }
                        if (SQLDB.DB.Role == "IN")
                        {
                            frm.ribbonPageInfor.Visible = true;
                        }
                        if (SQLDB.DB.Role == "AC")
                        {
                            frm.ribbonPageAction.Visible = true;
                        }
                        if (SQLDB.DB.Role == "RP")
                        {
                            frm.ribbonPageReport.Visible = true;
                        }
                    }
                    this.Hide();
                    frm.barStaticUser.Caption = txtUser.Text;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("PassWord has Expired");
                    
                }
            }
            else
            {
                MessageBox.Show("Invalid User");
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            SQLDB.DB.ConnectionDB("Server=(local); Uid=sa; Pwd=123 ; Database=ProductMaster");
        }

        private void chbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chbShowPass.Checked;
        }
    }
}
