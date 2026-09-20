using dapperlastproject;

var repository = new ProductRepository();


var products = new List<Product>
{
    new Product
    {
        Name = "Laptop",
        Category = "Electronics",
        Price = 1500,
        Stock = 10
    },

    new Product
    {
        Name = "Mouse",
        Category = "Electronics",
        Price = 25,
        Stock = 50
    },

    new Product
    {
        Name = "Keyboard",
        Category = "Electronics",
        Price = 50,
        Stock = 30
    },

    new Product
    {
        Name = "Monitor",
        Category = "Electronics",
        Price = 300,
        Stock = 15
    },

    new Product
    {
        Name = "Phone",
        Category = "Electronics",
        Price = 900,
        Stock = 20
    },

    new Product
    {
        Name = "Headphones",
        Category = "Electronics",
        Price = 100,
        Stock = 25
    },

    new Product
    {
        Name = "Chair",
        Category = "Furniture",
        Price = 200,
        Stock = 10
    },

    new Product
    {
        Name = "Table",
        Category = "Furniture",
        Price = 400,
        Stock = 5
    },

    new Product
    {
        Name = "Printer",
        Category = "Office",
        Price = 250,
        Stock = 8
    },

    new Product
    {
        Name = "Notebook",
        Category = "Office",
        Price = 5,
        Stock = 0
    }
};


repository.BulkInsert(products);
Console.WriteLine("10 товаров добавлены.");


repository.BulkUpdate();
Console.WriteLine("Цена всех товаров увеличена на 10%.");


repository.BulkDelete();
Console.WriteLine("Товары с Stock = 0 удалены.");


var newProduct = new Product
{
    Id = 1,
    Name = "Updated Laptop",
    Category = "Electronics",
    Price = 1700,
    Stock = 20
};

repository.BulkMerge(newProduct);

Console.WriteLine("Товар обновлен или добавлен.");