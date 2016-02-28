using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ThreeDSecureParamsInfo
    {
        public bool Process { get; set; }
        public List<ThreeDSecureParamDetail> ThreeDSecureParams { get; set; }
        public List<ThreeDSecureParamDetail> PostParameters { get; set; }
        public string ThreeDSecurePostUrl { get; set; }
        public string ThreeDSecurePostMessage { get; set; }
        public string ThreeDSecureHash { get; set; }

        public class ThreeDSecureParamDetail
        {
            public string ParamName { get; set; }
            public string ParamValue { get; set; }
        }
    }
}
