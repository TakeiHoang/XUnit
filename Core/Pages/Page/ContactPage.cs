using Core.Browsers;
using OpenQA.Selenium;

namespace Core.Pages.Page
{
    public class ContactPage : BasePage
    {
        public ContactPage(Browser UI) : base(UI)
        {
        }

        // Elements
        private By contactModalBox = By.CssSelector("#exampleModal.modal.fade.show");

        public string ValidateContactModalDispalyed()
        {
            var validation = FindElement(contactModalBox, 5000).Displayed;
            if (validation)
            {
                return "Contact modal displayed";
            }
            else
            {
                throw new Exception("Unable to get Contract modal display!");
            }
        }
    }
}
