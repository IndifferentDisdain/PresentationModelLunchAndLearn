using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Web.VendorPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace F23.PresentationModelLnL.Web.VendorPortal.Controllers
{
    /// <summary>
    /// This is the products controller for a vendor. Consumers can only
    /// see products for their vendor.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        // This would generally be handled by user auth, but skipping that for now.
        private const int _vendorId = 1;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CaseSheetProductViewModel>> GetAll(string searchTerm)
        {
            var products = await _productRepository.GetProductsAsync(_vendorId, searchTerm);
            // I don't want vendors to see our selling price, so controlling access here at the server level.
            return products.Select(x => new CaseSheetProductViewModel(x));
        }
    }
}