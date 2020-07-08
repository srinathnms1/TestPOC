namespace Fuel.Api.Infrastructure.Models.Binders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Threading.Tasks;
    using Fuel.Contracts;
    using System.Globalization;

    public class FuelInfoModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                bindingContext.ModelState.TryAddModelError(
                    modelName, "Date is required.");
                return Task.CompletedTask;
            }

            if (!DateTime.TryParseExact(value, Constants.DateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime result))
            {
                bindingContext.ModelState.TryAddModelError(
                    modelName, "Date must be of yyyy-MM-dd.");

                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
