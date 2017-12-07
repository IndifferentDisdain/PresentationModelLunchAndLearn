using F23.PresentationModelLnL.Domain.ReadModels;

namespace F23.PresentationModelLnL.Web.VendorPortal.Models
{
    public class CaseSheetProductViewModel
    {
        public int ProductId { get; set; }

        public string ProductSku { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public CaseSheetProductViewModel(ProductDetails productDetails)
        {
            ProductId = productDetails.Id;
            ProductSku = productDetails.ProductSku;
            Description = productDetails.Description;
            Quantity = 1;
            UnitPrice = productDetails.VendorPrice;
        }
    }
}
