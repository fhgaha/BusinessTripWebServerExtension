using BusinessTripWebServerExtension.Models;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.ObjectModel.Services;
using DocsVision.BackOffice.WebClient.Employee;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;

namespace BusinessTripWebServerExtension.Services
{
    public class CustomTicketsCostService : ICustomTicketsCostService
    {
        public CustomTicketsCostData GetCustomTicketsCostData(SessionContext context) => new CustomTicketsCostData { Cost = "222" };
    }
}
