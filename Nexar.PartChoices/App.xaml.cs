using Nexar.Client;
using Nexar.Client.Login;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Nexar.PartChoices
{
    public partial class App : Application
    {
        public static IReadOnlyList<IMyWorkspace> Workspaces { get; private set; }

        /// <summary>
        /// Run this as a task after the window is shown.
        /// </summary>
        /// <remarks>
        /// Why not before as it used to be. If a user does not login and maybe closes the login page,
        /// then the application is running waiting for the login. The user may not know about it.
        /// So, with the window shown the user is aware of it and may close.
        /// </remarks>
        public static async Task LoginAsync()
        {
            try
            {
                if (Config.Authority.Contains(":"))
                {
                    var clientId = Environment.GetEnvironmentVariable("NEXAR_CLIENT_ID") ?? throw new InvalidOperationException("Please set environment 'NEXAR_CLIENT_ID'");
                    var clientSecret = Environment.GetEnvironmentVariable("NEXAR_CLIENT_SECRET") ?? throw new InvalidOperationException("Please set environment 'NEXAR_CLIENT_SECRET'");
                    var login = await LoginHelper.LoginAsync(
                        clientId,
                        clientSecret,
                        new string[] { "user.access", "design.domain" },
                        Config.Authority);

                    Config.AccessToken = login.AccessToken;
                }
                else
                {
                    Config.AccessToken = Config.Authority;
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
                Environment.Exit(1);
            }
        }

        public static async Task LoadWorkspacesAsync()
        {
            try
            {
                var client = NexarClientFactory.CreateClient(Config.ApiEndpoint, Config.AccessToken);
                var res = await client.Workspaces.ExecuteAsync();
                res.AssertNoErrors();
                Workspaces = res.Data.DesWorkspaces;
            }
            catch (Exception ex)
            {
                ShowException(ex);
                Environment.Exit(1);
            }
        }

        public static void ShowException(Exception ex)
        {
            var message = $"{ex.Message}\n\n{ex}";
            MessageBox.Show(message, Config.MyTitle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ShowException(e.Exception);
            e.Handled = true;
        }
    }
}
