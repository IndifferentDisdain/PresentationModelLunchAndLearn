using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace F23.PresentationModelLnL.Domain.CaseSheets
{
    public class CaseSheetDetails
    {
        public int Id { get; set; }

        [DisplayName("Case Sheet Number")]
        public string CaseSheetNumber { get; set; }

        public int LocationId { get; set; }

        [DisplayName("Location")]
        public string LocationName { get; set; }

        [DisplayName("Case Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CaseDate { get; set; }

        [DisplayName("Total Cost")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalCost { get; set; }

        [DisplayName("Processed?")]
        public bool IsProcessed { get; set; }
    }
}
