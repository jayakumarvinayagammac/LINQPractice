using LinqExcercise.DataRepo;

namespace LinqExcercise.Operator;

public interface ICountOperator
{
    void Execute();
}

public class CountOperator : ICountOperator
{    
    public void Execute()
    {
        // Retrieves the products from the ProductDump class.
        var products = ProductDump.GetProducts();
        
        // Counts the total number of products and displays the result.
        var productCount = products.Count();
        Console.WriteLine($"Total products: {productCount}");
        
        // Counts the number of products with DaysToManufacture greater than 3 and displays the result.
        var quickManufactureCount = products.Count(p => p.DaysToManufacture > 3);
        Console.WriteLine($"Total products with DaysToManufacture greater than 3: {quickManufactureCount}");
        
        // Groups the products by the Size property and displays the count for each group.
        var groupedBySize = products.GroupBy(p => p.Size)
                .Select(g => new { Size = g.Key, Count = g.Count() });
        // Display the result.
        foreach (var group in groupedBySize)
        {
            Console.WriteLine($"Size: {group.Size}, Count: {group.Count}");
        }
    }
}
