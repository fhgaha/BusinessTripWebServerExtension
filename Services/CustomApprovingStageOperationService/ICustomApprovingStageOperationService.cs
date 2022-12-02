using BusinessTripWebServerExtension.Models;
using DocsVision.Platform.WebClient;
using System;

namespace BusinessTripWebServerExtension.Services
{
    public interface ICustomApprovingStageOperationService
    {
        CustomApprovingStageOperationData GetCustomApprovingStageOperationData(SessionContext context, Guid cardId, string approvalStageName);
    }
}
