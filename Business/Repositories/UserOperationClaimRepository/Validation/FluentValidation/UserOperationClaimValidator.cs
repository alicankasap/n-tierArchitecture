using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserOperationClaimRepository.Validation.FluentValidation
{
    public class UserOperationClaimValidator : AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            RuleFor(x => x.UserId).Must(IsIdValid).GreaterThan(0).WithMessage("Yetki ataması için kullanıcı seçimi yapmalısınız");
            //RuleFor(x => x.UserId).NotEmpty().GreaterThan(0).WithMessage("Yetki ataması için kullanıcı seçimi yapmalısınız");

            RuleFor(x => x.OperationClaimId).Must(IsIdValid).WithMessage("Yetki ataması için yetki seçimi yapmalısınız");
            //RuleFor(x => x.OperationClaimId).NotEmpty().GreaterThan(0).WithMessage("Yetki ataması için yetki seçimi yapmalısınız");
        }

        private bool IsIdValid(int id)
        {
            if (id > 0 && id != null)
            {
                return true;
            }
            return false;
        }
    }
}
