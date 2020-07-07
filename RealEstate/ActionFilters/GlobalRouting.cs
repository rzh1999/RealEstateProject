using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RealEstate.ActionFilters
{
    public class GlobalRouting
    {
     
            private readonly ClaimsPrincipal _claimsPrincipal;
            public GlobalRouting(ClaimsPrincipal claimsPrincipal)
            {
                _claimsPrincipal = claimsPrincipal;
            }
            public void OnActionExecuting(ActionExecutingContext context)
            {
                var controller = context.RouteData.Values["controller"];
                if (controller.Equals("Home"))
                {
                    if (_claimsPrincipal.IsInRole("Client"))
                    {
                        context.Result = new RedirectToActionResult("Index",
                        "Clients", null);
                    }
                    else if (_claimsPrincipal.IsInRole("Realtor"))
                    {
                        context.Result = new RedirectToActionResult("Index",
                        "Realtors", null);
                    }
                else if (_claimsPrincipal.IsInRole("LoanOfficer"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "LoanOfficers", null);
                }
                else if (_claimsPrincipal.IsInRole("Closing"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "Closings", null);
                }
            }
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
        }
    }

