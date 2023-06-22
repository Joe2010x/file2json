using cwproj.Models;

namespace cwproject.Models; 
 
 public class RuleLine {

        public RuleLine (string name ,List<Rule> rules)
        {
            this.rules = rules;
            this.name = name;
        }
        public string name {get; set;}
        public List<Rule> rules {get; set;}

        public bool isValid (List<string> line) 
        {
            for ( var i=0; i<rules.Count(); i++)
            {   
                var cellPosition = rules[i].cellPosition;
                var index = cellPosition - 1;
                var type = rules[i].type;
                var value = rules[i].value;
                if (!rules[i].isValid(line[index])) return false;
            }

            return true;
        }
        
        public T produce <T>(List<string> lines) where T : new ()
        {
            var result = new T();
            for ( var i=0; i<rules.Count(); i++)
            {   
                var cellPosition = rules[i].cellPosition;
                var index = cellPosition - 1;
                var type = rules[i].type;
                var property = rules[i].property;

                if (type == "Property" && result!=null) 
                    {
                        var propInfo = result.GetType().GetProperty(property); 
                        if (propInfo != null)  
                            propInfo.SetValue (result, lines[index]);
                    }
            }
            
            return result;
        }
        
    }