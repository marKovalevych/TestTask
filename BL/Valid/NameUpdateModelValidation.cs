using BL.Services;
using BL.ValidationModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Valid
{
    public class NameUpdateModelValidation : AbstractValidator<AccountUpdateModel>
    {
        private readonly IAccountService _accountService;
        public NameUpdateModelValidation(IAccountService accountService)
        {
            _accountService = accountService;
            RuleFor(x => x.Name).MustAsync(async (x, _) =>
            {
                bool result = await _accountService.CheckAccountExistingAsync(x);
                return result;
            }).WithMessage($"Name is not available").WithErrorCode("400");
        }
    }
}
