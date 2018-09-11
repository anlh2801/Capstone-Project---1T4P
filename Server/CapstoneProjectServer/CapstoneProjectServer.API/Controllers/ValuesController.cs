using CapstoneProjectServer.API.Validators;
using CapstoneProjectServer.BusinessLogic.Services;
using CapstoneProjectServer.DataAccess.EF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CapstoneProjectServer.API.Controllers
{
    
    public class ValuesController : ApiController
    {
        private  IContactService _contactService;
        private IUnitOfWork _unitOfWork;
        public ValuesController(IContactService contactService,IUnitOfWork unitOfWork)
        {
            this._contactService = contactService;
            this._unitOfWork = unitOfWork;
        }
       
        [HttpGet]
        [Route("contact/latest-contact")]
        public async Task<HttpResponseMessage> GetAllValue()
        {
            
            var result = await _contactService.GetLatestContact();
            if (!result.Success)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Validations);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result.Result);


        }
        
        [HttpPost]
        [Route("value/data-test")]
        public async Task<HttpResponseMessage> AddData(An anDto)
        {
            var anvalidator = new AnValidator();
            var result = await anvalidator.ValidateAsync(anDto);
            if (result.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { game = "Hoang", price = 100 });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }   
        }
      
    }
}
