using System;
using System.Collections.Generic;

namespace YMTDotNetTrainingBatch2.Database.AppDbContextModels;

public partial class TblSalesDetail
{
    public int SaleDetailId { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public double Quantity { get; set; }

    public double Price { get; set; }
}
