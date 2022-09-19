using Hectre.OMS.Tests.Pages;
using Hectre.OMS.Tests.Setup;
using NUnit.Framework;

namespace Hectre.OMS.Tests.Tests
{
    public class Test : BaseTest
    {
        [Test]
        public void Verify_User_Login_Success()
        {
            Page.Login.EnterLoginEmail("heber@hectre.com");
            Page.Login.EnterLoginPassword("Hectre2022");
            Page.Login.ClickSignInBtn();
            Assert.True(Page.Home.IsLogOutIconPresent(), "LogOut Icon not present which means user was not successfully logged in.");
        }
    }
}
