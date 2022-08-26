
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
namespace EventReg.API.Wrappers

{
    public class InvalidModelBadRequest

    {
        public List<string> errors{get;}
        public bool succeeded{get;}

        public InvalidModelBadRequest(ModelStateDictionary modelState)

        {
            List<string> modelErrors = modelState.SelectMany(x => x.Value.Errors)
                 .Select(x => x.ErrorMessage).ToList();
           errors=modelErrors;
           succeeded=false;

        
        }
        
    }
}