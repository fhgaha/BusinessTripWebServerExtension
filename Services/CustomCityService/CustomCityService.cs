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
    }
}
