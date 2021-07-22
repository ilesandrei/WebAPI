using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Entities
{
    public class Manufacturer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        public bool? Deleted { get; set; }
    }
}
