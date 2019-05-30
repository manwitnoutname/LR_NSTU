using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISWebApp.Models;

namespace Lr1WebApi.Models
{
    public class PersonModel
    {
        public Guid Id {get;set;} =Guid.Empty;
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Sex { get; set; }
        public string Relationships { get; set; }

    public BaseModelValidationResult Validate()
    {

        var validationResult = new BaseModelValidationResult();

        if (string.IsNullOrWhiteSpace(Name))
        {
            validationResult.Append($"Name cannot be empty");
        }
        else
        {
        if (!char.IsUpper(Name.FirstOrDefault()))
        {
            validationResult.Append($"Name {Name} should start from capital letter");
        }
        }
        if (string.IsNullOrWhiteSpace(SurName))
        {
            validationResult.Append($"SurName cannot be empty");
        }
        else
        {
                if (!char.IsUpper(SurName.FirstOrDefault()))
            {
                validationResult.Append($"SurName {SurName} should start from capital letter");
            }
        }

        if ((string.IsNullOrWhiteSpace(Sex)))
        {
            validationResult.Append($"Sex cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(Relationships))
        {
            validationResult.Append($"Relationships cannot be empty");
        }

        return validationResult;

    }

    public override string ToString()

    {
        return $"{Name} {SurName} Sex {Sex} Relationships {Relationships}";
    }

    }
}