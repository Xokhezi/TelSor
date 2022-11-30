using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserRoleValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var manager = (ManagersMasterData)validationContext.ObjectInstance;

            if (manager.Role == "Admin" || manager.Role == "Manager" || manager.Role == "Accounting" || manager.Role == "Asistent" || manager.Role == "Nový uživatel")
                return ValidationResult.Success;
            else
                return new ValidationResult("Je nutno přiřadit existjící roli");
        }
    }
}