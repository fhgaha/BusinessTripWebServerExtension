using BusinessTripWebServerExtension.Models;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.ObjectModel.Services;
using DocsVision.BackOffice.WebClient.Employee;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;

namespace BusinessTripWebServerExtension.Services
{
    public class CustomEmployeeService : ICustomEmployeeService
    {
        public CustomEmployeeData GetCustomEmployeeData(SessionContext context, Guid employeeId)
        {
            StaffEmployee employee = context.ObjectContext.GetObject<StaffEmployee>(employeeId);
            if (employee == null) return null;
            CustomEmployeeData model = BuildCustomEmployeeDataModel(employee);
            return model;
        }

        private static CustomEmployeeData BuildCustomEmployeeDataModel(StaffEmployee employee)
        {
            CustomEmployeeData model = new CustomEmployeeData();
            AddManager(employee, model);
            AddPhone(employee, model);
            return model;
        }

        private static void AddManager(StaffEmployee employee, CustomEmployeeData model)
        {
            StaffEmployee manager = employee.Manager ?? employee.Unit.Manager;
            if (manager != null)
            {
                EmployeeModel managerModel = new EmployeeModel();
                managerModel.Initialize(manager);
                model.Manager = managerModel;
            }
        }

        private static void AddPhone(StaffEmployee employee, CustomEmployeeData model) => model.Phone = employee.Phone;

        public CustomEmployeeModelsData GetCustomEmployeesFromGroup(SessionContext context, string groupName)
        {
            IStaffService service = context.ObjectContext.GetService<IStaffService>();
            if (service == null) return null;
            StaffGroup group = service.FindGroupByName(null, groupName);
            if (group == null || group.GroupItems.Count == 0) return null;
            StaffGroupItem[] items = group.GroupItems.ToArray();

            CustomEmployeeModelsData model = new CustomEmployeeModelsData();
            List<EmployeeModel> list = new List<EmployeeModel>();
            foreach (StaffGroupItem item in items)
            {
                EmployeeModel m = new EmployeeModel();
                m.Initialize(item.Employee);
                list.Add(m);
            }
            model.Employees = list.ToArray();
            return model;
        }
    }
}
