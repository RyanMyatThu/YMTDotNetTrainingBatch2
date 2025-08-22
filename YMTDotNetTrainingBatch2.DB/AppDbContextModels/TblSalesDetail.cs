using System;
using System.Collections.Generic;

namespace YMTDotNetTrainingBatch2.DB.AppDbContextModels;

public partial class TblSalesDetail
{
    public int SaleDetailId { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }
}
