using DemoMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BOL;
using DAL;

namespace DemoMvc.Controllers
{
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
        public IActionResult List()
        {
            List<Employee> list = DBmanager.GetEmployees();
            ViewBag.List = list;
            return View();
        }
        public IActionResult AddEmp() { return View(); }
        [HttpPost]
        public IActionResult AddEmp(string id, string name, string salary)
        {
            Employee employee = new Employee(int.Parse(id), name, Convert.ToDouble(salary));
            DBmanager.insert(employee);
            return RedirectToAction("List");
        }
        public IActionResult DeleteEmp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteEmp(string empid)
        {
            DBmanager.delete(int.Parse(empid));
            return RedirectToAction("List");
        }
        public IActionResult UpdateEmp(int empid)
        {
            Employee emp=DBmanager.GetEmployeeById(empid);
            if(emp!=null)
            {
                ViewBag.Emp = emp;
                return View ();
            }
            return RedirectToAction("AddEmp");
        }
        [HttpPost]
        public IActionResult UpdateEmp(string id, string name, string salary) {
            Employee employee = new Employee(int.Parse(id), name, Convert.ToDouble(salary));
            DBmanager.update(employee);
            return RedirectToAction("List");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}