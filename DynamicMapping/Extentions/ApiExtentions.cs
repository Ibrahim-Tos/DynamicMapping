using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DynamicMapping.Extentions
{
    public static class ApiExtentions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
