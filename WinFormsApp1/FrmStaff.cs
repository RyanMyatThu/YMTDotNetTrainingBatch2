using YMTDotNetTrainingBatch2.WinFormApp.Database.AppDbContextModels;

using AppDbContext =  YMTDotNetTrainingBatch2.WinFormApp.Database.AppDbContextModels.AppDbContextModels;

namespace WinFormsApp1
{
    public partial class FrmStaff : Form
    {
        private readonly AppDbContext _db;
        private int _editId;

        public FrmStaff()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _db = new AppDbContext();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_editId == 0)
                {
                    _db.TblStaffs.Add(new TblStaff()
                    {
                        StaffCode = txtStaffCode.Text.Trim(),
                        StaffName = txtStaffName.Text.Trim(),
                        IsDelete = false,
                        EmailAddress = txtEmail.Text.Trim(),
                        Password = txtPassword.Text.Trim(),
                        Position = positionCb.Text.Trim(),
                        MobileNo = txtMobile.Text.Trim()
                    });
                    int result = _db.SaveChanges();
                    string message = result > 0 ? "Saving Successful." : "Saving Failed.";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtStaffCode.Clear();
                    txtStaffName.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    positionCb.SelectedIndex = -1;
                    txtMobile.Clear();
                    txtStaffCode.Focus();

                    BindData();
                } else
                {
                    TblStaff? staffData = _db.TblStaffs.FirstOrDefault(x => x.StaffId == _editId && x.IsDelete == false);
                    if (staffData is null)
                    {
                        return;
                    }

                    staffData.StaffCode = txtStaffCode.Text.Trim();
                    staffData.StaffName = txtStaffName.Text.Trim();
                    staffData.EmailAddress = txtEmail.Text.Trim();
                    staffData.Password = txtPassword.Text.Trim();
                    staffData.Position = positionCb.Text.Trim();   
                    staffData.MobileNo = txtMobile.Text.Trim();
                    int result = _db.SaveChanges();
                    string message = result > 0 ? "Update Successful." : "Update Failed.";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtStaffCode.Clear();
                    txtStaffName.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    positionCb.SelectedIndex = -1;
                    txtMobile.Clear();
                    txtStaffCode.Focus();
                    _editId = 0;
                    saveBtn.Text = "Save";
                    txtStaffCode.Focus();

                    BindData();
                }
            }
            catch (Exception)
            {


            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            try
            {
                dgvData.DataSource = _db.TblStaffs.Where(x => x.IsDelete == false).ToList();
            }
            catch (Exception)
            {

            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;


            if(e.ColumnIndex == dgvData.Columns["colEdit"].Index)
            {
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                TblStaff? staffData = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id);
                if(staffData is null)
                {
                    return;
                }

                txtStaffCode.Text = staffData.StaffCode;
                txtStaffName.Text = staffData.StaffName;
                txtEmail.Text = staffData.EmailAddress;
                txtMobile.Text = staffData.MobileNo;
                txtPassword.Text = staffData.Password;
                positionCb.Text = staffData.Position;
                _editId = staffData.StaffId;

                saveBtn.Text = "Update";
            }
            else if(e.ColumnIndex == dgvData.Columns["colDelete"].Index)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return;

                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                TblStaff? staffData = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id && x.IsDelete == false);
                if (staffData is null)
                {
                    return;
                }
                staffData.IsDelete = true;
                int result = _db.SaveChanges();
                string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindData();
            }
        }

      
    }
}
