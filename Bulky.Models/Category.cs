using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models

// all the columns we create in the table
// prop + Enter to quickly create property (id, name, etc. in the class)
// Id is primary key

{
    public class Category
    {
        // [Key] needs to be added here if you want to change 'Id' to anything. It states that this is the primary key.
        // Also, if we write CategoryId, it is also a primary key -- model name + Id
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "The field Display Order must be between 1-100.")]
        public int DisplayOrder { get; set; }
    }
}
