using MarketWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketWPF.Service
{
    public static class ValidationLine
    {
        public static StringBuilder ValidationProduct(Product product)
        {
            var error = new StringBuilder();
            var validationContext = new ValidationContext(product);
            var validationResult = new List<ValidationResult>();
            if(!Validator.TryValidateObject(product, validationContext,validationResult)) 
            {
                foreach( var item in validationResult )
                {
                    error.AppendLine(item.ErrorMessage);
                }
            }
            return error;
        }
    }
}
