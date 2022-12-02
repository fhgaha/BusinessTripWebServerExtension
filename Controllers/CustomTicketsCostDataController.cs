//using BusinessTripWebServerExtension.Models;
//using BusinessTripWebServerExtension.Services;
//using DocsVision.Platform.WebClient;
//using DocsVision.Platform.WebClient.Helpers;
//using DocsVision.Platform.WebClient.Models;
//using DocsVision.Platform.WebClient.Models.Generic;
//using System;
//using System.Web.Mvc;

//namespace WebServerExtension.Controllers
//{
//    public class CustomTicketsCostDataController : Controller
//    {
//        private readonly ICurrentObjectContextProvider currentObjectContextProvider;
//        private readonly ICustomTicketsCostService customTicketsCostService;

//        public CustomTicketsCostDataController(
//            ICurrentObjectContextProvider currentObjectContextProvider, 
//            ICustomTicketsCostService customTicketsCostService)
//        {
//            this.currentObjectContextProvider = currentObjectContextProvider;
//            this.customTicketsCostService = customTicketsCostService;
//        }

//        public ActionResult GetCustomTicketsCostData(Guid cityId)
//        {
//            //SessionContext sessionContext = currentObjectContextProvider.GetOrCreateCurrentSessionContext();
//            //CustomCityData model = customCityService.GetCustomCityData(sessionContext, cityId);
//            //CommonResponse<CustomCityData> response = CommonResponse.CreateSuccess(model);
//            //ContentResult result = Content(JsonHelper.SerializeToJson(response));
//            //return result;

//            SessionContext sessionContext = currentObjectContextProvider.GetOrCreateCurrentSessionContext();
//            sessionContext.ObjectContext.GetService<>
//        }
//    }
//}
