namespace cwproj.Models;

public class Pricetilbud {
    public Seller? seller {get; set;} = new Seller();
    public List<Product> products {get; set;} = new List<Product>();

    public void addProduct (Product product) {
        products.Add(product);
    }

    internal void addWeight(VXRecord vx)
    {
        products[products.Count()-1].weight = vx.weight;
    }
    internal void addWeight(string w)
    {
        products[products.Count()-1].weight = w;
    }
}