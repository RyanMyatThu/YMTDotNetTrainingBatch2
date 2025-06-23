// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using YMTDotNetTrainingBatch2.MiniPOSConsoleApp;

Console.WriteLine("Welcome to Mini POS Console App!");
Console.WriteLine("--------------------------------");

Menu:
Console.WriteLine("\nMenus");
Console.WriteLine("--------------------------------");
Console.WriteLine("1. Product");
Console.WriteLine("2. Sale");
Console.WriteLine("3. Sale Detail");
Console.WriteLine("4. Exit");
Console.WriteLine("--------------------------------");

Console.Write("\nChoose menu : ");
bool isInt = int.TryParse(Console.ReadLine(), out int no);
if (!isInt)
{
    Console.WriteLine("Invalid input. Please choose a number between 1 and 4");
    goto Menu;
}

EnumMenu menu = (EnumMenu)no;

switch (menu)
{        
    case EnumMenu.Product:
        ProductService ps = new ProductService();
        ps.Execute();
        break;
    case EnumMenu.Sale:
        break;
    case EnumMenu.SaleDetail:
        break;
    case EnumMenu.Exit:
        goto End;
    case EnumMenu.None:
    default:
        break;
}

Console.WriteLine("--------------------------------");
goto Menu;

End:
Console.WriteLine("\nExiting Mini POS...");




public enum EnumMenu
{
    None,
    Product,
    Sale,
    SaleDetail,
    Exit
}