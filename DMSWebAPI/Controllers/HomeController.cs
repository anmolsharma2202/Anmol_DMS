using DMSWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Claims;


namespace DMSWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext db;

        private AppDBContext Context { get; }
       

        public HomeController(ILogger<HomeController> logger, AppDBContext context, AppDBContext _home)
        {
            _logger = logger;
            db = context;
            this.Context = _home;
            

        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            var fullName = "Name From Database";
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            claimsIdentity.AddClaim(new Claim("FullName", fullName));

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        //Employee
        public IActionResult EmployeeDetails()
        {

            List<Employee> employees = (from Employee in this.Context.Employees.Take(10)
                                        select Employee).ToList();
            return View(employees);
        }

        //Department
        public IActionResult Department()
        {

            List<Department> dept = (from Department in this.Context.Departments.Take(10)
                                        select Department).ToList();
            return View(dept);
        }

        //Drug
        public IActionResult Drug()
        {

            List<Drug> drg = (from Drug in this.Context.Drugs.Take(10)
                                     select Drug).ToList();
            return View(drg);
        }

        //Usage Condition
        public IActionResult UsageCondition()
        {

            List<UsageCondition> usageConditions = (from UsageCondition in this.Context.UsageConditions.Take(10)
                                                    select UsageCondition).ToList();
            return View(usageConditions);
        }

        //Reaction Agent Detail
        public IActionResult ReactionAgent()
        {

            List<ReactionAgent> reactionAgents = (from ReactionAgent in this.Context.ReactionAgents.Take(10)
                                                  select ReactionAgent).ToList();
            return View(reactionAgents);
        }

        //Allergic Symptoms
        public IActionResult AllergicSymptom()
        {

            List<AllergicSymptom> allergicSymptom = (from AllergicSymptom in this.Context.AllergicSymptoms.Take(10)
                                                     select AllergicSymptom).ToList();
            return View(allergicSymptom);
        }

        //Anti-Allergic Drug
        public IActionResult AntiAllergicDrug()
        {

            List<AntiAllergicDrug> antiAllergicDrug = (from AntiAllergicDrug in this.Context.AntiAllergicDrugs.Take(10)
                                                       select AntiAllergicDrug).ToList();
            return View(antiAllergicDrug);
        }

        //Anti-Allergic Drug Symptoms
        public IActionResult AntiAllergicDrugSymptom()
        {

            List<AntiAllergicDrugSymptom> antiAllergicDrugSymptom = (from AntiAllergicDrugSymptom in this.Context.AntiAllergicDrugSymptoms.Take(10)
                                                                     select AntiAllergicDrugSymptom).ToList();
            return View(antiAllergicDrugSymptom);
        }

        //Condition Details
        public IActionResult ConditionDetail()
        {

            List<ConditionDetail> conditionDetail = (from ConditionDetail in this.Context.ConditionDetails.Take(10)
                                                     select ConditionDetail).ToList();
            return View(conditionDetail);
        }

        //Patient
        public IActionResult Patient()
        {

            List<Patient> patient = (from Patient in this.Context.Patients.Take(10)
                                     select Patient).ToList();
            return View(patient);
        }

        //New Drug Trial
        public IActionResult NewDrugTrial()
        {

            List<NewDrugTrial> newDrugTrial = (from NewDrugTrial in this.Context.NewDrugTrials.Take(10)
                                               select NewDrugTrial).ToList();
            return View(newDrugTrial);
        }



    }

}


//        public IActionResult Login()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Login(Login obj)
//        {
//            try
//            {
//                if (db.login.Any(a => a.Email == obj.Email && a.Password == obj.Password))
//                {
//                    TempData["user"] = obj.Email;
//                    return RedirectToAction("Index");
//                }

//                else
//                {
//                    ViewBag.error = "!!Please Enter valid login credentials.";
//                }
//                db.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                ViewBag.error = "!!There is some error.";
//            }
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Registration(Login obj)
//        {
//            //db.login.Add(obj);
//            //db.SaveChanges();
//            //return RedirectToAction("Index");
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    db.login.Add(obj);
//                    db.SaveChanges();
//                    ViewBag.success = "Sign Up successfully.";
//                    return View();
//                }
//                else
//                {
//                    ViewBag.error = "!!There is some error.";
//                }
//                db.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                ViewBag.error = "!!There is some error.";
//            }
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}