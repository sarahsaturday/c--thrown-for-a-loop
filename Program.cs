﻿// See https://aka.ms/new-console-template for more information
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        StockDate = new DateTime(2020, 1, 1),
        ManufactureYear = 2019,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.40M,
        Sold = false,
        StockDate = new DateTime(2022, 6, 26),
        ManufactureYear = 2021,
        Condition = 6.3
    },
    new Product()
    {
        Name = "Golf Club",
        Price = 10.22M,
        Sold = false,
        StockDate = new DateTime(2021, 3, 13),
        ManufactureYear = 2020,
        Condition = 2.1
    },
    new Product()
    {
        Name = "Baseball Bat",
        Price = 8.78M,
        Sold = false,
        StockDate = new DateTime(2018, 11, 23),
        ManufactureYear = 2017,
        Condition = 3.8
    },
};

string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View Product Details");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ViewProductDetails();
    }
}

void ViewProductDetails()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");

    Console.WriteLine("Products");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    DateTime now = DateTime.Now;

    TimeSpan timeInStock = now - chosenProduct.StockDate;
    Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old, and its condition is rated {chosenProduct.Condition}. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");

}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}