using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace F23.PresentationModelLnL.Presentation.CaseSheets
{
    public interface ICaseSheetPresentationFactory
    {
        Task<CaseSheetDetailsPresentationModel> GetCaseSheetDetailsAsync(int caseSheetId, bool isUserAdmin, bool canProcess, int? vendorId = null);
    }
}
