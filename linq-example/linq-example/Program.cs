using linq_example;

List<Product> products = new List<Product>
{
    new("Kaffe", "Dryck", 35),
    new("Juice", "Dryck", 28),
    new("Smörgås", "Mat", 55),
    new("Sallad", "Mat", 89),
    new("Kanelbulle", "Bakverk", 30)
};

// Filtrera och omvandla
List<Product> newList = products.Where(product => product.Price > 30).ToList();  // Filtrera ut baserat på ett villkor, få tillbaka en filtrerad lista
foreach (Product item in newList)
{
    Console.WriteLine(item.Name);
}

List<string> upperCaseList = products.Select(product => product.Name.ToUpper()).ToList();

foreach (string item in upperCaseList)
{
    Console.WriteLine(item);
}

// Sortering

List<Product> sortedAscending = products.OrderBy(p => p.Price).ToList(); // Stigande ordning
List<Product> sortedDescending = products.OrderByDescending(p => p.Price).ToList(); // Fallande ordning

// Plocka ut ett element

Product foundProduct = products.First(product => product.Category == "Mat"); // Hittas ingen produkt så kastas ett fel
Product foundProduct2 = products.FirstOrDefault(product => product.Category == "Mat"); // Hittas ingen produkt så returneras null


var cheapProducts = products.Where(product => product.Price < 30);
Console.WriteLine($"Antalet produkter: {cheapProducts.Count()}"); // 1
products.Add(new("Kaka", "Bakverk", 25));
Console.WriteLine($"Antalet produkter: {cheapProducts.Count()}");  // 2

var cheapList = products.Where(product => product.Price < 30).ToList(); // ToList() tar en ögonblicksbild
products.Add(new("Te", "Dryck", 22));
Console.WriteLine($"Antalet produkter: {cheapList.Count()}");  // 2

var formatedList = products
    .Where(product => product.Category != "Mat")
    .OrderByDescending(product => product.Price)
    .Select(product => $"{product.Name} ({product.Price} kr)")
    .ToList();

foreach (var item in formatedList)
{
    Console.WriteLine(item);
}