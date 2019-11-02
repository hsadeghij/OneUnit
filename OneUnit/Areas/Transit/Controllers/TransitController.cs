using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneUnit.Areas.Admin.Data.Entities;
using OneUnit.Areas.QC.Data.Entities;
using OneUnit.Areas.Transit.Data;
using OneUnit.Areas.Transit.Data.Entities;
using OneUnit.Areas.Transit.ViewModels;
using OneUnit.Services;

namespace OneUnit.Areas.Transit.Controllers
{
    [Area("Transit")]
    public class TransitController : Controller
    {
        private readonly IMailService _mailService;
        private readonly ITransitRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<StoreUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public TransitController(IMailService mailService, ITransitRepository repository, IMapper mapper, UserManager<StoreUser> userManager,IHostingEnvironment hostingEnvironment)
        {
            _mailService = mailService;
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }
        #region Index
        public ActionResult PassDate(string TempDate)
        {
            TempData["PassDate"] = TempDate;

            //ViewBag.DateForQualityDesign = TempDate;
            //return RedirectToAction("DynamicFormQualityDesign");
            return Json(Url.Action("AllProjectPlan", "Transit"));

        }
        #endregion
        #region Person
        public ActionResult DynamicPerson()
        {

            return View();
        }

        [HttpGet("GetCurrentStateWithJson")]
        public JsonResult GetCurrentStateWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<CurrentState> ICurrentState = _repository.GetAllCurrentState();
            return new JsonResult(ICurrentState, sa);
        }
        [HttpPost("AddPersonList")]
        public JsonResult AddPersonList([FromBody] List<PersonViewModel> persons)
        {

            //Truncate Table to delete all old records.
            //  entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

            //Check for NULL.
            if (persons == null)
            {
                persons = new List<PersonViewModel>();
            }

            //Loop and insert records.
            foreach (PersonViewModel person in persons)
            {
                var newPerson = _mapper.Map<PersonViewModel, Person>(person);
                _repository.AddEntity(newPerson);
                _repository.SaveAll();
            }
            bool insertedRecords = true;
            // return Json(insertedRecords);
            // return RedirectToAction("AllControlParameter");
            return Json(new
            {
                redirectUrl = Url.Action("DynamicPerson", "Transit"),
                isRedirect = true
            });
        }
        [HttpGet("GetPersonWithJson")]
        public JsonResult GetPersonWithJson()
        {
            var sa = new JsonSerializerSettings();
            IEnumerable<Person> IPerson = _repository.GetAllPerson();
            return new JsonResult(IPerson, sa);
        }

