using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string CatName { get; set; }
        public bool? Deleted { get; set; }
    }
}
