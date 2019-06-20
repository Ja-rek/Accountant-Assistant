using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAccountant.Web.Summaries
{
    public class SummarySheetRequest
    {
        [Required]
        public IEnumerable<string> confirmationPaths  { get; set; }

        [Required]
        public string SummaryPath { get; set; }
    }
}
