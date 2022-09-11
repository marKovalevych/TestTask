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
        
        public IncidentController(IIncidentService incidentService)
        {
            _incidentService=incidentService;
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

        //[HttpPut("edit/incident/add/account")]
        //public async Task<IActionResult> UpdateIncidentByAddAccount([FromBody]AccountCreateModel model, [FromQuery]string title)
        //{
        //    var result = await _incidentService.UpdateIncident(model, title);
        //    return result is null ?
        //        BadRequest($"{title} does not exist or wrong account name") :
        //        Ok(result);
        //}
    }
}