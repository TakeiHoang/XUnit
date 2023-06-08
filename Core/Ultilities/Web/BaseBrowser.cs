using Core.Browsers;
using Core.Ultilities.Model.TestSettingsModel;
using Newtonsoft.Json;

namespace Core.Ultilities.Web
{
    public class BaseBrowser
    {
        public async static Task<GuiTestSettingsModel> ConvertSettings<T>()
        {
            // Read the JSON file containing the base URL
            string jsonSetting = File.ReadAllText("D:\\Code\\XUnit\\Gui\\test-settings.json");
            return JsonConvert.DeserializeObject<GuiTestSettingsModel>(jsonSetting);
        }
    }
}