using System.Net.Http;
using System.Web.Http;

namespace Tony.Accounting.WebApi
{
    //[Export]
    //[PartCreationPolicy(CreationPolicy.NonShared)]
    public class BaseController:ApiController
    {

        protected HttpResponseMessage Response;

        protected bool Succeded;

        protected string Message;

        protected const string ErrorMessage = "Error in saving changes";

        protected const string SuccesMessage = "Save changes succeded";

        public BaseController()
        {
        }
    }
}
