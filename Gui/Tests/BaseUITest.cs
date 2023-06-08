using Api.Utils;
using Core.Browsers;
using Core.Ultilities.Helpers;
using Gui.Utils;
using Xunit.Abstractions;

namespace Gui.Tests
{
    public class BaseUITest : GuiListMethod, IDisposable
    {
        protected readonly Logger Logger;
        private Browser UI { get; set; }

        /// <summary>
        /// Constructor act as [SetUp]
        /// </summary>
        /// <param name="outputHelper"> Log output helper init </param>
        /// <param name="browser"> Browser type </param>
        public BaseUITest(DriverType browser, ITestOutputHelper outputHelper) : base(new Browser(browser))
        {
            UI = base.UI;
            Logger = new Logger(outputHelper);
        }

        /// <summary>
        /// Method act as [Teardown]
        /// </summary>
        public void Dispose()
        {
            var screenshot = UI.GetScreenshot();
            UI.SaveScreenshot("TearDown", screenshot);
            UI.Quit();
        }
    }
}
