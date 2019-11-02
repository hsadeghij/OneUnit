using AutoMapper;
using OneUnit.Areas.QC.Data.Entities;
using OneUnit.Areas.QC.ViewModels;
using OneUnit.Data.Entities;
using OneUnit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Data
{
    public class OneUnitMappingProfile:Profile
    {
        public OneUnitMappingProfile()
        {
            #region QC
            CreateMap<Order, OrderViewModel>()
                .ForMember(o=>o.OrderId,ex=>ex.MapFrom(o=>o.Id))
                .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.QualityDesign, OneUnit.Areas.QC.ViewModels.QualityDesignViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.ProcessName, OneUnit.Areas.QC.ViewModels.ProcessNameViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.ControlParameter, OneUnit.Areas.QC.ViewModels.ControlParameterViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.DegreeOfImportance, OneUnit.Areas.QC.ViewModels.DegreeOfImportanceViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.UnitOfMeasurement, OneUnit.Areas.QC.ViewModels.UnitOfMeasurementViewModel>()
            .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
            .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.SamplingLocation, OneUnit.Areas.QC.ViewModels.SamplingLocationViewModel>()
               .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
               .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.SampleValue, OneUnit.Areas.QC.ViewModels.SampleValueViewModel>()
               .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
               .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.TestValue, OneUnit.Areas.QC.ViewModels.TestValueViewModel>()
               .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
               .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.OrganizationalUnit, OneUnit.Areas.QC.ViewModels.OrganizationalUnitViewModel>()
               .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
               .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.ProcessType, OneUnit.Areas.QC.ViewModels.ProcessTypeViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Confirmation, OneUnit.Areas.QC.ViewModels.ConfirmationViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Day, OneUnit.Areas.QC.ViewModels.DayViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Year, OneUnit.Areas.QC.ViewModels.YearViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Month, OneUnit.Areas.QC.ViewModels.MonthViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Hour, OneUnit.Areas.QC.ViewModels.HourViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Shift, OneUnit.Areas.QC.ViewModels.ShiftViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.QualityControl, OneUnit.Areas.QC.ViewModels.QualityControlViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Tank, OneUnit.Areas.QC.ViewModels.TankViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Storage, OneUnit.Areas.QC.ViewModels.StorageViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Production, OneUnit.Areas.QC.ViewModels.ProductionViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.ColumnNumber, OneUnit.Areas.QC.ViewModels.ColumnNumberViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.QParameterStatus, OneUnit.Areas.QC.ViewModels.QParameterStatusViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.DateForQualityDesign, OneUnit.Areas.QC.ViewModels.DateForQualityDesignViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(o => o.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Company, OneUnit.Areas.QC.ViewModels.CompanyViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.HasT, OneUnit.Areas.QC.ViewModels.HasTViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Minute, OneUnit.Areas.QC.ViewModels.MinuteViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.Site, OneUnit.Areas.QC.ViewModels.SiteViewModel>()
            .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
            .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.TypeOfCorn, OneUnit.Areas.QC.ViewModels.TypeOfCornViewModel>()
            .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
            .ReverseMap();
            CreateMap<OneUnit.Areas.QC.Data.Entities.PauseTime, OneUnit.Areas.QC.ViewModels.PauseTimeViewModel>()
            .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
            .ReverseMap();
            #endregion
            #region Transit
            CreateMap<OneUnit.Areas.Transit.Data.Entities.Person, OneUnit.Areas.Transit.ViewModels.PersonViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.Post, OneUnit.Areas.Transit.ViewModels.PostViewModel>()
            .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
            .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.WorkType, OneUnit.Areas.Transit.ViewModels.WorkTypeViewModel>()
            .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
            .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.CurrentState, OneUnit.Areas.Transit.ViewModels.CurrentStateViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.TransitInfo, OneUnit.Areas.Transit.ViewModels.TransitInfoViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.Rating, OneUnit.Areas.Transit.ViewModels.RatingViewModel>()
             .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
             .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.Project, OneUnit.Areas.Transit.ViewModels.ProjectViewModel>()
            .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
            .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.ProjectPlan, OneUnit.Areas.Transit.ViewModels.ProjectPlanViewModel>()
           .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
           .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.Attachment, OneUnit.Areas.Transit.ViewModels.AttachmentViewModel>()
           .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
           .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.TraceWorker, OneUnit.Areas.Transit.ViewModels.TraceWorkerViewModel>()
           .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
           .ReverseMap();
            CreateMap<OneUnit.Areas.Transit.Data.Entities.TransitType, OneUnit.Areas.Transit.ViewModels.TransitTypeViewModel>()
           .ForMember(o => o.Id, ex => ex.MapFrom(c => c.Id))
           .ReverseMap();
            #endregion
        }
    }
}
