using BL.Services;
using BL.ValidationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [Route("api")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        private readonly IAccountService _accountService;
        private readonly IContactService _contactService;

        public ContactController(IIncidentService incidentService, IAccountService accountService, IContactService contactService)
        {
            _incidentService=incidentService;
            _accountService=accountService;
            _contactService=contactService;
        }

        [HttpGet]
        public  IActionResult GetContacts()
        {
            var result = _contactService.GetContacts();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody]ContactModel model)
        {
            var result = await _contactService.UpdateContact(model);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
