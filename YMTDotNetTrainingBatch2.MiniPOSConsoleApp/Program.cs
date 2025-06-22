// See https://aka.ms/new-console-template for more information

using YMTDotNetTrainingBatch2.MiniPOSConsoleApp;

//Testing Product Services


ProductService ps = new ProductService();
ps.Create();
ps.Read();
ps.Edit();
ps.Update();
ps.Delete();


//Testing SalesDetailService


SalesService ss = new SalesService();
ss.Create();
ss.Read();
ss.Edit();



//Testing SalesService


SalesDetailService sds = new SalesDetailService();
sds.Create();
sds.Read();
sds.Edit(); 
