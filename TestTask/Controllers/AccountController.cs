using BL.Services;
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
            var result = await _accountService.UpdateAccount(model);

            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
