using MarketMAUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Service
{
   public static class ValidationLine
    {
        public static StringBuilder Validation(User contextUser)
        {
            var error = new StringBuilder();
            var valContext = new ValidationContext(contextUser);
            var valresult = new List<ValidationResult>();
            if(!Validator.TryValidateObject(contextUser,valContext,valresult))
            {
                foreach(var item in valresult)
                {
                    error.AppendLine(item.ErrorMessage);
                }
            }
            return error;
        }
    }
}
