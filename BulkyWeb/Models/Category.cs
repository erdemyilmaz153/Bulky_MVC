namespace BulkyWeb.Models

// all the columns we create in the table
// prop + Enter to quickly create property (id, name, etc. in the class)
// Id is primary key

{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayOrder { get; set; }
    }
}
