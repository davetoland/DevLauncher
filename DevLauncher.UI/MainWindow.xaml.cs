using System;
using System.Collections.Generic;
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

namespace DevLauncher.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var consoleLauncher = new ConsoleLauncher();
            var webLauncher = new WebLauncher();

            //Content Cataloger
            consoleLauncher.BuildExecutable(
                @"C:\Development\ActiveNavigationNG\Source\Apps\ActiveNavigation.ContentCatalog\ActiveNavigation.ContentCatalog.sln");
            consoleLauncher.LaunchAndWait(
                @"C:\Development\ActiveNavigationNG\Source\Apps\ActiveNavigation.ContentCatalog\ActiveNavigation.ContentCatalog\bin\x64\Debug\\ActiveNavContentCatalog.exe",
                "", "", "Service Running... Use Ctrl+C to Stop");
            
            //Admin API
            webLauncher.LaunchAndWait(BrowserType.Firefox,
                @"C:\Development\ActiveNavigationNG\Source\WebApps\ActiveNavigation.AdminApi\src\ActiveNavigation.AdminApi",
                "swagger", new { LinkText = "/swagger/v1/swagger.json" });

            //Resource Processor
            consoleLauncher.BuildExecutable(
                @"C:\Development\ActiveNavigationNG\Source\Apps\ActiveNavigation.ResourceProcessor\ActiveNavigation.ResourceProcessor.sln");
            consoleLauncher.LaunchAndWait(
                @"C:\Development\ActiveNavigationNG\Source\Apps\ActiveNavigation.ResourceProcessor\ActiveNavigation.ResourceProcessor\bin\x64\Debug\\ActiveNavigation.ResourceProcessor.exe",
                "", "", "Resource Processor Service running... Use Ctrl+C to Stop");

            //GraphQL
            webLauncher.LaunchAndWait(BrowserType.Firefox,
                @"C:\\Development\\ActiveNavigationNG\\Source\\WebApps\\ActiveNavigation.GraphQL\\src\ActiveNavigation.GraphQL.Api",
                "graphql", new { ClassName = "graphiql-container" });

            //Collector
            consoleLauncher.BuildExecutable(
                @"C:\Development\ActiveNavigationNG\Source\Apps\ActiveNavigation.ResourceProcessor\ActiveNavigation.ResourceProcessor.sln");
            consoleLauncher.LaunchAndWait(
                @"C:\Development\ActiveNavigationNG\Source\Apps\ActiveNavigation.Collector\ActiveNavigation.Collector\bin\x64\DebugActiveNavCollector.exe",
                "", "", DateTime.Today.ToString("yyyy-MM-dd") + "\\d+:\\d+:\\d+" + " Idle...");

            //Admin UI
            //...tbc
        }
    }
}
