using Epic.OnlineServices;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Platform;
using System.Collections.Generic;

namespace EOSCSharpSample
{
    public class ApplicationSettings
    {
        public string ProductId { get; private set; } = "";

        public string ClientId { get; private set; } = "";
        public string ClientSecret { get; private set; } = "";

        public string SandboxId { get; private set; } = "";

        public string DeploymentId { get; private set; } = "";

        public PlatformInterface PlatformInterface { get; set; }

        public LoginCredentialType LoginCredentialType { get; private set; } = LoginCredentialType.AccountPortal;
        public string Id { get; private set; } = "";
        public string Token { get; private set; } = "";

        public ExternalCredentialType ExternalCredentialType { get; private set; } = ExternalCredentialType.Epic;

        public AuthScopeFlags ScopeFlags
        {
            get
            {
                return AuthScopeFlags.BasicProfile;
            }
        }

        public void Initialize(Dictionary<string, string> commandLineArgs)
        {
            // Use command line arguments if passed
            ProductId = commandLineArgs.ContainsKey("-productid") ? commandLineArgs.GetValueOrDefault("-productid") : ProductId;
            SandboxId = commandLineArgs.ContainsKey("-sandboxid") ? commandLineArgs.GetValueOrDefault("-sandboxid") : SandboxId;
            DeploymentId = commandLineArgs.ContainsKey("-deploymentid") ? commandLineArgs.GetValueOrDefault("-deploymentid") : DeploymentId;
            ClientId = commandLineArgs.ContainsKey("-clientid") ? commandLineArgs.GetValueOrDefault("-clientid") : ClientId;
            ClientSecret = commandLineArgs.ContainsKey("-clientsecret") ? commandLineArgs.GetValueOrDefault("-clientsecret") : ClientSecret;

            LoginCredentialType = commandLineArgs.ContainsKey("-logincredentialtype") ? (LoginCredentialType)System.Enum.Parse(typeof(LoginCredentialType), commandLineArgs.GetValueOrDefault("-logincredentialtype")) : LoginCredentialType;
            Id = commandLineArgs.ContainsKey("-id") ? commandLineArgs.GetValueOrDefault("-id") : Id;
            Token = commandLineArgs.ContainsKey("-token") ? commandLineArgs.GetValueOrDefault("-token") : Token;
            ExternalCredentialType = commandLineArgs.ContainsKey("-externalcredentialtype") ? (ExternalCredentialType)System.Enum.Parse(typeof(ExternalCredentialType), commandLineArgs.GetValueOrDefault("-externalcredentialtype")) : ExternalCredentialType;
        }
    }
}
