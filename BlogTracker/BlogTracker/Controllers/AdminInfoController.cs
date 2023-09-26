using BlogTracker.Data;
using BlogTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogTracker.Controllers
{
    
    public class AdminInfoController : Controller
    {
        // Inject the DbContext and any other dependencies needed
        private readonly BlogTrackerDbContext _context;

        public AdminInfoController(BlogTrackerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Add an action method to handle the login POST request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AdminInfo model)
        {
            if (ModelState.IsValid)
            {
                // Perform the authentication logic here, e.g., check if the provided credentials are valid
                var admin = _context.AdminInfo.FirstOrDefault(a => a.EmailId == model.EmailId && a.Password == model.Password);

                if (admin != null)
                {
                    // Authentication successful, you can set a session or cookie to mark the user as logged in
                    // For simplicity, let's assume successful login means setting a session variable
                    HttpContext.Session.SetString("AdminEmail", admin.EmailId);

                    return RedirectToAction("Index", "EmpInfoes"); // Redirect to the home page or a dashboard
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // If the model state is not valid or authentication fails, return to the login page with an error message
            return View(model);
        }

        // Add a logout action method if needed
        public IActionResult Logout()
        {
            // Clear the session or cookie to log the user out
            HttpContext.Session.Remove("AdminEmail");
            return RedirectToAction("Index", "BlogInfoes");
        }
    }
}
