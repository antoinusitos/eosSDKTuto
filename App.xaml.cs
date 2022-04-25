using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EOSCSharpSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ApplicationSettings Settings { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Get command line arguments (if any) to overwrite default settings
            var commandLineArgsDict = new Dictionary<string, string>()
            {
                { "-productid","1541fc2a8b9a473fa925c516bf3aec79"},
                { "-sandboxid","35c606aa881148e4bd3e78a084a27f67"},
                { "-deploymentid","23f6b10917ee412eb78570835f70ccd3"},
                { "-clientid","xyza7891UEkAudvNUdt0JS4tY1fCuI0x"},
                { "-clientsecret","CAQ1jHMjLaKHiHIia3nC1mpyJx+DUuU5FJs3EdVvEfM"},

            };
            for (int index = 0; index < e.Args.Length; index += 2)
            {
                commandLineArgsDict.Add(e.Args[index], e.Args[index + 1]);
            }

            Settings = new ApplicationSettings();
            Settings.Initialize(commandLineArgsDict);

            base.OnStartup(e);
        }
    }
}
