using System;
using System.Collections.Generic;

namespace YMTDotNetTrainingBatch2.Database.AppDbContextModels;

public partial class TblSalesSummary
{
    public int SaleId { get; set; }

    public DateTime Date { get; set; }

    public string VoucherId { get; set; } = null!;

    public decimal TotalAmount { get; set; }
}
