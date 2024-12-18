using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Car> Cars { get; set; }
    }
}
