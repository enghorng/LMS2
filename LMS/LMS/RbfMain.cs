using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace LMS
{
   
    public partial class RbfMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static int m;        
        public RbfMain()
        {
            InitializeComponent();
            barStaticItemtime.Caption = DateTime.Now.ToString();
            if (m == 2)
                m = 2;
            else
                m = 1;
            
        }
        
        private void barbtnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = FrmImport.m;
            if (i < 1)
            {
                FrmImport frm = new FrmImport();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void RbfMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            m = 0;
        }
       public static int i;
        
        private void barbtnLirarian_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = FrmLibrarian.m;
            if (i < 1)
            {
                FrmLibrarian frm = new FrmLibrarian();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }



        private void barBtnBook_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmBook.m;
            if (i < 1)
            {
                frmBook frm = new frmBook();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnSupplier_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmSupplier.m;
            if (i < 1||i==3)
            {
                frmSupplier frm = new frmSupplier();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmCategory.m;
            if (i < 1)
            {
                frmCategory frm = new frmCategory();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnReader_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmReader.m;
            if (i < 1)
            {
                frmReader frm = new frmReader();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnSetup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmUser.m;
            if (i < 1)
            {
               frmUser frm = new frmUser();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnBorrow_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmBorrow.m;
            if (i < 1)
            {
                frmBorrow frm = new frmBorrow();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmReturn.m;
            if (i < 1)
            {
                frmReturn frm = new frmReturn();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnImportDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmImportDetail.m;
            if (i < 1)
            {
                frmImportDetail frm = new frmImportDetail();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnBorrowDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmBorrowDetail.m;
            if (i < 1)
            {
                frmBorrowDetail frm = new frmBorrowDetail();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnReturnDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmReturnDetail.m;
            if (i < 1)
            {
                frmReturnDetail frm = new frmReturnDetail();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m == 2)
            {
                i = 0;
                m = 1;
            }
            else
                i = frmViewReaderExpried.m;
            if (i < 1)
            {
                frmViewReaderExpried frm = new frmViewReaderExpried();
                frm.MdiParent = this;
                frm.Show();
                i++;
            }
        }

        private void barBtnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsLogout.Logout();
        }
    }
}