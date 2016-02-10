using System.ComponentModel.DataAnnotations;

namespace MSPAccounting.Models
{
    public class State
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abbreviation { get; set; }
    }
}
