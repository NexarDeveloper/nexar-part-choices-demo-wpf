using System;

namespace Nexar.PartChoices
{
    /// <summary>
    /// App configuration.
    /// </summary>
    static class Config
    {
        public const string MyTitle = "Nexar.PartChoices";

        public static string Authority { get; private set; }
        public static string ApiEndpoint { get; private set; }

        static Config()
        {
            Authority = Environment.GetEnvironmentVariable("NEXAR_AUTHORITY") ?? "https://identity.nexar.com";
            ApiEndpoint = Environment.GetEnvironmentVariable("NEXAR_API_URL") ?? "https://api.nexar.com/graphql";
        }
    }
}
