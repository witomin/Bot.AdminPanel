using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Bot.AdminPanel.Extensions {
    public class ValidateAjaxAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                return;

            var modelState = filterContext.ModelState;
            if (!modelState.IsValid) {
                var errorModel =
                        from x in modelState.Keys
                        where modelState[x].Errors.Count > 0
                        select new {
                            key = x,
                            errors = modelState[x].Errors.
                                                          Select(y => y.ErrorMessage).
                                                          ToArray()
                        };
                filterContext.Result = new JsonResult(errorModel);
                filterContext.HttpContext.Response.StatusCode =
                                                      (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
