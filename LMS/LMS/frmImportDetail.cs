using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class frmImportDetail : Form
    {
        public static int m;
        public frmImportDetail()
        {
            InitializeComponent();
            m = 1;
        }

        private void frmImportDetail_Load(object sender, EventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvImportDetail, "SELECT * FROM v_importDetail");
            this.MaximizeBox = false;
            dgvImportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            double result = 0;
            for (int i = 0; i < dgvImportDetail.Rows.Count; i++)
                result +=Convert.ToDouble(dgvImportDetail.Rows[i].Cells["Amount"].Value);
            txtTotal.Text = result.ToString("C2");
          

        }

        private void frmImportDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            m = 0;
        }

        private void dgvImportDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
    }
}
