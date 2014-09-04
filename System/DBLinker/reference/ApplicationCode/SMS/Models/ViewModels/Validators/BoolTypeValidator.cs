using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Specialized;

namespace SMS.Models.ViewModels.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BoolTypeAttribute : RequiredAttribute
    {
        public bool Flag { get; set; }

        public BoolTypeAttribute(bool FlagValue)
        {
            Flag = FlagValue;
        }
        public override bool IsValid(object value)
        {
            bool status = false;

            if (value == null)
                return status;

            if (Flag == bool.Parse(value.ToString()))
                status = true;

            return status;
        }
    }
    public class BoolTypeValidator : DataAnnotationsModelValidator<BoolTypeAttribute>
    {
        private readonly bool _flag;
        private readonly string _message;

        public BoolTypeValidator(ModelMetadata metadata, ControllerContext context, BoolTypeAttribute attribute)
            : base(metadata, context, attribute)
        {
            _flag = attribute.Flag;
            _message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = this.Metadata.PropertyName
            };

            rule.ValidationParameters.Add("reqparam", _flag);

            return new[] { rule };
        }
    }
}