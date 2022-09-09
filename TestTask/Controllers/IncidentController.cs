using BL.Services;
using BL.ValidationModels;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        private readonly IAccountService _accountService;
        private readonly IContactService _contactService;

        public IncidentController(IIncidentService incidentService, IAccountService accountService, IContactService contactService)
        {
            _incidentService=incidentService;
            _accountService=accountService;
            _contactService=contactService;
        }

        [HttpGet("incidents")]
        public async Task<IActionResult> GetIncidents()
        {
            var result = await _incidentService.GetAllIncidents();

            return Ok(result);
        }

        [HttpPost("incident/create")]
        public async Task<IActionResult> AddIncidents([FromBody]IncidentModel model)
        {
            var incident = await _incidentService.CreateIncident(model);

            return Ok(incident);
        }
    }
}