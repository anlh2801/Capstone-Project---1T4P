using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IITSupporterService
    {
        List<ITSupporterAPIViewModel> GetAllITSupporter();
    }

    public partial class ITSupporterService
    {
        public List<ITSupporterAPIViewModel> GetAllITSupporter()
        {
            List<ITSupporterAPIViewModel> rsList = new List<ITSupporterAPIViewModel>();
            var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var companies = ITSupporterRepo.GetActive().ToList();

            foreach (var item in companies)
            {                
                rsList.Add(new ITSupporterAPIViewModel
                {
                    ITSupporterId = item.ITSupporterId,
                    ITSupporterName = item.ITSupporterName,
                    Username = item.Account.Username,
                    Telephone = item.Telephone,
                    Email = item.Email,
                    Gender = item.Gender,
                    Address = item.Address,
                    RatingAVG = item.RatingAVG,
                    IsBusy = item.IsBusy,
                    CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                });
            }

            return rsList;
        }
}
}
