//using BusinessTripWebServerExtension.Models;
//using DocsVision.BackOffice.ObjectModel;
//using DocsVision.BackOffice.ObjectModel.Services;
//using DocsVision.BackOffice.WebClient.Employee;
//using DocsVision.Platform.WebClient;
//using System;
//using System.Collections.Generic;

//namespace BusinessTripWebServerExtension.Services
//{
//    public class CustomTicketsCostService : ICustomTicketsCostService
//    {
//        public CustomTicketsCostData GetCustomTicketsCostData(SessionContext context, Guid employeeId)
//        {
//            StaffEmployee employee = context.ObjectContext.GetObject<StaffEmployee>(employeeId);
//            if (employee == null) return null;
//            CustomEmployeeData model = BuildCustomEmployeeDataModel(employee);
//            return model;
//        }
//    }
//}
