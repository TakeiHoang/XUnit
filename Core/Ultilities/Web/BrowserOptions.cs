using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.IO;
using Core.Browsers;

namespace Core.Ultilities.Web
{
    public static class BrowserOptions
    {
        public static IWebDriver GetDriver(DriverType driverType = DriverType.Chrome)
        {
            switch (driverType)
            {
                case DriverType.Chrome:
                    return GetChromeDriver();
                case DriverType.Edge:
                    return GetEdgeDriver();
                case DriverType.Firefox:
                    return GetFireFoxDriver();
                default:
                    return GetEdgeDriver();
            }
        }

        public static IWebDriver GetChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(
                "incognito",
                "start-maximized",
                "disable-extensions"
                );
            return new ChromeDriver(options);
        }

        public static IWebDriver GetEdgeDriver()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            EdgeOptions options = new EdgeOptions();
            options.AddArguments(
                "--remote-debugging-port=8080",
                "--allowed-ips",
                "--no-sandbox",
                "--disable-dev-shm-usage",
                //"--headless",
                "disable-infobars",
                "start-maximized",
                "disable-extensions"
                );
            return new EdgeDriver(options);
        }

        public static IWebDriver GetFireFoxDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("browser.download.showWhenStarting", false);
            options.SetPreference("browser.download.folderList", 1);
            options.SetPreference("browser.download.manager.focusWhenStarting", false);
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            options.SetPreference("browser.download.manager.closeWhenDone", true);
            options.SetPreference("browser.download.manager.showAlertOnComplete", false);
            options.SetPreference("browser.download.manager.useWindow", false);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
            return new FirefoxDriver(options);
        }
    }
}
