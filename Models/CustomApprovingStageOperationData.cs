using DocsVision.BackOffice.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTripWebServerExtension.Models
{
    public class CustomApprovingStageOperationData
    {
        public bool IsSuccessful { get; set; }
        public StatesState NewState { get; set; }
    }
}
