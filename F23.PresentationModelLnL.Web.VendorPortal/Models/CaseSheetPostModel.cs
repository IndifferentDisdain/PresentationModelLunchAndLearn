using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using F23.PresentationModelLnL.Contracts.DataContracts;

namespace F23.PresentationModelLnL.Web.VendorPortal.Models
{
    public class CaseSheetPostModel
    {
        [Required]
        public int? LocationId { get; set; }

        [Required]
        public DateTime? CaseDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string CaseSheetNumber { get; set; }

        public IEnumerable<CaseSheetItemPostModel> Products { get; set; }

        public CaseSheetCreateRequest ToCaseSheetCreateRequest(int vendorId)
        {
            return new CaseSheetCreateRequest
            {
                CaseDate = CaseDate.GetValueOrDefault(),
                Locationid = LocationId.GetValueOrDefault(),
                CaseSheetNumber = CaseSheetNumber,
                VendorId = vendorId,
                Products = Products.Select(x => x.ToCaseSheetProductCreateRequest())
            };
        }
    }

    public class CaseSheetItemPostModel
    {
        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public CaseSheetProductCreateRequest ToCaseSheetProductCreateRequest()
        {
            return new CaseSheetProductCreateRequest
            {
                ProductId = ProductId.GetValueOrDefault(),
                Quantity = Quantity.GetValueOrDefault()
            };
        }
    }
}
