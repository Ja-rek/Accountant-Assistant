using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelAccountant.Application.Summaries;

namespace TravelAccountant.Web.Summaries
{
    [Route("api/summary/{action}")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly SummaryApplicationService service;

        public SummaryController(SummaryApplicationService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ActionName("incorrect-template")]
        public ActionResult<string[]> IncorrectTemplates([Required, MinLength(1)] string[] paths)
        {
            var incorrectTemplatePaths = this.service.FindPathsToIncorrectTemplates(paths);

            if (!incorrectTemplatePaths.Any()) return StatusCode(204);

            return incorrectTemplatePaths.ToArray();
        }

        [HttpPost]
        [ActionName("sheet")]
        public ActionResult SummarySheet(SummarySheetRequest request)
        {
            var success = this.service.FillSummarySheet(request.ConfirmationPaths, request.SummaryPath);

            if (success) return StatusCode(200);

            return StatusCode(204);
        }
    }
}
