using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models

// all the columns we create in the table
// prop + Enter to quickly create property (id, name, etc. in the class)
// Id is primary key

{
    public class Category
    {
        // [Key] needs to be added here if you want to change 'Id' to anything. It states that this is the primary key.
        // Also, if we write CategoryId, it is also a primary key -- model name + Id
        
        public int Id { get; set; }

        // We can add [Required] here as data annotation.
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}
