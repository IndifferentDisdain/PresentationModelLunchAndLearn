using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace F23.PresentationModelLnL.Domain.ReadModels
{
    /// <summary>
    /// This is a flattened view of a case sheet. So long include upon include upon include...
    /// Also, no EF here. Read Model.
    /// </summary>
    public class CaseSheetDetails
    {
        public int Id { get; set; }

        [DisplayName("Case Sheet Number")]
        public string CaseSheetNumber { get; set; }

        public int LocationId { get; set; }

        [DisplayName("Location")]
        public string LocationName { get; set; }

        [DisplayName("Case Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CaseDate { get; set; }

        [DisplayName("Total Cost")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalCost { get; set; }

        [DisplayName("Total Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPrice { get; set; }

        [DisplayName("Processed?")]
        public bool IsProcessed { get; set; }

        public int VendorId { get; set; }

        [DisplayName("Vendor")]
        public string VendorName { get; set; }
    }
}
