using System.Collections.Generic;
using F23.PresentationModelLnL.Domain.CaseSheets;

namespace F23.PresentationModelLnL.Presentation.CaseSheets
{
    /// <summary>
    /// Just a wrapper around our read models + action permissions.
    /// </summary>
    public class CaseSheetDetailsPresentationModel
    {
        public CaseSheetDetails CaseSheetDetails { get; set; }

        public IList<CaseSheetProduct> CaseSheetProducts { get; set; }

        public bool CanDelete { get; set; }

        public bool CanEdit { get; set; }
        public bool CanProcess { get; set; }
    }
}
