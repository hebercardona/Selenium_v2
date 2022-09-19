using Hectre.OMS.Tests.Pages.PageMap;

namespace Hectre.OMS.Tests.Pages.PagesObjects
{
    public class LoginPage
    {
        public readonly LoginMap Map;

        public LoginPage()
        {
            Map = new LoginMap();
        }

        public void EnterLoginEmail(string email)
        {
            Map.Email.SendKeys(email);
        }

        public void EnterLoginPassword(string password)
        {
            Map.Password.SendKeys(password);
        }

        public void ClickSignInBtn()
        {
            Map.SignInBtn.Click();
        }
    }
}
