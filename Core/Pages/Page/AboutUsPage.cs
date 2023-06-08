using Core.Browsers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pages.Page
{
    public class AboutUsPage : BasePage
    {
        public AboutUsPage(Browser UI) : base(UI)
        {
        }

        // Elements
        private By aboutUsModalBox = By.CssSelector("div#videoModal.modal.fade.show");

        public string ValidateAboutUsModalDispalyed()
        {
            var validation = FindElement(aboutUsModalBox).Displayed;
            if (validation)
            {
                return "About Us modal displayed";
            }
            else
            {
                throw new Exception("Unable to get About Us modal display!");
            }
        }
    }
}
