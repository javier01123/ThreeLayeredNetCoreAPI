using System.ComponentModel;

namespace DemoAPI.DAL.Enums
{
    public enum UserType
    {
        [Description("ADMIN")]
        Admin = 1,

        [Description("REGULAR")]
        Normal = 2
    }
}
