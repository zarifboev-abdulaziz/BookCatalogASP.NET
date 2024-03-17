using System.ComponentModel.DataAnnotations;

namespace BookCatalogv2.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public Category() { }

    }
}
