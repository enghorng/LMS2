namespace LMS
{
    partial class frmUser
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.cboSearchUserName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dTPDateStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.checkBoxReport = new System.Windows.Forms.CheckBox();
            this.checkBoxInformation = new System.Windows.Forms.CheckBox();
            this.checkBoxMain = new System.Windows.Forms.CheckBox();
            this.checkBoxSecurity = new System.Windows.Forms.CheckBox();
            this.chackBoxshow = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBoxAction = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboLbrarianID = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(229)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1678, 100);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Minion Pro", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(796, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(291, 84);
            this.label7.TabIndex = 33;
            this.label7.Text = "Form User";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 382);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(229)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnLogout);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnInsert);
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Location = new System.Drawing.Point(1, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 575);
            this.panel3.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.Coral;
            this.btnLogout.Location = new System.Drawing.Point(35, 316);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(123, 48);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.Coral;
            this.btnUpdate.Location = new System.Drawing.Point(35, 230);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(123, 40);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnInsert.ForeColor = System.Drawing.Color.Coral;
            this.btnInsert.Location = new System.Drawing.Point(35, 142);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(123, 40);
            this.btnInsert.TabIndex = 12;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.Coral;
            this.btnNew.Location = new System.Drawing.Point(35, 50);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(123, 40);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(273, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Librarian ";
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.Font = new System.Drawing.Font("Chantrea SR UI Low", 12F);
            this.txtUserID.Location = new System.Drawing.Point(534, 213);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(254, 39);
            this.txtUserID.TabIndex = 3;
            // 
            // cboSearchUserName
            // 
            this.cboSearchUserName.Font = new System.Drawing.Font("Chantrea SR UI Low", 12F);
            this.cboSearchUserName.FormattingEnabled = true;
            this.cboSearchUserName.Location = new System.Drawing.Point(32, 57);
            this.cboSearchUserName.Name = "cboSearchUserName";
            this.cboSearchUserName.Size = new System.Drawing.Size(392, 40);
            this.cboSearchUserName.TabIndex = 4;
            this.cboSearchUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboSearchUserName_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(273, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "User ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Coral;
            this.label3.Location = new System.Drawing.Point(273, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "User ";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Chantrea SR UI Low", 12F);
            this.txtUserName.Location = new System.Drawing.Point(534, 278);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(254, 39);
            this.txtUserName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(273, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Chantrea SR UI Low", 12F);
            this.txtPass.Location = new System.Drawing.Point(534, 341);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(254, 39);
            this.txtPass.TabIndex = 8;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Coral;
            this.label5.Location = new System.Drawing.Point(273, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Comform password";
            // 
            // txtCompass
            // 
            this.txtCompass.Font = new System.Drawing.Font("Chantrea SR UI Low", 12F);
            this.txtCompass.Location = new System.Drawing.Point(534, 409);
            this.txtCompass.Name = "txtCompass";
            this.txtCompass.Size = new System.Drawing.Size(254, 39);
            this.txtCompass.TabIndex = 10;
            this.txtCompass.UseSystemPasswordChar = true;
            this.txtCompass.Leave += new System.EventHandler(this.txtCompass_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Coral;
            this.label6.Location = new System.Drawing.Point(273, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "Date Start";
            // 
            // dTPDateStart
            // 
            this.dTPDateStart.CustomFormat = "dd/MM/yyyy";
            this.dTPDateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dTPDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPDateStart.Location = new System.Drawing.Point(534, 522);
            this.dTPDateStart.Name = "dTPDateStart";
            this.dTPDateStart.Size = new System.Drawing.Size(254, 35);
            this.dTPDateStart.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSearchUserName);
            this.groupBox1.Controls.Add(this.dgvUser);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.Coral;
            this.groupBox1.Location = new System.Drawing.Point(1158, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 470);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search User Name";
            // 
            // dgvUser
            // 
            this.dgvUser.AllowDrop = true;
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            this.dgvUser.AllowUserToResizeColumns = false;
            this.dgvUser.AllowUserToResizeRows = false;
            this.dgvUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(35, 135);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Chantrea SR UI Low", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvUser.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.RowTemplate.Height = 28;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(389, 295);
            this.dgvUser.TabIndex = 40;
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellClick);
            this.dgvUser.CellContextMenuStripChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellContextMenuStripChanged);
            this.dgvUser.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUser_CellMouseClick);
            this.dgvUser.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUser_CellMouseMove);
            this.dgvUser.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvUser_CellStateChanged);
            this.dgvUser.CurrentCellChanged += new System.EventHandler(this.dgvUser_CurrentCellChanged);
            this.dgvUser.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUser_RowPostPaint);
            // 
            // checkBoxReport
            // 
            this.checkBoxReport.AutoSize = true;
            this.checkBoxReport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBoxReport.Location = new System.Drawing.Point(173, 72);
            this.checkBoxReport.Name = "checkBoxReport";
            this.checkBoxReport.Size = new System.Drawing.Size(97, 32);
            this.checkBoxReport.TabIndex = 43;
            this.checkBoxReport.Text = "Report";
            this.checkBoxReport.UseVisualStyleBackColor = true;
            // 
            // checkBoxInformation
            // 
            this.checkBoxInformation.AutoSize = true;
            this.checkBoxInformation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBoxInformation.Location = new System.Drawing.Point(54, 110);
            this.checkBoxInformation.Name = "checkBoxInformation";
            this.checkBoxInformation.Size = new System.Drawing.Size(141, 32);
            this.checkBoxInformation.TabIndex = 42;
            this.checkBoxInformation.Text = "Information";
            this.checkBoxInformation.UseVisualStyleBackColor = true;
            // 
            // checkBoxMain
            // 
            this.checkBoxMain.AutoSize = true;
            this.checkBoxMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBoxMain.Location = new System.Drawing.Point(54, 34);
            this.checkBoxMain.Name = "checkBoxMain";
            this.checkBoxMain.Size = new System.Drawing.Size(82, 32);
            this.checkBoxMain.TabIndex = 41;
            this.checkBoxMain.Text = "Main";
            this.checkBoxMain.UseVisualStyleBackColor = true;
            // 
            // checkBoxSecurity
            // 
            this.checkBoxSecurity.AutoSize = true;
            this.checkBoxSecurity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxSecurity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBoxSecurity.Location = new System.Drawing.Point(54, 72);
            this.checkBoxSecurity.Name = "checkBoxSecurity";
            this.checkBoxSecurity.Size = new System.Drawing.Size(108, 32);
            this.checkBoxSecurity.TabIndex = 44;
            this.checkBoxSecurity.Text = "Security";
            this.checkBoxSecurity.UseVisualStyleBackColor = true;
            // 
            // chackBoxshow
            // 
            this.chackBoxshow.AutoSize = true;
            this.chackBoxshow.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chackBoxshow.ForeColor = System.Drawing.Color.Coral;
            this.chackBoxshow.Location = new System.Drawing.Point(616, 457);
            this.chackBoxshow.Name = "chackBoxshow";
            this.chackBoxshow.Size = new System.Drawing.Size(172, 32);
            this.chackBoxshow.TabIndex = 45;
            this.chackBoxshow.Text = "Show Password";
            this.chackBoxshow.UseVisualStyleBackColor = true;
            this.chackBoxshow.CheckedChanged += new System.EventHandler(this.chackBoxshow_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Font = new System.Drawing.Font("Modern No. 20", 8F);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(825, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 291);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Note";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label9.Location = new System.Drawing.Point(38, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "1. Atleast 4 Characters";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label10.Location = new System.Drawing.Point(19, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 21);
            this.label10.TabIndex = 23;
            this.label10.Text = "Password From :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label11.Location = new System.Drawing.Point(20, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 21);
            this.label11.TabIndex = 24;
            this.label11.Text = "E.g.Abc123";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label12.Location = new System.Drawing.Point(38, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(259, 21);
            this.label12.TabIndex = 26;
            this.label12.Text = "2.One of Characters must be Capital";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label13.Location = new System.Drawing.Point(39, 230);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 21);
            this.label13.TabIndex = 28;
            this.label13.Text = "4.Normally 60 days expired";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label14.Location = new System.Drawing.Point(38, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(178, 21);
            this.label14.TabIndex = 27;
            this.label14.Text = "3.Mix with Number digit";
            // 
            // checkBoxAction
            // 
            this.checkBoxAction.AutoSize = true;
            this.checkBoxAction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBoxAction.Location = new System.Drawing.Point(173, 34);
            this.checkBoxAction.Name = "checkBoxAction";
            this.checkBoxAction.Size = new System.Drawing.Size(95, 32);
            this.checkBoxAction.TabIndex = 47;
            this.checkBoxAction.Text = "Action";
            this.checkBoxAction.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxInformation);
            this.groupBox3.Controls.Add(this.checkBoxAction);
            this.groupBox3.Controls.Add(this.checkBoxSecurity);
            this.groupBox3.Controls.Add(this.checkBoxMain);
            this.groupBox3.Controls.Add(this.checkBoxReport);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.Coral;
            this.groupBox3.Location = new System.Drawing.Point(825, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 152);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Type";
            // 
            // cboLbrarianID
            // 
            this.cboLbrarianID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboLbrarianID.FormattingEnabled = true;
            this.cboLbrarianID.Location = new System.Drawing.Point(534, 149);
            this.cboLbrarianID.Name = "cboLbrarianID";
            this.cboLbrarianID.Size = new System.Drawing.Size(254, 37);
            this.cboLbrarianID.TabIndex = 49;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1678, 673);
            this.Controls.Add(this.cboLbrarianID);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chackBoxshow);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dTPDateStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCompass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmUser";
            this.Text = "frmUser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUser_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUser_FormClosed);
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.ComboBox cboSearchUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dTPDateStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxReport;
        private System.Windows.Forms.CheckBox checkBoxInformation;
        private System.Windows.Forms.CheckBox checkBoxMain;
        private System.Windows.Forms.CheckBox checkBoxSecurity;
        private System.Windows.Forms.CheckBox chackBoxshow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBoxAction;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.ComboBox cboLbrarianID;
    }
}