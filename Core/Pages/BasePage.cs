using Core.Browsers;
using Core.Pages.Page;
using Core.Ultilities.Model.TestSettingsModel;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Pages
{
    public class BasePage
    {
        protected Browser UI { get; private set; }
        protected IWebDriver driver => UI.driver;

        // Elements
        private By homeLink = By.CssSelector("#navbarExample ul li a[href='index.html']");
        private By contactLink = By.CssSelector("#navbarExample ul li a[data-target='#exampleModal']");
        private By aboutUsLink = By.CssSelector("#navbarExample ul li a[data-target='#videoModal']");
        private By cartLink = By.CssSelector("#navbarExample ul li a[href='cart.html']");
        private By loginLink = By.CssSelector("#navbarExample ul li a[data-target='#logInModal']");
        private By logoutLink = By.CssSelector("#navbarExample ul li a#logout2");

        public BasePage(Browser UI)
        {
            this.UI = UI;
        }

        public IWebElement FindElement(By by, int timeoutInMiliseconds = 3000)
        {
            if (timeoutInMiliseconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMiliseconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public async Task<HomePage> OpenHomePage()
        {
            // Read the JSON file containing the base URL
            string currentDirectory = Directory.GetCurrentDirectory();
            string jsonSetting = File.ReadAllText(Path.Combine(currentDirectory, "test-settings.json"));
            var settingModel = JsonConvert.DeserializeObject<GuiTestSettingsModel>(jsonSetting);
            UI.Go(settingModel.BaseUrl);
            return new HomePage(UI);
        }

        public async Task<HomePage> GoToHomePage()
        {
            FindElement(homeLink).Click();
            return new HomePage(UI);
        }

        public async Task<ContactPage> GoToContactPage()
        {
            FindElement(contactLink).Click();
            return new ContactPage(UI);
        }

        public async Task<AboutUsPage> GoToAboutUsPage()
        {
            FindElement(aboutUsLink).Click();
            return new AboutUsPage(UI);
        }

        public async Task<CartPage> GoToCartPage()
        {
            FindElement(cartLink).Click();
            return new CartPage(UI);
        }

        public async Task<LoginPage> GoToLoginPage()
        {
            FindElement(loginLink).Click();
            return new LoginPage(UI);
        }

        public async Task<HomePage> Logout()
        {
            FindElement(logoutLink).Click();
            return new HomePage(UI);
        }
    }
}
