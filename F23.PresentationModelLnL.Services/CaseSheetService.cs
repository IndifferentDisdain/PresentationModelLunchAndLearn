using System;
using System.Linq;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.DataContracts;
using F23.PresentationModelLnL.Contracts.Exceptions;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Contracts.Services;
using F23.PresentationModelLnL.Domain;

namespace F23.PresentationModelLnL.Services
{
    public class CaseSheetService : ICaseSheetService
    {
        private readonly ICaseSheetRepository _caseSheetRepository;
        private readonly IProductRepository _productRepository;

        public CaseSheetService(ICaseSheetRepository caseSheetRepository, IProductRepository productRepository)
        {
            _caseSheetRepository = caseSheetRepository;
            _productRepository = productRepository;
        }
        public async Task<int> CreateCaseSheetAsync(CaseSheetCreateRequest request)
        {
            // case sheet
            var caseSheet = new CaseSheet
            {
                CaseDate = request.CaseDate,
                IsProcessed = false,
                LocationId = request.Locationid,
                VendorId = request.VendorId,
                CaseSheetNumber = request.CaseSheetNumber
            };

            // TODO.JS: Unit of work/transaction? Need ID before we can save the case sheet number, chicken or egg?
            await _caseSheetRepository.AddCaseSheetAsync(caseSheet);

            caseSheet.GenerateCaseSheetNumber();

            await _caseSheetRepository.UpdateCaseSheetAsync(caseSheet);

            var products = await _productRepository.GetProductDetailsAsync(request.Products.Select(x => x.ProductId).ToArray(), request.VendorId);

            await _caseSheetRepository.AddCaseSheetProductsAsync((from item in request.Products
                                                                  let match = products.Single(x => x.Id == item.ProductId)
                                                                  select new CaseSheetProduct
                                                                  {
                                                                      CaseSheetId = caseSheet.Id,
                                                                      ProductId = item.ProductId,
                                                                      Quantity = item.Quantity,
                                                                      ProductDescription = match.Description,
                                                                      ProductSku = match.ProductSku,
                                                                      SellingPrice = match.SellingPrice,
                                                                      VendorPrice = match.VendorPrice
                                                                  }).ToList());

            // TODO: notifications

            return caseSheet.Id;

        }

        public async Task ProcessAsync(int caseSheetId)
        {
            var caseSheet = await _caseSheetRepository.GetCaseSheetAsync(caseSheetId);
            if (caseSheet == null)
                throw new EntityNotFoundException(typeof(CaseSheet), caseSheetId);

            if (caseSheet.IsProcessed)
                throw new InvalidOperationException($"Case sheet {caseSheetId} has already been processed; aborting.");

            caseSheet.IsProcessed = true;
            await _caseSheetRepository.UpdateCaseSheetAsync(caseSheet);
        }
    }
}
