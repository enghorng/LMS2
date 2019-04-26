using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    class clsLogout
    {
        public static void Logout()
        {
            for (int ix = Application.OpenForms.Count - 1; ix >= 0; --ix)
            {
                var frm = Application.OpenForms[ix];
                if (frm.GetType() != typeof(RbfMain)) frm.Close();
            }
            for (int ix = Application.OpenForms.Count - 1; ix >= 0; --ix)
            {
                var frm = Application.OpenForms[ix];
                if (frm.GetType() != typeof(FormLogin)) frm.Close();
            }
            Process p = new Process();
            p.StartInfo.FileName = @"LMS.exe";
            p.Start();
        }
    }
}
