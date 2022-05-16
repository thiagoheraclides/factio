namespace Br.Com.FactIO.Api
{
    public static class ApiRoutes
    {
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";

        public static class Identity 
        {
            public const string Login = "Login";
            public const string Register = "Register";
        }

        public static class Company
        {
            public const string Add = "Add";
            public const string Id = "{id}";
        }

        public static class Category
        {           
            public const string Id = "{id}";
            public const string Add = "Add";
        }

        public static class CostCenter
        {
            public const string Id = "{id}";
            public const string Add = "Add";
        }

        public static class Group
        {
            public const string Id = "{id}";
            public const string Add = "Add";
        }

        public static class Status
        {
            public const string Id = "{id}";
            public const string Add = "Add";
        }

        public static class Site
        {
            public const string Id = "{id}";
            public const string Add = "Add";
        }

        public static class Area
        {
            public const string Id = "{id}";
            public const string Add = "Add";
        }

        public static class Address
        {
            public const string Id = "{id}";
            public const string Add = "Add";
        }

        public static class Zone
        {
            public const string Id = "{id}";
            public const string Add = "Add";
        }
    }
}
