// Student ID: 00011224
using BookCatalogv2.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalogv2.Models
{
    public class Book
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

/*        [Required(ErrorMessage = "Price is required")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Price cannot be negative Value.")]
        public double Price { get; set; }*/

        [Required(ErrorMessage = "CategoryId is required")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }


    }

}
