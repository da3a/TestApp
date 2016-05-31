using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core
{
    public static class AppConstants
    {
        public const string APPID = "IVD";

        public const string SESSION_ACTIVITY_LOG_ID = "__SessionActivityLog";

        public const string DATA_ASSEMBLY_NAME = "TestApp.Data";

        public const string APMODE_PROD = "Prod";

        public const int PAGESIZE = 20;

        public const string DateFormat = "{0:yyyy-MM-dd}"; //"{0:dd-MM-yyyy}";
        public static class Roles
        {
            public const string USER = "User";
            public const string ADMIN = "Admin";
        }
        public static class Connections
        {
            public const string DEFAULT = "IVD";
        }
    }
}
