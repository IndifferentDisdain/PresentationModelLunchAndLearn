using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.Exceptions;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Domain.CaseSheets;

namespace F23.PresentationModelLnL.Presentation.CaseSheets
{
    public class CaseSheetPresentationFactory : ICaseSheetPresentationFactory
    {
        private readonly ICaseSheetRepository _caseSheetRepository;

        public CaseSheetPresentationFactory(ICaseSheetRepository caseSheetRepository)
        {
            _caseSheetRepository = caseSheetRepository;
        }

        public async Task<CaseSheetDetailsPresentationModel> GetCaseSheetDetailsAsync(int caseSheetId, bool isUserAdmin)
        {
            var model = await _caseSheetRepository.GetCaseSheetDetailsAsync(caseSheetId);
            if (model == null)
            {
                throw new EntityNotFoundException(typeof(CaseSheetDetails), caseSheetId);
            }

            return new CaseSheetDetailsPresentationModel
            {
                CaseSheetDetails = model,
                CaseSheetProducts = await _caseSheetRepository.GetCaseSheetProductsAsync(caseSheetId),
                CanDelete = isUserAdmin,
                CanEdit = isUserAdmin
            };
        }
    }
}
