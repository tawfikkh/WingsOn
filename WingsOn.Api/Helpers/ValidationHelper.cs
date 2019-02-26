using System.Linq;
using System.Web.Http.ModelBinding;
using WingsOn.Api.DTOs;

namespace WingsOn.Api.Helpers
{
    public class ValidationHelper
    {
        internal static ApiError GenerateApiError(ModelStateDictionary modelState)
        {
            return new ApiError()
            {
                Code = "InvalidModelState",
                Message = "Request failed validation",
                Details =  modelState.SelectMany(m =>
                {
                    ModelState error = modelState[m.Key];
                    return error.Errors.Select(m1 => new ApiError()
                    {
                        Message = m1.ErrorMessage,
                        Code = m1.Exception?.GetType().Name,
                        Target = m.Key
                    });
                })
            };
        }
    }
}