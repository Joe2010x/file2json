namespace cwproj.Models;

public class Rule
{
    // types are "Must by", "Property"
    public Rule (int cellPosition, string type, string input)
    {
        this.cellPosition = cellPosition;
        this.type = type;
        this.value = type == "Must be" ? input : "";
        this.property = type == "Property" ? input : "";
    }
    public int cellPosition {get;set;}

    public string type {get; set;} 

    public string value {get; set;}

    public string property {get; set;}

    public bool isValid (string input) 
    {
        switch (type)
        { 
            case "Property" : 
                return true;

            case "Must be" :
                return input == value;

            default: return false;
        }
    }

}