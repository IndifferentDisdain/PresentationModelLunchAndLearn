using System;
using System.Linq;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.DataContracts;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Contracts.Services;
using F23.PresentationModelLnL.Domain.CaseSheets;

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
                VendorId = request.VendorId
            };

            // TODO.JS: Unit of work/transaction? Need ID before we can save the case sheet number, chicken or egg?
            _caseSheetRepository.AddCaseSheet(caseSheet);

            await _caseSheetRepository.SaveAsync();

            caseSheet.GenerateCaseSheetNumber();

            _caseSheetRepository.UpdateCaseSheet(caseSheet);

            await _caseSheetRepository.SaveAsync();

            var products = await _productRepository.GetProductDetailsAsync(request.Products.Select(x => x.ProductId).ToArray(), request.VendorId);

            // case sheet items
            // notifications
            throw new NotImplementedException();
        }
    }
}
