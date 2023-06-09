using Core.Browsers;
using Core.Ultilities.Helpers;
using System.ComponentModel;
using Xunit.Abstractions;

namespace Gui.Tests.UIValidation
{
    public class Navigation : BaseUITest
    {
        public Navigation(ITestOutputHelper outputHelper) : base(DriverType.Firefox, outputHelper) { }

        [Category(CategoryName.GUI_Regression)]
        [Trait(Category.Package, CategoryName.GUI_Regression)]
        [Trait(Category.TestCase, "TC12")]
        [Fact(DisplayName = "Verify that user able to navigate to Contact page")]
        public async Task VerifyThatUserAbleNavigateToContactPage()
        {
            var homePage = await OpenHomePage();
            var contactPage = await homePage.GoToContactPage();
            var message = ValidateContactModalDispalyed();
            Logger.Text(message);    
        }

        [Category(CategoryName.GUI_Regression)]
        [Trait(Category.Package, CategoryName.GUI_Regression)]
        [Trait(Category.TestCase, "TC13")]
        [Fact(DisplayName = "Verify that user able to navigate to About Us page")]
        public async Task VerifyThatUserAbleNavigateToAboutUsPage()
        {
            var homePage = await OpenHomePage();
            var aboutUsPage = await homePage.GoToAboutUsPage();
            var message = ValidateAboutUsModalDispalyed();
            Logger.Text(message);
        }
    }
}
