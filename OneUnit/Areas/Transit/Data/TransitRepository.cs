using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneUnit.Areas.Admin.Data.Entities;
using OneUnit.Areas.Transit.Data.Entities;
using OneUnit.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data
{
    public class TransitRepository : ITransitRepository
    {
        private readonly OneUnitContext _ctx;

        private readonly UserManager<StoreUser> _userManager;

        public TransitRepository(OneUnitContext ctx, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }
        #region Person
        public IEnumerable<Person> GetAllPerson()
        {
            return _ctx.Persons
                .OrderBy(p => p.FullName)
                .ToList();
        }
        public Person GetPersonById(int? id)
        {
            return _ctx.Persons
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Post
        public IEnumerable<Post> GetAllPost()
        {
            return _ctx.Posts
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Post GetPostById(int? id)
        {
            return _ctx.Posts
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region WorkType
        public IEnumerable<WorkType> GetAllWorkType()
        {
            return _ctx.WorkTypes
                .OrderBy(p => p.Name)
                .ToList();
        }
        public WorkType GetWorkTypeById(int? id)
        {
            return _ctx.WorkTypes
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
        #region CurrentState
        public IEnumerable<CurrentState> GetAllCurrentState()
        {
            return _ctx.CurrentStates
                .OrderBy(p => p.Name)
                .ToList();
        }
        public CurrentState GetCurrentStateById(int? id)
        {
            return _ctx.CurrentStates
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region TransitInfo
        public IEnumerable<TransitInfo> GetAllTransitInfo()
        {
            return _ctx.TransitInfos
                .OrderBy(p => p.DateReg)
                .ToList();
        }
        public TransitInfo GetTransitInfoById(int? id)
        {
            return _ctx.TransitInfos
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }

        public dynamic GetAllTransitInfo_EnableForCombo_Worker(string Items,string itemSwitch)
        {
           var  empRecord = _ctx.EnableWorkerViewModels.FromSql("Show_EnableWorkers {0}", Items).ToList();
            #region relation in linq
            //var query = (from t in _ctx.TransitInfos
            //             join p in _ctx.Persons on t.PersonId equals p.Id
            //             where t.CurrentStateId == 1 || Items.Contains(t.Id.ToString())
            // orderby p.FullName
            // select new
            // {
            //     t.Id,
            //     p.FullName
            // }).ToList();
            //return query;
            // var lst = _ctx.Set<EnableWorker>().FromSql("Show_EnableWorkers {0}", Items);
            //SqlParameter value1Input = new SqlParameter("@Items", Items ?? (object)DBNull.Value);

            //var lst = _ctx.Database.ExecuteSqlCommand("Show_EnableWorkers @Items", value1Input);

            //  IEnumerable<EnableWorker> empDetails = _ctx.Database.ExecuteSqlCommand("Show_EnableWorkers @Items", Items)
            #endregion
            if (itemSwitch == "sarparast")
                 empRecord = _ctx.EnableWorkerViewModels.FromSql("Show_EnableSarparast {0}", Items).ToList();
            else if(itemSwitch == "ostadkar")
                 empRecord = _ctx.EnableWorkerViewModels.FromSql("Show_EnableOstadKar {0}", Items).ToList();

            return empRecord;
        }
        public dynamic GetAllTransitInfo_EnableForComboWithoutTime_Worker(string Items, string itemSwitch)
        {
            var empRecord = _ctx.EnableWorkerViewModels.FromSql("Show_EnableWorkersWithoutTime {0}", Items).ToList();
            if (itemSwitch == "sarparast")
                 empRecord = _ctx.EnableWorkerViewModels.FromSql("Show_EnableSarparastWithoutTime {0}", Items).ToList();
            else if (itemSwitch == "ostadkar")
                empRecord = _ctx.EnableWorkerViewModels.FromSql("Show_EnableOstadKarWithoutTime {0}", Items).ToList();
            return empRecord;
        }

        public dynamic GetAllTransitInfo_Enable()
        {
            var query = (from t in _ctx.TransitInfos
                         join p in _ctx.Persons on t.PersonId equals p.Id
                         where t.CurrentStateId == 1 
                         orderby p.FullName
                         select new
                         {
                             t.Id,
                             p.FullName
                         }).ToList();
            return query;
        }
        public dynamic GetAllTransitInfoWithPerson()
        {
            var query = (from t in _ctx.TransitInfos
                         join p in _ctx.Persons on t.PersonId equals p.Id
                         orderby p.FullName
                         select new
                         {
                             t.Id,
                             p.FullName
                         }).ToList();
            return query;
        }
        public void Update_StatusTransit(int Id,int value)
        {

                var transitinfo = new TransitInfo { Id = Id, CurrentStateId = value };
                _ctx.TransitInfos.Attach(transitinfo);
                _ctx.Entry(transitinfo).Property(x => x.CurrentStateId).IsModified = true;
          
            
        }
        public void Save_TransitInfo(int? tPersonId, byte ratingId)
        {
            _ctx.Database.ExecuteSqlCommand("Save_TransitInfo @TPersonId ={0},@RatingId={1}", tPersonId, ratingId);
        }
        #endregion
        #region Rating
        public IEnumerable<Rating> GetAllRating()
        {
            return _ctx.Ratings
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Rating GetRatingById(int? id)
        {
            return _ctx.Ratings
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region Project
        public IEnumerable<Project> GetAllProject()
        {
            return _ctx.Projects
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Project GetProjectById(int? id)
        {
            return _ctx.Projects
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }
        #endregion
        #region ProjectPlan
        public IEnumerable<ProjectPlan> GetAllProjectPlan()
        {
            //return _ctx.ProjectPlans
            //    .OrderBy(p => p.ProjectId)
            //    .Include(p=>p.Person)
            //    .Include(p=> p.Project)
            //    .Include(p=>p.WorkType)
            //    .ToList();
            var empRecord1 = _ctx.ProjectPlanInCurrentDateViewModels.FromSql("Show_ProjectPlanInCurrentDate").ToList();
            ProjectPlan pPlan;
            List<ProjectPlan> listPlan = new List<ProjectPlan>();
            foreach (var item in empRecord1)
            {
                pPlan = new ProjectPlan();
                pPlan.Id = item.Id;
                pPlan.Person = new Person() { FullName = item.FullName };
                pPlan.Activity = item.Activity;
                pPlan.Description = item.Description;
                pPlan.WorkType = new WorkType() { Name = item.FullName };
                pPlan.WorkType.Name = item.WorkTypeName;
                pPlan.SarparastList = item.SarparastList;
                pPlan.OstadKarList = item.OstadKarList;
                pPlan.WorkerList = item.WorkerList;
                pPlan.DateReg = item.DateReg;

                listPlan.Add(pPlan);
            }
            return listPlan;
        }
        public IEnumerable<ProjectPlan> GetAllProjectPlanForCombo()
        {
            return _ctx.ProjectPlans
                .OrderBy(p => p.ProjectId)
                .ToList();
        }
        public IEnumerable<ProjectPlan> GetAllProjectPlan_WithProjectId(int projectId)
        {
            return _ctx.ProjectPlans
                .Where(s => s.ProjectId == projectId)
                .OrderBy(p => p.ProjectId)
                .Include(p => p.Person)
                .Include(p => p.Project)
                .Include(p => p.WorkType)
                .ToList();
        }
        public ProjectPlan GetProjectPlanById(int? id)
        {
             //IEnumerable<Person> PersonListTemp = _ctx.Persons
             //                     .OrderBy(p => p.FullName)
             //                     .ToList();

          // ProjectPlan ProjectPlanWithIdTemp_New = new ProjectPlan();
            ProjectPlan ProjectPlanWithIdTemp_Old = _ctx.ProjectPlans
                                         .Where(s => s.Id == id)
                                         .FirstOrDefault();
           // string[] WorkerListCodesTemp = ProjectPlanWithIdTemp_Old.WorkerListCodes.Split(',');
            //foreach (Person person in PersonListTemp)
            //{
            //    foreach (string item in WorkerListCodesTemp)
            //    {
            //        if (item == Convert.ToString(person.Id))
            //        {
            //            ProjectPlanWithIdTemp_New.WorkerList = ProjectPlanWithIdTemp_New.WorkerList + ","+  person.FullName ;
            //        }
            //    }
            //}
           // ProjectPlanWithIdTemp_Old.personList = ProjectPlanWithIdTemp_Old.WorkerListCodes.Split(',');
           // ProjectPlanWithIdTemp_New.WorkerList= ProjectPlanWithIdTemp_New.WorkerList.Remove(0,1)+",";
            //ProjectPlanWithIdTemp_Old.WorkerList = ProjectPlanWithIdTemp_New.WorkerList;
            return ProjectPlanWithIdTemp_Old;
        }
        public int Add_ProjectPlan_ReturnId(ProjectPlan projctplan)
        {
            _ctx.ProjectPlans.Add(projctplan);
            _ctx.SaveChanges();
            return projctplan.Id;
        }
        #endregion
        #region TraceWorker
        public void Save_TraceWorker(int projectPlanId,int transitTypeId,string dateReg,string timeReg,int transitInfoId,int PostId)
        {
            _ctx.Database.ExecuteSqlCommand("Save_TraceWorker @ProjectPlanId ={0},@TransitTypeId ={1},@DateReg ={2},@TimeReg ={3},@TransitInfoId={4},@PostId={5}", projectPlanId, transitTypeId, dateReg, timeReg, transitInfoId,PostId);
        }
        #endregion
        #region Upload Image
        public IEnumerable<Attachment> GetAllAttachment()
        {
            return _ctx.Attachments
                .OrderBy(p => p.Id)
                .ToList();
        }
        public List<Attachment> GetAllAttachmentForShow(int Value1)
        {
            return _ctx.Attachments.Where(s => s.ProjectPlanId == Value1)
              .OrderBy(p => p.Id)
              .ToList();
        }
            #endregion
        }
}
