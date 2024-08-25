using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace part3.Models
{
    public class Computer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        // Navigation property for related components
        public List<Component> Components { get; set; } = new List<Component>();
    }
}
