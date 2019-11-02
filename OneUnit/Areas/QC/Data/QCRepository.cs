using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneUnit.Areas.Admin.Data.Entities;
using OneUnit.Areas.QC.Data.Entities;
using OneUnit.Areas.QC.ViewModels;
using OneUnit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Data
{
    public class QCRepository : IQCRepository
    {
        private readonly OneUnitContext _ctx;
        
        private readonly UserManager<StoreUser> _userManager;

        public QCRepository(OneUnitContext  ctx , UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }
        #region ProcessName
        public IEnumerable<ProcessName> GetAllProcessName()
        {
            return _ctx.ProcessNames
                .OrderBy(p => p.Name)
                .Include(d => d.Company)
                .Include(F =>F.HasT)
                .ToList();
        }
        public IEnumerable<ProcessName> GetAllProcessNameWithCompany()
        {
            return _ctx.ProcessNames
                .OrderBy(p => p.Name)
                .Include(d => d.Company)
                .ToList();
        }
        public IEnumerable<ProcessName> GetJustProcessName()
        {
            return _ctx.ProcessNames
                .OrderBy(p => p.Name)
                .ToList();
        }
        public ProcessName GetProcessNameById(int? id)
        {
            return _ctx.ProcessNames
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        //------------Q22--------------------------------------------
        public ProcessName GetOneRecoredWithProcessNameId(int Id)
        {
            if (Id >= 0)
            {
                return _ctx.ProcessNames
                .Where(s => s.Id == Id)
                .FirstOrDefault();
            }

            return null;
        }
        #endregion
        #region QualityDesign
        public IEnumerable<QualityDesign> GetAllQualityDesign()
        {
            return _ctx.QualityDesigns
                .OrderBy(p => p.Id)
                .Include(d => d.ProcessName)
                .Include(d => d.Shift)
                .Include(d => d.Confirmation)
                //.Include(d => d.Sampler)
               // .Include(d => d.Tester)
                //.Include(d => d.ControllerUser)
                //.Include(d => d.Production)
               // .Include(d => d.ColumnNumber)
                //.Include(d => d.SamplingLocation)
               // .Include(d => d.Storage)
                .Include(d => d.ControlParameter)
                .Include(d => d.QParameterStatus)
               // .Include(d => d.Tank)
                .ToList();
        }
        public UsersQualityDesignViewModel GetAllUser()
        {
             UsersQualityDesignViewModel Model = new UsersQualityDesignViewModel();
            //  return _userManager.Users.Include(x => x.Name);
            foreach (var user in _userManager.Users)
            {
                Model.Sampler.Add(user);
                Model.Tester.Add(user);
                Model.ControllerUser.Add(user);
            }
            return Model;
        }
        public QualityDesign GetQualityDesignById(int? id)
        {
            return _ctx.QualityDesigns
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<QualityDesign> QualityDesigns
        {
            get
            {
                return _ctx.QualityDesigns.Include(c => c.ProcessName);
            }
        }
        public IEnumerable<ControlParameter> GetControlParameter(int? Value1 ,int? Value2)
        {

            if (Value1 != null && Value2 != null)
            {
                return _ctx.ControlParameters
                 .Where(n=> n.ProcessNameId ==Value1 && n.SamplingLocationId == Value2)
                  .Include(d => d.SamplingLocation)
                 .OrderBy(p => p.Name)
                 .ToList();
            }
            else
            {
                return _ctx.ControlParameters
                 .OrderBy(p => p.Name)
                 .ToList();
            }

        }
        public IEnumerable<QualityDesign> GetQualityDesignForTypeOfCorn(String Value1, int? Value2)
        {

            if (Value1 != null && Value2 != null)
            {
                  return _ctx.QualityDesigns
                 .Where(n => n.DateQD == Value1 && n.ProcessNameId == Value2)
                 .Include(d => d.TypeOfCorn)
                 .OrderBy(p => p.Id)
                 .ToList();
            }
            else
            {
                return _ctx.QualityDesigns
                 .OrderBy(p => p.Id)
                 .ToList();
            }

        }
        public IEnumerable<ProcessName> GetProcessnameWithCompany(int? Value1)
        {

            if (Value1 != null )
            {
                return _ctx.ProcessNames
                 .Where(n => n.CompanyId == Value1 )
                  .Include(d => d.Company)
                 .OrderBy(p => p.Name)
                 .ToList();
            }
            else
            {
                return _ctx.ProcessNames
                 .OrderBy(p => p.Name)
                 .ToList();
            }

        }
        public IEnumerable<SamplingLocation> GetSamplingLocationWithProcessName(int? Value1)
        {

            if (Value1 != null)
            {
                return _ctx.SamplingLocations
                 .Where(n => n.ProcessNameId == Value1)
                  .Include(d => d.Company)
                 .OrderBy(p => p.Name)
                 .ToList();
            }
            else
            {
                return _ctx.SamplingLocations
                 .OrderBy(p => p.Name)
                 .ToList();
            }

        }
        public ControlParameter GetOneRecoredWithControlParametreId(int Id)
        {
            if (Id >= 0)
            {
                return _ctx.ControlParameters
                .Where(s => s.Id == Id)
                .FirstOrDefault();
            }
            
            return null;
        }
        public Boolean CheckExistenceId(int Id)
        {

            if (_ctx.QualityDesigns.Where(s => s.Id == Id).FirstOrDefault() == null)
                return false;
            else
                return true;

        }
        public List<QualityDesign> GetAllQualityDesignWithDate(string DateQD)
        {
            return _ctx.QualityDesigns.Where(s=> s.DateQD == DateQD)
                .OrderBy(p => p.Id)
                .Include(d => d.ProcessName)
                .Include(d => d.Shift)
                .Include(d => d.Confirmation)
                .Include(d => d.ControlParameter)
                .Include(d => d.QParameterStatus)
                .Include(d => d.SamplingLocation)
                .Include(d => d.Company)
                .ToList();
        }
        public List<QualityDesign> GetAllQualityDesignForShow(string Value1,int Value2,int Value3,int Value4,string Value5,byte Value6)
        {
            if (Value1 ==  null && Value2 == 0 && Value3 == 0 && Value4 == 0 && Value5 == "انتخاب:انتخاب" && Value6 ==0 )
            {
                return _ctx.QualityDesigns
                    .OrderBy(p => p.Id)
                    .Include(d => d.ProcessName)
                    .Include(d => d.Shift)
                    .Include(d => d.Confirmation)
                    .Include(d => d.ControlParameter)
                    .Include(d => d.QParameterStatus)
                    .Include(d => d.SamplingLocation)
                    .Include(d => d.Company)
                    .ToList();
            }
 

            if (Value1 == null && Value6 != 0 )
            {
                return _ctx.QualityDesigns.Where(s => s.CompanyId == Value2 || s.ProcessNameId == Value3 || s.SamplingLocationId == Value4 || s.RegistrationTime == Value5 || s.ShiftId == Value6)
                    .OrderBy(p => p.Id)
                    .Include(d => d.ProcessName)
                    .Include(d => d.Shift)
                    .Include(d => d.Confirmation)
                    .Include(d => d.ControlParameter)
                    .Include(d => d.QParameterStatus)
                    .Include(d => d.SamplingLocation)
                    .Include(d => d.Company)
                    .ToList();
            }

            if (Value6 != 0 && Value1 != null)
            {
                return _ctx.QualityDesigns.Where(s => s.DateQD == Value1  && s.ShiftId == Value6)
                    .OrderBy(p => p.Id)
                    .Include(d => d.ProcessName)
                    .Include(d => d.Shift)
                    .Include(d => d.Confirmation)
                    .Include(d => d.ControlParameter)
                    .Include(d => d.QParameterStatus)
                    .Include(d => d.SamplingLocation)
                    .Include(d => d.Company)
                    .ToList();
            }
            if ( Value1 != null && Value2 != 0 && Value3 == 0)
            {
                return _ctx.QualityDesigns.Where(s => s.DateQD == Value1  && s.CompanyId == Value2)
                    .OrderBy(p => p.Id)
                    .Include(d => d.ProcessName)
                    .Include(d => d.Shift)
                    .Include(d => d.Confirmation)
                    .Include(d => d.ControlParameter)
                    .Include(d => d.QParameterStatus)
                    .Include(d => d.SamplingLocation)
                    .Include(d => d.Company)
                    .ToList();
            }
            if (Value1 != null && Value2 != 0 && Value3 != 0)
            {
                return _ctx.QualityDesigns.Where(s => s.DateQD == Value1 && s.CompanyId == Value2 && s.ProcessNameId == Value3)
                    .OrderBy(p => p.Id)
                    .Include(d => d.ProcessName)
                    .Include(d => d.Shift)
                    .Include(d => d.Confirmation)
                    .Include(d => d.ControlParameter)
                    .Include(d => d.QParameterStatus)
                    .Include(d => d.SamplingLocation)
                    .Include(d => d.Company)
                    .ToList();
            }
            if (Value6 != 0 && Value1 != null && Value2 != 0)
            {
                return _ctx.QualityDesigns.Where(s => s.DateQD == Value1 && s.ShiftId == Value6 && s.CompanyId == Value2)
                    .OrderBy(p => p.Id)
                    .Include(d => d.ProcessName)
                    .Include(d => d.Shift)
                    .Include(d => d.Confirmation)
                    .Include(d => d.ControlParameter)
                    .Include(d => d.QParameterStatus)
                    .Include(d => d.SamplingLocation)
                    .Include(d => d.Company)
                    .ToList();
            }
            if (Value6 != 0 && Value1 != null && Value2 != 0 && Value3 != 0)
            {
                return _ctx.QualityDesigns.Where(s => s.DateQD == Value1 && s.ShiftId == Value6 && s.CompanyId == Value2 && s.ProcessNameId ==Value3)
                    .OrderBy(p => p.Id)
                    .Include(d => d.ProcessName)
                    .Include(d => d.Shift)
                    .Include(d => d.Confirmation)
                    .Include(d => d.ControlParameter)
                    .Include(d => d.QParameterStatus)
                    .Include(d => d.SamplingLocation)
                    .Include(d => d.Company)
                    .ToList();
            }
            else
            {
                return _ctx.QualityDesigns.Where(s => s.DateQD == Value1 || s.CompanyId == Value2 || s.ProcessNameId == Value3 || s.SamplingLocationId == Value4 || s.RegistrationTime == Value5 || s.ShiftId == Value6)
                    .OrderBy(p => p.Id)
                    .Include(d => d.ProcessName)
                    .Include(d => d.Shift)
                    .Include(d => d.Confirmation)
                    .Include(d => d.ControlParameter)
                    .Include(d => d.QParameterStatus)
                    .Include(d => d.SamplingLocation)
                    .Include(d => d.Company)
                    .ToList();
            }
        }
        #endregion
        #region ControlParameter
        public IEnumerable<ControlParameter> GetAllControlParameter()
        {
            return _ctx.ControlParameters
                .OrderBy(p => p.ProcessName.Name)
                .Include(d => d.ProcessType)
                .Include(d => d.ProcessName)
                .Include(d => d.DegreeOfImportance)
                .Include(d => d.UnitOfMeasurement)
                .Include(d => d.SamplingLocation )
                .Include(d => d.SampleValue)
                .Include(d => d.TestValue)
                .Include(d => d.RAction)
                .Include(d => d.Company)
                .ToList();
        }
        public ControlParameter GetControlParameterById(int? id)
        {
            return _ctx.ControlParameters
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region DegreeOfImportance
        public IEnumerable<DegreeOfImportance> GetAllDegreeOfImportance()
        {
            return _ctx.DegreeOfImportances
                .OrderBy(p => p.Name)
                .ToList();
        }
        public DegreeOfImportance GetDegreeOfImportanceById(int? id)
        {
            return _ctx.DegreeOfImportances
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region UnitOfMeasurement
        public IEnumerable<UnitOfMeasurement> GetAllUnitOfMeasurement()
        {
            return _ctx.UnitOfMeasurements
                .OrderBy(p => p.Name)
                .ToList();
        }
        public UnitOfMeasurement GetUnitOfMeasurementById(int? id)
        {
            return _ctx.UnitOfMeasurements
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region SamplingLocation
        public IEnumerable<SamplingLocation> GetAllSamplingLocation()
        {
            return _ctx.SamplingLocations
                .OrderBy(p => p.Name)
                .Include(d => d.Company)
                .Include(d=>d.ProcessName)
                .ToList();
        }
        public IEnumerable<SamplingLocation> GetJustSamplingLocation()
        {
            return _ctx.SamplingLocations
                .OrderBy(p => p.Name)
                .ToList();
        }
        public SamplingLocation GetSamplingLocationById(int? id)
        {
            return _ctx.SamplingLocations
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        public IEnumerable<SamplingLocation> GetSamplingLocationWithCompany(int? Value1)
        {

            if (Value1 != null)
            {
                return _ctx.SamplingLocations
                 .Where(n => n.CompanyId == Value1)
                  .Include(d => d.Company)
                 .OrderBy(p => p.Name)
                 .ToList();
            }
            else
            {
                return _ctx.SamplingLocations
                 .OrderBy(p => p.Name)
                 .ToList();
            }

        }
        #endregion
        #region SampleValue
        public IEnumerable<SampleValue> GetAllSampleValue()
        {
            return _ctx.SampleValues
                .OrderBy(p => p.Name)
                .ToList();
        }
        public SampleValue GetSampleValueById(int? id)
        {
            return _ctx.SampleValues
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region TestValue
        public IEnumerable<TestValue> GetAllTestValue()
        {
            return _ctx.TestValues
                .OrderBy(p => p.Name)
                .ToList();
        }
        public TestValue GetTestValueById(int? id)
        {
            return _ctx.TestValues
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region ProcessType
        public IEnumerable<ProcessType> GetAllProcessType()
        {
            return _ctx.ProcessTypes
                .OrderBy(p => p.Name)
                .ToList();
        }
        public ProcessType GetProcessTypeById(int? id)
        {
            return _ctx.ProcessTypes
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Year
        public IEnumerable<Year> GetAllYear()
        {
            return _ctx.Years
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Year GetYearById(int? id)
        {
            return _ctx.Years
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Month
        public IEnumerable<Month> GetAllMonth()
        {
            return _ctx.Months
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Month GetMonthById(int? id)
        {
            return _ctx.Months
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Day
        public IEnumerable<Day> GetAllDay()
        {
            return _ctx.Days
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Day GetDayById(int? id)
        {
            return _ctx.Days
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Hour
        public IEnumerable<Hour> GetAllHour()
        {
            return _ctx.Hours
                .OrderBy(p => p.Id)
                .ToList();
        }
        public Hour GetHourById(int? id)
        {
            return _ctx.Hours
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Shift
        public IEnumerable<Shift> GetAllShift()
        {
            return _ctx.Shifts
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Shift GetShiftById(int? id)
        {
            return _ctx.Shifts
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region QualityControl
        public IEnumerable<QualityControl> GetAllQualityControl()
        {
            return _ctx.QualityControls
                .OrderBy(p => p.Id)
                 .Include(d => d.Year)
                 .Include(d => d.Month)
                 .Include(d => d.Day)
                 .Include(d => d.Shift)
                 .Include(d => d.Hour)
                 .ToList();
        }
        public QualityControl GetQualityControlById(int? id)
        {
            return _ctx.QualityControls
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Confirmation
        public IEnumerable<Confirmation> GetAllConfirmation()
        {
            return _ctx.Confirmations
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Confirmation GetConfirmationById(int? id)
        {
            return _ctx.Confirmations
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region OrganizationalUnit
        public IEnumerable<OrganizationalUnit> GetAllOrganizationalUnit()
        {
            return _ctx.OrganizationalUnits
                .OrderBy(p => p.Name)
                .ToList();
        }
        public OrganizationalUnit GetOrganizationalUnitById(int? id)
        {
            return _ctx.OrganizationalUnits
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Common
        public void AddEntity(object model)
        {
            _ctx.Add(model);

        }
        public void DeleteEntity(object model)
        {

            _ctx.Remove(model);

        }
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
        #endregion
        #region Tank
        public IEnumerable<Tank> GetAllTank()
        {
            return _ctx.Tanks
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Tank GetTankById(int? id)
        {
            return _ctx.Tanks
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Storage
        public IEnumerable<Storage> GetAllStorage()
        {
            return _ctx.Storages
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Storage GetStorageById(int? id)
        {
            return _ctx.Storages
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Production
        public IEnumerable<Production> GetAllProduction()
        {
            return _ctx.Productions
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Production GetProductionById(int? id)
        {
            return _ctx.Productions
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region ColumnNumber
        public IEnumerable<ColumnNumber> GetAllColumnNumber()
        {
            return _ctx.ColumnNumbers
                .OrderBy(p => p.Name)
                .ToList();
        }
        public ColumnNumber GetColumnNumberById(int? id)
        {
            return _ctx.ColumnNumbers
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region QParameterStatus
        public IEnumerable<QParameterStatus> GetAllQParameterStatus()
        {
            return _ctx.QParameterStatuss
                .OrderBy(p => p.Id)
                .Include(p => p.Confirmation)
                .ToList();
        }
        public QParameterStatus GetQParameterStatusById(int? id)
        {
            return _ctx.QParameterStatuss
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Company
        public IEnumerable<Company> GetAllCompany()
        {
            return _ctx.Companys
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Company GetCompanyById(int? id)
        {
            return _ctx.Companys
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region HasT
        public IEnumerable<HasT> GetAllHasT()
        {
            return _ctx.HasTs
                .OrderBy(p => p.Name)
                .ToList();
        }
        public HasT GetHasTById(int? id)
        {
            return _ctx.HasTs
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Minute
        public IEnumerable<Minute> GetAllMinute()
        {
            return _ctx.Minutes
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Minute GetMinuteById(int? id)
        {
            return _ctx.Minutes
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Site
        public IEnumerable<Site> GetAllSite()
        {
            return _ctx.Sites
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Site GetSiteById(int? id)
        {
            return _ctx.Sites
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }


        #endregion
        #region TypeOfCorn
        public IEnumerable<TypeOfCorn> GetAllTypeOfCorn()
        {
            return _ctx.TypeOfCorns
            .OrderBy(p => p.Name)
            .ToList();
        }

        public TypeOfCorn GetTypeOfCornById(int? id)
        {
            return _ctx.TypeOfCorns
            .Where(s => s.Id == id)
            .FirstOrDefault();
        }
        #endregion
        #region PauseTime
        public IEnumerable<PauseTime> GetAllPauseTime()
        {
            return _ctx.PauseTimes
            .OrderBy(p => p.Id)
            .ToList();
        }

        public PauseTime GetPauseTimeById(int? id)
        {
            return _ctx.PauseTimes
             .Where(s => s.Id == id)
             .FirstOrDefault();
        }
        public List<PauseTime> GetAllPauseTimeWithDate(string DateQD)
        {
            return _ctx.PauseTimes.Where(s => s.BreakDate == DateQD)
                .OrderBy(p => p.Id)
                .Include(d => d.Hour)
                .ToList();
        }
        //public List<PauseTime> GetAllPauseDateBetweenTwoDate(string StartDate , string EndDate)
        //{
        //    return _ctx.PauseTimes.Where(s => s.BreakDate >= StartDate && s.BreakDate <= EndDate)
        //        .OrderBy(p => p.Id)
        //        .Include(d => d.Hour)
        //        .ToList();
        //}
        #endregion
    }
}