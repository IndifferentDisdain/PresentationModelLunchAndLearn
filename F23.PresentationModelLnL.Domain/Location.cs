using System.ComponentModel.DataAnnotations;

namespace F23.PresentationModelLnL.Domain
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
