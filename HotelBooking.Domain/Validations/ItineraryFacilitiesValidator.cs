using HotelBooking.Entity.Entities;
using FluentValidation;

namespace HotelBooking.Domain.Validations
{
    // Added by AI009 on 07-04-23
    public class ItineraryFacilitiesValidator : AbstractValidator<ItineraryFacilitiesEntity>
    {
        public ItineraryFacilitiesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
