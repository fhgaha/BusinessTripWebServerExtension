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
    public class CustomApprovingStageOperationDataController : Controller
    {
        readonly ICurrentObjectContextProvider currentObjectContextProvider;
        readonly ICustomApprovingStageOperationService customOperationService;

        public CustomApprovingStageOperationDataController(
            ICurrentObjectContextProvider currentObjectContextProvider,
            ICustomApprovingStageOperationService customOperationService)
        {
            this.currentObjectContextProvider = currentObjectContextProvider;
            this.customOperationService = customOperationService;
        }

        public ActionResult GetCustomApprovingStageOperationData(Guid cardId, string approvalStageName)
        {
            SessionContext sessionContext = currentObjectContextProvider.GetOrCreateCurrentSessionContext();
            CustomApprovingStageOperationData model = customOperationService
                .GetCustomApprovingStageOperationData(sessionContext, cardId, approvalStageName);
            CommonResponse<CustomApprovingStageOperationData> response = CommonResponse.CreateSuccess(model);
            ContentResult result = Content(JsonHelper.SerializeToJson(response));
            return result;
        }
    }
}
