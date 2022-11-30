using BusinessTripWebServerExtension.Models;
using DocsVision.Platform.WebClient;
using System;

namespace BusinessTripWebServerExtension.Services
{
    public interface ICustomEmployeeService
    {
        CustomEmployeeData GetCustomEmployeeData(SessionContext context, Guid employeeId);
        CustomEmployeeModelsData GetCustomEmployeesFromGroup(SessionContext context, string groupName);
    }
}
