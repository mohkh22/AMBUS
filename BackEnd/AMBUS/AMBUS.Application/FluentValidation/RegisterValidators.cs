using AMBUS.Application.CQRS.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Application.FluentValidation
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FName).NotEmpty().WithMessage("الاسم الأول مطلوب");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("الإيميل غير صحيح");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("كلمة السر ضعيفة");
            RuleFor(x => x.Address).NotEmpty().WithMessage("العنوان مطلوب لمشروع الباصات");
        }
    }
}
