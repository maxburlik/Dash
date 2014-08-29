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

namespace SMS.Views.Shared
{
    
    public class ListCountValidator : DataAnnotationsModelValidator<ListCountAttribute>
    {
        int _min;
        string _message;

        public ListCountValidator(ModelMetadata metadata, ControllerContext context
          , ListCountAttribute attribute)
            : base(metadata, context, attribute)
        {
            _min = attribute.Min;
            _message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule>
         GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "listcount"
            };
            rule.ValidationParameters.Add("min", _min);

            return new[] { rule };
        }
    }

   
    public class ListCountAttribute : ValidationAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override bool IsValid(object value)
        {
            if (Min == 0 && Max == 0)
                return true;

            if (value == null)
                return false;

            if (!(value is ICollection))
                throw new InvalidOperationException("ListCountAttribute requires underlying property to implement ICollection");

            ICollection countable = value as ICollection;
            if (Min == 0 && Max != 0)
                return countable.Count <= Max;
            else if (Max == 0 && Min != 0)
                return countable.Count >= Min;
            return (countable.Count >= Min) && (countable.Count <= Max);
        }


    }

    public static class InputExtensions
   {
        public static string CheckBoxList(this HtmlHelper htmlHelper, string name, List<CheckBoxListInfo> listInfo)
        {
            return htmlHelper.CheckBoxList(name, listInfo,
                ((IDictionary<string, object>) null));
        }
   
        public static string CheckBoxList(this HtmlHelper htmlHelper, string name, List<CheckBoxListInfo> listInfo,
           object htmlAttributes)
       {
           return htmlHelper.CheckBoxList(name, listInfo, 
               ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes)));
       }
    
       public static string CheckBoxList(this HtmlHelper htmlHelper, string name, List<CheckBoxListInfo> listInfo,
           IDictionary<string, object> htmlAttributes)
       {
           if (String.IsNullOrEmpty(name))
              throw new ArgumentException("The argument must have a value", "name");
           if (listInfo == null)
               throw new ArgumentNullException("listInfo");
          if (listInfo.Count < 1)
               throw new ArgumentException("The list must contain at least one value", "listInfo");
    
           StringBuilder sb = new StringBuilder();

           int counter = 0;
           foreach (CheckBoxListInfo info in listInfo)
           {
               TagBuilder builder = new TagBuilder("input");
               if (info.IsChecked) builder.MergeAttribute("checked", "checked");
               builder.MergeAttributes<string, object>(htmlAttributes);
               builder.MergeAttribute("type", "checkbox");
               builder.MergeAttribute("value", info.Value);
               builder.MergeAttribute("id", name);
               builder.MergeAttribute("name", name + "[" + counter + "]");
               builder.InnerHtml = info.DisplayText;
               sb.Append(builder.ToString(TagRenderMode.Normal));
               sb.Append("<br />");
               counter++;
           }
    
           return sb.ToString();
       }
   }

     // This the information that is needed by each checkbox in the
   // CheckBoxList helper.
   public class CheckBoxListInfo
   {
       public CheckBoxListInfo()
       {


       }
       public CheckBoxListInfo(string value, string displayText, bool isChecked)
       {
           this.Value = value;
           this.DisplayText = displayText;
           this.IsChecked = isChecked;
       }

       public string Value { get; set; }
       public string DisplayText { get; set; }
       public bool IsChecked { get; set; }
   }

   public class CheckboxListInfoModelBinder : DefaultModelBinder
   {
       public override object BindModel(ControllerContext controllerContext,
           ModelBindingContext bindingContext)
       {

           System.Collections.Specialized.NameValueCollection form = controllerContext.HttpContext.Request.Form;
           //get what you need from the form collection

           //creata your model

           List<CheckBoxListInfo> myModel = new List<CheckBoxListInfo>();

           for (int i = 0; i < form.AllKeys.Length; i++)
           {
               if (form.AllKeys[i].Contains("AvailableFunctions[" + (i-1) + "]"))
               {
                   CheckBoxListInfo chk = new CheckBoxListInfo();
                   chk.Value = form[form.AllKeys[i]];
                   myModel.Add(chk);
               }
           }

           ////or add some model errors if you need to
           //ModelStateDictionary mState = bindingContext.ModelState;
           //mState.Add("Property", new ModelState { });
           //mState.AddModelError("Property", "There's an error.");

           return myModel;
       }
   }
}