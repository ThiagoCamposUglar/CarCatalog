using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
