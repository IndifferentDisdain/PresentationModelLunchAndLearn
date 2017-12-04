using System;
using System.Collections.Generic;

namespace F23.PresentationModelLnL.Contracts.DataContracts
{
    public class CaseSheetCreateRequest
    {
        public DateTime CaseDate { get; set; }

        public int Locationid { get; set; }

        public int VendorId { get; set; }

        public IEnumerable<CaseSheetProductCreateRequest> Products { get; set; }
        public string CaseSheetNumber { get; set; }
    }

    public class CaseSheetProductCreateRequest
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
