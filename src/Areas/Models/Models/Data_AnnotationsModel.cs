using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Models
{
    public class TimeCard : IValidatableObject
    {
        public TimeCard()
        {
        }

        public Guid Id
        {
            get;
            set;
        }

        [Required]
        [StringLength(25)]
        [Remote("CheckUsername", "Data_Annotations", "Models")]
        public string Username
        {
            get;
            set;
        }

        [Required]
        [Range(1, 120)]
        public int? Hours
        {
            get;
            set;
        }

        [Required]
        [Range(1, 120)]
        [System.ComponentModel.DataAnnotations.Compare("Hours")]
        public int? ConfirmHours
        {
            get;
            set;
        }

        [Required]
        public DateTime? StartDate
        {
            get;
            set;
        }

        [GreaterThanDate("StartDate")]
        [Required]
        public DateTime? EndDate
        {
            get;
            set;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate <= StartDate)
            {
                yield return new ValidationResult("EndDate must be greater than StartDate", new string[]{"EndDate"});
            }

            if (Username != "TestUser")
            {
                yield return new ValidationResult("Username must be TestUser", new string[] { "Username" });
            }
        }
    }

    public class GreaterThanDateAttribute : ValidationAttribute, IClientValidatable
    {
        public GreaterThanDateAttribute(string otherPropertyName)
            : base("{0} must be greater than {1}")
        {
            this.OtherPropertyName = otherPropertyName;
        }

        public string OtherPropertyName
        {
            get;
            set;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(this.ErrorMessageString, name, this.OtherPropertyName);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.OtherPropertyName);
            var otherDateObj = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (otherDateObj == null || value == null)
            {
                return null;
            }

            var otherDate = (DateTime)otherDateObj;
            var thisDate = (DateTime)value;

            if (thisDate <= otherDate)
            {
                var message = this.FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(message);
            }

            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationType = "vtype[greater]";

            // instead vtype you can use Validator
            // rule.ValidationType = "validator[greater]";
            // in this case 'greater' must be defined js function

            rule.ValidationParameters.Add("other", this.OtherPropertyName);
            yield return rule;
        }
    }

}