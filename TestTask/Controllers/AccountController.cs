using BL.Services;
using BL.Valid;
using BL.ValidationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;


        public AccountController(IAccountService accountService)
        {
            _accountService=accountService;
        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var result = await _accountService.GetAllAccounts();
            return Ok(result);
        }

        [HttpPut("edit/account")]
        public async Task<IActionResult> UpdateAccount([FromBody]AccountUpdateModel model)
        {
            var oldNameValidator = new OldNameUpdateModelValidation(_accountService);
            var olNameValidResult = await oldNameValidator.ValidateAsync(model);
            if (!olNameValidResult.IsValid)
            {
                return NotFound(olNameValidResult.Errors);
            }
            var nameValidator = new NameUpdateModelValidation(_accountService);
            var nameValidResult = await nameValidator.ValidateAsync(model);
            if (nameValidResult.IsValid)
            {
                return BadRequest(nameValidResult.Errors);
            }

            var result = await _accountService.UpdateAccount(model);

            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("edit/account/add/contact")]
        public async Task<IActionResult> AddContactToAccount([FromBody]ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _accountService.AddContactToAccount(model);

            return result is null ? NotFound() : Ok(result);
        }
    }
}
