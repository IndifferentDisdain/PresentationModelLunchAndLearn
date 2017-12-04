using System.Threading.Tasks;

namespace F23.PresentationModelLnL.Presentation.CaseSheets
{
    /// <summary>
    /// Abstracting away comples object creation. Plus, this will control setting permissions on what I can
    /// and can't do.
    /// </summary>
    public interface ICaseSheetPresentationFactory
    {
        Task<CaseSheetDetailsPresentationModel> GetCaseSheetDetailsAsync(int caseSheetId, bool isUserAdmin, bool canProcess, int? vendorId = null);
    }
}
