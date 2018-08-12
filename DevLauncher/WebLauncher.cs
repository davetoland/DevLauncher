using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DevLauncher
{
    public class WebLauncher
    {
        public void LaunchAndWait(BrowserType browserType, string dirPath, string urlPath, dynamic selector)
        {
            By by = null;
            var p = selector.GetType().GetProperties()[0];
            switch (p.Name)
            {
                case "LinkText": by = By.LinkText(p.GetValue(selector)); break;
                case "ClassName": by = By.ClassName(p.GetValue(selector)); break;
            }

            var proc = Process.GetProcessesByName(dirPath.Substring(dirPath.LastIndexOf("\\") + 1)).FirstOrDefault();
            if (proc != null)
                proc.Kill();

            string msg = "Now listening on: http://\\w+";
            var launcher = new ConsoleLauncher();

            launcher.BuildDotnetCoreApp(dirPath);
            string result = launcher.LaunchAndWait("dotnet", "run", dirPath, msg);
            string url = result.Replace(msg, "");

            IWebDriver driver = GetDriver(browserType);
            driver.Navigate().GoToUrl(Path.Combine(url, urlPath));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));


            wait.Until(d => d.FindElement(by));
        }

        private IWebDriver GetDriver(BrowserType browserType)
        {
            IWebDriver driver = null;

            switch (browserType)
            {
                case BrowserType.Firefox: driver = new OpenQA.Selenium.Firefox.FirefoxDriver(); break;
                case BrowserType.Chrome: driver = new OpenQA.Selenium.Chrome.ChromeDriver(); break;
                case BrowserType.IE: driver = new OpenQA.Selenium.IE.InternetExplorerDriver(); break;
                case BrowserType.Edge: driver = new OpenQA.Selenium.Edge.EdgeDriver(); break;
                case BrowserType.Opera: driver = new OpenQA.Selenium.Opera.OperaDriver(); break;
            }

            return driver;
        }
    }
}
