using System;
using System.Collections.Generic;
using System.Linq;
using F23.PresentationModelLnL.Contracts.DataContracts;

namespace F23.PresentationModelLnL.Web.VendorPortal.Models
{
    public class CaseSheetPostModel
    {
        public int LocationId { get; set; }

        public DateTime CaseDate { get; set; }

        public IEnumerable<CaseSheetItemPostModel> Products { get; set; }

        public CaseSheetCreateRequest ToCaseSheetCreateRequest(int vendorId)
        {
            return new CaseSheetCreateRequest
            {
                CaseDate = CaseDate,
                Locationid = LocationId,
                VendorId = vendorId,
                Products = Products.Select(x => x.ToCaseSheetProductCreateRequest())
            };
        }
    }

    public class CaseSheetItemPostModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public CaseSheetProductCreateRequest ToCaseSheetProductCreateRequest()
        {
            return new CaseSheetProductCreateRequest
            {
                ProductId = ProductId,
                Quantity = Quantity
            };
        }
    }
}
