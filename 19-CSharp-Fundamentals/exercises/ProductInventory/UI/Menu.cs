using Controllers;
using Models;

namespace UI;


class Menu
{
    private readonly ProductController _productController;

    public Menu(ProductController productController)
    {
        _productController = productController;
    }

    public void Run()
    {
        while (true)
        {
            ShowMenu();
        }
    }

    void ShowMenu()
    {
        Console.WriteLine($"\n----------Menu----------\n");
        Console.WriteLine($"Enter your option via key");


        Console.WriteLine($"{"""

        a -> Add product;

        m -> Add products in bulk

        l -> List all products

        g -> Get product by id;

        r -> remove product by id
        
        n -> find by name

        e -> exit
    """}");

        var userChoice = Console.ReadKey();
        Console.Clear();
        Console.WriteLine($"");


        switch (userChoice.Key)
        {

            case ConsoleKey.A:
                _productController.AddProduct();
                break;
            case ConsoleKey.M:
                _productController.AddMultipleProducts();
                break;
            case ConsoleKey.L:
                _productController.ListProduct();
                break;
            case ConsoleKey.G:
                _productController.GetById();
                break;
            case ConsoleKey.R:
                _productController.RemoveById();
                break;
            case ConsoleKey.N:
                _productController.FindByName();
                break;
            case ConsoleKey.E:
                Console.WriteLine($"GoodBye");
                Environment.Exit(0);
                return;

            default:
                Console.WriteLine($"Not a valid option");
                break;
        }


    }
}