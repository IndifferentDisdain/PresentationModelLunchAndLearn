using System;
using System.ComponentModel.DataAnnotations;

namespace F23.PresentationModelLnL.Domain.CaseSheets
{
    /// <summary>
    /// Our POCO, but notice no EF dependencies...
    /// </summary>
    public class CaseSheet
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string CaseSheetNumber { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public DateTime CaseDate { get; set; }

        public bool IsProcessed { get; set; }

        public void GenerateCaseSheetNumber()
        {
            CaseSheetNumber = $"CS-{Id}";
        }
    }
}
