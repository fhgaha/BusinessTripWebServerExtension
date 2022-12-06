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

            return new CustomCityData
            {
                DailyAllowance = city.ItemCard.MainInfo["DailyAllowance"].ToString(),
            };
        }
    }
}
