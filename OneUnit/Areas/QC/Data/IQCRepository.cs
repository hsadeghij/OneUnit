using System.Collections.Generic;
using OneUnit.Areas.QC.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneUnit.Areas.Admin.Data.Entities;
using OneUnit.Areas.QC.ViewModels;
using System;

namespace OneUnit.Areas.QC.Data
{
    public interface IQCRepository
    {
        #region ProcessName
        IEnumerable<ProcessName> GetAllProcessName();
        IEnumerable<ProcessName> GetJustProcessName();
        ProcessName GetProcessNameById(int? id);
        ProcessName GetOneRecoredWithProcessNameId(int Id);
        #endregion
        #region QualityDesign
        IEnumerable<QualityDesign> GetAllQualityDesign();
        UsersQualityDesignViewModel GetAllUser();
        QualityDesign GetQualityDesignById(int? id);
        IEnumerable<QualityDesign> QualityDesigns { get; }
        IEnumerable<ControlParameter> GetControlParameter(int? Value1 ,int? Value2);
        IEnumerable<QualityDesign> GetQualityDesignForTypeOfCorn(String Value1, int? Value2);
        IEnumerable<ProcessName> GetProcessnameWithCompany(int? Value1);
        IEnumerable<SamplingLocation> GetSamplingLocationWithProcessName(int? Value1);
        ControlParameter GetOneRecoredWithControlParametreId(int Id);
        Boolean CheckExistenceId(int Id);
        List<QualityDesign> GetAllQualityDesignWithDate(string DateQD);
        List<QualityDesign> GetAllQualityDesignForShow(string Value1, int Value2, int Value3, int Value4, string Value5,byte Value6);
        #endregion
        #region ControlParameter
        IEnumerable<ControlParameter> GetAllControlParameter();
        ControlParameter GetControlParameterById(int? id);
        #endregion
        #region DegreeOfImportance
        IEnumerable<DegreeOfImportance> GetAllDegreeOfImportance();
        DegreeOfImportance GetDegreeOfImportanceById(int? id);
        #endregion
        #region UnitOfMeasurement
        IEnumerable<UnitOfMeasurement> GetAllUnitOfMeasurement();
        UnitOfMeasurement GetUnitOfMeasurementById(int? id);
        #endregion
        #region SamplingLocation
        IEnumerable<SamplingLocation> GetAllSamplingLocation();
        SamplingLocation GetSamplingLocationById(int? id);
        IEnumerable<SamplingLocation> GetJustSamplingLocation();
        IEnumerable<SamplingLocation> GetSamplingLocationWithCompany(int? Value1);
        #endregion
        #region SampleValue
        IEnumerable<SampleValue> GetAllSampleValue();
        SampleValue GetSampleValueById(int? id);
        #endregion
        #region TestValue
        IEnumerable<TestValue> GetAllTestValue();
        TestValue GetTestValueById(int? id);
        #endregion
        #region ProcessType
        IEnumerable<ProcessType> GetAllProcessType();
        ProcessType GetProcessTypeById(int? id);
        #endregion
        #region Day
        IEnumerable<Day> GetAllDay();
        Day GetDayById(int? id);
        #endregion
        #region Year
        IEnumerable<Year> GetAllYear();
        Year GetYearById(int? id);
        #endregion
        #region Month
        IEnumerable<Month> GetAllMonth();
        Month GetMonthById(int? id);
        #endregion
        #region Hour
        IEnumerable<Hour> GetAllHour();
        Hour GetHourById(int? id);
        #endregion
        #region Shift
        IEnumerable<Shift> GetAllShift();
        Shift GetShiftById(int? id);
        #endregion
        #region QualityControl
        IEnumerable<QualityControl> GetAllQualityControl();
        QualityControl GetQualityControlById(int? id);
        #endregion
        #region Confirmation
        IEnumerable<Confirmation> GetAllConfirmation();
        Confirmation GetConfirmationById(int? id);
        #endregion
        #region OrganizationalUnit
        IEnumerable<OrganizationalUnit> GetAllOrganizationalUnit();
        OrganizationalUnit GetOrganizationalUnitById(int? id);
        #endregion
        #region Common
        void AddEntity(object model);
        void DeleteEntity(object model);
        bool SaveAll();
        #endregion
        #region Tank
        IEnumerable<Tank> GetAllTank();
        Tank GetTankById(int? id);
        #endregion
        #region Storage
        IEnumerable<Storage> GetAllStorage();
        Storage GetStorageById(int? id);
        #endregion
        #region Production
        IEnumerable<Production> GetAllProduction();
        Production GetProductionById(int? id);
        #endregion
        #region ColumnNumber
        IEnumerable<ColumnNumber> GetAllColumnNumber();
        ColumnNumber GetColumnNumberById(int? id);
        #endregion
        #region QParameterStatus
        IEnumerable<QParameterStatus> GetAllQParameterStatus();
        QParameterStatus GetQParameterStatusById(int? id);
        #endregion
        #region Company
        IEnumerable<Company> GetAllCompany();
        Company GetCompanyById(int? id);
        #endregion
        #region Minute
        IEnumerable<Minute> GetAllMinute();
        Minute GetMinuteById(int? id);
        #endregion
        #region HasT
        IEnumerable<HasT> GetAllHasT();
        HasT GetHasTById(int? id);
        #endregion
        #region Site
         IEnumerable<Site> GetAllSite();
         Site GetSiteById(int? id);
        #endregion
        #region TypeOfCorn
        IEnumerable<TypeOfCorn> GetAllTypeOfCorn();
        TypeOfCorn GetTypeOfCornById(int? id);
        #endregion
        #region PauseTime
        IEnumerable<PauseTime> GetAllPauseTime();
        PauseTime GetPauseTimeById(int? id);
        List<PauseTime> GetAllPauseTimeWithDate(string DateQD);
        #endregion
    }
}