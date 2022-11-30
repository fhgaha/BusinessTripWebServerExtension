using BusinessTripWebServerExtension.Models;
using BusinessTripWebServerExtension.Services;
using DocsVision.Platform.WebClient;
using DocsVision.Platform.WebClient.Helpers;
using DocsVision.Platform.WebClient.Models;
using DocsVision.Platform.WebClient.Models.Generic;
using System;
using System.Web.Mvc;

namespace WebServerExtension.Controllers
{
    public class CustomCityDataController : Controller
    {
        readonly ICurrentObjectContextProvider currentObjectContextProvider;
        readonly ICustomCityService customCityService;

        public CustomCityDataController(ICurrentObjectContextProvider currentObjectContextProvider,
                                        ICustomCityService customCityService)
        {
            this.currentObjectContextProvider = currentObjectContextProvider;
            this.customCityService = customCityService;
        }

        public ActionResult GetCustomCityData(Guid cityId)
        {
            SessionContext sessionContext = currentObjectContextProvider.GetOrCreateCurrentSessionContext();
            CustomCityData model = customCityService.GetCustomCityData(sessionContext, cityId);
            CommonResponse<CustomCityData> response = CommonResponse.CreateSuccess(model);
            ContentResult result = Content(JsonHelper.SerializeToJson(response));
            return result;
        }
    }
}
