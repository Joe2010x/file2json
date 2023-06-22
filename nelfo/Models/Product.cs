namespace cwproj.Models;

public class Product {
    public Product(string pn,string des,string pu,string p,string q,string sp) {
        productNo = pn;
        description = des;
        priceUnit = pu;
        price = p;
        quantity = q;
        stockProduct = sp;
        weight = "";
    }

    public Product (VLRecord vl) {
        productNo = vl.productNo;
        description = vl.description;
        priceUnit = vl.priceUnit;
        price = vl.price;
        quantity = vl.quantity;
        stockProduct = vl.stockProduct;
        weight = "";
    }
     public string productNo {get; set;}

    public string description {get; set;}
    public string priceUnit {get; set;}
    public string price {get; set;}
    public string quantity {get; set;}
    public string stockProduct {get; set;}
    public string weight {get; set;}
}