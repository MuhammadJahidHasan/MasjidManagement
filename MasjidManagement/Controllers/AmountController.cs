using MasjidManagement.Models;
using MasjidManagement.View_Models;
using MasjidManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.Controllers
{
    //Admin user name=jahid@gmail.com
    //Admin Password=Jahid@123
    [Authorize(Roles = "Admin")]
    public class AmountController : Controller 
    {
        int index = 0;
        private AddMusolliAmountRepo _addMusolliAmountReop;
        public AmountController(AddMusolliAmountRepo addMusolliAmountRepo)
        {
            _addMusolliAmountReop = addMusolliAmountRepo;
        }
       

        [HttpGet]

        public ViewResult AddAmount()
        {
            ViewAddAmount addAmount = new ViewAddAmount();
            return View(addAmount);
        }

        [HttpPost]

        public IActionResult AddAmount(AddMusolliAmount ammusolli, int id)
        {
            if (ModelState.IsValid)
            {
                _addMusolliAmountReop.AddAmount(ammusolli, id);
                return RedirectToAction("ViewAmount", new { Id = id });
            }
            return View();
        }

        /*
        [HttpGet]

        public ViewResult EditAmount(int id)
        {
            AddMusolliAmount addMusolliAmount = _addMusolliAmountReop.GetAmount(index=1,id);

            ViewEditAmount viewEditAmount = new ViewEditAmount
            {
                Date = addMusolliAmount.Date,
                Amount = addMusolliAmount.Amount

            };
            return View(viewEditAmount);
        }

        [HttpPost]
        public IActionResult EditAmount(ViewEditAmount model, int id)
        {
            if (ModelState.IsValid)
            {
                AddMusolliAmount addMusolliAmount = _addMusolliAmountReop.GetAmount(index,id);
                addMusolliAmount.Date = model.Date;
                addMusolliAmount.Amount = model.Amount;
                _addMusolliAmountReop.Update(addMusolliAmount,index=1, id);
                return RedirectToAction("ViewAmount", new { Id = id });
            }

            return View();
        }*/
    }
}
