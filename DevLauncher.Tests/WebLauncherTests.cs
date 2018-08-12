using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace DevLauncher.Tests
{
    [TestClass]
    public class WebLauncherTests
    {
        [TestMethod]
        public void Web_LaunchAndWait_WaitsForAll()
        {
            string graphQl = "C:\\Development\\ActiveNavigationNG\\Source\\WebApps\\ActiveNavigation.GraphQL\\src\ActiveNavigation.GraphQL.Api";
            string adminApi = @"C:\Development\ActiveNavigationNG\Source\WebApps\ActiveNavigation.AdminApi\src\ActiveNavigation.AdminApi";

            var launcher = new WebLauncher();
            launcher.LaunchAndWait(BrowserType.Firefox, adminApi, "swagger", new { LinkText = "/swagger/v1/swagger.json" });
            launcher.LaunchAndWait(BrowserType.Firefox, graphQl, "graphql", new { ClassName = "graphiql-container" });
        }
    }
}
