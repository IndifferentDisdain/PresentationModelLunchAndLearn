using F23.PresentationModelLnL.Domain.CaseSheets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F23.PresentationModelLnL.Contracts.Repositories
{
    public interface ICaseSheetRepository
    {
        Task<IEnumerable<CaseSheetDetails>> GetCaseSheetsAsync();
    }
}
