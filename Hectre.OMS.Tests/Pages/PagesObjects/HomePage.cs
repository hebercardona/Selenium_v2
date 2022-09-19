using Hectre.OMS.Tests.Pages.PageMap;

namespace Hectre.OMS.Tests.Pages.PagesObjects
{
    public class HomePage
    {
        private HomeMap Map;

        public HomePage()
        {
            Map = new HomeMap();
        }
        public bool IsLogOutIconPresent()
        {
            return Map.LogOutIcon.Displayed;
        }

        public void ClickHarvestFromSideMenu()
        {
            Map.HarvestBtn.Click();
        }

        public void ClickPayrollFromSideMenu()
        {
            Map.PayrollBtn.Click();
        }

        public void ClickTimesheetsFromSideMenu()
        {
            Map.TimesheetsBtn.Click();
        }

        public void ClickMapsFromSideMenu()
        {
            Map.MapsBtn.Click();
        }

        public void ClickInsightsFromSideMenu()
        {
            Map.InsightsBtn.Click();
        }

        public void ClickScoutFromSideMenu()
        {
            Map.ScoutBtn.Click();
        }

        public void ClickAdminFromSideMenu()
        {
            Map.AdminBtn.Click();
        }

        public void ClickStaffFromSideMenu()
        {
            Map.StaffBtn.Click();
        }

        public void ClickJobsAndTasksFromSideMenu()
        {
            Map.JobsAndTasksBtn.Click();
        }

        public void ClickOrchardsFromSideMenu()
        {
            Map.OrchardsBtn.Click();
        }

        public void ClickVarietiesFromSideMenu()
        {
            Map.VarietiesBtn.Click();
        }

        public void ClickGeneralFromSideMenu()
        {
            Map.GeneralBtn.Click();
        }

        public void ClickAdminPayrollFromSideMenu()
        {
            Map.AdminPayrollBtn.Click();
        }
    }
}
