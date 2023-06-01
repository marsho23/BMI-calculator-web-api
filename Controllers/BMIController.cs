using Microsoft.AspNetCore.Mvc;

namespace BMI_calculator_with_Jquery.Controllers
{
    public class BMIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double? weight, double? height)
        {
            if (weight.HasValue && height.HasValue)
            {
                if (height.Value != 0)
                {
                    var bmi = weight.Value / (height.Value * height.Value);
                    return View("Index", bmi);
                }
                else
                {
                    ViewData["Error"] = "Height cannot be zero.";
                    return View("Index");
                }
            }
            else
            {
                ViewData["Error"] = $"Invalid weight or height.";
                return View("Index");
            }
        }


    }
}
