using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult != ValueProviderResult.None)
            {
                var value = valueProviderResult.FirstValue;

                if (string.IsNullOrEmpty(value))
                {
                    bindingContext.Result = ModelBindingResult.Success(null);
                    return Task.CompletedTask;
                }

                // Nokta ve virgül ayırıcıyı destekle
                value = value.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                             .Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                if (decimal.TryParse(value, out decimal parsedValue))
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }
                else
                {
                    bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Geçersiz para formatı yanlış.");
                }
            }

            return Task.CompletedTask;
        }
    }
} 