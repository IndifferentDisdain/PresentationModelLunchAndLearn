using F23.PresentationModelLnL.Domain;
using F23.PresentationModelLnL.Domain.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F23.PresentationModelLnL.Contracts.Repositories
{
    public interface ICaseSheetRepository
    {
        Task<IEnumerable<CaseSheetDetails>> GetCaseSheetsAsync(int? vendorId = null);
        Task<CaseSheetDetails> GetCaseSheetDetailsAsync(int caseSheetId);
        Task<IList<CaseSheetProduct>> GetCaseSheetProductsAsync(int caseSheetId);
        Task AddCaseSheetAsync(CaseSheet caseSheet);
        Task AddCaseSheetProductsAsync(IEnumerable<CaseSheetProduct> products);
        Task UpdateCaseSheetAsync(CaseSheet caseSheet);
        Task<CaseSheet> GetCaseSheetAsync(int caseSheetId);
    }
}
