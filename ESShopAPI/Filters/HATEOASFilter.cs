using ESShopAPI.Models.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ESShopAPI.Filters
{
    public class HATEOASFilter : Attribute, IActionFilter
    {
        private readonly Type _linkProfileType;

        public HATEOASFilter(Type linkProfileType)
        {
            _linkProfileType = linkProfileType;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var linkProfile = Activator.CreateInstance(_linkProfileType) as ILinkProfile;

            if (context.Result is ObjectResult contextResult && (!contextResult.StatusCode.HasValue || contextResult.StatusCode == 200))
            {
                context.Result = new JsonResult(new HATEOASWrapper()
                {
                    Result = contextResult.Value,
                    Links = linkProfile.Links
                });
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
