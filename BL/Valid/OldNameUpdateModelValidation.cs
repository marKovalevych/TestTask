using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services;
using BL.ValidationModels;
using FluentValidation;

namespace BL.Valid
{
    public class OldNameUpdateModelValidation:AbstractValidator<AccountUpdateModel>
    {
        private readonly IAccountService _accountService;
        public OldNameUpdateModelValidation(IAccountService accountService)
        {
            _accountService = accountService;

            RuleFor(x => x.OldName).MustAsync(async (x, _) =>
            {
                bool result = await _accountService.CheckAccountExistingAsync(x);
                return result;
            }).WithMessage("NotFound").WithErrorCode("404");
        }
    }
}
