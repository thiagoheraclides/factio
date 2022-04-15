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

    }
}