        #endregion
        #region Post
        public IActionResult AllPost()
        {
            var results = _repository.GetAllPost();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditPost(int? id)
        {
            PostViewModel model = new PostViewModel();
            try
            {
                var post = _repository.GetPostById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Post, PostViewModel>(post);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/Transit/Views/Transit/AddEditPost.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditPost(int? id, PostViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newPost = _mapper.Map<PostViewModel, Post>(model);
                if (isNew)
                {
                    _repository.AddEntity(newPost);
                    _repository.SaveAll();
                }
                else
                {
                    Post oldPost = _repository.GetPostById(id);
                    oldPost.Name = newPost.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllPost");
        }
        [HttpGet]
        public IActionResult DeletePost(int id)
        {
            PostViewModel model = new PostViewModel();
            var post = _repository.GetPostById(id);

            model = _mapper.Map<Post, PostViewModel>(post);

            return PartialView("~/Areas/Transit/Views/Transit/DeletePost.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeletePost(int id, PostViewModel model)
        {

            Post post = _repository.GetPostById(id);

            _repository.DeleteEntity(post);

            _repository.SaveAll();
            return RedirectToAction("AllPost");
        }
        [HttpGet("GetPostWithJson")]
        public JsonResult GetPostWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<Post> IPost = _repository.GetAllPost();
            return new JsonResult(IPost, sa);
        }
        #endregion
        #region WorkType
        public IActionResult AllWorkType()
        {
            var results = _repository.GetAllWorkType();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditWorkType(int? id)
        {
            WorkTypeViewModel model = new WorkTypeViewModel();
            try
            {
                var workType = _repository.GetWorkTypeById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<WorkType, WorkTypeViewModel>(workType);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/Transit/Views/Transit/AddEditWorkType.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditWorkType(int? id, WorkTypeViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newWorkType = _mapper.Map<WorkTypeViewModel, WorkType>(model);
                if (isNew)
                {
                    _repository.AddEntity(newWorkType);
                    _repository.SaveAll();
                }
                else
                {
                    WorkType oldWorkType = _repository.GetWorkTypeById(id);
                    oldWorkType.Name = newWorkType.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllWorkType");
        }
        [HttpGet]
        public IActionResult DeleteWorkType(int id)
        {
            WorkTypeViewModel model = new WorkTypeViewModel();
            var workType = _repository.GetWorkTypeById(id);

            model = _mapper.Map<WorkType, WorkTypeViewModel>(workType);

            return PartialView("~/Areas/Transit/Views/Transit/DeleteWorkType.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteWorkType(int id, WorkTypeViewModel model)
        {

            WorkType workType = _repository.GetWorkTypeById(id);

            _repository.DeleteEntity(workType);

            _repository.SaveAll();
            return RedirectToAction("AllWorkType");
        }
        [HttpGet("GetWorkTypeWithJson")]
        public JsonResult GetWorkTypeWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<WorkType> IWorkType = _repository.GetAllWorkType();
            return new JsonResult(IWorkType, sa);
        }
        #endregion
        #region Index

          public IActionResult Index()
          {
 

            ViewBag.Project = _repository.GetAllProject();
            return View();
          }

        //public IActionResult Generate(string productId)
        //{
        //    ViewBag.productId = productId;
        //    return View("Index");
        //}
        //public IActionResult ShowFields(string fullName,IFormFile pic)
        //{
        //    //ViewData["fname"] = fullName;
        //    //if (pic != null)
        //    //{
        //    //    var fileName = Path.
        //    //}
        //    //return View();
        //}
        #endregion
        #region QRcode
        public IActionResult QRcode()
        {

            return View();

        }

        public IActionResult Generate(string productId)
        {
            ViewBag.productId = productId;
            return View("QRcode");
        }
        #endregion
        #region Rating
        [HttpGet("GetRatingWithJson")]
        public JsonResult GetRatingWithJson()
        {
            var sa = new JsonSerializerSettings();
            IEnumerable<Rating> IRating = _repository.GetAllRating();
            return new JsonResult(IRating, sa);
        }
        #endregion
        #region TransitInfo
        public ActionResult DynamicTransitInfo()
        {
            return View();
        }
        [HttpPost("AddTransitInfoList")]
        public JsonResult AddTransitInfoList([FromBody] List<TransitInfoViewModel> transitInfos)
         {

            //  Truncate Table to delete all old records.
            //  entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

            //Check for NULL.
            if (transitInfos == null)
            {
                transitInfos = new List<TransitInfoViewModel>();
            }

            // Loop and insert records.
            foreach (TransitInfoViewModel transitinfo in transitInfos)
            {
                var newTransitInfo = _mapper.Map<TransitInfoViewModel, TransitInfo>(transitinfo);
                _repository.Save_TransitInfo(newTransitInfo.PersonId, newTransitInfo.RatingId);
                //_repository.AddEntity(newTransitInfo);
                //_repository.SaveAll();
            }
            bool insertedRecords = true;
            // return Json(insertedRecords);
            // return RedirectToAction("AllControlParameter");
            return Json(new
            {
                redirectUrl = Url.Action("DynamicTransitInfo", "Transit"),
                isRedirect = true
            });
        }
        #endregion
        #region Project
        public IActionResult AllProject()
        {
            var results = _repository.GetAllProject();

            return View(results);

        }
        public IActionResult SelectProject()
        {

            ViewBag.Project = _repository.GetAllProject();

            return View();

        }
        [HttpGet]
        public IActionResult AddEditProject(int? id)
        {
            ProjectViewModel model = new ProjectViewModel();
            try
            {
                var project = _repository.GetProjectById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Project, ProjectViewModel>(project);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/Transit/Views/Transit/AddEditProject.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditProject(int? id, ProjectViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newProject = _mapper.Map<ProjectViewModel, Project>(model);
                if (isNew)
                {
                    _repository.AddEntity(newProject);
                    _repository.SaveAll();
                }
                else
                {
                    Project oldProject = _repository.GetProjectById(id);
                    oldProject.Name = newProject.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllProject");
        }
        [HttpGet]
        public IActionResult DeleteProject(int id)
        {
            ProjectViewModel model = new ProjectViewModel();
            var project = _repository.GetProjectById(id);

            model = _mapper.Map<Project, ProjectViewModel>(project);

            return PartialView("~/Areas/Transit/Views/Transit/DeleteProject.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteProject(int id, ProjectViewModel model)
        {

            Project project = _repository.GetProjectById(id);

            _repository.DeleteEntity(project);

            _repository.SaveAll();
            return RedirectToAction("AllProject");
        }
        [HttpGet("GetProjectWithJson")]
        public JsonResult GetProjectWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<Project> IProject = _repository.GetAllProject();
            return new JsonResult(IProject, sa);
        }
        #endregion

        #region ProjectPlan

        public IActionResult AllProjectPlan(int Id)
        {

               //  ViewBag.Value = 0;
            //    var results = _repository.GetAllProjectPlan_WithProjectId(Id);
            var results = _repository.GetAllProjectPlan();
            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditProjectPlan(int? id)
        {
            ProjectPlanViewModel model = new ProjectPlanViewModel();
            try
            {


                var projectPlan  = _repository.GetProjectPlanById(id);
                ViewBag.Project  = _repository.GetAllProject();
                ViewBag.WorkType = _repository.GetAllWorkType();
                ViewBag.Person   = _repository.GetAllPerson();
                string[] WorkerListCodesTemp = new string[0];
                string[] SarparastListCodesTemp = new string[0];
                string[] OstadKarListCodesTemp = new string[0];
                string worklistForPass = string.Empty;
                string SarparastlistForPass = string.Empty;
                string OstadkarlistForPass = string.Empty;
                if (id.HasValue)
                {


                    if (projectPlan.WorkerListCodes != null)
                    {
                        WorkerListCodesTemp = projectPlan.WorkerListCodes.Split(',');
                        ViewBag.tempq = WorkerListCodesTemp;
                        worklistForPass = projectPlan.WorkerListCodes;
                    }
                    if (projectPlan.SarparastCodes != null)
                    {
                        SarparastListCodesTemp = projectPlan.SarparastCodes.Split(',');
                        SarparastlistForPass = projectPlan.SarparastCodes;
                    }
                    if (projectPlan.OstadKarCodes != null)
                    {
                        OstadKarListCodesTemp = projectPlan.OstadKarCodes.Split(',');
                        OstadkarlistForPass = projectPlan.OstadKarCodes;
                    }

                    model = _mapper.Map<ProjectPlan, ProjectPlanViewModel>(projectPlan);

                }
                // model.GetPersonList = _repository.GetAllPerson().Select(s => new Person { Id = s.Id, FullName = s.FullName }).ToList();

                List<Person> Lperson;

                Person Tperson;
                //----------worker-----------------
                Lperson = new List<Person>();
                var queryWorker = _repository.GetAllTransitInfo_EnableForCombo_Worker(worklistForPass,"worker");

               // if (id.HasValue)   
                  // queryWorker = _repository.GetAllTransitInfo_EnableForComboWithoutTime_Worker(worklistForPass,"worker");


                foreach (var item in queryWorker)
                {
                    Tperson = new Person();
                    Tperson.Id = item.Id;
                    Tperson.FullName = item.FullName;
                    Lperson.Add(Tperson);
                }

                model.GetWorkerList = Lperson;
                model.workerList = WorkerListCodesTemp;
                //-------------Sarparast------------
                Lperson = new List<Person>();
                var querySarparast = _repository.GetAllTransitInfo_EnableForCombo_Worker(SarparastlistForPass, "sarparast");

              //  if (id.HasValue)
                 //   querySarparast = _repository.GetAllTransitInfo_EnableForComboWithoutTime_Worker(SarparastlistForPass, "sarparast");
                

                foreach (var item in querySarparast)
                {
                    Tperson = new Person();
                    Tperson.Id = item.Id;
                    Tperson.FullName = item.FullName;
                    Lperson.Add(Tperson);
                }

                model.GetSarparastList = Lperson;
                model.sarparastList = SarparastListCodesTemp;
                //------------Ostadkar---------------
                Lperson = new List<Person>();
                var queryOstadKar = _repository.GetAllTransitInfo_EnableForCombo_Worker(OstadkarlistForPass, "ostadkar");

               // if (id.HasValue)
                  //  queryOstadKar = _repository.GetAllTransitInfo_EnableForComboWithoutTime_Worker(OstadkarlistForPass, "ostadkar");


                foreach (var item in queryOstadKar)
                {
                    Tperson = new Person();
                    Tperson.Id = item.Id;
                    Tperson.FullName = item.FullName;
                    Lperson.Add(Tperson);
                }

                model.GetOstadKarList = Lperson;
                model.ostadkarList = OstadKarListCodesTemp;

                // ViewBag.ProcessName = _repository.GetAllControlTools();

                return PartialView("~/Areas/Transit/Views/Transit/AddEditProjectPlan.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditProjectPlan(int? id, ProjectPlanViewModel model)
        {
          //  if (false)
           // {


                Boolean flag = false;
                 Boolean flagForEqual = true;
                string WorkerList = string.Empty;
                string OstadKarList = string.Empty;
                string SarparastList = string.Empty;
                int Identity;
                string WorkerCodes = string.Empty;
                string OstadKarCodes = string.Empty;
                string SarparastCodes = string.Empty;
                string[] workerlist = new string[0];
                string[] ostadkarlist = new string[0];
                string[] sarparastlist = new string[0];
                // model.GetPersonList = _repository.GetAllPerson().Select(s => new Person { Id = s.Id, FullName = s.FullName }).ToList();

                var query = _repository.GetAllTransitInfoWithPerson();
            #region CheckForEqual
            //---------------------------------------
            if (model.workerList != null && model.ostadkarList != null)
            {
                foreach (string ww in model.workerList)
                {
                    foreach (string oo in model.ostadkarList)
                    {
                        if (oo == ww)
                        {
                            flagForEqual = false;
                        }
                    }
                }
            }
            //-----------------------------------
            if (model.workerList != null && model.sarparastList != null)
            {
                foreach (string ww in model.workerList)
                {
                    foreach (string ss in model.sarparastList)
                    {
                        if (ss == ww)
                        {
                            flagForEqual = false;
                        }
                    }
                }
            }
            //--------------------------------------
            if (model.ostadkarList != null && model.sarparastList != null)
            {
                foreach (string oo in model.ostadkarList)
                {
                    foreach (string ss in model.sarparastList)
                    {
                        if (oo == ss)
                        {
                            flagForEqual = false;
                        }
                    }
                }
            }
            #endregion
            if(flagForEqual)
            { 

            if (model.workerList != null)
                {
                    foreach (string pp in model.workerList)
                    {

                        WorkerCodes += pp + ",";

                        foreach (var item in query)
                        {
                            if (pp == Convert.ToString(item.Id))
                            {
                                WorkerList += item.FullName + ",";
                            }
                        }

                    }
                    WorkerCodes = WorkerCodes.Remove(WorkerCodes.Length - 1);
                    WorkerList = WorkerList.Remove(WorkerList.Length - 1);
                }
                else
                {
                    WorkerCodes = null;
                    WorkerList = null;
                }

                if (model.ostadkarList != null)
                {
                    foreach (string pp in model.ostadkarList)
                    {

                        OstadKarCodes += pp + ",";

                        foreach (var item in query)
                        {
                            if (pp == Convert.ToString(item.Id))
                            {
                                OstadKarList += item.FullName + ",";
                            }
                        }

                    }
                    OstadKarCodes = OstadKarCodes.Remove(OstadKarCodes.Length - 1);
                    OstadKarList = OstadKarList.Remove(OstadKarList.Length - 1);
                }
                else
                {
                    OstadKarCodes = null;
                    OstadKarList = null;
                }

                if (model.sarparastList != null)
                {
                    foreach (string pp in model.sarparastList)
                    {

                        SarparastCodes += pp + ",";

                        foreach (var item in query)
                        {
                            if (pp == Convert.ToString(item.Id))
                            {
                                SarparastList += item.FullName + ",";
                            }
                        }

                    }
                    SarparastCodes = SarparastCodes.Remove(SarparastCodes.Length - 1);
                    SarparastList = SarparastList.Remove(SarparastList.Length - 1);
                }
                else
                {
                    SarparastCodes = null;
                    SarparastList = null;
                }

                bool isNew = !id.HasValue;

                var newProjectPlan = _mapper.Map<ProjectPlanViewModel, ProjectPlan>(model);

                if (isNew)
                {
                    TraceWorker traceworker;


                    ProjectPlan oldProjectPlan = new ProjectPlan();
                    oldProjectPlan.ProjectId = newProjectPlan.ProjectId;
                    oldProjectPlan.DateReg = newProjectPlan.DateReg;
                    oldProjectPlan.Description = newProjectPlan.Description;
                    oldProjectPlan.PersonId = newProjectPlan.PersonId;
                    oldProjectPlan.Activity = newProjectPlan.Activity;
                    oldProjectPlan.WorkTypeId = newProjectPlan.WorkTypeId;
                    oldProjectPlan.WorkerList = WorkerList;
                    oldProjectPlan.WorkerListCodes = WorkerCodes;
                    oldProjectPlan.OstadKarList = OstadKarList;
                    oldProjectPlan.OstadKarCodes = OstadKarCodes;
                    oldProjectPlan.SarparastList = SarparastList;
                    oldProjectPlan.SarparastCodes = SarparastCodes;
                    Identity = _repository.Add_ProjectPlan_ReturnId(oldProjectPlan);
                    if (model.workerList != null)
                    {
                        foreach (string pp in model.workerList)
                        {
                            //کد 1 در ورودی دوم  معنی ورود به پروژه است
                            //کد 1 در ورودی ششم به معنی پست کارگر است
                            _repository.Save_TraceWorker(Identity, 1, "0", "0", Convert.ToInt32(pp), 1);
                            _repository.Update_StatusTransit(Convert.ToInt32(pp), 2);
                            _repository.SaveAll();
                        }
                    }

                    if (model.ostadkarList != null)
                    {
                        foreach (string pp in model.ostadkarList)
                        {
                            //کد 1 در ورودی دوم  معنی ورود به پروژه است
                            //کد 2 در ورودی ششم به معنی پست استاد کار است
                            _repository.Save_TraceWorker(Identity, 1, "0", "0", Convert.ToInt32(pp), 2);
                            _repository.Update_StatusTransit(Convert.ToInt32(pp), 2);
                            _repository.SaveAll();
                        }
                    }
                    if (model.sarparastList != null)
                    {
                        foreach (string pp in model.sarparastList)
                        {
                            //کد 1 در ورودی دوم  معنی ورود به پروژه است
                            //کد 4 در ورودی ششم به معنی پست سرپرست است
                            _repository.Save_TraceWorker(Identity, 1, "0", "0", Convert.ToInt32(pp), 4);
                            _repository.Update_StatusTransit(Convert.ToInt32(pp), 2);
                            _repository.SaveAll();
                        }
                    }
                }
                else
                {
                    ProjectPlan projectPlan = _repository.GetProjectPlanById(model.Id);
                    TraceWorker traceworker;
                    //--------------------------------------------------------------------
                    #region TraceForWorker
                    if (projectPlan.WorkerListCodes != null)
                        workerlist = projectPlan.WorkerListCodes.Split(',');
                    else
                        workerlist = null;

                    traceworker = new TraceWorker();
                    if (model.workerList != null)
                    {

                        if (workerlist != null)
                        {


                            //-------------------حلقه زیر برای ورود به پروژه است---------------------------
                            foreach (string pp in model.workerList)
                            {
                                flag = true;
                                for (int i = 0; i < workerlist.Length; i++)
                                {
                                    if (workerlist[i] == pp)
                                    {
                                        flag = false;
                                    }
                                }
                                if (flag)
                                {
                                    //کد 1 در ورودی دوم  معنی ورود به پروژه است
                                    //کد 1 در ورودی ششم به معنی پست کارگر است
                                    _repository.Save_TraceWorker(newProjectPlan.Id, 1, "0", "0", Convert.ToInt32(pp), 1);
                                    _repository.Update_StatusTransit(Convert.ToInt32(pp), 2);
                                    _repository.SaveAll();
                                }
                            }
                            //-------------------حلقه زیر برای خروج از پروژه است---------------------------
                            for (int i = 0; i < workerlist.Length; i++)
                            {
                                flag = true;
                                foreach (string pp in model.workerList)
                                {
                                    if (workerlist[i] == pp)
                                    {
                                        flag = false;
                                    }
                                }
                                if (flag)
                                {
                                    //کد 1 در ورودی دوم  معنی خروج از پروژه است
                                    //کد 1 در ورودی ششم به معنی پست کارگر است
                                    _repository.Save_TraceWorker(newProjectPlan.Id, 2, "0", "0", Convert.ToInt32(workerlist[i]), 1);
                                    _repository.Update_StatusTransit(Convert.ToInt32(workerlist[i]), 1);
                                    _repository.SaveAll();
                                }
                            }
                        }
                        else
                        {
                            foreach (string pp in model.workerList)
                            {
                                //کد 1 در ورودی دوم  معنی ورود به پروژه است
                                //کد 1 در ورودی ششم به معنی پست کارگر است
                                _repository.Save_TraceWorker(newProjectPlan.Id, 1, "0", "0", Convert.ToInt32(pp), 1);
                                _repository.Update_StatusTransit(Convert.ToInt32(pp), 2);
                                _repository.SaveAll();
                            }
                        }
                    }
                    else
                    {
                        if (workerlist != null)
                        {
                            for (int i = 0; i < workerlist.Length; i++)
                            {
                                //کد 12 در ورودی دوم  معنی خروج از پروژه است
                                //کد 1 در ورودی ششم به معنی پست کارگر است
                                _repository.Save_TraceWorker(newProjectPlan.Id, 2, "0", "0", Convert.ToInt32(workerlist[i]), 1);
                                _repository.Update_StatusTransit(Convert.ToInt32(workerlist[i]), 1);
                                _repository.SaveAll();
                            }
                        }

                    }
                    #endregion
                    #region TraceForOstadKar
                    if (projectPlan.OstadKarCodes != null)
                        ostadkarlist = projectPlan.OstadKarCodes.Split(',');
                    else
                        ostadkarlist = null;

                    traceworker = new TraceWorker();
                    if (model.ostadkarList != null)
                    {

                        if (ostadkarlist != null)
                        {


                            //-------------------حلقه زیر برای ورود به پروژه است---------------------------
                            foreach (string pp in model.ostadkarList)
                            {
                                flag = true;
                                for (int i = 0; i < ostadkarlist.Length; i++)
                                {
                                    if (ostadkarlist[i] == pp)
                                    {
                                        flag = false;
                                    }
                                }
                                if (flag)
                                {
                                    //کد 1 در ورودی دوم  معنی ورود به پروژه است
                                    //کد 1 در ورودی ششم به معنی پست استادکار است
                                    _repository.Save_TraceWorker(newProjectPlan.Id, 1, "0", "0", Convert.ToInt32(pp), 2);
                                    _repository.Update_StatusTransit(Convert.ToInt32(pp), 2);
                                    _repository.SaveAll();
                                }
                            }
                            //-------------------حلقه زیر برای خروج از پروژه است---------------------------
                            for (int i = 0; i < ostadkarlist.Length; i++)
                            {
                                flag = true;
                                foreach (string pp in model.ostadkarList)
                                {
                                    if (ostadkarlist[i] == pp)
                                    {
                                        flag = false;
                                    }
                                }
                                if (flag)
                                {
                                    //کد 2 در ورودی دوم  معنی خروج از پروژه است
                                    //کد 2 در ورودی ششم به معنی پست استادکار است
                                    _repository.Save_TraceWorker(newProjectPlan.Id, 2, "0", "0", Convert.ToInt32(ostadkarlist[i]), 2);
                                    _repository.Update_StatusTransit(Convert.ToInt32(ostadkarlist[i]), 1);
                                    _repository.SaveAll();
                                }
                            }
                        }
                        else
                        {
                            foreach (string pp in model.ostadkarList)
                            {

                                //کد 1 در ورودی دوم  معنی ورود به پروژه است
                                //کد 2 در ورودی ششم به معنی پست استادکار است
                                _repository.Save_TraceWorker(newProjectPlan.Id, 1, "0", "0", Convert.ToInt32(pp), 2);
                                _repository.Update_StatusTransit(Convert.ToInt32(pp), 2);
                                _repository.SaveAll();
                            }
                        }
                    }
                    else
                    {
                        if (ostadkarlist != null)
                        {
                            for (int i = 0; i < ostadkarlist.Length; i++)
                            {
                                //کد 2 در ورودی دوم  معنی خروج از پروژه است
                                //کد 2 در ورودی ششم به معنی پست استادکار است
                                _repository.Save_TraceWorker(newProjectPlan.Id, 2, "0", "0", Convert.ToInt32(ostadkarlist[i]), 2);
                                _repository.Update_StatusTransit(Convert.ToInt32(ostadkarlist[i]), 1);
                                _repository.SaveAll();
                            }
                        }

                    }
                    #endregion
                    #region TraceForSarparast
                    if (projectPlan.SarparastCodes != null)
                        sarparastlist = projectPlan.SarparastCodes.Split(',');
                    else
                        sarparastlist = null;

                    traceworker = new TraceWorker();
                    if (model.sarparastList != null)
                    {

                        if (sarparastlist != null)
                        {


                            //-------------------حلقه زیر برای ورود به پروژه است---------------------------
                            foreach (string pp in model.sarparastList)
                            {
                                flag = true;
                                for (int i = 0; i < sarparastlist.Length; i++)
                                {
                                    if (sarparastlist[i] == pp)
                                    {
                                        flag = false;
                                    }
                                }
                                if (flag)
                                {
                                    //کد 1 در ورودی دوم  معنی ورود به پروژه است
                                    //کد 4 در ورودی ششم به معنی پست سرپرست است
                                    _repository.Save_TraceWorker(newProjectPlan.Id, 1, "0", "0", Convert.ToInt32(pp), 4);
                                    _repository.Update_StatusTransit(Convert.ToInt32(pp), 2);
                                    _repository.SaveAll();
                                }
                            }
                            //-------------------حلقه زیر برای خروج از پروژه است---------------------------
                            for (int i = 0; i < sarparastlist.Length; i++)
                            {
                                flag = true;
                                foreach (string pp in model.sarparastList)
                                {
                                    if (sarparastlist[i] == pp)
                                    {
                                        flag = false;
                                    }
                                }
                                if (flag)
                                {
                                    //کد 2 در ورودی دوم  معنی خروج از پروژه است
                                    //کد 4 در ورودی ششم به معنی پست سرپرست است
                                    _repository.Save_TraceWorker(newProjectPlan.Id, 2, "0", "0", Convert.ToInt32(sarparastlist[i]), 4);
                                    _repository.Update_StatusTransit(Convert.ToInt32(sarparastlist[i]), 1);
                                    _repository.SaveAll();
                                }
                            }
                        }
                        else
                        {
                            foreach (string pp in model.sarparastList)
                            {

                                //کد 1 در ورودی دوم  معنی ورود به پروژه است
                                //کد 4 در ورودی ششم به معنی پست سرپرست است
                                _repository.Save_TraceWorker(newProjectPlan.Id, 1, "0", "0", Convert.ToInt32(pp), 4);
                                _repository.Update_StatusTransit(Convert.ToInt32(pp), 2);
                                _repository.SaveAll();
                            }
                        }
                    }
                    else
                    {
                        if (sarparastlist != null)
                        {
                            for (int i = 0; i < sarparastlist.Length; i++)
                            {
                                //کد 2 در ورودی دوم  معنی خروج از پروژه است
                                //کد 4 در ورودی ششم به معنی پست سرپرست است
                                _repository.Save_TraceWorker(newProjectPlan.Id, 2, "0", "0", Convert.ToInt32(sarparastlist[i]), 4);
                                _repository.Update_StatusTransit(Convert.ToInt32(sarparastlist[i]), 1);
                                _repository.SaveAll();
                            }
                        }

                    }
                    #endregion
                    ProjectPlan oldProjectPlan = _repository.GetProjectPlanById(id);
                    oldProjectPlan.ProjectId = newProjectPlan.ProjectId;
                    oldProjectPlan.DateReg = newProjectPlan.DateReg;
                    oldProjectPlan.Description = newProjectPlan.Description;
                    oldProjectPlan.PersonId = newProjectPlan.PersonId;
                    oldProjectPlan.Activity = newProjectPlan.Activity;
                    oldProjectPlan.WorkTypeId = newProjectPlan.WorkTypeId;
                    oldProjectPlan.WorkerList = WorkerList;
                    oldProjectPlan.WorkerListCodes = WorkerCodes;

                    oldProjectPlan.OstadKarList = OstadKarList;
                    oldProjectPlan.OstadKarCodes = OstadKarCodes;

                    oldProjectPlan.OstadKarList = OstadKarList;
                    oldProjectPlan.OstadKarCodes = OstadKarCodes;

                    oldProjectPlan.SarparastList = SarparastList;
                    oldProjectPlan.SarparastCodes = SarparastCodes;

                    _repository.SaveAll();
                }
                // }

                return RedirectToAction("AllProjectPlan");
            }
            else
            {
                return Json(new { Result = "اسم ها نباید یکسان باشد" });
           }
        }
        [HttpGet]
        public IActionResult DeleteProjectPlan(int id)
        {
            ProjectPlanViewModel model = new ProjectPlanViewModel();
            var projectPlan = _repository.GetProjectPlanById(id);

            model = _mapper.Map<ProjectPlan, ProjectPlanViewModel>(projectPlan);

            return PartialView("~/Areas/Transit/Views/Transit/DeleteProjectPlan.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteProjectPlan(int id, ProjectPlanViewModel model)
        {

            ProjectPlan projectPlan = _repository.GetProjectPlanById(id);

            _repository.DeleteEntity(projectPlan);

            _repository.SaveAll();
            return RedirectToAction("AllProjectPlan");
        }
        [HttpGet("GetProjectPlanWithJson")]
        public JsonResult GetProjectPlanWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<ProjectPlan> IProjectPlan = _repository.GetAllProjectPlanForCombo();
            return new JsonResult(IProjectPlan, sa);
        }
        [HttpPost("AddProjectPlanList")]
        public JsonResult AddProjectPlanList([FromBody] List<ProjectPlanViewModel> projectplans)
        {

            //Truncate Table to delete all old records.
            //  entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

            //Check for NULL.
            if (projectplans == null)
            {
                projectplans = new List<ProjectPlanViewModel>();
            }

            //Loop and insert records.
            foreach (ProjectPlanViewModel projectplan in projectplans)
            {
                var newProjectPlan = _mapper.Map<ProjectPlanViewModel, ProjectPlan>(projectplan);
                _repository.AddEntity(newProjectPlan);
                _repository.SaveAll();
            }
            bool insertedRecords = true;
            // return Json(insertedRecords);
            // return RedirectToAction("AllControlParameter");
            return Json(new
            {
                redirectUrl = Url.Action("DynamicProjectPlan", "Transit"),
                isRedirect = true
            });
        }
        #endregion
        #region Upload Image
        public ActionResult AddEditAttachment()
        {
            var results = _repository.GetAllAttachment();
            return View(results);
        }
        [HttpPost]
        public ActionResult SaveData(AttachmentViewModel model)
        {
            var newAttachment = _mapper.Map<AttachmentViewModel, Attachment>(model);
            if (model.ImageUpload != null)
            {
                string UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images\\Transit");
                string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                string extention = Path.GetExtension(model.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extention;
                newAttachment.PicUrl = fileName;
                string filePath = Path.Combine(UploadFolder, fileName);
                model.ImageUpload.CopyTo(new FileStream(filePath,FileMode.Create));
                _repository.AddEntity(newAttachment);
                _repository.SaveAll();
      
            }
            var sa = new JsonSerializerSettings();
            var result = "Successfuly Added";
            return Json(result, sa);
           // return Json(Url.Action("AddEditAttachment", "Transit"));
        }

        public JsonResult GetAllAttachmentForShow(int Value1)
        {
            var sa = new JsonSerializerSettings();
            IEnumerable<Attachment> AttachmentList = new List<Attachment>();

            var attachments = _repository.GetAllAttachmentForShow(Value1);
        
            if (attachments.Count > 0)
            {



                AttachmentList = attachments.Select(x =>
                                new Attachment()
                                {
                                    Id = x.Id,
                                    Description = x.Description,
                                    PicUrl = x.PicUrl
                                    

                                });
            }
            return Json(AttachmentList, sa);
        }
        #endregion

    }
}