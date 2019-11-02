using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneUnit.Services;
using OneUnit.Areas.QC.Data;
using AutoMapper;
using OneUnit.Areas.QC.ViewModels;
using OneUnit.Areas.QC.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using OneUnit.Areas.Admin.Data.Entities;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Globalization;

namespace OneUnit.Areas.QC.Controllers
{
    [Area("QC")]
   // [Authorize(Roles = "Administrators")]
   
    public class QCController : Controller
    {
        private readonly IMailService _mailService;

        private readonly IQCRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<StoreUser> _userManager;

        public QCController(IMailService mailService,IQCRepository repository,IMapper mapper, UserManager<StoreUser> userManager)
        {
            _mailService = mailService;
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region ProcessName
        public IActionResult AllProcessName()
        {

            var results = _repository.GetAllProcessName();
            return View(results);
        }
       // [Authorize(Policy = "AddProcessName1")]
        [HttpGet]
        public IActionResult AddEditProcessName(int? id)
        {
            ProcessNameViewModel model = new ProcessNameViewModel();
            try
            {
                var processname = _repository.GetProcessNameById(id);
                ViewBag.Company = _repository.GetAllCompany();
                ViewBag.HasT = _repository.GetAllHasT();
                if (id.HasValue)
                {
                    model = _mapper.Map<ProcessName, ProcessNameViewModel>(processname);
                }
                // ViewBag.ProcessName = _repository.GetAllControlParameterType();
                return PartialView("~/Areas/QC/Views/QC/AddEditProcessName.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditProcessName(int? id, ProcessNameViewModel model)
        {
            //  ProcessNameViewModel model1 = new ProcessNameViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newProcessName = _mapper.Map<ProcessNameViewModel, ProcessName>(model);
                if (isNew)
                {
                    _repository.AddEntity(newProcessName);
                    _repository.SaveAll();
                }
                else
                {
                    ProcessName oldProcessName = _repository.GetProcessNameById(id);
                    oldProcessName.Name = newProcessName.Name;
                    oldProcessName.CompanyId = newProcessName.CompanyId;
                    oldProcessName.HasTId = newProcessName.HasTId;
                    // orderOld = newOrder;
                    //_repository.UpdateEntity(newOrder);

                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllProcessName");
        }
        [HttpGet]
        [Authorize(Policy = "DeleteProcessName")]
        public IActionResult DeleteProcessName(int id)
        {
            ProcessNameViewModel model = new ProcessNameViewModel();
            var processname = _repository.GetProcessNameById(id);

            model = _mapper.Map<ProcessName, ProcessNameViewModel>(processname);

            return PartialView("~/Areas/QC/Views/QC/DeleteProcessName.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteProcessName(int id, ProcessNameViewModel model)
        {

            ProcessName processname = _repository.GetProcessNameById(id);

            _repository.DeleteEntity(processname);

            _repository.SaveAll();
            return RedirectToAction("AllProcessName");
        }
        #endregion
        #region QualityDesign
        public IActionResult AllQualityDesign()
        {
            var results = _repository.GetAllQualityDesign();
           // var ProcessNumber = _repository.GetAllProcessName();
            return View(results);
        }


        [HttpGet("AddQualityDesign")]
        public IActionResult AddQualityDesign()
        {

            QualityDesignViewModel model = new QualityDesignViewModel();
            UsersQualityDesignViewModel Model1 = new UsersQualityDesignViewModel();
            Model1 = _repository.GetAllUser(); 
            try
            {
                ViewBag.ProcessName = _repository.GetAllProcessName();
                ViewBag.ControlParameter = _repository.GetAllControlParameter();
                ViewBag.ProcessType = _repository.GetAllProcessType();
                ViewBag.Shift = _repository.GetAllShift();
                ViewBag.Confirmation = _repository.GetAllConfirmation();
               // ViewBag.Tank = _repository.GetAllTank();
               // ViewBag.Storage = _repository.GetAllStorage();
               // ViewBag.Production = _repository.GetAllProduction();
               // ViewBag.ColumnNumber = _repository.GetAllColumnNumber();
               // ViewBag.SamplingLocation = _repository.GetAllSamplingLocation();
                ViewBag.QParameterStatus = _repository.GetAllQParameterStatus();
               // ViewBag.Sampler = Model1.Sampler;
              //  ViewBag.Tester = Model1.Tester;
               // ViewBag.ControllerUser = Model1.ControllerUser;
                //foreach (var user in _userManager.Users)
                //{
                //    Model1.Sampler.Add(user);
                //    Model1.Tester.Add(user);
                //    Model1.ControllerUser.Add(user);
                //}
                return View(model);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult EditQualityDesign(int? id)
        {

            QualityDesignViewModel model = new QualityDesignViewModel();
            try
            {
                var qualitydesign = _repository.GetQualityDesignById(id);
                model = _mapper.Map<QualityDesign, QualityDesignViewModel>(qualitydesign);
                ViewBag.ProcessName = _repository.GetAllProcessName();
                ViewBag.ControlParameter = _repository.GetAllControlParameter();
                ViewBag.Shift = _repository.GetAllShift();
                ViewBag.Confirmation = _repository.GetAllConfirmation();
               // ViewBag.Tank = _repository.GetAllTank();
                //ViewBag.Storage = _repository.GetAllStorage();
                //ViewBag.Production = _repository.GetAllProduction();
               // ViewBag.ColumnNumber = _repository.GetAllColumnNumber(); 
               // ViewBag.SamplingLocation = _repository.GetAllSamplingLocation();
                ViewBag.QParameterStatus = _repository.GetAllQParameterStatus();
                return View(model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }

        }
        [HttpPost("AddQualityDesign")]
        public IActionResult AddQualityDesign(int? id, QualityDesignViewModel model)
        {
            try
            {
                
               // if (ModelState.IsValid)
                //{

                    var newQualityDesign = _mapper.Map<QualityDesignViewModel,QualityDesign>(model);

                    _repository.AddEntity(newQualityDesign);
                    _repository.SaveAll();


                    return RedirectToAction("AllQualityDesign");
                //}
               // return View(model);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult EditQualityDesign(int? id, QualityDesignViewModel model)
        {

            QualityDesignViewModel model1 = new QualityDesignViewModel();

            if (ModelState.IsValid)
            {
               

                var newQualityDesign = _mapper.Map<QualityDesignViewModel, QualityDesign>(model);
                    QualityDesign oldQualityDesign = _repository.GetQualityDesignById(id);
                    oldQualityDesign.ProcessNameId = newQualityDesign.ProcessNameId;
                    oldQualityDesign.ControlParameterId = newQualityDesign.ControlParameterId;
                    oldQualityDesign.ValueLimit = newQualityDesign.ValueLimit;
                    oldQualityDesign.DateQD = newQualityDesign.DateQD;
                    oldQualityDesign.ShiftId = newQualityDesign.ShiftId;
                    oldQualityDesign.Confirmation = newQualityDesign.Confirmation;
                    oldQualityDesign.QParameterStatusId = newQualityDesign.QParameterStatusId;

                _repository.SaveAll();
          
                return RedirectToAction("AllQualityDesign");
            }
            return Json(new { Result = "OK" });
        }
        [HttpGet]
        public IActionResult DeleteQualityDesign(int id)
        {
            QualityDesignViewModel model = new QualityDesignViewModel();

            var qualitydesign = _repository.GetQualityDesignById(id);

            model = _mapper.Map<QualityDesign, QualityDesignViewModel>(qualitydesign);

            return PartialView("~/Areas/QC/Views/QC/DeleteQualityDesign.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteQualityDesign(int id, QualityDesignViewModel model)
        {

            QualityDesign qualitydesign = _repository.GetQualityDesignById(id);

            _repository.DeleteEntity(qualitydesign);

            _repository.SaveAll();
            return RedirectToAction("QualityDesign");
        }
        [HttpPost("PassDate")]
        public ActionResult  PassDate(string TempDate)
        {
            TempData["PassDate"] = TempDate;

            //ViewBag.DateForQualityDesign = TempDate;
            //return RedirectToAction("DynamicFormQualityDesign");
            return Json(Url.Action("DynamicFormQualityDesign", "QC"));
        
        }
        #endregion
        #region DynamicQualityDesign
        // GET: Home
        public ActionResult DynamicFormQualityDesign()
        {

            return View();
        }

        public ActionResult DynamicFormQualityDesignTest()
        {
            return View();
        }
        [HttpGet("GetShiftWithJson")]
        public JsonResult GetShiftWithJson()
        {
            
            var sa = new JsonSerializerSettings();
            IEnumerable<Shift> IShift = _repository.GetAllShift();
            return new JsonResult ( IShift, sa );
        }
        [HttpGet("GetHourWithJson")]
        public JsonResult GetHourWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<Hour> IHour = _repository.GetAllHour();
            return new JsonResult(IHour, sa);
        }
        [HttpGet("GetMinuteWithJson")]
        public JsonResult GetMinuteWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<Minute> IMinute = _repository.GetAllMinute();
            return new JsonResult(IMinute, sa);
        }
        [HttpGet("GetStorageWithJson")]
        public JsonResult GetStorageWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<Storage> IStorage = _repository.GetAllStorage();
            return new JsonResult(IStorage, sa);
        }
        [HttpGet("GetCompanyWithJson")]
        public JsonResult GetCompanyWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<Company> ICompany = _repository.GetAllCompany();
            return new JsonResult(ICompany, sa);
        }
        [HttpGet("GetSamplingLocationWithJson")]
        public JsonResult GetSamplingLocationWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<SamplingLocation> ISamplingLocation = _repository.GetJustSamplingLocation();
            return new JsonResult(ISamplingLocation, sa);
        }
        [HttpGet("GetProcessNameWithJson")]
        public JsonResult GetProcessNameWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<ProcessName> IProcessName = _repository.GetJustProcessName();
            return new JsonResult(IProcessName, sa);
        }
        [HttpGet("GetQParameterStatusWithJson")]
        public JsonResult GetQParameterStatusWithJson()
        {
            IEnumerable<QParameterStatus> modelList = new List<QParameterStatus>();
            var sa = new JsonSerializerSettings();
            IEnumerable<QParameterStatus> QParameterStatusWithId = _repository.GetAllQParameterStatus();
            modelList = QParameterStatusWithId.Select(x =>
                new QParameterStatus()
                {
                    Id = x.Id,
                    Name = x.Name,
                }
                );
            return Json(modelList, sa);
        }

        [HttpGet("GetConfirmationWithJson")]
        public JsonResult GetConfirmationWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<Confirmation> IConfirmation = _repository.GetAllConfirmation();
            return new JsonResult(IConfirmation, sa);
        }
        [HttpGet("GetTypeOfCornWithJson")]
        public JsonResult GetTypeOfCornWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<TypeOfCorn> ITypeOfCorn = _repository.GetAllTypeOfCorn();
            return new JsonResult(ITypeOfCorn, sa);
        }
        [HttpGet("GetControlParameterWithJson")]
        public JsonResult GetControlParameterWithJson(int? Value1 ,int? Value2)
        {
            IEnumerable<ControlParameter> modelList = new List<ControlParameter>();
            if (Value1 != null && Value2 != null)
            {
                var sa = new JsonSerializerSettings();
                IEnumerable<ControlParameter> ControlParameterWithId = _repository.GetControlParameter(Value1, Value2);
                modelList = ControlParameterWithId.Select(x=>
                    new ControlParameter()
                    {
                        Id =x.Id,
                        Name =x.Name +" "+"("+x.SamplingLocation.Name +")",
                    }
                    );
                return Json(modelList, sa);
            }
            else
            {
                var sa = new JsonSerializerSettings();
                IEnumerable<ControlParameter> IControlParameter = _repository.GetControlParameter(Value1, Value2);
                return new JsonResult(IControlParameter, sa);
            }
        }
        public DateTime ConvertShamsiToMiladi(string SampleDate)
        {
            PersianCalendar pc = new PersianCalendar();
            string[] ArrayDate = SampleDate.Split('/');
            string jj = ArrayDate[0].PersianToEnglish();
            Int32 year = Convert.ToInt32(jj);
            jj = ArrayDate[1].PersianToEnglish();
            Int32 month = Convert.ToInt32(jj);
            jj = ArrayDate[2].PersianToEnglish();
            Int32 day = Convert.ToInt32(jj);
            DateTime dt = new DateTime(year, month, day, pc);
            return dt;
        }
        public string ConvertMiladiToShamsi(DateTime SampleDate)
        {
            PersianCalendar pc = new PersianCalendar();
            string[] ArrayDate;
            string dateCurrnetTemp = string.Format("{0}/{1}/{2}", pc.GetYear(SampleDate), pc.GetMonth(SampleDate), pc.GetDayOfMonth(SampleDate));

            ArrayDate = dateCurrnetTemp.Split('/');
            string yearT = ArrayDate[0].EnglishToPersian();

            string monthT = ArrayDate[1].EnglishToPersian();
            if (monthT.Length == 1)
                monthT = "۰" + monthT;
            string dayT = ArrayDate[2].EnglishToPersian();
            if (dayT.Length == 1)
                dayT = "۰" + dayT;
            return  yearT + "/" + monthT + "/" + dayT;
        }
        [HttpGet("GetQualityDesignForTypeOfCorn")]
        public JsonResult GetQualityDesignForTypeOfCorn(string dateCurrnet, int? typeOfCornId)
        {

            DateTime dt;
            Int32 totalHour = 0;
            string dateTemp;
            DateTime dt1;
            for (int i = 0; i <= 3; i++)
            {
                dt = ConvertShamsiToMiladi(dateCurrnet);
                dt1 =  dt.AddDays(-i);
                dateTemp = ConvertMiladiToShamsi(dt1);
                totalHour +=GetTotalHour(dateTemp);
            }
            totalHour = totalHour / 24;
            totalHour = totalHour + 3;
            dt = ConvertShamsiToMiladi(dateCurrnet);
            dt1 = dt.AddDays(-totalHour);
            dateCurrnet = ConvertMiladiToShamsi(dt1);
            IEnumerable<QualityDesign> modelList = new List<QualityDesign>();
            if (dateCurrnet != null && typeOfCornId != null)
            {
                var sa = new JsonSerializerSettings();
                IEnumerable<QualityDesign> QualityDesignWithId = _repository.GetQualityDesignForTypeOfCorn(dateCurrnet, 44);
                modelList = QualityDesignWithId.Select(x =>
                    new QualityDesign()
                    {
                        Id = x.Id,
                        TypeOfCornId = x.TypeOfCornId
                    }
                    );
                return Json(modelList, sa);
            }
            else
            {
                var sa = new JsonSerializerSettings();
                IEnumerable<QualityDesign> QualityDesignWithId = _repository.GetQualityDesignForTypeOfCorn(dateCurrnet, typeOfCornId);
                return new JsonResult(QualityDesignWithId, sa);
            }
        }
        [HttpGet("GetProcessNameWithCompanyWithJson")]
        public JsonResult GetProcessNameWithCompanyWithJson(int? Value1)
        {
            IEnumerable<ProcessName> modelList = new List<ProcessName>();
            if (Value1 != null )
            {
                var sa = new JsonSerializerSettings();
                IEnumerable<ProcessName> ProcessNameWithCompanyWithId = _repository.GetProcessnameWithCompany(Value1);
                modelList = ProcessNameWithCompanyWithId.Select(x =>
                    new ProcessName()
                    {
                        Id = x.Id,
                        Name = x.Name
                    }
                    );
                return Json(modelList, sa);
            }
            else
            {

                var sa = new JsonSerializerSettings();
                IEnumerable<ProcessName> IProcessName = _repository.GetProcessnameWithCompany(Value1);
                return new JsonResult(IProcessName, sa);
            }


        }
        //تابع زیر حد بالا و حد پایین پارامتر کنترلی مورد نظر را برمی گرداند
        [HttpGet("GetOneRecoredWithControlParametreId")]
        public JsonResult GetOneRecoredWithControlParametreId(int Id)
        {
            if (Id > 0)
            {
                var sa = new JsonSerializerSettings();

                ControlParameter OneRecoredId = _repository.GetOneRecoredWithControlParametreId(Id);

                return Json(new { Id = OneRecoredId.Id, UpperLimit = OneRecoredId.UpperLimit, BottomLimit = OneRecoredId.BottomLimit, ProcessTypeId = OneRecoredId.ProcessTypeId }, sa);
            }
            return null;
        }
        //------------------کد زیر  برای مشخص کردن فرایندهای کا داری استورج هستند استفاده می شود--------------------------------------
        [HttpGet("GetOneRecoredWithProcessNameId")]
        public JsonResult GetOneRecoredWithProcessNameId(int Id)
        {
            if (Id > 0)
            {
                var sa = new JsonSerializerSettings();

                ProcessName OneRecoredId = _repository.GetOneRecoredWithProcessNameId(Id);

                return Json(new { Id = OneRecoredId.Id, Name = OneRecoredId.Name, HasTId = OneRecoredId.HasTId }, sa);
            }
            return null;
        }
        [HttpGet("GetOneRecoredWithQParameterStatusId")]
        public JsonResult GetOneRecoredWithQParameterStatusId(int Id)
        {
            if (Id > 0)
            {
                var sa = new JsonSerializerSettings();

                QParameterStatus OneRecoredId = _repository.GetQParameterStatusById(Id);

                return Json(new { Id = OneRecoredId.Id, ConfirmationId = OneRecoredId.ConfirmationId }, sa);
            }
            else
            {
                return null;
            }
        }
        [HttpPost("SaveQD")]
        public JsonResult SaveQD(int Id,[FromBody] List<QualityDesignViewModel> QualityDesignViewModels)
        {
            //bool status = false;


            //var isValidModel = true;
            var sa = new JsonSerializerSettings();
            //if (isValidModel)
            //{

            foreach (QualityDesignViewModel qualitydesignviewmodel in QualityDesignViewModels)
            {
                var newQualityDesign = _mapper.Map<QualityDesignViewModel, QualityDesign>(qualitydesignviewmodel);
                if (_repository.CheckExistenceId(qualitydesignviewmodel.Id))
                {
                    QualityDesign oldQualityDesign = _repository.GetQualityDesignById(qualitydesignviewmodel.Id);
                    oldQualityDesign.DateQD = newQualityDesign.DateQD;
                    oldQualityDesign.ShiftId = newQualityDesign.ShiftId;
                    oldQualityDesign.RegistrationTime = newQualityDesign.RegistrationTime;
                    oldQualityDesign.ProcessNameId = newQualityDesign.ProcessNameId;
                    oldQualityDesign.SamplingLocationId = newQualityDesign.SamplingLocationId;
                    oldQualityDesign.ValueLimit = newQualityDesign.ValueLimit;
                    oldQualityDesign.QParameterStatusId = newQualityDesign.QParameterStatusId;
                    oldQualityDesign.ControlParameterId = newQualityDesign.ControlParameterId;
                    oldQualityDesign.ConfirmationId = newQualityDesign.ConfirmationId;
                    oldQualityDesign.StorageId = newQualityDesign.StorageId;
                    oldQualityDesign.TransferTimeToStorage = newQualityDesign.TransferTimeToStorage;
                    oldQualityDesign.Description = newQualityDesign.Description;
                    _repository.SaveAll();
                }
                else
                {

                    _repository.AddEntity(newQualityDesign);
                    _repository.SaveAll();
                }

            }
            return Json(true,sa);


        }
        public JsonResult GetAllQualityDesignWithDate1(string DateQD)
        {
            var sa = new JsonSerializerSettings();
            List<QualityDesign> QualityDesignList = new List<QualityDesign>();
            QualityDesignList = _repository.GetAllQualityDesignWithDate(DateQD);
            return Json(new { QualityDesignList = QualityDesignList },sa);
        }
        public JsonResult GetAllQualityDesignWithDate(string DateQD)
        {
            var sa = new JsonSerializerSettings();
            IEnumerable<QualityDesign> QualityDesignList = new List<QualityDesign>();

            var QualityDesigns = _repository.GetAllQualityDesignWithDate(DateQD);

            if (QualityDesigns.Count > 0 && DateQD != null)
            {



                QualityDesignList = QualityDesigns.Select(x =>
                                new QualityDesign()
                                {
                                    Id = x.Id,
                                    DateQD = x.DateQD,
                                    ShiftId = x.ShiftId,
                                    Shift = x.Shift,
                                    ProcessNameId = x.ProcessNameId,
                                    ProcessName = new ProcessName() { Name = x.ProcessName.Name },
                                    ValueLimit = x.ValueLimit,
                                    QParameterStatusId = x.QParameterStatusId,
                                    QParameterStatus = new QParameterStatus() { Name =  x.QParameterStatus==null ? " " : x.QParameterStatus.Name },
                                    ControlParameterId = x.ControlParameterId,
                                    ControlParameter = new ControlParameter() { Name = x.ControlParameter.Name },
                                    ConfirmationId = x.ConfirmationId,
                                    Confirmation = new Confirmation() { Name = x.Confirmation.Name },
                                    SamplingLocation = new SamplingLocation() { Name = x.SamplingLocation.Name},
                                    Company = new Company() { Name = x.Company.Name },
                                    RegistrationTime = x.RegistrationTime,
                                    Description = x.Description

                                });
            }
            return Json(QualityDesignList, sa);
        }
        public JsonResult GetAllQualityDesignForShow(string Value1,int Value2,int Value3,int Value4,string Value5,byte Value6)
        {
            var sa = new JsonSerializerSettings();
            IEnumerable<QualityDesign> QualityDesignList = new List<QualityDesign>();

            var QualityDesigns = _repository.GetAllQualityDesignForShow(Value1, Value2, Value3, Value4, Value5,Value6);

            if (QualityDesigns.Count > 0 )
            {



                QualityDesignList = QualityDesigns.Select(x =>
                                new QualityDesign()
                                {
                                    Id = x.Id,
                                    DateQD = x.DateQD,
                                    ShiftId = x.ShiftId,
                                    Shift = x.Shift,
                                    ProcessNameId = x.ProcessNameId,
                                    ProcessName = new ProcessName() { Name = x.ProcessName.Name },
                                    ValueLimit = x.ValueLimit,
                                    QParameterStatusId = x.QParameterStatusId,
                                    QParameterStatus = new QParameterStatus() { Name = x.QParameterStatus == null ? " " : x.QParameterStatus.Name },
                                    ControlParameterId = x.ControlParameterId,
                                    ControlParameter = new ControlParameter() { Name = x.ControlParameter.Name },
                                    ConfirmationId = x.ConfirmationId,
                                    Confirmation = new Confirmation() { Name = x.Confirmation.Name },
                                    SamplingLocation = new SamplingLocation() { Name = x.SamplingLocation.Name },
                                    Company = new Company() { Name = x.Company.Name },
                                    RegistrationTime = x.RegistrationTime,
                                    Description = x.Description

                                });
            }
            return Json(QualityDesignList, sa);
        }
        [HttpPost("AddQualityDesignList")]
        public JsonResult AddQualityDesignList([FromBody] List<QualityDesignViewModel> qualitydesigns)
        {

            //Truncate Table to delete all old records.
            //  entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

            //Check for NULL.
            if (qualitydesigns == null)
            {
                qualitydesigns = new List<QualityDesignViewModel>();
            }

            //Loop and insert records.
            foreach (QualityDesignViewModel qualitydesign in qualitydesigns)
            {
                var newQualityDesign = _mapper.Map<QualityDesignViewModel, QualityDesign>(qualitydesign);
                _repository.AddEntity(newQualityDesign);
                _repository.SaveAll();
            }
       

            return Json(new
            {
                redirectUrl = Url.Action("AllQualityDesign", "QC"),
                isRedirect = true
            });

        }
        #endregion
        #region ControlParameter
        public IActionResult AllControlParameter()
        {
            var results = _repository.GetAllControlParameter();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditControlParameter(int? id)
        {
            IEnumerable<SamplingLocation> SamplingLocationList = new List<SamplingLocation>();
            var SamplingLocations = _repository.GetAllSamplingLocation();
            SamplingLocationList = SamplingLocations.Select(x =>
                new SamplingLocation()
                {

                    Id = x.Id,
                    Name = x.Name + " (" + x.Company.Name + " )" ,

                });
            ControlParameterViewModel model = new ControlParameterViewModel();
            try
            {
                var controlparameter = _repository.GetControlParameterById(id);
                ViewBag.ProcessType = _repository.GetAllProcessType();
                ViewBag.ProcessName = _repository.GetAllProcessName();
                ViewBag.DegreeOfImportance = _repository.GetAllDegreeOfImportance();
                ViewBag.UnitOfMeasurement = _repository.GetAllUnitOfMeasurement();
                ViewBag.SamplingLocation = SamplingLocationList;
                ViewBag.SampleValue = _repository.GetAllSampleValue();
                ViewBag.TestValue = _repository.GetAllTestValue();
                ViewBag.OrganizationalUnit = _repository.GetAllOrganizationalUnit();
                if (id.HasValue)
                {
                    model = _mapper.Map<ControlParameter, ControlParameterViewModel>(controlparameter);
                }
                // ViewBag.ProcessName = _repository.GetAllControlParameterType();
                return PartialView("~/Areas/QC/Views/QC/AddEditControlParameter.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        //[ActionName("AddEditControlParameter")]
        public IActionResult AddEditControlParameter(int? id, ControlParameterViewModel model)
        {
            ControlParameterViewModel model1 = new ControlParameterViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newControlParameter = _mapper.Map<ControlParameterViewModel, ControlParameter>(model);
                if (isNew)
                {
                    _repository.AddEntity(newControlParameter);
                    _repository.SaveAll();
                }
                else
                {
                    ControlParameter oldControlParameter = _repository.GetControlParameterById(id);
                    oldControlParameter.Name = newControlParameter.Name;
                    oldControlParameter.BottomLimit = newControlParameter.BottomLimit;
                    oldControlParameter.UpperLimit = newControlParameter.UpperLimit;
                    oldControlParameter.ProcessTypeId = newControlParameter.ProcessTypeId;
                    oldControlParameter.ProcessNameId = newControlParameter.ProcessNameId;
                    oldControlParameter.DegreeOfImportanceId = newControlParameter.DegreeOfImportanceId;
                    oldControlParameter.UnitOfMeasurementId = newControlParameter.UnitOfMeasurementId;
                    oldControlParameter.SamplingLocationId = newControlParameter.SamplingLocationId;
                    oldControlParameter.SamplingFrequencyId = newControlParameter.SamplingFrequencyId;
                    oldControlParameter.SampleValueId = newControlParameter.SampleValueId;
                    oldControlParameter.TestValueId = newControlParameter.TestValueId;
                    oldControlParameter.RActionId = newControlParameter.RActionId;
                    _repository.SaveAll();
                }
            }

             return RedirectToAction("AllControlParameter");
            //return RedirectToAction("AddEditControlParameter", model1);
        }
        [HttpGet]
        public IActionResult DeleteControlParameter(int id)
        {
            ControlParameterViewModel model = new ControlParameterViewModel();
            var controlparameter = _repository.GetControlParameterById(id);

            model = _mapper.Map<ControlParameter, ControlParameterViewModel>(controlparameter);

            return PartialView("~/Areas/QC/Views/QC/DeleteControlParameter.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteControlParameter(int id, ControlParameterViewModel model)
        {

            ControlParameter controlparameter = _repository.GetControlParameterById(id);

            _repository.DeleteEntity(controlparameter);

            _repository.SaveAll();
            return RedirectToAction("AllControlParameter");
        }
        #endregion
        #region DynamicControlParameter
        // GET: Home
        public ActionResult DynamicControlParameter()
        {
            return View();
        }
        [HttpGet("GetProcessTypeWithJson")]
        public JsonResult GetProcessTypeWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<ProcessType> IProcessType = _repository.GetAllProcessType();
            return new JsonResult(IProcessType, sa);
        }
        [HttpGet("GetDegreeOfImportanceWithJson")]
        public JsonResult GetDegreeOfImportanceWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<DegreeOfImportance> IDegreeOfImportance = _repository.GetAllDegreeOfImportance();
            return new JsonResult(IDegreeOfImportance, sa);
        }
        [HttpGet("GetUnitOfMeasurementWithJson")]
        public JsonResult GetUnitOfMeasurementWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<UnitOfMeasurement> IUnitOfMeasurement = _repository.GetAllUnitOfMeasurement();
            return new JsonResult(IUnitOfMeasurement, sa);
        }

        [HttpGet("GetSampleValueWithJson")]
        public JsonResult GetSampleValueWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<SampleValue> ISampleValue = _repository.GetAllSampleValue();
            return new JsonResult(ISampleValue, sa);
        }
        [HttpGet("GetTestValueWithJson")]
        public JsonResult GetTestValueWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<TestValue> ITestValue = _repository.GetAllTestValue();
            return new JsonResult(ITestValue, sa);
        }
        [HttpGet("GetOrganizationalUnitWithJson")]
        public JsonResult GetOrganizationalUnitWithJson()
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<OrganizationalUnit> IOrganizationalUnit = _repository.GetAllOrganizationalUnit();
            return new JsonResult(IOrganizationalUnit, sa);
        }
        [HttpPost("AddControlParameterList")]
        public JsonResult AddControlParameterList([FromBody] List<ControlParameterViewModel> controlparameters)
        {

            //Truncate Table to delete all old records.
            //  entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

            //Check for NULL.
            if (controlparameters == null)
            {
                controlparameters = new List<ControlParameterViewModel>();
            }

            //Loop and insert records.
            foreach (ControlParameterViewModel controlparameter in controlparameters)
            {
                var newControlParameter = _mapper.Map<ControlParameterViewModel, ControlParameter>(controlparameter);
                _repository.AddEntity(newControlParameter);
                _repository.SaveAll();
            }
            bool insertedRecords = true;
           // return Json(insertedRecords);
            // return RedirectToAction("AllControlParameter");
            return Json(new
            {
                redirectUrl = Url.Action("AllControlParameter", "QC"),
                isRedirect = true
            });
        }
       [HttpGet("GetSamplingLocationWithCompanyWithJson")]
        public JsonResult GetSamplingLocationWithCompanyWithJson(int? Value1)
        {
            IEnumerable<SamplingLocation> modelList = new List<SamplingLocation>();
            if (Value1 != null )
            {
                var sa = new JsonSerializerSettings();
                IEnumerable<SamplingLocation> SamplingLocationWithCompanyWithId = _repository.GetSamplingLocationWithCompany(Value1);
                modelList = SamplingLocationWithCompanyWithId.Select(x =>
                    new SamplingLocation()
                    {
                        Id = x.Id,
                        Name = x.Name
                    }
                    );
                return Json(modelList, sa);
            }
            else
            {

                var sa = new JsonSerializerSettings();
                IEnumerable<SamplingLocation> ISamplingLocation = _repository.GetSamplingLocationWithCompany(Value1);
                return new JsonResult(ISamplingLocation, sa);
            }


        }
        #endregion
        #region DegreeOfImportance
        public IActionResult AllDegreeOfImportance()
        {
            var results = _repository.GetAllDegreeOfImportance();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditDegreeOfImportance(int? id)
        {
            DegreeOfImportanceViewModel model = new DegreeOfImportanceViewModel();
            try
            {
                var degreeofimportance = _repository.GetDegreeOfImportanceById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<DegreeOfImportance, DegreeOfImportanceViewModel>(degreeofimportance);
                }
                // ViewBag.ProcessName = _repository.GetAllControlParameterType();
                return PartialView("~/Areas/QC/Views/QC/AddEditDegreeOfImportance.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditDegreeOfImportance(int? id, DegreeOfImportanceViewModel model)
        {
            DegreeOfImportanceViewModel model1 = new DegreeOfImportanceViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newDegreeOfImportance = _mapper.Map<DegreeOfImportanceViewModel, DegreeOfImportance>(model);
                if (isNew)
                {
                    _repository.AddEntity(newDegreeOfImportance);
                    _repository.SaveAll();
                }
                else
                {
                    DegreeOfImportance oldDegreeOfImportance = _repository.GetDegreeOfImportanceById(id);
                    oldDegreeOfImportance.Name = newDegreeOfImportance.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllDegreeOfImportance");
        }
        [HttpGet]
        public IActionResult DeleteDegreeOfImportance(int id)
        {
            DegreeOfImportanceViewModel model = new DegreeOfImportanceViewModel();
            var degreeofimportance = _repository.GetDegreeOfImportanceById(id);

            model = _mapper.Map<DegreeOfImportance, DegreeOfImportanceViewModel>(degreeofimportance);

            return PartialView("~/Areas/QC/Views/QC/DeleteDegreeOfImportance.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteDegreeOfImportance(int id, DegreeOfImportanceViewModel model)
        {

            DegreeOfImportance degreeofimportance = _repository.GetDegreeOfImportanceById(id);

            _repository.DeleteEntity(degreeofimportance);

            _repository.SaveAll();
            return RedirectToAction("AllDegreeOfImportance");
        }
        #endregion
        #region UnitOfMeasurement
        public IActionResult AllUnitOfMeasurement()
        {
            var results = _repository.GetAllUnitOfMeasurement();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditUnitOfMeasurement(int? id)
        {
            UnitOfMeasurementViewModel model = new UnitOfMeasurementViewModel();
            try
            {
                var unitofmeasurement = _repository.GetUnitOfMeasurementById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<UnitOfMeasurement, UnitOfMeasurementViewModel>(unitofmeasurement);
                }
                // ViewBag.ProcessName = _repository.GetAllControlParameterType();
                return PartialView("~/Areas/QC/Views/QC/AddEditUnitOfMeasurement.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditUnitOfMeasurement(int? id, UnitOfMeasurementViewModel model)
        {
            UnitOfMeasurementViewModel model1 = new UnitOfMeasurementViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newUnitOfMeasurement = _mapper.Map<UnitOfMeasurementViewModel, UnitOfMeasurement>(model);
                if (isNew)
                {
                    _repository.AddEntity(newUnitOfMeasurement);
                    _repository.SaveAll();
                }
                else
                {
                    UnitOfMeasurement oldUnitOfMeasurement = _repository.GetUnitOfMeasurementById(id);
                    oldUnitOfMeasurement.Name = newUnitOfMeasurement.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllUnitOfMeasurement");
        }
        [HttpGet]
        public IActionResult DeleteUnitOfMeasurement(int id)
        {
            UnitOfMeasurementViewModel model = new UnitOfMeasurementViewModel();
            var unitofmeasurement = _repository.GetUnitOfMeasurementById(id);

            model = _mapper.Map<UnitOfMeasurement, UnitOfMeasurementViewModel>(unitofmeasurement);

            return PartialView("~/Areas/QC/Views/QC/DeleteUnitOfMeasurement.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteUnitOfMeasurement(int id, UnitOfMeasurementViewModel model)
        {

            UnitOfMeasurement unitufmeasurement = _repository.GetUnitOfMeasurementById(id);

            _repository.DeleteEntity(unitufmeasurement);

            _repository.SaveAll();
            return RedirectToAction("AllUnitOfMeasurement");
        }
        #endregion
        #region SamplingLocation
        public IActionResult AllSamplingLocation()
        {
            var results = _repository.GetAllSamplingLocation();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditSamplingLocation(int? id)
        {
            SamplingLocationViewModel model = new SamplingLocationViewModel();
            IEnumerable<ProcessName> ProcessNameList = new List<ProcessName>();
            var ProcessNames = _repository.GetAllProcessName();
            try
            {

                ProcessNameList = ProcessNames.Select(x =>
                new ProcessName()
                {

                        Id = x.Id,
                        Name = x.Name +" (" +x.Company.Name +" )",

                });

                var samplinglocation = _repository.GetSamplingLocationById(id);

                ViewBag.Company = _repository.GetAllCompany();
                ViewBag.ProcessName = ProcessNameList;

                if (id.HasValue)
                {
                    model = _mapper.Map<SamplingLocation, SamplingLocationViewModel>(samplinglocation);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditSamplingLocation.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditSamplingLocation(int? id, SamplingLocationViewModel model)
        {
            SamplingLocationViewModel model1 = new SamplingLocationViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newSamplingLocation = _mapper.Map<SamplingLocationViewModel, SamplingLocation>(model);
                if (isNew)
                {
                    _repository.AddEntity(newSamplingLocation);
                    _repository.SaveAll();
                }
                else
                {
                    SamplingLocation oldSamplingLocation = _repository.GetSamplingLocationById(id);
                    oldSamplingLocation.Name = newSamplingLocation.Name;
                    oldSamplingLocation.CompanyId = newSamplingLocation.CompanyId;
                    oldSamplingLocation.ProcessNameId = newSamplingLocation.ProcessNameId;
                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllSamplingLocation");
        }
        [HttpGet]
        public IActionResult DeleteSamplingLocation(int id)
        {
            SamplingLocationViewModel model = new SamplingLocationViewModel();
            var samplinglocation = _repository.GetSamplingLocationById(id);

            model = _mapper.Map<SamplingLocation, SamplingLocationViewModel>(samplinglocation);

            return PartialView("~/Areas/QC/Views/QC/DeleteSamplingLocation.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteSamplingLocation(int id, SamplingLocationViewModel model)
        {

            SamplingLocation samplinglocation = _repository.GetSamplingLocationById(id);

            _repository.DeleteEntity(samplinglocation);

            _repository.SaveAll();
            return RedirectToAction("AllSamplingLocation");
        }

        [HttpGet("GetSamplingLocationWithProcessNameWithJson")]
        public JsonResult GetSamplingLocationWithProcessNameWithJson(int? Value1)
        {
            IEnumerable<SamplingLocation> modelList = new List<SamplingLocation>();
            if (Value1 != null)
            {
                var sa = new JsonSerializerSettings();
                IEnumerable<SamplingLocation> SamplingLocationWithProcessNameWithId = _repository.GetSamplingLocationWithProcessName(Value1);
                modelList = SamplingLocationWithProcessNameWithId.Select(x =>
                    new SamplingLocation()
                    {
                        Id = x.Id,
                        Name = x.Name
                    }
                    );
                return Json(modelList, sa);
            }
            else
            {

                var sa = new JsonSerializerSettings();
                IEnumerable<SamplingLocation> ISamplingLocation = _repository.GetSamplingLocationWithProcessName(Value1);
                return new JsonResult(ISamplingLocation, sa);
            }


        }
        #endregion
        #region SampleValue
        public IActionResult AllSampleValue()
        {
            var results = _repository.GetAllSampleValue();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditSampleValue(int? id)
        {
            SampleValueViewModel model = new SampleValueViewModel();
            try
            {
                var samplevalue = _repository.GetSampleValueById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<SampleValue, SampleValueViewModel>(samplevalue);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditSampleValue.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditSampleValue(int? id, SampleValueViewModel model)
        {
            SampleValueViewModel model1 = new SampleValueViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newSampleValue = _mapper.Map<SampleValueViewModel, SampleValue>(model);
                if (isNew)
                {
                    _repository.AddEntity(newSampleValue);
                    _repository.SaveAll();
                }
                else
                {
                    SampleValue oldSampleValue = _repository.GetSampleValueById(id);
                    oldSampleValue.Name = newSampleValue.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllSampleValue");
        }
        [HttpGet]
        public IActionResult DeleteSampleValue(int id)
        {
            SampleValueViewModel model = new SampleValueViewModel();
            var samplevalue = _repository.GetSampleValueById(id);

            model = _mapper.Map<SampleValue, SampleValueViewModel>(samplevalue);

            return PartialView("~/Areas/QC/Views/QC/DeleteSampleValue.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteSampleValue(int id, SampleValueViewModel model)
        {

            SampleValue samplevalue = _repository.GetSampleValueById(id);

            _repository.DeleteEntity(samplevalue);

            _repository.SaveAll();
            return RedirectToAction("AllSampleValue");
        }
        #endregion
        #region TestValue
        public IActionResult AllTestValue()
        {
            var results = _repository.GetAllTestValue();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditTestValue(int? id)
        {
            TestValueViewModel model = new TestValueViewModel();
            try
            {
                var testvalue = _repository.GetTestValueById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<TestValue, TestValueViewModel>(testvalue);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditTestValue.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditTestValue(int? id, TestValueViewModel model)
        {
            TestValueViewModel model1 = new TestValueViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newTestValue = _mapper.Map<TestValueViewModel, TestValue>(model);
                if (isNew)
                {
                    _repository.AddEntity(newTestValue);
                    _repository.SaveAll();
                }
                else
                {
                    TestValue oldTestValue = _repository.GetTestValueById(id);
                    oldTestValue.Name = newTestValue.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllTestValue");
        }
        [HttpGet]
        public IActionResult DeleteTestValue(int id)
        {
            TestValueViewModel model = new TestValueViewModel();
            var testvalue = _repository.GetTestValueById(id);

            model = _mapper.Map<TestValue, TestValueViewModel>(testvalue);

            return PartialView("~/Areas/QC/Views/QC/DeleteTestValue.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteTestValue(int id, TestValueViewModel model)
        {

            TestValue testvalue = _repository.GetTestValueById(id);

            _repository.DeleteEntity(testvalue);

            _repository.SaveAll();
            return RedirectToAction("AllTestValue");
        }
        #endregion
        #region ProcessType
        public IActionResult AllProcessType()
        {
            var results = _repository.GetAllProcessType();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditProcessType(int? id)
        {
            ProcessTypeViewModel model = new ProcessTypeViewModel();
            try
            {
                var processtype = _repository.GetProcessTypeById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<ProcessType, ProcessTypeViewModel>(processtype);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditProcessType.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditProcessType(int? id, ProcessTypeViewModel model)
        {
            ProcessTypeViewModel model1 = new ProcessTypeViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newProcessType = _mapper.Map<ProcessTypeViewModel, ProcessType>(model);
                if (isNew)
                {
                    _repository.AddEntity(newProcessType);
                    _repository.SaveAll();
                }
                else
                {
                    ProcessType oldProcessType = _repository.GetProcessTypeById(id);
                    oldProcessType.Name = newProcessType.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllProcessType");
        }
        [HttpGet]
        public IActionResult DeleteProcessType(int id)
        {
            ProcessTypeViewModel model = new ProcessTypeViewModel();
            var processtype = _repository.GetProcessTypeById(id);

            model = _mapper.Map<ProcessType, ProcessTypeViewModel>(processtype);

            return PartialView("~/Areas/QC/Views/QC/DeleteProcessType.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteProcessType(int id, TestValueViewModel model)
        {

            ProcessType processtype = _repository.GetProcessTypeById(id);

            _repository.DeleteEntity(processtype);

            _repository.SaveAll();
            return RedirectToAction("AllProcessType");
        }
        #endregion
        #region Day
        public IActionResult AllDay()
        {
            var results = _repository.GetAllDay();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditDay(int? id)
        {
            DayViewModel model = new DayViewModel();
            try
            {
                var day = _repository.GetDayById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Day, DayViewModel>(day);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditDay.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditDay(int? id, DayViewModel model)
        {
            DayViewModel model1 = new DayViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newDay = _mapper.Map<DayViewModel, Day>(model);
                if (isNew)
                {
                    _repository.AddEntity(newDay);
                    _repository.SaveAll();
                }
                else
                {
                    Day oldDay = _repository.GetDayById(id);
                    oldDay.Name = newDay.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllDay");
        }
        [HttpGet]
        public IActionResult DeleteDay(int id)
        {
            DayViewModel model = new DayViewModel();
            var day = _repository.GetDayById(id);

            model = _mapper.Map<Day,DayViewModel>(day);

            return PartialView("~/Areas/QC/Views/QC/DeleteDay.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteDay(int id, DayViewModel model)
        {

            Day day = _repository.GetDayById(id);

            _repository.DeleteEntity(day);

            _repository.SaveAll();
            return RedirectToAction("AllDay");
        }
        #endregion
        #region Year
        public IActionResult AllYear()
        {
            var results = _repository.GetAllYear();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditYear(int? id)
        {
            YearViewModel model = new YearViewModel();
            try
            {
                var year = _repository.GetYearById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Year, YearViewModel>(year);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditYear.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditYear(int? id, YearViewModel model)
        {
            YearViewModel model1 = new YearViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newYear = _mapper.Map<YearViewModel, Year>(model);
                if (isNew)
                {
                    _repository.AddEntity(newYear);
                    _repository.SaveAll();
                }
                else
                {
                    Year oldYear = _repository.GetYearById(id);
                    oldYear.Name = newYear.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllYear");
        }
        [HttpGet]
        public IActionResult DeleteYear(int id)
        {
            YearViewModel model = new YearViewModel();
            var year = _repository.GetYearById(id);

            model = _mapper.Map<Year, YearViewModel>(year);

            return PartialView("~/Areas/QC/Views/QC/DeleteYear.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteYear(int id, YearViewModel model)
        {

            Year year = _repository.GetYearById(id);

            _repository.DeleteEntity(year);

            _repository.SaveAll();
            return RedirectToAction("AllYear");
        }
        #endregion
        #region Month
        public IActionResult AllMonth()
        {
            var results = _repository.GetAllMonth();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditMonth(int? id)
        {
            MonthViewModel model = new MonthViewModel();
            try
            {
                var month = _repository.GetMonthById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Month, MonthViewModel>(month);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditMonth.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditMonth(int? id, MonthViewModel model)
        {
            MonthViewModel model1 = new MonthViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newMonth = _mapper.Map<MonthViewModel, Month>(model);
                if (isNew)
                {
                    _repository.AddEntity(newMonth);
                    _repository.SaveAll();
                }
                else
                {
                    Month oldMonth = _repository.GetMonthById(id);
                    oldMonth.Name = newMonth.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllMonth");
        }
        [HttpGet]
        public IActionResult DeleteMonth(int id)
        {
            MonthViewModel model = new MonthViewModel();
            var month = _repository.GetMonthById(id);

            model = _mapper.Map<Month, MonthViewModel>(month);

            return PartialView("~/Areas/QC/Views/QC/DeleteMonth.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteMonth(int id, MonthViewModel model)
        {

            Month month = _repository.GetMonthById(id);

            _repository.DeleteEntity(month);

            _repository.SaveAll();
            return RedirectToAction("AllMonth");
        }
        #endregion
        #region Confirmation
        public IActionResult AllConfirmation()
        {
            var results = _repository.GetAllConfirmation();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditConfirmation(int? id)
        {
            ConfirmationViewModel model = new ConfirmationViewModel();
            try
            {
                var confirmation = _repository.GetConfirmationById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Confirmation, ConfirmationViewModel>(confirmation);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditConfirmation.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditConfirmation(int? id, ConfirmationViewModel model)
        {
            ConfirmationViewModel model1 = new ConfirmationViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newConfirmation = _mapper.Map<ConfirmationViewModel, Confirmation>(model);
                if (isNew)
                {
                    _repository.AddEntity(newConfirmation);
                    _repository.SaveAll();
                }
                else
                {
                    Confirmation oldConfirmation = _repository.GetConfirmationById(id);
                    oldConfirmation.Name = newConfirmation.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllConfirmation");
        }
        [HttpGet]
        public IActionResult DeleteConfirmation(int id)
        {
            ConfirmationViewModel model = new ConfirmationViewModel();
            var confirmation = _repository.GetConfirmationById(id);

            model = _mapper.Map<Confirmation, ConfirmationViewModel>(confirmation);

            return PartialView("~/Areas/QC/Views/QC/DeleteConfirmation.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteConfirmation(int id, ConfirmationViewModel model)
        {

            Confirmation confirmation = _repository.GetConfirmationById(id);

            _repository.DeleteEntity(confirmation);

            _repository.SaveAll();
            return RedirectToAction("AllConfirmation");
        }
        #endregion
        #region OrganizationalUnit
        public IActionResult AllOrganizationalUnit()
        {
            var results = _repository.GetAllOrganizationalUnit();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditOrganizationalUnit(int? id)
        {
            OrganizationalUnitViewModel model = new OrganizationalUnitViewModel();
            try
            {
                var organizationalunit = _repository.GetOrganizationalUnitById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<OrganizationalUnit, OrganizationalUnitViewModel>(organizationalunit);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditOrganizationalUnit.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditOrganizationalUnit(int? id, OrganizationalUnitViewModel model)
        {
            OrganizationalUnitViewModel model1 = new OrganizationalUnitViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newOrganizationalUnit = _mapper.Map<OrganizationalUnitViewModel, OrganizationalUnit>(model);
                if (isNew)
                {
                    _repository.AddEntity(newOrganizationalUnit);
                    _repository.SaveAll();
                }
                else
                {
                    OrganizationalUnit oldOrganizationalUnit = _repository.GetOrganizationalUnitById(id);
                    oldOrganizationalUnit.Name = newOrganizationalUnit.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllOrganizationalUnit");
        }
        [HttpGet]
        public IActionResult DeleteOrganizationalUnit(int id)
        {
            OrganizationalUnitViewModel model = new OrganizationalUnitViewModel();
            var organizationalunit = _repository.GetOrganizationalUnitById(id);

            model = _mapper.Map<OrganizationalUnit, OrganizationalUnitViewModel>(organizationalunit);

            return PartialView("~/Areas/QC/Views/QC/DeleteOrganizationalUnit.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteOrganizationalUnit(int id, OrganizationalUnitViewModel model)
        {

            OrganizationalUnit organizationalunit = _repository.GetOrganizationalUnitById(id);

            _repository.DeleteEntity(organizationalunit);

            _repository.SaveAll();
            return RedirectToAction("AllOrganizationalUnit");
        }
        #endregion
        #region Hour
        public IActionResult AllHour()
        {
            var results = _repository.GetAllHour();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditHour(int? id)
        {
            HourViewModel model = new HourViewModel();
            try
            {
                var hour = _repository.GetHourById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Hour, HourViewModel>(hour);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditHour.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditHour(int? id, HourViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newHour = _mapper.Map<HourViewModel, Hour>(model);
                if (isNew)
                {
                    _repository.AddEntity(newHour);
                    _repository.SaveAll();
                }
                else
                {
                    Hour oldHour = _repository.GetHourById(id);
                    oldHour.Name = newHour.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllHour");
        }
        [HttpGet]
        public IActionResult DeleteHour(int id)
        {
            HourViewModel model = new HourViewModel();
            var hour = _repository.GetHourById(id);

            model = _mapper.Map<Hour, HourViewModel>(hour);

            return PartialView("~/Areas/QC/Views/QC/DeleteHour.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteHour(int id, HourViewModel model)
        {

            Hour hour = _repository.GetHourById(id);

            _repository.DeleteEntity(hour);

            _repository.SaveAll();
            return RedirectToAction("AllHour");
        }
        #endregion
        #region Shift
        public IActionResult AllShift()
        {
            var results = _repository.GetAllShift();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditShift(int? id)
        {
            ShiftViewModel model = new ShiftViewModel();
            try
            {
                var shift = _repository.GetShiftById(id);

                if (id.HasValue)
                {
                    model = _mapper.Map<Shift, ShiftViewModel>(shift);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditShift.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditShift(int? id, ShiftViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newShift = _mapper.Map<ShiftViewModel, Shift>(model);
                if (isNew)
                {
                    _repository.AddEntity(newShift);
                    _repository.SaveAll();
                }
                else
                {
                    Shift oldShift = _repository.GetShiftById(id);
                    oldShift.Name = newShift.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllShift");
        }
        [HttpGet]
        public IActionResult DeleteShift(int id)
        {
            ShiftViewModel model = new ShiftViewModel();
            var shift = _repository.GetShiftById(id);

            model = _mapper.Map<Shift, ShiftViewModel>(shift);

            return PartialView("~/Areas/QC/Views/QC/DeleteShift.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteShift(int id, ShiftViewModel model)
        {

            Shift shift = _repository.GetShiftById(id);

            _repository.DeleteEntity(shift);

            _repository.SaveAll();
            return RedirectToAction("AllShift");
        }
        #endregion
        #region QualityControl
        public IActionResult AllQualityControl()
        {
            var results = _repository.GetAllQualityControl();
            return View(results);
        }
        [HttpGet]
        public IActionResult AddQualityControl()
        {

            QualityControlViewModel model = new QualityControlViewModel();
            try
            {
                ViewBag.Year = _repository.GetAllYear();
                ViewBag.Month = _repository.GetAllMonth();
                ViewBag.Day= _repository.GetAllDay();
                ViewBag.Hour = _repository.GetAllHour();
                ViewBag.Shift = _repository.GetAllShift();
                ViewBag.QualityDesign = _repository.GetAllQualityDesign();
                return View();

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }

        }

        [HttpGet]
        public IActionResult EditQualityControl(int? id)
        {

            QualityControlViewModel model = new QualityControlViewModel();
            try
            {
                var qualitycontrol = _repository.GetQualityControlById(id);
                model = _mapper.Map<QualityControl, QualityControlViewModel>(qualitycontrol);
                ViewBag.Year = _repository.GetAllYear();
                ViewBag.Month = _repository.GetAllMonth();
                ViewBag.Day = _repository.GetAllDay();
                ViewBag.Hour = _repository.GetAllHour();
                ViewBag.Shift = _repository.GetAllShift();
                ViewBag.QualityDesign = _repository.GetAllQualityDesign();
                return View(model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }

        }
        [HttpPost]
        public IActionResult AddQualityControl(int? id, QualityControlViewModel model)
        {
            if (ModelState.IsValid)
            {

                var newQualityControl = _mapper.Map<QualityControlViewModel, QualityControl>(model);

                _repository.AddEntity(newQualityControl);
                _repository.SaveAll();


                return RedirectToAction("AllQualityControl");
            }
            //ViewBag.Year = _repository.GetAllYear();
            //ViewBag.Month = _repository.GetAllMonth();
            //ViewBag.Day = _repository.GetAllDay();
            //ViewBag.Hour = _repository.GetAllHour();
            //ViewBag.Shift = _repository.GetAllShift();
            //ViewBag.QualityDesign = _repository.GetAllQualityDesign();
            return View(model);
        }
        [HttpPost]
        public IActionResult EditQualityControl(int? id, QualityControlViewModel model)
        {

            QualityControlViewModel model1 = new QualityControlViewModel();

            if (ModelState.IsValid)
            {


                var newQualityControl = _mapper.Map<QualityControlViewModel, QualityControl>(model);
                QualityControl oldQualityControl = _repository.GetQualityControlById(id);
                oldQualityControl.YearId = newQualityControl.YearId;
                oldQualityControl.MonthId = newQualityControl.MonthId;
                oldQualityControl.DayId = newQualityControl.DayId;
                oldQualityControl.ShiftId = newQualityControl.ShiftId;
                oldQualityControl.HourId = newQualityControl.HourId;
                // orderOld = newOrder;
                //_repository.UpdateEntity(newOrder);

                _repository.SaveAll();

                return RedirectToAction("AllQualityControl");
            }
            return Json(new { Result = "OK" });
        }
        [HttpGet]
        public IActionResult DeleteQualityControl(int id)
        {
            QualityControlViewModel model = new QualityControlViewModel();
            var qualitycontrol = _repository.GetQualityControlById(id);

            model = _mapper.Map<QualityControl, QualityControlViewModel>(qualitycontrol);

            return PartialView("~/Areas/QC/Views/QC/DeleteQualityControl.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteQualityControl(int id, QualityControlViewModel model)
        {

            QualityControl qualitycontrol = _repository.GetQualityControlById(id);

            _repository.DeleteEntity(qualitycontrol);

            _repository.SaveAll();
            return RedirectToAction("QualityControl");
        }
        #endregion
        #region Tank
        public IActionResult AllTank()
        {

            var results = _repository.GetAllTank();
            return View(results);
        }
        [HttpGet]
       // [Authorize(Policy = "AddTank")]
        public IActionResult AddEditTank(int? id)
        {
            TankViewModel model = new TankViewModel();
            try
            {
                var tank = _repository.GetTankById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Tank, TankViewModel>(tank);
                }
                return PartialView("~/Areas/QC/Views/QC/AddEditTank.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditTank(int? id, TankViewModel model)
        {
            //  ProcessNameViewModel model1 = new ProcessNameViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newTank = _mapper.Map<TankViewModel, Tank>(model);
                if (isNew)
                {
                    _repository.AddEntity(newTank);
                    _repository.SaveAll();
                }
                else
                {
                    Tank oldTank = _repository.GetTankById(id);
                    oldTank.Name = newTank.Name;
                    // orderOld = newOrder;
                    //_repository.UpdateEntity(newOrder);

                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllTank");
        }
        [HttpGet]
        //[Authorize(Policy = "DeleteTank")]
        public IActionResult DeleteTank(int id)
        {
            TankViewModel model = new TankViewModel();
            var tank = _repository.GetTankById(id);

            model = _mapper.Map<Tank, TankViewModel>(tank);

            return PartialView("~/Areas/QC/Views/QC/DeleteTank.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteTank(int id, TankViewModel model)
        {

            Tank tank = _repository.GetTankById(id);

            _repository.DeleteEntity(tank);

            _repository.SaveAll();
            return RedirectToAction("AllTank");
        }
        #endregion
        #region Storage
        public IActionResult AllStorage()
        {

            var results = _repository.GetAllStorage();
            return View(results);
        }
        [HttpGet]
       // [Authorize(Policy = "AddStorage")]
        public IActionResult AddEditStorage(int? id)
        {
            StorageViewModel model = new StorageViewModel();
            try
            {
                var storage = _repository.GetStorageById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Storage, StorageViewModel>(storage);
                }
                return PartialView("~/Areas/QC/Views/QC/AddEditStorage.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditStorage(int? id, StorageViewModel model)
        {
            //  ProcessNameViewModel model1 = new ProcessNameViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newStorage = _mapper.Map<StorageViewModel, Storage>(model);
                if (isNew)
                {
                    _repository.AddEntity(newStorage);
                    _repository.SaveAll();
                }
                else
                {
                    Storage oldStorage = _repository.GetStorageById(id);
                    oldStorage.Name = newStorage.Name;
                    // orderOld = newOrder;
                    //_repository.UpdateEntity(newOrder);

                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllStorage");
        }
        [HttpGet]
       // [Authorize(Policy = "DeleteStorage")]
        public IActionResult DeleteStorage(int id)
        {
            StorageViewModel model = new StorageViewModel();
            var storage = _repository.GetStorageById(id);

            model = _mapper.Map<Storage, StorageViewModel>(storage);

            return PartialView("~/Areas/QC/Views/QC/DeleteStorage.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteStorage(int id, StorageViewModel model)
        {

            Storage storage = _repository.GetStorageById(id);

            _repository.DeleteEntity(storage);

            _repository.SaveAll();
            return RedirectToAction("AllStorage");
        }
        #endregion
        #region Production
        public IActionResult AllProduction()
        {

            var results = _repository.GetAllProduction();
            return View(results);
        }
        [HttpGet]
       // [Authorize(Policy = "AddProduction")]
        public IActionResult AddEditProduction(int? id)
        {
            ProductionViewModel model = new ProductionViewModel();
            try
            {
                var production = _repository.GetProductionById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<Production, ProductionViewModel>(production);
                }
                return PartialView("~/Areas/QC/Views/QC/AddEditProduction.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditProduction(int? id, ProductionViewModel model)
        {
            //  ProcessNameViewModel model1 = new ProcessNameViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newProduction = _mapper.Map<ProductionViewModel, Production>(model);
                if (isNew)
                {
                    _repository.AddEntity(newProduction);
                    _repository.SaveAll();
                }
                else
                {
                    Production oldProduction = _repository.GetProductionById(id);
                    oldProduction.Name = newProduction.Name;
                    // orderOld = newOrder;
                    //_repository.UpdateEntity(newOrder);

                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllProduction");
        }
        [HttpGet]
       // [Authorize(Policy = "DeleteProduction")]
        public IActionResult DeleteProduction(int id)
        {
            ProductionViewModel model = new ProductionViewModel();
            var production = _repository.GetProductionById(id);

            model = _mapper.Map<Production, ProductionViewModel>(production);

            return PartialView("~/Areas/QC/Views/QC/DeleteProduction.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteProduction(int id, ProductionViewModel model)
        {

            Production production = _repository.GetProductionById(id);

            _repository.DeleteEntity(production);

            _repository.SaveAll();
            return RedirectToAction("AllProduction");
        }
        #endregion
        #region ColumnNumber
        public IActionResult AllColumnNumber()
        {

            var results = _repository.GetAllColumnNumber();
            return View(results);
        }
        [HttpGet]
       // [Authorize(Policy = "AddColumnNumber")]
        public IActionResult AddEditColumnNumber(int? id)
        {
            ColumnNumberViewModel model = new ColumnNumberViewModel();
            try
            {
                var columnNumber = _repository.GetColumnNumberById(id);
                if (id.HasValue)
                {
                    model = _mapper.Map<ColumnNumber, ColumnNumberViewModel>(columnNumber);
                }
                return PartialView("~/Areas/QC/Views/QC/AddEditColumnNumber.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditColumnNumber(int? id, ColumnNumberViewModel model)
        {
            //  ProcessNameViewModel model1 = new ProcessNameViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newColumnNumber = _mapper.Map<ColumnNumberViewModel, ColumnNumber>(model);
                if (isNew)
                {
                    _repository.AddEntity(newColumnNumber);
                    _repository.SaveAll();
                }
                else
                {
                    ColumnNumber oldColumnNumber = _repository.GetColumnNumberById(id);
                    oldColumnNumber.Name = newColumnNumber.Name;
                    // orderOld = newOrder;
                    //_repository.UpdateEntity(newOrder);

                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllColumnNumber");
        }
        [HttpGet]
       // [Authorize(Policy = "DeleteColumnNumber")]
        public IActionResult DeleteColumnNumber(int id)
        {
            ColumnNumberViewModel model = new ColumnNumberViewModel();
            var columnNumber = _repository.GetColumnNumberById(id);

            model = _mapper.Map<ColumnNumber, ColumnNumberViewModel>(columnNumber);

            return PartialView("~/Areas/QC/Views/QC/DeleteColumnNumber.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteColumnNumber(int id, ColumnNumberViewModel model)
        {

            ColumnNumber columnNumber = _repository.GetColumnNumberById(id);

            _repository.DeleteEntity(columnNumber);

            _repository.SaveAll();
            return RedirectToAction("AllColumnNumber");
        }
        #endregion
        #region QParameterStatus
        public IActionResult AllQParameterStatus()
        {

            var results = _repository.GetAllQParameterStatus();
            return View(results);
        }
        [HttpGet]
       // [Authorize(Policy = "AddQParameterStatus")]
        public IActionResult AddEditQParameterStatus(int? id)
        {
            QParameterStatusViewModel model = new QParameterStatusViewModel();
            try
            {
                var qparameterstatus = _repository.GetQParameterStatusById(id);
                ViewBag.Confirmation = _repository.GetAllConfirmation();
                if (id.HasValue)
                {
                    model = _mapper.Map<QParameterStatus, QParameterStatusViewModel>(qparameterstatus);
                }
                return PartialView("~/Areas/QC/Views/QC/AddEditQParameterStatus.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditQParameterStatus(int? id, QParameterStatusViewModel model)
        {
            //  ProcessNameViewModel model1 = new ProcessNameViewModel();

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newQParameterStatus = _mapper.Map<QParameterStatusViewModel, QParameterStatus>(model);
                if (isNew)
                {
                    _repository.AddEntity(newQParameterStatus);
                    _repository.SaveAll();
                }
                else
                {
                    QParameterStatus oldQParameterStatus = _repository.GetQParameterStatusById(id);
                    oldQParameterStatus.Name = newQParameterStatus.Name;
                    oldQParameterStatus.ConfirmationId = newQParameterStatus.ConfirmationId;
                    // orderOld = newOrder;
                    //_repository.UpdateEntity(newOrder);

                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllQParameterStatus");
        }
        [HttpGet]
       // [Authorize(Policy = "DeleteQParameterStatus")]
        public IActionResult DeleteQParameterStatus(int id)
        {
            QParameterStatusViewModel model = new QParameterStatusViewModel();
            var qparameterstatus = _repository.GetQParameterStatusById(id);

            model = _mapper.Map<QParameterStatus, QParameterStatusViewModel>(qparameterstatus);

            return PartialView("~/Areas/QC/Views/QC/DeleteQParameterStatus.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteQParameterStatus(int id, QParameterStatusViewModel model)
        {

            QParameterStatus qparameterstatus = _repository.GetQParameterStatusById(id);

            _repository.DeleteEntity(qparameterstatus);

            _repository.SaveAll();
            return RedirectToAction("AllQParameterStatus");
        }
        #endregion
        #region Company
        public IActionResult AllCompany()
        {
            var results = _repository.GetAllCompany();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditCompany(int? id)
        {
            CompanyViewModel model = new CompanyViewModel();
            try
            {
                var company = _repository.GetCompanyById(id);
                ViewBag.Site = _repository.GetAllSite();
                if (id.HasValue)
                {
                    model = _mapper.Map<Company, CompanyViewModel>(company);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditCompany.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditCompany(int? id, CompanyViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newCompany = _mapper.Map<CompanyViewModel, Company>(model);
                if (isNew)
                {
                    _repository.AddEntity(newCompany);
                    _repository.SaveAll();
                }
                else
                {
                    Company oldCompany = _repository.GetCompanyById(id);
                    oldCompany.Name = newCompany.Name;
                    oldCompany.SiteId = newCompany.SiteId;

                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllCompany");
        }
        [HttpGet]
        public IActionResult DeleteCompany(int id)
        {
            CompanyViewModel model = new CompanyViewModel();
            var company = _repository.GetCompanyById(id);

            model = _mapper.Map<Company, CompanyViewModel>(company);

            return PartialView("~/Areas/QC/Views/QC/DeleteCompany.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteCompany(int id, CompanyViewModel model)
        {

            Company company = _repository.GetCompanyById(id);

            _repository.DeleteEntity(company);

            _repository.SaveAll();
            return RedirectToAction("AllCompany");
        }
        #endregion
        #region QualityDesignForView
        public IActionResult QualityDesignForView()
        {
            var results = _repository.GetAllQualityDesign();
            // var ProcessNumber = _repository.GetAllProcessName();
            return View(results);
        }
        #endregion
        #region Site
        public IActionResult AllSite()
        {
            var results = _repository.GetAllSite();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditSite(int? id)
        {
            SiteViewModel model = new SiteViewModel();
            try
            {
                var site = _repository.GetSiteById(id);

                if (id.HasValue)
                {
                    model = _mapper.Map<Site , SiteViewModel>(site);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditSite.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditSite(int? id, SiteViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newSite = _mapper.Map<SiteViewModel, Site>(model);
                if (isNew)
                {
                    _repository.AddEntity(newSite);
                    _repository.SaveAll();
                }
                else
                {
                    Site oldSite = _repository.GetSiteById(id);
                    oldSite.Name = newSite.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllSite");
        }
        [HttpGet]
        public IActionResult DeleteSite(int id)
        {
            SiteViewModel model = new SiteViewModel();
            var site = _repository.GetSiteById(id);

            model = _mapper.Map<Site, SiteViewModel>(site);

            return PartialView("~/Areas/QC/Views/QC/DeleteSite.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteSite(int id, SiteViewModel model)
        {

            Site site = _repository.GetSiteById(id);

            _repository.DeleteEntity(site);

            _repository.SaveAll();
            return RedirectToAction("AllSite");
        }
        #endregion
        #region TypeOfCorn
        public IActionResult AllTypeOfCorn()
        {
            var results = _repository.GetAllTypeOfCorn();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditTypeOfCorn(int? id)
        {
            TypeOfCornViewModel model = new TypeOfCornViewModel();
            try
            {
                var typeOfCorn = _repository.GetTypeOfCornById(id);

                if (id.HasValue)
                {
                    model = _mapper.Map<TypeOfCorn, TypeOfCornViewModel>(typeOfCorn);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditTypeOfCorn.cshtml", model);

            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditTypeOfCorn(int? id, TypeOfCornViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newTypeOfCorn = _mapper.Map<TypeOfCornViewModel, TypeOfCorn>(model);
                if (isNew)
                {
                    _repository.AddEntity(newTypeOfCorn);
                    _repository.SaveAll();
                }
                else
                {
                    TypeOfCorn oldTypeOfCorn = _repository.GetTypeOfCornById(id);
                    oldTypeOfCorn.Name = newTypeOfCorn.Name;


                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllTypeOfCorn");
        }
        [HttpGet]
        public IActionResult DeleteTypeOfCorn(int id)
        {
            TypeOfCornViewModel model = new TypeOfCornViewModel();
            var typeOfCorn = _repository.GetTypeOfCornById(id);

            model = _mapper.Map<TypeOfCorn, TypeOfCornViewModel>(typeOfCorn);

            return PartialView("~/Areas/QC/Views/QC/DeleteTypeOfCorn.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteTypeOfCorn(int id, TypeOfCornViewModel model)
        {

            TypeOfCorn typeOfCorn = _repository.GetTypeOfCornById(id);

            _repository.DeleteEntity(typeOfCorn);

            _repository.SaveAll();
            return RedirectToAction("AllTypeOfCorn");
        }
        #endregion
        #region PauseTime
        public ActionResult DynamicPauseTime()
        {

            return View();
        }
        public IActionResult AllPauseTime()
        {
            var results = _repository.GetAllPauseTime();

            return View(results);

        }
        [HttpGet]
        public IActionResult AddEditPauseTime(int? id)
        {
            PauseTimeViewModel model = new PauseTimeViewModel();
            try
            {
                var pauseTime = _repository.GetPauseTimeById(id);
                ViewBag.Hour = _repository.GetAllHour();
                ViewBag.Company = _repository.GetAllCompany();
                if (id.HasValue)
                {
                    model = _mapper.Map<PauseTime, PauseTimeViewModel>(pauseTime);
                }
                // ViewBag.ProcessName = _repository.GetAllControlTools();
                return PartialView("~/Areas/QC/Views/QC/AddEditPauseTime.cshtml", model);

            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult AddEditPauseTime(int? id, PauseTimeViewModel model)
        {

            if (ModelState.IsValid)
            {
                bool isNew = !id.HasValue;

                var newPauseTime = _mapper.Map<PauseTimeViewModel, PauseTime>(model);
                if (isNew)
                {
                    _repository.AddEntity(newPauseTime);
                    _repository.SaveAll();
                }
                else
                {
                    PauseTime oldPauseTime = _repository.GetPauseTimeById(id);
                    oldPauseTime.BreakDate = newPauseTime.BreakDate;
                    oldPauseTime.HourId = newPauseTime.HourId;
                    oldPauseTime.CompanyId = newPauseTime.CompanyId;

                    _repository.SaveAll();
                }
            }

            return RedirectToAction("AllPauseTime");
        }
        [HttpGet]
        public IActionResult DeletePauseTime(int id)
        {
            PauseTimeViewModel model = new PauseTimeViewModel();
            var pauseTime = _repository.GetPauseTimeById(id);

            model = _mapper.Map<PauseTime, PauseTimeViewModel>(pauseTime);

            return PartialView("~/Areas/QC/Views/QC/DeletePauseTime.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeletePauseTime(int id, PauseTimeViewModel model)
        {

            PauseTime pauseTime = _repository.GetPauseTimeById(id);

            _repository.DeleteEntity(pauseTime);

            _repository.SaveAll();
            return RedirectToAction("AllPauseTime");
        }
        [HttpPost("PassDateForPauseTime")]
        public ActionResult PassDateForPauseTime(string TempDate)
        {
            TempData["PassDateForPauseTime"] = TempDate;

            //ViewBag.DateForQualityDesign = TempDate;
            //return RedirectToAction("DynamicFormQualityDesign");
            return Json(Url.Action("DynamicPauseTime", "QC"));
        }
        [HttpPost("AddPauseTimeList")]
        public JsonResult AddPauseTimeList([FromBody] List<PauseTimeViewModel> pauseTimes)
        {

            //Truncate Table to delete all old records.
            //  entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

            //Check for NULL.
            if (pauseTimes == null)
            {
                pauseTimes = new List<PauseTimeViewModel>();
            }

            //Loop and insert records.
            foreach (PauseTimeViewModel pausetime in pauseTimes)
            {
                var newPauseTime = _mapper.Map<PauseTimeViewModel, PauseTime>(pausetime);
                _repository.AddEntity(newPauseTime);
                _repository.SaveAll();
            }
            bool insertedRecords = true;
            // return Json(insertedRecords);
            // return RedirectToAction("AllControlParameter");
            return Json(new
            {
                redirectUrl = Url.Action("AllPauseTime", "QC"),
                isRedirect = true
            });
        }

        public JsonResult GetAllPauseTimeWithDate(string DateQD)
        {

            var sa = new JsonSerializerSettings();
            IEnumerable<PauseTime> PauseTimeList = new List<PauseTime>();

            var PauseTimes = _repository.GetAllPauseTimeWithDate(DateQD);

            if (PauseTimes.Count > 0 && DateQD != null)
            {
                PauseTimeList = PauseTimes.Select(x =>
                                new PauseTime()
                                {
                                    BreakDate = x.BreakDate,
                                    HourId = x.HourId,
                                    Hour = new Hour() { Name = x.Hour == null ? " " : x.Hour.Name },
                                    Company = new Company() { Name = x.Company == null ? " " : x.Company.Name }
                                });
            }
            return Json(PauseTimeList, sa);
        }
       public Int32 totalHour;
        public Int32 GetTotalHour(string DateQD)
        {
            var sa = new JsonSerializerSettings();
            IEnumerable<PauseTime> PauseTimeList = new List<PauseTime>();

            var PauseTimes = _repository.GetAllPauseTimeWithDate(DateQD);

            if (PauseTimes.Count > 0 && DateQD != null)
            {
                PauseTimeList = PauseTimes.Select(x =>
                                new PauseTime()
                                {
                                    BreakDate = x.BreakDate,
                                    HourId = x.HourId,
                                    Hour = new Hour() { Name = x.Hour == null ? " " : x.Hour.Name }

                                });
            }
            Int32 totalHour=0;
            foreach (PauseTime item in PauseTimeList)
            {
                totalHour =Convert.ToInt32(item.Hour.Name) + totalHour;
            }
            return totalHour;
        }
        #endregion
    }
    //کلاس زیر برای تبدیل عدد فارسی به انگلیسی استفاده می شود
    public static class MyExtensions
    {
        public static string PersianToEnglish(this string persianStr)
        {
            Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
            {
                ['۰'] = '0',
                ['۱'] = '1',
                ['۲'] = '2',
                ['۳'] = '3',
                ['۴'] = '4',
                ['۵'] = '5',
                ['۶'] = '6',
                ['۷'] = '7',
                ['۸'] = '8',
                ['۹'] = '9'
            };
            foreach (var item in persianStr)
            {
                persianStr = persianStr.Replace(item, LettersDictionary[item]);
            }
            return persianStr;
        }
        public static string EnglishToPersian(this string persianStr)
        {
            Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
            {
                ['0'] = '۰',
                ['1'] = '۱',
                ['2'] = '۲',
                ['3'] = '۳',
                ['4'] = '۴',
                ['5'] = '۵',
                ['6'] = '۶',
                ['7'] = '۷',
                ['8'] = '۸',
                ['9'] = '۹'
            };
            foreach (var item in persianStr)
            {
                persianStr = persianStr.Replace(item, LettersDictionary[item]);
            }
            return persianStr;
        }
    }
}