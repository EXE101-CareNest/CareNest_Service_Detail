using System.ComponentModel;

namespace CareNest_Service_Detail.Domain.Commons.Enum
{
    public enum Status
    {
        [Description("Active")]
        Active = 1,

        [Description("Inactive")]
        Inactive = 0
    }
}
