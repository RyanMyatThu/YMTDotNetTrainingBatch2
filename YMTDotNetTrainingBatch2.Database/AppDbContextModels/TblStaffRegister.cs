using System;
using System.Collections.Generic;

namespace YMTDotNetTrainingBatch2.Database.AppDbContextModels;

public partial class TblStaffRegister
{
    public int Id { get; set; }

    public string StaffCode { get; set; } = null!;

    public string StaffName { get; set; } = null!;

    public string StaffEmail { get; set; } = null!;

    public string Password { get; set; } = null!;
}
