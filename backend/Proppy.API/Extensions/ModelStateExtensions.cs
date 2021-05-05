using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Proppy.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(modelStateEntry => modelStateEntry.Value.Errors)
                .Select(errors => errors.ErrorMessage)
                .ToList();
        }
    }
}