using EOSCSharpSample.ViewModels;
using Epic.OnlineServices.Logging;
using Epic.OnlineServices.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EOSCSharpSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer updateTimer;
        private const float updateFrequency = 1 / 30f;

        public MainWindow()
        {
            InitializeComponent();

            Closing += MainWindow_Closing;

            InitializeApplication();

            DataContext = ViewModelLocator.Main;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Settings.PlatformInterface.Release();
            App.Settings.PlatformInterface = null;

            _ = PlatformInterface.Shutdown();
        }

        private void InitializeApplication()
        {
            var initializeOptions = new InitializeOptions()
            {
                ProductName = "EOSCSharpSample",
                ProductVersion = "1.0.0"
            };

            var result = PlatformInterface.Initialize(initializeOptions);
            Debug.WriteLine($"Initialize: {result}");

            _ = LoggingInterface.SetLogLevel(LogCategory.AllCategories, LogLevel.Info);
            _ = LoggingInterface.SetCallback((LogMessage message) => Debug.WriteLine($"[{message.Level}] {message.Category} - {message.Message}"));

            var options = new Options()
            {
                ProductId = App.Settings.ProductId,
                SandboxId = App.Settings.SandboxId,
                ClientCredentials = new ClientCredentials()
                {
                    ClientId = App.Settings.ClientId,
                    ClientSecret = App.Settings.ClientSecret
                },
                DeploymentId = App.Settings.DeploymentId,
                Flags = PlatformFlags.DisableOverlay,
                IsServer = false
            };

            PlatformInterface platformInterface = PlatformInterface.Create(options);

            if (platformInterface == null)
            {
                Debug.WriteLine($"Failed to create platform. Ensure the relevant settings are set.");
            }

            App.Settings.PlatformInterface = platformInterface;

            updateTimer = new DispatcherTimer(DispatcherPriority.Render)
            {
                Interval = new TimeSpan(0, 0, 0, 0, (int)(updateFrequency * 1000))
            };

            updateTimer.Tick += (sender, e) => Update(updateFrequency);
            updateTimer.Start();
        }

        private void Update(float updateFrequency)
        {
            App.Settings.PlatformInterface?.Tick();
        }
    }
}
