using System;

namespace Nexar.PartChoices
{
    /// <summary>
    /// App configuration. Different modes and endpoints are used for internal development.
    /// Clients usually use nexar.com endpoints.
    /// </summary>
    static class Config
    {
        public const string MyTitle = "Nexar.PartChoices";

        public static A365Mode NexarA365Mode { get; }
        public static string Authority { get; }
        public static string ApiEndpoint { get; set; }

        static Config()
        {
            // default mode
            var mode = Environment.GetEnvironmentVariable("NEXAR_A365_MODE");
            NexarA365Mode = mode == null ? A365Mode.Dev1 : (A365Mode)Enum.Parse(typeof(A365Mode), mode, true);

            // init mode related data
            switch (NexarA365Mode)
            {
                case A365Mode.Dev1:
                    Authority = "https://identity.nexar.com/";
                    ApiEndpoint = "https://api.nexar.com/graphql/";
                    break;
                case A365Mode.Prod:
                    Authority = "https://identity.nexar.com/";
                    ApiEndpoint = "https://api.nexar.com/graphql/";
                    break;
                default:
                    throw new Exception();
            }
        }

        public enum A365Mode
        {
            Prod,
            Dev1
        }
    }
}
