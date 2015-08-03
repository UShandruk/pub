using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public enum Operation
    {
        plus=0,
        minus=1,
        multiple=2,
        divide=3
    }

    public class CalculatorController : Controller
    {
        public ViewResult Calculator()
        {
            var operationsList = new List<Operation> {Operation.plus, Operation.minus, Operation.multiple, Operation.divide};
            var selectList = new SelectList(operationsList);
            ViewBag.Operations = selectList;

            ViewBag.Result = 0;

            return View();
        }

        [HttpPost]
        public ActionResult Calculator(int A, Operation operation, int B)
        {
            var result = 0;
            switch (operation)
            {
                case Operation.plus:
                    result = A + B;
                    break;
                case Operation.minus:
                    result = A - B;
                    break;
                case Operation.multiple:
                    result = A * B;
                    break;
                case Operation.divide:
                    result = B != 0 ? A / B : 0; //if a !=0 {A/B}, else 0
                    break;
            }

            var operationsList = new List<Operation> { Operation.plus, Operation.minus, Operation.multiple, Operation.divide };
            var selectList = new SelectList(operationsList);
            ViewBag.Operations = selectList;

            ViewBag.Result = result;

            TempData["A"] = A;
            TempData["B"] = B;
            TempData["Operations"] = operation;
            TempData["Result"] = result;

            return View("CalculatorResult");
        }

        public ViewResult CalculatorResult()
        {
            return View();
        }
	}
}