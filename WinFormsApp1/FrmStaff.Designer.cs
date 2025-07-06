namespace WinFormsApp1
{
    partial class FrmStaff
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            staffCodeLabel = new Label();
            txtStaffCode = new TextBox();
            txtStaffName = new TextBox();
            staffNameLabel = new Label();
            txtEmail = new TextBox();
            staffEmailLabel = new Label();
            txtPassword = new TextBox();
            passwordLabel = new Label();
            staffPositionLabel = new Label();
            positionCb = new ComboBox();
            mobileNumberLabel = new Label();
            txtMobile = new TextBox();
            saveBtn = new Button();
            dgvData = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colCode = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // staffCodeLabel
            // 
            staffCodeLabel.AutoSize = true;
            staffCodeLabel.Font = new Font("Segoe UI", 10F);
            staffCodeLabel.Location = new Point(35, 39);
            staffCodeLabel.Name = "staffCodeLabel";
            staffCodeLabel.Size = new Size(102, 28);
            staffCodeLabel.TabIndex = 0;
            staffCodeLabel.Text = "Staff Code";
            // 
            // txtStaffCode
            // 
            txtStaffCode.Font = new Font("Segoe UI", 12F);
            txtStaffCode.Location = new Point(35, 74);
            txtStaffCode.Name = "txtStaffCode";
            txtStaffCode.Size = new Size(315, 39);
            txtStaffCode.TabIndex = 1;
            // 
            // txtStaffName
            // 
            txtStaffName.Font = new Font("Segoe UI", 12F);
            txtStaffName.Location = new Point(35, 151);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.Size = new Size(315, 39);
            txtStaffName.TabIndex = 3;
            // 
            // staffNameLabel
            // 
            staffNameLabel.AutoSize = true;
            staffNameLabel.Font = new Font("Segoe UI", 10F);
            staffNameLabel.Location = new Point(35, 116);
            staffNameLabel.Name = "staffNameLabel";
            staffNameLabel.Size = new Size(64, 28);
            staffNameLabel.TabIndex = 2;
            staffNameLabel.Text = "Name";
            staffNameLabel.UseMnemonic = false;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(35, 228);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(315, 39);
            txtEmail.TabIndex = 5;
            // 
            // staffEmailLabel
            // 
            staffEmailLabel.AutoSize = true;
            staffEmailLabel.Font = new Font("Segoe UI", 10F);
            staffEmailLabel.Location = new Point(35, 193);
            staffEmailLabel.Name = "staffEmailLabel";
            staffEmailLabel.Size = new Size(59, 28);
            staffEmailLabel.TabIndex = 4;
            staffEmailLabel.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(35, 305);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(315, 39);
            txtPassword.TabIndex = 7;
            txtPassword.TextChanged += textBox2_TextChanged;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 10F);
            passwordLabel.Location = new Point(35, 270);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(93, 28);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "Password";
            // 
            // staffPositionLabel
            // 
            staffPositionLabel.AutoSize = true;
            staffPositionLabel.Font = new Font("Segoe UI", 10F);
            staffPositionLabel.Location = new Point(35, 347);
            staffPositionLabel.Name = "staffPositionLabel";
            staffPositionLabel.Size = new Size(82, 28);
            staffPositionLabel.TabIndex = 8;
            staffPositionLabel.Text = "Position";
            // 
            // positionCb
            // 
            positionCb.DropDownStyle = ComboBoxStyle.DropDownList;
            positionCb.Font = new Font("Segoe UI", 12F);
            positionCb.FormattingEnabled = true;
            positionCb.Items.AddRange(new object[] { "Admin", "Staff" });
            positionCb.Location = new Point(35, 378);
            positionCb.Name = "positionCb";
            positionCb.Size = new Size(315, 40);
            positionCb.TabIndex = 9;
            // 
            // mobileNumberLabel
            // 
            mobileNumberLabel.AutoSize = true;
            mobileNumberLabel.Font = new Font("Segoe UI", 10F);
            mobileNumberLabel.Location = new Point(35, 421);
            mobileNumberLabel.Name = "mobileNumberLabel";
            mobileNumberLabel.Size = new Size(110, 28);
            mobileNumberLabel.TabIndex = 10;
            mobileNumberLabel.Text = "Mobile No.";
            // 
            // txtMobile
            // 
            txtMobile.Font = new Font("Segoe UI", 12F);
            txtMobile.Location = new Point(35, 452);
            txtMobile.Name = "txtMobile";
            txtMobile.Size = new Size(315, 39);
            txtMobile.TabIndex = 11;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(233, 510);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(117, 45);
            saveBtn.TabIndex = 12;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colId, colName, colCode });
            dgvData.Location = new Point(379, 39);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(899, 526);
            dgvData.TabIndex = 13;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 150;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 8;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Width = 150;
            // 
            // colId
            // 
            colId.DataPropertyName = "StaffId";
            colId.HeaderText = "Id";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 150;
            // 
            // colName
            // 
            colName.DataPropertyName = "StaffName";
            colName.HeaderText = "Staff Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // colCode
            // 
            colCode.DataPropertyName = "StaffCode";
            colCode.HeaderText = "Staff Code";
            colCode.MinimumWidth = 8;
            colCode.Name = "colCode";
            colCode.ReadOnly = true;
            colCode.Width = 150;
            // 
            // FrmStaff
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1303, 577);
            Controls.Add(dgvData);
            Controls.Add(saveBtn);
            Controls.Add(txtMobile);
            Controls.Add(mobileNumberLabel);
            Controls.Add(positionCb);
            Controls.Add(staffPositionLabel);
            Controls.Add(txtPassword);
            Controls.Add(passwordLabel);
            Controls.Add(txtEmail);
            Controls.Add(staffEmailLabel);
            Controls.Add(txtStaffName);
            Controls.Add(staffNameLabel);
            Controls.Add(txtStaffCode);
            Controls.Add(staffCodeLabel);
            Name = "FrmStaff";
            Text = "Form1";
            Load += FrmStaff_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label staffCodeLabel;
        private TextBox txtStaffCode;
        private TextBox txtStaffName;
        private Label staffNameLabel;
        private TextBox txtEmail;
        private Label staffEmailLabel;
        private TextBox txtPassword;
        private Label passwordLabel;
        private Label staffPositionLabel;
        private ComboBox positionCb;
        private Label mobileNumberLabel;
        private TextBox txtMobile;
        private Button saveBtn;
        private DataGridView dgvData;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCode;
    }
}
