using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace F23.PresentationModelLnL.Domain.CaseSheets
{
    public class CaseSheetProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CaseSheetId { get; set; }

        [Required]
        [MaxLength(20)]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(500)]
        [DisplayName("SKU")]
        public string ProductSku { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Vendor Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal VendorPrice { get; set; }

        [Required]
        [DisplayName("Selling Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal SellingPrice { get; set; }

        [DisplayName("Total Vendor Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalVendorPrice => VendorPrice * Quantity;

        [DisplayName("Total Selling Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalSellingPrice => SellingPrice * Quantity;
    }
}
