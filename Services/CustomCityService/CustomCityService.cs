using BusinessTripWebServerExtension.Models;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.Platform.WebClient;
using System;

namespace BusinessTripWebServerExtension.Services
{
    public class CustomCityService : ICustomCityService
    {
        public CustomCityData GetCustomCityData(SessionContext context, Guid cityId)
        {
            BaseUniversalItem city = context.ObjectContext.GetObject<BaseUniversalItem>(cityId);
            if (city == null) return null;
            string allowance = city.ItemCard.MainInfo["DailyAllowance"].ToString();

            CustomCityData model = new CustomCityData
            {
                DailyAllowance = allowance,
            };
            return model;
        }

        // ILayoutPropertyItem cityControl = CustomizableControl.FindPropertyItem<ILayoutPropertyItem>("City");
        // if (cityControl == null) return;
        // SpinEdit daysControl = CustomizableControl.FindPropertyItem<SpinEdit>("TripDays");
        // if (daysControl == null) return;
        // ILayoutPropertyItem expensesControl = CustomizableControl.FindPropertyItem<ILayoutPropertyItem>("Expenses");
        // if (expensesControl == null) return;
        // BaseUniversalItem citiesRow = ObjContext.GetObject<BaseUniversalItem>((Guid)cityControl.ControlValue);
        // if (citiesRow == null) return;
        // string allowance = citiesRow.ItemCard.MainInfo["DailyAllowance"].ToString();
        // expensesControl.ControlValue = decimal.Parse(allowance) * daysControl.Value;
    }
}
