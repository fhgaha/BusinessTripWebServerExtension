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
    public class CustomEmployeeDataController : Controller
    {
        readonly ICurrentObjectContextProvider currentObjectContextProvider;
        readonly ICustomEmployeeService customEmplService;

        public CustomEmployeeDataController(ICurrentObjectContextProvider currentObjectContextProvider,
                                            ICustomEmployeeService customEmplService)
        {
            this.currentObjectContextProvider = currentObjectContextProvider;
            this.customEmplService = customEmplService;
        }

        public ActionResult GetCustomEmployeeData(Guid employeeId)
        {
            SessionContext sessionContext = currentObjectContextProvider.GetOrCreateCurrentSessionContext();
            CustomEmployeeData model = customEmplService.GetCustomEmployeeData(sessionContext, employeeId);
            CommonResponse<CustomEmployeeData> response = CommonResponse.CreateSuccess(model);
            ContentResult result = Content(JsonHelper.SerializeToJson(response));
            return result;
        }

        public ActionResult GetCustomEmployeesFromGroup(string groupName)
        {
            SessionContext sessionContext = currentObjectContextProvider.GetOrCreateCurrentSessionContext();
            CustomEmployeeModelsData model = customEmplService.GetCustomEmployeesFromGroup(sessionContext, groupName);
            CommonResponse<CustomEmployeeModelsData> response = CommonResponse.CreateSuccess(model);
            ContentResult result = Content(JsonHelper.SerializeToJson(response));
            return result;
        }
    }
}
