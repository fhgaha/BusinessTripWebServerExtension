using BusinessTripWebServerExtension.Models;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.ObjectModel.Services;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTripWebServerExtension.Services
{
    public class CustomApprovingStageOperationService : ICustomApprovingStageOperationService
    {
        public CustomApprovingStageOperationData GetCustomApprovingStageOperationData(
            SessionContext context, Guid cardId, string approvalStageName)
        {
            BaseCard card = context.ObjectContext.GetObject<BaseCard>(cardId);
            IStateService stateService = context.ObjectContext.GetService<IStateService>();
            StatesStateMachineBranch branch = stateService
                .GetStateMachineBranches(card.SystemInfo.CardKind)
                .Single(b => b.Operation.DefaultName == approvalStageName);

            stateService.ChangeState(card, branch);
            return new CustomApprovingStageOperationData 
            { 
                IsSuccessful = true,
                NewState = card.SystemInfo.State, 
            };
        }
    }
}
