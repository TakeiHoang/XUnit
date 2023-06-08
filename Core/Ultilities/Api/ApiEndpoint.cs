namespace Core.Ultilities.Api
{
    public class ApiEndpoint
    {
        // /api/users?page={int}
        public readonly static string getListUsersOnpageEndpoint = "/api/users?page=";

        // /api/users/{int}
        public readonly static string getSingleUserEndpoint = "/api/users/";

        public readonly static string getListResourceEndpoint = "/api/unknown";

        // /api/unknown/{int}
        public readonly static string getSingleResourceEndpoint = "/api/unknown/";

        public readonly static string createUser = "/api/users";

        public readonly static string registerAccount = "/api/register";
    }
}
