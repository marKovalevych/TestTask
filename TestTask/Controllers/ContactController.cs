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
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService=contactService;
        }

        [HttpGet("contacts")]
        public  IActionResult GetContacts()
        {
            var result = _contactService.GetContacts();
            return Ok(result);
        }

        [HttpPut("edit/contact")]
        public async Task<IActionResult> UpdateContact([FromBody]ContactModel model)
        {
            var result = await _contactService.UpdateContact(model);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
