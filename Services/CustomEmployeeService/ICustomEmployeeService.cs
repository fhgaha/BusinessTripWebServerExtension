using BusinessTripWebServerExtension.Models;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTripWebServerExtension.Services
{
    public interface ICustomEmployeeService
    {
        CustomEmployeeData GetCustomEmployeeData(SessionContext context, Guid employeeId);
        CustomEmployeeModelsData GetCustomEmployeesFromGroup(SessionContext context, string groupName);
    }
}
