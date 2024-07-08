using Microsoft.AspNetCore.Mvc;
using RepositoryPatternCRUD.Models;
using System.Diagnostics;

namespace RepositoryPatternCRUD.Controllers
{
    /*

      // Repository Pattern //

      -> Repository Pattern is a design pattern in which an abstraction layer is created between the web application and the data layer
      -> So We will not be able to directly contect the database which is secured for security purposes
      -> And secondly, create a seprate method to perform that operation and call that method as and when required so that our code remains optimize. 
      -> create project -> 3 Package -> Model and DbContext -> appsetttings(connectionstring) -> Program.cs(add DbContext) -> run migration -> create repository(Interface,Service) -> Interface(abstract method),Service(create method) -> so both interface and service injecting in programe.cs by singleton method for dependency injection then this method use to in controller action method
      
    // Dependency Injection //

      -> Transient - It is use for a user send single request so make instance 1 id are different from another instance id 2,3.. and also other send request then for every instance id different from each other
      -> Scoped - It is use for a user send single request so make every instance id same in scoped but another request every instance id same for second request but different from one request every instance id to other request 
      -> Singleton - It is use for every request and every instance id same only one id 

    */

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
