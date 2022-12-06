using BusinessTripWebServerExtension.Models;
using DocsVision.Platform.WebClient;

namespace BusinessTripWebServerExtension.Services
{
    public interface ICustomTicketsCostService
    {
        CustomTicketsCostData GetCustomTicketsCostData(SessionContext context);
    }
}
