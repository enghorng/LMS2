namespace LMS
{
    partial class frmViewReaderExpried
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvViewReaderEx = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewReaderEx)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvViewReaderEx
            // 
            this.dgvViewReaderEx.AllowDrop = true;
            this.dgvViewReaderEx.AllowUserToAddRows = false;
            this.dgvViewReaderEx.AllowUserToDeleteRows = false;
            this.dgvViewReaderEx.AllowUserToOrderColumns = true;
            this.dgvViewReaderEx.AllowUserToResizeColumns = false;
            this.dgvViewReaderEx.AllowUserToResizeRows = false;
            this.dgvViewReaderEx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvViewReaderEx.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dgvViewReaderEx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewReaderEx.Location = new System.Drawing.Point(66, 279);
            this.dgvViewReaderEx.Name = "dgvViewReaderEx";
            this.dgvViewReaderEx.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Chantrea SR UI Low", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvViewReaderEx.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewReaderEx.RowTemplate.Height = 28;
            this.dgvViewReaderEx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViewReaderEx.Size = new System.Drawing.Size(1162, 304);
            this.dgvViewReaderEx.TabIndex = 7;
            this.dgvViewReaderEx.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvViewReaderEx_RowPostPaint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(229)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1324, 100);
            this.panel1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Minion Pro", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(640, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(385, 84);
            this.label7.TabIndex = 35;
            this.label7.Text = "Borrow Detail";
            // 
            // frmViewReaderExpried
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1327, 644);
            this.Controls.Add(this.dgvViewReaderEx);
            this.Controls.Add(this.panel1);
            this.Name = "frmViewReaderExpried";
            this.Text = "frmViewReaderExpried";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewReaderExpried_FormClosing);
            this.Load += new System.EventHandler(this.frmViewReaderExpried_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewReaderEx)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvViewReaderEx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
    }
}