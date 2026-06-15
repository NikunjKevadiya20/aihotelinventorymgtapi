using HotelBooking.Entity.Entities;
using FluentValidation;

namespace HotelBooking.Domain.Validations
{
    // Added by AI009 on 25-03-23
    public class FestivalsValidator : AbstractValidator<FestivalEntity>
    {
        public FestivalsValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        }
    }
}
