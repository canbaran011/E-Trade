using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicTrade.BusinessLayer.Utilities
{
    public static class ValidationTool
    {
        public static ValidationResult Validate(IValidator validator,object entity)
        {
            var result = validator.Validate(entity);

            return result;
        }
    }
}
