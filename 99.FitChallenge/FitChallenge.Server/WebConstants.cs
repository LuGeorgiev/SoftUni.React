namespace FitChallenge.Server
{
    public class WebConstants
    {
        public class DataSeed
        { 
            public const string AdministratorRoleName = "Administrator";
            public const string ModeratorRoleName = "Moderator";

            public const string DefaultUserPassword = "test";
            public const string DefaultUserId = "4ae0340d-91db-46e3-adc0-bba88392a9c6";
        }

        public class Identity
        {
            public const string InvalidCredentials = "Ivalid user credentials";
            public const string AuthenticationCookieName = "Authentication";
        }

        public class Controllers
        {
            public const string Id = "{id}";
            public const string Name = "{name}";
        }
    }
}
