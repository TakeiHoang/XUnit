using Core.Ultilities.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace Core.Browsers
{
    public class Browser
    {
        private bool KillAllProcess = true;
        protected readonly IWait<IWebDriver> _wait;
        public IWebDriver driver;

        public IJavaScriptExecutor JsExecutor { get; set; }
        public Browser(IWebDriver driver, int waitFor = 30000, int pollInterval = 500)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            JsExecutor = (IJavaScriptExecutor)this.driver;

            _wait = new WebDriverWait(this.driver, TimeSpan.FromMilliseconds(waitFor))
            {
                PollingInterval = TimeSpan.FromMilliseconds(pollInterval)
            };
            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            _wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
        }
        public Browser(DriverType browser, int waitFor = 30000, int pollInterval = 500)
            : this(BrowserOptions.GetDriver(browser))
        { }

        public Browser() {}

        public byte[]? GetScreenshot()
        {
            try
            {
                return ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            }
            catch (WebDriverException)
            {
                return null;
            }
        }
        public void SaveScreenshot(string context, byte[]? image = null)
        {
            const ScreenshotImageFormat format = ScreenshotImageFormat.Png;
            var directoryPath = Path.Combine(Environment.CurrentDirectory, "Screenshots");
            Directory.CreateDirectory(directoryPath);
            var path = Path.Combine(directoryPath, $"{DateTime.Now:MM-ddThh-mm-ss}-{context}.{format}");
            try
            {
                var screenshot = image == null ? ((ITakesScreenshot)driver).GetScreenshot() : new Screenshot(Convert.ToBase64String(image));
                screenshot.SaveAsFile(path, format);
            }
            catch (Exception) { }
        }

        public void KillProcesses()
        {
            foreach (var chromeProcess in Process.GetProcessesByName("chrome"))
            {
                chromeProcess.Kill();
            }
            foreach (var chromeDriverProcess in Process.GetProcessesByName("chromedriver"))
            {
                chromeDriverProcess.Kill();
            }
        }

        public void Go(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            driver.Quit();
            if (KillAllProcess) KillProcesses();
        }

        public class ChromeBrowser : Browser
        {
            public ChromeBrowser() : base(DriverType.Chrome) { }
        }
        public class EdgeBrowser : Browser
        {
            public EdgeBrowser() : base(DriverType.Edge) { }
        }
        public class FirefoxBrowser : Browser
        {
            public FirefoxBrowser() : base(DriverType.Firefox) { }
        }
    }
}