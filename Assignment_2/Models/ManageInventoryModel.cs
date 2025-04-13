namespace Assignment_1.Models;

public class ManageInventoryModel
{
    public IEnumerable<ProductModel> Products { get; set; }
    public IEnumerable<CategoryModel> Categories { get; set; }
}

public class ProductModel
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class CategoryModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}
