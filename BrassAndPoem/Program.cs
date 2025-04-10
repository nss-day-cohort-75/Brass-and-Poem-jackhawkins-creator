//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "A Light in the Attic",
        Price = 20.00M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Sousaphone",
        Price = 2996.00M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Leaves of Grass",
        Price = 15.00M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "French Horn",
        Price = 1325.50M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "The Raven",
        Price = 18.75M,
        ProductTypeId = 2
    }
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass",
        Id = 1
    },
    new ProductType()
    {
        Title = "Poem",
        Id = 2
    }
};

//put your greeting here
string greeting = @"Welcome to Brass & Poem
Today's Special Deal is 'The Raven' for only $18.75";
Console.WriteLine(greeting);

//implement your loop here
string choice = null;
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();
    if (choice == "1")
    {
        DisplayAllProducts(products, productTypes);
    }
    else if (choice == "2")
    {
        DeleteProduct(products, productTypes);
    }
    else if (choice == "3")
    {
        AddProduct(products, productTypes);
    }
    else if (choice == "4")
    {
        UpdateProduct(products, productTypes);
    }
    else if (choice == "5")
    {
        Console.WriteLine("Farewell!");
    }

    void DisplayMenu()
    {
        Console.WriteLine(@"1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit");
    }

    void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
    {
        for (int i = 0; i < products.Count; i++)
        {
            Product product = products[i]; //set to current product we're cycling thru
            string productTypeTitle = productTypes.First(pType => pType.Id == product.ProductTypeId).Title; //get our type
            Console.WriteLine($"{i + 1}. {product.Name} - ${product.Price} - {productTypeTitle}");
        }
    }

    void DeleteProduct(List<Product> products, List<ProductType> productTypes)
    {
        DisplayAllProducts(products, productTypes);
        Console.WriteLine("Please enter the number of the product you want to delete:");
        string input = Console.ReadLine();
        int index = int.Parse(input) - 1;
        products.RemoveAt(index); //little confused at difference between this and a plain Remove - maybe ask question
    }

    void AddProduct(List<Product> products, List<ProductType> productTypes)
    {
        Console.WriteLine("Enter product name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter product price:");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter product type ID:");
        int productTypeId = int.Parse(Console.ReadLine());

        Product newProduct = new Product
        {
            Name = name,
            Price = price,
            ProductTypeId = productTypeId
        };

        products.Add(newProduct);
    }

    void UpdateProduct(List<Product> products, List<ProductType> productTypes)
    {
        DisplayAllProducts(products, productTypes);
        Console.WriteLine("Please enter the number of the product you want to update:");
        string input = Console.ReadLine();
        int index = int.Parse(input) - 1;
        Product productToUpdate = products[index];

        Console.WriteLine($@"Enter new name for {productToUpdate.Name}.
        Press Enter to keep the current name.");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            productToUpdate.Name = newName;
        }

        Console.WriteLine($@"Enter new price for {productToUpdate.Price}.
        Press Enter to keep the current price.");
        string newPrice = Console.ReadLine();
        if (!string.IsNullOrEmpty(newPrice))
        {
            productToUpdate.Price = decimal.Parse(newPrice);
        }

        Console.WriteLine($@"Enter new type for {productToUpdate.ProductTypeId}.
        Press Enter to keep the current type.");
        string newType = Console.ReadLine();
        if (!string.IsNullOrEmpty(newType))
        {
            productToUpdate.ProductTypeId = int.Parse(newType);
        }
    }

}
// don't move or change this!
public partial class Program { }