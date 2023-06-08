using Api.Utils;

namespace Api.Tests
{
    public class BaseAPITest : ApiMethodList, IDisposable
    {
        protected readonly Logger Logger;

        /// <summary>
        /// Constructor act as [SetUp]
        /// </summary>
        /// <param name="output"> Log output helper init </param>
        public BaseAPITest(ITestOutputHelper outputHelper)
        {
            Logger = new Logger(outputHelper);
        }

        /// <summary>
        /// Method act as [Teardown]
        /// </summary>
        public void Dispose()
        {
            // TO-DO Will be implement if nesscessary
            // Can be implement with report to Confluence, Team-Rally and other 3rd service API if available
            // Disconnect database
        }
    }
}
