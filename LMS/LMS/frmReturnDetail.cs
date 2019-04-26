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
    public partial class frmReturnDetail : Form
    {
        public static int m;
        public frmReturnDetail()
        {
            InitializeComponent();
            m = 1;
        }

        private void dgvReturnDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void frmReturnDetail_Load(object sender, EventArgs e)
        {
            SQLDB.DB.SQL_Grid(dgvReturnDetail, "SELECT * FROM v_ReturnDetail");
            this.MaximizeBox = false;
            dgvReturnDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
    
}
