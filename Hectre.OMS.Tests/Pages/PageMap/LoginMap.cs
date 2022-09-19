using Hectre.OMS.Tests.Selenium;
using OpenQA.Selenium;

namespace Hectre.OMS.Tests.Pages.PageMap
{
    public class LoginMap
    {
        public Element Email        => Webdriver.FindElement(By.Id("hectre-login-email"), "Email");
        public Element Password     => Webdriver.FindElement(By.Id("hectre-login-password"), "Password");
        public Element SignInBtn    => Webdriver.FindElement(By.Id("hectre-login-button-sign-in"), "Sign In Btn");
    }
}
