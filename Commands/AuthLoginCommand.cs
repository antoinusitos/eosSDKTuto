using EOSCSharpSample.Helpers;
using EOSCSharpSample.Services;
using EOSCSharpSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EOSCSharpSample.Commands
{
    public class AuthLoginCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return string.IsNullOrWhiteSpace(ViewModelLocator.Main.AccountId);
        }

        public override void Execute(object parameter)
        {
            AuthService.AuthLogin();
        }
    }
}
