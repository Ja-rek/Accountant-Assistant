using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TravelAccountant.Application.Summaries;

namespace TravelAccountant.Web.Summaries
{
    [Route("api/")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly SummaryApplicationService service;

        public SummaryController(SummaryApplicationService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IEnumerable<string> PathsToIncorrectTemplates([Required] IEnumerable<string> paths)
        {
            return this.service.FindPathsToIncorrectTemplates(paths);
        }

        [HttpPost]
        public void SummarySheet(SummarySheetRequest request)
        {
            this.service.FillSummarySheet(request.confirmationPaths, request.SummaryPath);
        }
    }
}
