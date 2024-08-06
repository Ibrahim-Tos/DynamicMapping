using FluentValidation;

namespace DynamicMapping.Core
{
    public class MappingModelBaseValidator<T> : AbstractValidator<T> where T : MappingModelBase
    {
        public MappingModelBaseValidator()
        {
            RuleFor(model => model)
                .NotNull()
                .WithErrorCode("model_is_null")
                .WithMessage("Model must be not null");

            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThan(0)
                .WithErrorCode("id_is_zero")
                .WithMessage("Id must not be zero");

            RuleFor(x => x.Reservation).SetValidator(new ReservationValidator());
        }
    }

    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(model => model)
                .NotNull()
                .WithErrorCode("model_is_null")
                .WithMessage("Model must be not null");

            RuleFor(x => x.RoomNumber)
                .NotNull()
                .GreaterThan(0)
                .WithErrorCode("roomNumber_is_zero")
                .WithMessage("Room number must not be zero");

            RuleFor(x => x.GuestQuantity)
                .NotNull()
                .GreaterThan(0)
                .WithErrorCode("guestQuantity_is_zero")
                .WithMessage("Guest quantity must not be zero");
        }
    }
}
