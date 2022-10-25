//using System.Net;
//using System.Net.Http;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using SAF.Kernel.CommandBus;
//using SAF.ONet.PerformanceEvaluation.ApiService.Security.Models;
//using SAF.ONet.PerformanceEvaluation.ApiService.SeedWorks.Core;
//using SAF.ONet.PerformanceEvaluation.ApiService.SeedWorks.Models;

//namespace SAF.ONet.PerformanceEvaluation.ApiService.Security.Core
//{
//    public abstract class SecurityApiControllerBase : ApiControllerBase
//    {
//        private readonly ApplicationRoleManager _appRoleManager = null;

//        protected SecurityApiControllerBase(ICommandBus bus)
//            : base(bus)
//        {
//        }

//        protected ApplicationRoleManager AppRoleManager
//        {
//            get { return _appRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>(); }
//        }

//        #region Helpers

//        protected HttpResponseMessage GetErrorResult(IdentityResult result)
//        {
//            if (result == null)
//            {
//                return Request.CreateResponse(HttpStatusCode.InternalServerError,
//                    CreateResponseModel("Internal Server Error", ResponseMessageType.Error));
//            }
//            return result.Succeeded ? null : BadRequestResult(result.Errors);
//        }


//        #endregion
//    }
//}