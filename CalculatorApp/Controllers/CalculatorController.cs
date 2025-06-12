using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult Calculate(double number1, double number2, string operation)
        {
            double result = 0;
            string errorMessage = null;

            switch (operation)
            {
                case "Add":
                    result = number1 + number2;
                    break;
                case "Subtract":
                    result = number1 - number2;
                    break;
                case "Multiply":
                    result = number1 * number2;
                    break;
                case "Divide":
                    if (number2 == 0)
                        errorMessage = "Деление на ноль невозможно!";
                    else
                        result = number1 / number2;
                    break;
                default:
                    errorMessage = "Неизвестная операция.";
                    break;
            }

            ViewBag.Result = errorMessage ?? $"Результат: {result}";
            return View();
        }
    }
}
