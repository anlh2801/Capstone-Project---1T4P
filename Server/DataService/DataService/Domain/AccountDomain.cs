﻿using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{

    public interface IAccountDomain
    {
        ResponseObject<AccountAPIViewModel> ViewProfile(int account_id);
        ResponseObject<AgencyAPIViewModel> CheckLoginForAgency(string username, string password, int roleid);
        ResponseObject<ITSupporterAPIViewModel> CheckLoginForITSupporter(string username, string password, int roleid);
        ResponseObject<List<AccountAPIViewModel>> GetAllAccount();
        ResponseObject<bool> CreateAccount(AccountAPIViewModel model);
        ResponseObject<bool> RemoveAccount(int account_id);
        ResponseObject<bool> UpdateProfile(AccountAPIViewModel model);

        ResponseObject<AccountAPIViewModel> CheckLogin(string username, string password, int roleId);
        ResponseObject<List<AccountAPIViewModel>> GetAllAgencyAccount();
    };

    public class AccountDomain : BaseDomain, IAccountDomain
    {
        public ResponseObject<AgencyAPIViewModel> CheckLoginForAgency(string username, string password, int roleid)
        {
            var accountService = this.Service<IAccountService>();
            var isLoginSucess = accountService.CheckLoginForAgency(username, password, roleid);
            return isLoginSucess;
        }

        public ResponseObject<ITSupporterAPIViewModel> CheckLoginForITSupporter(string username, string password, int roleid)
        {
            var accountService = this.Service<IAccountService>();
            var isLoginSucess = accountService.CheckLoginForITSupporter(username, password, roleid);
            return isLoginSucess;
        }

        public ResponseObject<bool> CreateAccount(AccountAPIViewModel model)
        {
            var AccountService = this.Service<IAccountService>();

            var result = AccountService.CreateAccount(model);

            return result;
        }

        public ResponseObject<List<AccountAPIViewModel>> GetAllAccount()
        {
            var accountService = this.Service<IAccountService>();

            var accounts = accountService.GetAllAccount();

            return accounts;
        }

        public ResponseObject<AccountAPIViewModel> ViewProfile(int account_id)
        {
            var accountService = this.Service<IAccountService>();

            var account = accountService.ViewProfile(account_id);

            return account;
        }
        public ResponseObject<bool> RemoveAccount(int account_id)
        {
            var AccountList = new List<AccountAPIViewModel>();

            var accountService = this.Service<IAccountService>();
            var rs = accountService.RemoveAccount(account_id);
            return rs;
        }

        public ResponseObject<bool> UpdateProfile(AccountAPIViewModel model)
        {
            var accountService = this.Service<IAccountService>();

            var result = accountService.UpdateProfile(model);

            return result;
        }

        public ResponseObject<AccountAPIViewModel> CheckLogin(string username, string password, int roleId)
        {
            var accountService = this.Service<IAccountService>();

            var result = accountService.CheckLogin(username, password, roleId);

            return result;
        }

        public ResponseObject<List<AccountAPIViewModel>> GetAllAgencyAccount()
        {
            var accountService = this.Service<IAccountService>();

            var accounts = accountService.GetAllAgencyAccount();

            return accounts;
        }
    }
}
