using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQLDB
{
    class DB
    {
        public static SqlConnection conn = new SqlConnection();
        public static SqlCommand cmdSQL = new SqlCommand();
       // public static SqlDataReader reader;
        public static string Role=null;
        //public static string user;
        public static void ClearData(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    c.Text = null;
                }
                else
                {
                    ClearData(c);
                }
            }
        }

        public static bool ConnectionDB(string str)
        {
            try
            {
                //using (SqlConnection conn = new SqlConnection())
                //{
                // Create the connectionString
                // Trusted_Connection is used to denote the connection uses Windows Authentication
                conn.ConnectionString = "Server=(local); Uid=sa; Pwd=123 ; Database=LMS";
                conn.Open();
                //}
                return true;
            }

            catch
            {
                return false;
            }

        }
        public static void SQL_Grid(DataGridView DG, string select)
        {
            //SqlConnection conn = new SqlConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conn); //c.con is the connection string

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            DG.ReadOnly = true;
            DG.DataSource = dt;
            DG.AutoGenerateColumns = true;
        }

        public static void SQL_List(ListBox lst, string select)
        {
            //SqlConnection conn = new SqlConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conn); //c.con is the connection string

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            
            lst.DataSource = dt;
        }
        public static void SQL_String_CBO_SQL(ComboBox CBO, String SQL_STR, String Vm, string Dm)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(SQL_STR, conn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            CBO.DataSource = dt;
            CBO.DisplayMember = Dm;
            CBO.ValueMember = Vm;
        }

        public static bool TStatement_SQL(string SQL)
        {
            try
            {
                cmdSQL.Connection = conn;
                cmdSQL.CommandText = SQL;
                cmdSQL.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string Get1Record(string SQL_STR)
        {
            SqlDataAdapter objDa = new SqlDataAdapter(SQL_STR, conn);
            DataTable objTable = new DataTable();
            objDa.Fill(objTable);
            if (objTable.Rows.Count > 0)
            {
                if (Convert.ToString(objTable.Rows[0][0]) != string.Empty)
                {
                    return objTable.Rows[0][0].ToString();
                }
            }
            return "";
        }
    }
}
