using EOSCSharpSample.ViewModels;
using Epic.OnlineServices;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.UserInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EOSCSharpSample.Services
{
    public static class AuthService
    {
        public static void AuthLogin()
        {
            ViewModelLocator.Main.StatusBarText = "Getting auth interface...";

            var authInterface = App.Settings.PlatformInterface.GetAuthInterface();
            if (authInterface == null)
            {
                Debug.WriteLine("Failed to get auth interface");
                ViewModelLocator.Main.StatusBarText = string.Empty;
                return;
            }

            var loginOptions = new LoginOptions()
            {
                Credentials = new Credentials()
                {
                    Type = App.Settings.LoginCredentialType,
                    Id = App.Settings.Id,
                    Token = App.Settings.Token,
                    ExternalType = App.Settings.ExternalCredentialType
                },
                ScopeFlags = App.Settings.ScopeFlags
            };

            ViewModelLocator.Main.StatusBarText = "Requesting user login...";

            authInterface.Login(loginOptions, null, (LoginCallbackInfo loginCallbackInfo) =>
            {
                Debug.WriteLine($"Auth login {loginCallbackInfo.ResultCode}");

                if (loginCallbackInfo.ResultCode == Result.Success)
                {
                    ViewModelLocator.Main.StatusBarText = "Auth login successful.";

                    ViewModelLocator.Main.AccountId = loginCallbackInfo.LocalUserId.ToString();

                    var userInfoInterface = App.Settings.PlatformInterface.GetUserInfoInterface();
                    if (userInfoInterface == null)
                    {
                        Debug.WriteLine("Failed to get user info interface");
                        return;
                    }

                    var queryUserInfoOptions = new QueryUserInfoOptions()
                    {
                        LocalUserId = loginCallbackInfo.LocalUserId,
                        TargetUserId = loginCallbackInfo.LocalUserId
                    };

                    ViewModelLocator.Main.StatusBarText = "Getting user info...";

                    userInfoInterface.QueryUserInfo(queryUserInfoOptions, null, (QueryUserInfoCallbackInfo queryUserInfoCallbackInfo) =>
                    {
                        Debug.WriteLine($"QueryUserInfo {queryUserInfoCallbackInfo.ResultCode}");

                        if (queryUserInfoCallbackInfo.ResultCode == Result.Success)
                        {
                            ViewModelLocator.Main.StatusBarText = "User info retrieved.";

                            var copyUserInfoOptions = new CopyUserInfoOptions()
                            {
                                LocalUserId = queryUserInfoCallbackInfo.LocalUserId,
                                TargetUserId = queryUserInfoCallbackInfo.TargetUserId
                            };

                            var result = userInfoInterface.CopyUserInfo(copyUserInfoOptions, out var userInfoData);
                            Debug.WriteLine($"CopyUserInfo: {result}");

                            if (userInfoData != null)
                            {
                                ViewModelLocator.Main.DisplayName = userInfoData.DisplayName;
                            }

                            ViewModelLocator.Main.StatusBarText = string.Empty;
                            ViewModelLocator.RaiseAuthCanExecuteChanged();
                        }
                    });
                }
                else if (Common.IsOperationComplete(loginCallbackInfo.ResultCode))
                {
                    Debug.WriteLine("Login failed: " + loginCallbackInfo.ResultCode);
                }
            });
        }

        public static void AuthLogout()
        {
            var logoutOptions = new LogoutOptions()
            {
                LocalUserId = EpicAccountId.FromString(ViewModelLocator.Main.AccountId)
            };

            App.Settings.PlatformInterface.GetAuthInterface().Logout(logoutOptions, null, (LogoutCallbackInfo logoutCallbackInfo) =>
            {
                Debug.WriteLine($"Logout {logoutCallbackInfo.ResultCode}");

                if (logoutCallbackInfo.ResultCode == Result.Success)
                {
                    ViewModelLocator.Main.StatusBarText = "Logout successful.";

                    var deletePersistentAuthOptions = new DeletePersistentAuthOptions();
                    App.Settings.PlatformInterface.GetAuthInterface().DeletePersistentAuth(deletePersistentAuthOptions, null, (DeletePersistentAuthCallbackInfo deletePersistentAuthCallbackInfo) =>
                    {
                        Debug.WriteLine($"DeletePersistentAuth {logoutCallbackInfo.ResultCode}");

                        if (logoutCallbackInfo.ResultCode == Result.Success)
                        {
                            ViewModelLocator.Main.StatusBarText = "Persistent auth deleted.";

                            ViewModelLocator.Main.AccountId = string.Empty;
                            ViewModelLocator.Main.DisplayName = string.Empty;

                            ViewModelLocator.Main.StatusBarText = string.Empty;
                            ViewModelLocator.RaiseAuthCanExecuteChanged();
                        }
                    });
                }
                else if (Common.IsOperationComplete(logoutCallbackInfo.ResultCode))
                {
                    Debug.WriteLine("Logout failed: " + logoutCallbackInfo.ResultCode);
                }
            });
        }
    }
}
