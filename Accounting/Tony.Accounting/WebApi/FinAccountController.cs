using System;
using System.Collections.Generic;
using System.Net.Http;
using Tony.Accounting.Models;

namespace Tony.Accounting.WebApi
{
    public class FinAccountController:BaseController
    {
        //[ImportingConstructor]
        //public FinAccountController(IAccountService service)
        //{
        //    Service = service;
        //}

        public IEnumerable<Account> Get()
        {
            return Service.GetAccounts();
        }

        public Account Get(int id)
        {
            return Service.FindAccount(id);
        }

        public HttpResponseMessage Post(Account account)
        {
            try
            {
                Service.AddAccount(account);
                Succeded = account.Id != 0;
                Message = account.Id == 0 ? ErrorMessage : SuccesMessage;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Succeded = false;
            }

            return Request.CreateResponse(new { Succeded, Message, content = new { account.Id } });
        }
    }
}
