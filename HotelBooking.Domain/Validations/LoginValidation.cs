using FluentValidation;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Validations
{
    public class LoginValidation : AbstractValidator<LoginRequestEntity>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        }

    }
    public class LoginInValidation : AbstractValidator<LoginRequestEntity>
    {
        public LoginInValidation()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }

    }
}
