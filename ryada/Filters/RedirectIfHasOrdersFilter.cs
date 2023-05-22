using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ryada.Filters
{
    public class RedirectIfHasOrdersFilter : IActionFilter
    {
        private readonly AppDBContext _context;
        
        public RedirectIfHasOrdersFilter(AppDBContext context)
        {
            _context = context;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            var claims = context.HttpContext.User.Claims.ToList();
            if (!claims.Any()) { return; }
            var userId = context.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                var hasOrders = _context.orders.Any(o => o.InsertById == userId);

                if (hasOrders)
                {
                    context.Result = new RedirectToActionResult("Index", "Orders", null);
                    return;
                }
            }
        }

      
    }
}
