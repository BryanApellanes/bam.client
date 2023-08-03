using Bam.Sdk.Model;
using Bam.Wizard.VisualStudio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class OpenIdConnectApplicationCreateDataProvider : CreateDataProvider<OpenIdConnectApplication>
    {
        public OpenIdConnectApplicationCreateDataProvider(IJsonWebKeyProvider jsonWebKeyProvider, IApplicationCallbackPathProvider applicationCallbackPathProvider)
        {
            JsonWebKeyProvider = jsonWebKeyProvider;
            ApplicationCallbackPathProvider = applicationCallbackPathProvider;
        }

        /// <summary>
        /// Gets or sets the JsonWebKeyProvider.
        /// </summary>
        protected IJsonWebKeyProvider JsonWebKeyProvider { get; set; }

        /// <summary>
        /// Gets or sets the ApplicationCallbackPathProvider.
        /// </summary>
        protected IApplicationCallbackPathProvider ApplicationCallbackPathProvider { get; set; }

        /// <inheritdoc />
        public override async Task<OpenIdConnectApplication> GetDataDefinitionAsync(ICreateArguments arguments)
        {
            if (!(arguments is OpenIdConnectApplicationCreateArguments applicationCreateArguments))
            {
                throw new ArgumentException($"{nameof(arguments)} must be of type {nameof(OpenIdConnectApplicationCreateArguments)}");
            }

            ProjectArguments projectArguments = applicationCreateArguments.GetArgument<ProjectArguments>();
            if (projectArguments == null)
            {
                throw new ArgumentNullException($"{nameof(ProjectArguments)}");
            }

            string projectName = projectArguments.ProjectName;
            if (string.IsNullOrEmpty(projectName))
            {
                throw new ArgumentNullException("ProjectName");
            }

            OpenIdConnectApplication application = GetOpenIdConnectApplicationDefinition(projectArguments);
            JsonWebKey jsonWebKey = JsonWebKeyProvider.CreateJsonWebKey(projectName);
            if (jsonWebKey != null)
            {
                application.Settings.OauthClient.Jwks = new OpenIdConnectApplicationSettingsClientKeys
                {
                    Keys = new List<JsonWebKey> { JsonWebKeyProvider.CreateJsonWebKey(projectName) }
                };
            }
            arguments.Value = application;
            return application;
        }

        /// <summary>
        /// Gets the OpenidConnectApplication definition.
        /// </summary>
        /// <param name="projectArguments">ProjectArguments</param>
        /// <returns>OpenIdConnectApplication</returns>
        public OpenIdConnectApplication GetOpenIdConnectApplicationDefinition(ProjectArguments projectArguments)
        {
            LaunchSettingsReader launchSettingsReader = new LaunchSettingsReader();
            OpenIdConnectApplication result = GetDefaultOpenIdConnectApplicationDefinition(projectArguments.ProjectName, launchSettingsReader.GetProfilesIisExpressLaunchUrl(projectArguments));

            string[] applicationUrls = launchSettingsReader.GetAllUrls(projectArguments);
            ApplicationCallbacks callbacks = ApplicationCallbackPathProvider.GetApplicationCallbacks(projectArguments);
            HashSet<string> redirectUris = new HashSet<string>();
            HashSet<string> logoutUris = new HashSet<string>();
            foreach (string url in result.Settings.OauthClient.RedirectUris)
            {
                redirectUris.Add(url);
            }

            foreach (string url in result.Settings.OauthClient.PostLogoutRedirectUris)
            {
                logoutUris.Add(url);
            }

            foreach (string url in applicationUrls)
            {
                foreach(string loginCallback in callbacks.LoginCallbacks)
                {
                    string value = loginCallback;
                    if (loginCallback.StartsWith("/"))
                    {
                        value = loginCallback.Substring(1);
                    }
                    redirectUris.Add($"{url}{value}");
                }
                foreach(string logoutCallback in callbacks.LogoutCallbacks)
                {
                    string value = logoutCallback;
                    if (logoutCallback.StartsWith("/"))
                    {
                        value = logoutCallback.Substring(1);
                    }
                    logoutUris.Add($"{url}{value}");
                }
            }
            result.Settings.OauthClient.RedirectUris = redirectUris.ToList();
            result.Settings.OauthClient.PostLogoutRedirectUris = logoutUris.ToList();
            return result;
        }

        /// <summary>
        /// Gets a instance of the default OpenIdConnectApplication definition.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="clientUri">The client uri.</param>
        /// <returns>OpenIdConnectApplication</returns>
        public static OpenIdConnectApplication GetDefaultOpenIdConnectApplicationDefinition(string label, string clientUri)
        {
            return new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = label,
                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = Guid.NewGuid().ToString(),
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation = true,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = clientUri,
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "token",
                            "id_token",
                            "code",
                        },
                        RedirectUris = new List<string>() { "http://localhost/oauth2/callback"},
                        PostLogoutRedirectUris = new List<string> { "http://localhost/signout/callback"},
                        GrantTypes = new List<OAuthGrantType>
                        {
                            "implicit",
                            "authorization_code",
                        },
                        ApplicationType = "web",
                    },
                }
            };
        }
    }
}
