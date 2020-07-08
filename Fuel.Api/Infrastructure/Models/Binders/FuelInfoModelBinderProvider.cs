namespace Fuel.Api.Infrastructure.Models.Binders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    using System;

    public class FuelInfoModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(FuelInfoServiceRequest))
            {
                return new BinderTypeModelBinder(typeof(FuelInfoModelBinder));
            }

            return null;
        }
    }
}
