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
   
    public class HomeController : Controller 
    {
        private IMusolliRepo _musolliRepo;
       
        public HomeController(IMusolliRepo musolliRepo)
        {
            _musolliRepo = musolliRepo;
            
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _musolliRepo.GetAllMusolli();
            ViewBag.PageTitle = "Musolli Details";
            return View(model);

        }

        [AllowAnonymous]
        public ViewResult ViewAmount(int id)
        {
            RetriveID reId = new RetriveID();
            reId.Id=2;
            var model = _musolliRepo.GetMusolli(id);
            ViewBag.PageTitle = "Amounnt Details";
            return View(model);

        }
        [AllowAnonymous]
        [HttpGet]

        public ViewResult AddAmount()
        {
            ViewAddAmount addAmount = new ViewAddAmount();
            return View(addAmount);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddAmount(AddMusolliAmount addmusolliamount, int id)
        {
            if (ModelState.IsValid)
            {
                _musolliRepo.AddAmount(addmusolliamount, id);

                return RedirectToAction("ViewAmount", new { Id = id });
            }

            return View();
        }

        public ViewResult Details()
        {
            AddMusolliAmount model = new AddMusolliAmount();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Musolli musolli)
        {
            if (ModelState.IsValid)
            {
                Musolli newMusolli = _musolliRepo.Add(musolli);
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Musolli musolli = _musolliRepo.GetMusolli(id);

            MusolliEditViewModel musolliEditViewModel = new MusolliEditViewModel
            {

                Id = musolli.Id,
                Name = musolli.Name,
                Department = musolli.Department

            };
            return View(musolliEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(MusolliEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Musolli musolli = _musolliRepo.GetMusolli(model.Id);
                musolli.Name = model.Name;
                musolli.Department = model.Department;
                _musolliRepo.Update(musolli);
                return RedirectToAction("index");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
       public ViewResult EditAmount(int aid)
       {
            RetriveID reId = new RetriveID();
           
            Musolli musolli = _musolliRepo.GetMusolli(reId.Id);

            ViewEditAmount viewEditAmount = new ViewEditAmount
           {
               Date = musolli.ListAmount[aid].Date,
               Amount = musolli.ListAmount[aid].Amount,

            };
           return View(viewEditAmount);
       }

        [AllowAnonymous]
        [HttpPost]
       public IActionResult EditAmount(ViewEditAmount model, int id)
       {
           if (ModelState.IsValid)
           {
                Musolli musolli = _musolliRepo.GetMusolli(1);
                musolli.ListAmount[id].Date = model.Date;
                musolli.ListAmount[id].Amount = model.Amount;
                _musolliRepo.UpdateAmount(musolli,id);
               return RedirectToAction("ViewAmount", new { Id = id });
           }

           return View();
       }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            _musolliRepo.Delete(id);
            return RedirectToAction("index");
        }

       
    }
}
