using Hectre.OMS.Tests.Data;
using Hectre.OMS.Tests.Pages;
using Hectre.OMS.Tests.Setup;
using Hectre.OMS.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Hectre.OMS.Tests.Tests
{
    public class Login : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            Page.Login.EnterLoginEmail(TestData.PersonalLoginData.Email);
            Page.Login.EnterLoginPassword(TestData.PersonalLoginData.Password);
            Page.Login.ClickSignInBtn();
        }

        /// <summary>
        /// Just a sample test to go to Hectre Dashbord, create a Job Type and Validate that newly created job is present in Jon types list
        /// </summary>
        [Test,
            Category(Categories.Regression)]
        public void Verify_User_Login_And_JobType_Create()
        {
            Page.Home.ClickAdminFromSideMenu();
            Page.Home.ClickJobsAndTasksFromSideMenu();
            Page.JobAndTasks.ClickJobTypes();
            Page.JobAndTasks.EnterAnyJobName(out string jobName);
            Page.JobAndTasks.ClickWagesRadioBtn();
            Page.JobAndTasks.SelectAnyJobCategory();
            Page.JobAndTasks.EnterAnyCostCode();
            Page.JobAndTasks.ClickSaveBtn();
            Assert.True(Page.JobAndTasks.IsJobNamePresentOnJobTypeList(jobName), $"Job Type recently added with name {jobName} is not present on the job type list");
        }

    }
}
