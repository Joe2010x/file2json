namespace cwproj.Models;

public class Seller {
    public Seller () 
    {
        orgName = "";
        orgNo = "";
    }

    public Seller (VHRecord vh) {
        orgNo = vh.orgNo;
        orgName = vh.orgName;
    }

    public string orgNo {get; set;} = "";

    public string orgName {get; set;} = "";

}