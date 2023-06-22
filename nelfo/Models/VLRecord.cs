namespace cwproj.Models;

public class VLRecord 
{
    public VLRecord ()
    {
        productNo = "";
        description = "";
        priceUnit = "";
        price = "";
        quantity = "";
        stockProduct = "";
    }
    public string productNo {get; set;}

    public string description {get; set;}
    public string priceUnit {get; set;}
    public string price {get; set;}
    public string quantity {get; set;}
    public string stockProduct {get; set;}
}