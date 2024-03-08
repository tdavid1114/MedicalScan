using System.ComponentModel.DataAnnotations;

namespace MedicalScan
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100000)]
        public double Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}