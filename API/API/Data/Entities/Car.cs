using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int MaxPower { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }
        public string Description { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
