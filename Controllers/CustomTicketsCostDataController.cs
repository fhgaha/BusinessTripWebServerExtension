using BusinessTripWebServerExtension.Models;
using BusinessTripWebServerExtension.Services;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.Platform.ObjectManager;
using DocsVision.Platform.WebClient;
using DocsVision.Platform.WebClient.Helpers;
using DocsVision.Platform.WebClient.Models;
using DocsVision.Platform.WebClient.Models.Generic;
using System;
using System.Web.Mvc;

namespace WebServerExtension.Controllers
{
    public class CustomTicketsCostDataController : Controller
    {
        private readonly ICurrentObjectContextProvider currentObjectContextProvider;
        private readonly ICustomTicketsCostService customTicketsCostService;

        public CustomTicketsCostDataController(
            ICurrentObjectContextProvider currentObjectContextProvider,
            ICustomTicketsCostService customTicketsCostService)
        {
            this.currentObjectContextProvider = currentObjectContextProvider;
            this.customTicketsCostService = customTicketsCostService;
        }

        public ActionResult GetCustomTicketsCostData(string destinationId, DateTime departureDate, DateTime destinationDate)
        {
            SessionContext sessionContext = currentObjectContextProvider.GetOrCreateCurrentSessionContext();
            BaseUniversalItem citiesRow = sessionContext.ObjectContext.GetObject<BaseUniversalItem>(new Guid(destinationId));
            string destIATA = citiesRow.ItemCard.MainInfo["AeroCode"].ToString();

            ExtensionMethod method = sessionContext.Session.ExtensionManager.GetExtensionMethod("DEVSchoolSE", "GetTicketsCost");
            method.Parameters.AddNew("destinationIATA", ParameterValueType.String, destIATA);
            method.Parameters.AddNew("since", ParameterValueType.DateTime, departureDate);
            method.Parameters.AddNew("till", ParameterValueType.DateTime, destinationDate);
            string cost = method.Execute().ToString();

            CustomTicketsCostData model = new CustomTicketsCostData { Cost = cost };

            CommonResponse<CustomTicketsCostData> response = CommonResponse.CreateSuccess(model);
            ContentResult result = Content(JsonHelper.SerializeToJson(response));
            return result;
        }
    }
}
