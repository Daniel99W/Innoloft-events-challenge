namespace Innoloft_back_end_app_challenge
{
    public static class ApiRoutes
    {
        public const string IdRoute = "{Id}";
        public static class EventRoutes
        {
            public const string CreateEvent = "CreateEvent";
            public const string GetEvents = "GetEvents";
            public const string EditEvent = $"EditEvent/{IdRoute}";
            public const string DeleteEvent = $"DeleteEvent/{IdRoute}";
            public const string RegisterToEvent = "RegisterToEvent";
        }
        public static class UserRoutes
        {
            public const string CreateUser = $"CreateUser/{IdRoute}";
        }
    }
}
