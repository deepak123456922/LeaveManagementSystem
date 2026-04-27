using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using LeaveManagementSystem.Web.Models;


namespace LeaveManagementSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {

             var temp = new TestViewModel
             {
                 Name = "wipro",
                 Description = "It IS IT Conuslting and Services."
             };
            return View(temp);
        }
    }
}
