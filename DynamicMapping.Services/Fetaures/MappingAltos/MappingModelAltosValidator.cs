using DynamicMapping.Core;
using FluentValidation;

namespace DynamicMapping.Services.Fetaures.MappingAltos
{
    public class MappingModelAltosValidator : MappingModelBaseValidator<MappingModelAltos>
    {
        public MappingModelAltosValidator()
        {
            this.RuleFor(model => model)
                .NotNull()
                .WithErrorCode("model_is_null")
                .WithMessage("Model must be not null");

            RuleFor(x => x.PropertyAltos)
                .NotEmpty()
                .NotNull()
                .WithErrorCode("PropertyAltos_is_empty")
                .WithMessage("PropertyAltos must not be empt");
        }
    }
}
