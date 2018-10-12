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
    public partial interface IAgencyService
    {

        AgencyAPIViewModel ViewProfile(int agency_id);

        bool UpdateProfile(AgencyUpdateAPIViewModel model);

        List<AgencyAPIViewModel> GetAllAgency();

        bool CreateRequest(AgencyCreateRequestAPIViewModel model);

        void CreateTicket(List<AgencyCreateTicketAPIViewModel> listTicket, int RequestId);

        int AssignITSupporter(Ticket ticket);

        Boolean removeAgency(int agency_id);

        bool CreateAgency(AgencyAPIViewModel model);

    }

    public partial class AgencyService
    {
        public AgencyAPIViewModel ViewProfile(int agency_id)
        {            
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == agency_id);
            if  (agency != null)
            {
                   var agencyAPIViewModel = new AgencyAPIViewModel
                    {
                        AgencyId = agency.AgencyId,
                       CompanyId = agency.CompanyId ?? 0,
                       CompanyName = agency.Company.CompanyName,
                        AccountId = agency.AccountId,
                        UserName = agency.Account.Username,
                        AgencyName = agency.AgencyName,
                        Address = agency.Address,
                        Telephone = agency.Telephone,
                        CreateAt = agency.CreateDate != null ? agency.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateAt = agency.UpdateDate != null ? agency.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                   };
                return agencyAPIViewModel;
            }
            return null;
        }

        public bool UpdateProfile(AgencyUpdateAPIViewModel model)
        {
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var updateAgency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == model.AgencyId);
            if (updateAgency.AgencyId == model.AgencyId)
            {
                updateAgency.AgencyName = model.AgencyName;
                updateAgency.Address = model.Address;
                updateAgency.Telephone = model.Telephone;
                updateAgency.UpdateDate = DateTime.Now;

                agencyRepo.Edit(updateAgency);
                agencyRepo.Save();
                return true;
            }

            return false;
        }

        public List<AgencyAPIViewModel> GetAllAgency()
        {
            List<AgencyAPIViewModel> rsList = new List<AgencyAPIViewModel>();
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agencies = agencyRepo.GetActive().ToList();

            foreach (var item in agencies)
            {
                    rsList.Add(new AgencyAPIViewModel
                    {
                        AgencyId = item.AgencyId,
                        CompanyName = item.Company.CompanyName,
                        UserName = item.Account.Username,
                        AgencyName = item.AgencyName,
                        Address = item.Address,
                        Telephone = item.Telephone,
                        CreateAt = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateAt = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    });              
            }

            return rsList;
        }
        public Boolean removeAgency(int agency_id)
        {
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == agency_id);
            Deactivate(agency);
            return true;
        }

        public bool CreateAgency(AgencyAPIViewModel model)
        {
            try
            {
                var ticketTaskRepo = DependencyUtils.Resolve<IAgencyRepository>();
                var createTask = new Agency();

                createTask.CompanyId = model.CompanyId;
                createTask.AccountId = model.AccountId;
                createTask.AgencyName = model.AgencyName;
                createTask.Address = model.Address;
                createTask.Telephone = model.Telephone;
                createTask.IsDelete = false;
                createTask.CreateDate = DateTime.Now;
                ticketTaskRepo.Add(createTask);
                ticketTaskRepo.Save();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool CreateRequest(AgencyCreateRequestAPIViewModel model)
        {
            try
            {

                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();

                var createRequest = new Request();

                createRequest.AgencyId = model.AgencyId;
                createRequest.RequestCategoryId = model.RequestCategoryId;
                createRequest.RequestStatus = (int)RequestStatusEnum.Pending;
                createRequest.RequestName = model.RequestName;
                requestRepo.Add(createRequest);
                requestRepo.Save();

                CreateTicket(model.Ticket, createRequest.RequestId);

                createRequest.RequestStatus = (int)RequestStatusEnum.Processing; 

                requestRepo.Save();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }

        public void CreateTicket(List<AgencyCreateTicketAPIViewModel> listTicket, int RequestId)
        {

            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();

            foreach (var item in listTicket)
            {
                var createTicket = new Ticket();
                createTicket.RequestId = RequestId;
                createTicket.ServiceItemId = item.ServiceItemId;
                createTicket.DeviceId = item.DeviceId;
                createTicket.Current_TicketStatus = (int)TicketStatusEnum.Await;
                createTicket.Desciption = item.Desciption;

                createTicket.CurrentITSupporter_Id = AssignITSupporter(createTicket);
                ticketRepo.Add(createTicket);
            }
            ticketRepo.Save();

        }

        public int AssignITSupporter(Ticket ticket)
        {

            var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var itSupporter = itSupporterRepo.GetActive(p => (p.IsBusy == null || p.IsBusy == false)).FirstOrDefault(x => x.Skills.OrderByDescending(o => o.MonthExperience).Any(s => s.ServiceItemId == ticket.ServiceItemId));
            if (itSupporter != null)
            {
                //var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                //var ticketById = ticketRepo.GetActive().SingleOrDefault(a => a.TicketId == ticket.TicketId);
                //ticketById.CurrentITSupporter_Id = itSupporter.ITSupporterId;
                //ticketById.StartTime = DateTime.Now;
                itSupporter.IsBusy = true;
                //ticketById.Current_TicketStatus = (int)TicketStatusEnum.In_Process;

                itSupporterRepo.Edit(itSupporter);
                //ticketRepo.Edit(ticketById);

                itSupporterRepo.Save();
                //ticketRepo.Save;
            }

            return itSupporter.ITSupporterId;
        }


    }
}
