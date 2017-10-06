using F23.PresentationModelLnL.Domain.CaseSheets;

namespace F23.PresentationModelLnL.Presentation.CaseSheets
{
    public class CaseSheetDetailsPresentationModel
    {
        public CaseSheetDetails CaseSheetDetails { get; set; }

        public bool CanDelete { get; set; }

        public bool CanEdit { get; set; }
    }
}
