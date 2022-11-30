using BusinessTripWebServerExtension.Models;
using DocsVision.Platform.WebClient;
using System;

namespace BusinessTripWebServerExtension.Services
{ 
    public interface ICustomCityService
    {
        CustomCityData GetCustomCityData(SessionContext context, Guid cityId);
    }
}
