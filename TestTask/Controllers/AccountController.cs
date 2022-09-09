using BL.Services;
using BL.ValidationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        private readonly IAccountService _accountService;
        private readonly IContactService _contactService;

        public AccountController(IIncidentService incidentService, IAccountService accountService, IContactService contactService)
        {
            _incidentService=incidentService;
            _accountService=accountService;
            _contactService=contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var result = await _accountService.GetAllAccounts();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromBody]AccountUpdateModel model)
        {
            var result = await _accountService.UpdateAccount(model);

            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
