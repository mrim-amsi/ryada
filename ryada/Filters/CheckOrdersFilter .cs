//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace ryada.Filters
//{
//    public class CheckOrdersFilter : IActionFilter
//    {


//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//            // Check if the user has any orders
//            var userId = context.HttpContext.User.Identity.Name; // Assuming the user ID is stored in the User.Identity.Name property

//            // Add your logic here to check if the user has any orders
//            bool hasOrders = CheckUserOrders(userId); // Implement this method to check the user's orders

//            if (hasOrders)
//            {
//                // Redirect the user to an appropriate page or return a specific response
//                context.Result = new RedirectToActionResult("index", "Orders", null);
//            }
//        }

//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            // This method is called after the action is executed
//            // You can add any additional logic here if needed
//        }

//        private bool CheckUserOrders(string userId)
//        {
//            return true;
//        }
//    }
//}
