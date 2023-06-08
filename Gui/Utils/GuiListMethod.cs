using Api.Utils;
using Core.Browsers;
using Core.Pages.Page;
using ListUsers;

namespace Gui.Utils
{
    public class GuiListMethod
    {
        protected readonly Browser UI;
        public GuiListMethod(Browser UI)
        {
            this.UI = UI;
        }
        private ApiMethodList apiMethod = new ApiMethodList();

        public async Task<HomePage> OpenHomePage()
        {
            var homePage = new HomePage(UI);
            return await homePage.OpenHomePage();
        }
        public async Task<ContactPage> GoToContactPage()
        {
            var homePage = new HomePage(UI);
            return await homePage.GoToContactPage();
        }

        public async Task<AboutUsPage> GoToAboutUsPage()
        {
            var homePage = new HomePage(UI);
            return await homePage.GoToAboutUsPage();
        }

        public string ValidateContactModalDispalyed()
        {
            var contactPage = new ContactPage(UI);
            return contactPage.ValidateContactModalDispalyed();
        }

        public string ValidateAboutUsModalDispalyed()
        {
            var aboutUsPage = new AboutUsPage(UI);
            return aboutUsPage.ValidateAboutUsModalDispalyed();
        }
        public async void SearchProduct()
        {
            var test = await apiMethod.GetListOfUsers<ListUsersModel>(1);
        }
    }
}
