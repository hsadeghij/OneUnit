using OneUnit.Areas.Transit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.Transit.Data
{
    public interface ITransitRepository
    {
        #region Person
         IEnumerable<Person> GetAllPerson();
        Person GetPersonById(int? id);
        #endregion
        #region Post
        IEnumerable<Post> GetAllPost();
        Post GetPostById(int? id);
        #endregion
        #region WorkType
        IEnumerable<WorkType> GetAllWorkType();
        WorkType GetWorkTypeById(int? id);
        #endregion
        #region Common
        void AddEntity(object model);
        void DeleteEntity(object model);
        bool SaveAll();
        #endregion
        #region CurrentState
        IEnumerable<CurrentState> GetAllCurrentState();
        CurrentState GetCurrentStateById(int? id);
        #endregion
        #region TransitInfo
        IEnumerable<TransitInfo> GetAllTransitInfo();
        TransitInfo GetTransitInfoById(int? id);
        dynamic GetAllTransitInfo_EnableForCombo_Worker(string Items, string itemSwitch);
        dynamic GetAllTransitInfo_EnableForComboWithoutTime_Worker(string Items, string itemSwitch);
        dynamic GetAllTransitInfo_Enable();
        dynamic GetAllTransitInfoWithPerson();
        void Update_StatusTransit(int Id, int value);
        void Save_TransitInfo(int? tPersonI, byte ratingId);
        #endregion
        #region Rating
        IEnumerable<Rating> GetAllRating();
        Rating GetRatingById(int? id);
        #endregion
        #region Project
        IEnumerable<Project> GetAllProject();
        Project GetProjectById(int? id);
        #endregion
        #region ProjectPlan
        IEnumerable<ProjectPlan> GetAllProjectPlan();
        IEnumerable<ProjectPlan> GetAllProjectPlan_WithProjectId(int projectId);
        ProjectPlan GetProjectPlanById(int? id);
        int Add_ProjectPlan_ReturnId(ProjectPlan projctplan);
        IEnumerable<ProjectPlan> GetAllProjectPlanForCombo();
        #endregion
        #region TraceWorker
        void Save_TraceWorker(int projectPlanId, int transitTypeId, string dateReg, string timeReg, int transitInfoId,int PostId);
        #endregion
        #region Upload Image
        IEnumerable<Attachment> GetAllAttachment();
        List<Attachment> GetAllAttachmentForShow(int Value1);
        #endregion

    }
}
