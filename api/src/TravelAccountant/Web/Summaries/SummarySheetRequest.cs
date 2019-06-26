using System.ComponentModel.DataAnnotations;

namespace TravelAccountant.Web.Summaries
{
    public class SummarySheetRequest
    {
        [Required, MinLength(1)]
        public string[] ConfirmationPaths  { get; set; }

        [Required]
        public string SummaryPath { get; set; }
    }
}
