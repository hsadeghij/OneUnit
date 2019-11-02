using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneUnit.Data;
using OneUnit.Data.Entities;
using OneUnit.Services;
using OneUnit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Controllers
{   
    public class AppController:Controller
    {
        private readonly IMailService _mailService;
        private readonly IOneUnitRepository _repository;
        private readonly IMapper _mapper;

        public AppController(IMailService mailService,IOneUnitRepository repository,IMapper mapper)
        {
            _mailService = mailService;
            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "تماس با ما";
            return View();
        }
        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("mr.sadeghijedi@gmail.com", model.Subject, $"From:{model.Name}-{model.Email},Message:{model.Message}");
                ViewBag.UserMessage = "ایمیل با موفقیت ارسال شد";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "درباره ما";
            return View();
        }

        [HttpGet("Shop")]
        [Authorize]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }
        //public IActionResult ProcessName()
        //{
        //    var results = _repository.GetProcessName();
        //    return View(results);
        //}
        //[HttpGet]
        //public IActionResult AddEditProcessName(int? id)
        //{
        //    ProcessNameViewModel model = new ProcessNameViewModel();
        //    try
        //    {
        //        var order = _repository.GetProcessNameById(id);
        //        if (id.HasValue)
        //        {
        //            model = _mapper.Map<ProcessName, ProcessNameViewModel>(order);
        //        }
        //            return   PartialView("~/Views/App/AddEditProcessName.cshtml", model); 
               
        //    }
        //    catch (Exception ex)
        //    {
               
        //        return BadRequest("Failed to get orders");
        //    }
        //}
        //[HttpPost]
        //public IActionResult AddEditProcessName(int? id, ProcessNameViewModel model)
        //{
        //    ProcessNameViewModel model1 = new ProcessNameViewModel();

        //    if (ModelState.IsValid)
        //    {
        //        bool isNew = !id.HasValue;

        //        var newOrder = _mapper.Map<ProcessNameViewModel, ProcessName>(model);
        //        if (isNew)
        //        {
        //            _repository.AddEntity(newOrder);
        //            _repository.SaveAll();
        //        }
        //        else
        //        {
        //            ProcessName orderOld = _repository.GetProcessNameById(id);
        //            orderOld.Name = newOrder.Name;
        //           // orderOld = newOrder;
        //            //_repository.UpdateEntity(newOrder);

        //            _repository.SaveAll();
        //        }
        //    }
     
        //    return RedirectToAction("ProcessName");
        //}
        //[HttpGet]
        //public IActionResult DeleteProcessName(int id)
        //{
        //    ProcessNameViewModel model = new ProcessNameViewModel();
        //    var order = _repository.GetProcessNameById(id);

        //   model = _mapper.Map<ProcessName, ProcessNameViewModel>(order);
            
        //    return PartialView("~/Views/App/DeleteProcessName.cshtml", model);
        //}
        //[HttpPost]
        //public IActionResult DeleteProcessName(int id, ProcessNameViewModel model)
        //{
          
        //    ProcessName orderOld = _repository.GetProcessNameById(id);

        //    _repository.DeleteEntity(orderOld);

        //    _repository.SaveAll();
        //    return RedirectToAction("ProcessName");
        //}
    }
}
