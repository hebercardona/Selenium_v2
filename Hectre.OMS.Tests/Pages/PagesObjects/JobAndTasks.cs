using Hectre.OMS.Tests.Pages.PageMap;
using Hectre.OMS.Tests.Selenium;
using System;
using System.Linq;

namespace Hectre.OMS.Tests.Pages.PagesObjects
{
    public class JobAndTasks
    {
        private JobAndTasksMap Map;

        public JobAndTasks()
        {
            Map = new JobAndTasksMap();
        }

        public void ClickJobTypes()
        {
            Map.JobTypesBtn.Click();
        }

        public void ClickAddNewJobType()
        {
            Map.AddNewJobBtn.Click();
        }

        public void EnterJobName(string name)
        {
            Map.JobNameInput.SendKeys(name);
        }

        public void EnterAnyJobName(out string jobName)
        {
            string date = string.Format("{0:mmss}", DateTime.Now);
            jobName = $"JOB_TEST_{date}";
            Map.JobNameInput.SendKeys(jobName);
        }

        public void ClickPieceRateRadioBtn()
        {
            Map.PieceRateRadioBtn.Click();
        }

        public void ClickWagesRadioBtn()
        {
            Map.WagesRadioBtn.Click();
        }

        public void ClickBothRadioBtn()
        {
            Map.BothRadioBtn.Click();
        }

        public void ClickCategoryDropdwon()
        {
            Map.CategoryDropdown.Click();
        }

        public void ClickRateUnitDropdown()
        {
            Map.RateUnitDropdown.Click();
        }

        public void ClickAgriculturalRadioBtn()
        {
            Map.AgriculturalLaborCategory.Click();
        }

        public void EnterCostCode(string costCode)
        {
            Map.CostCodeInput.SendKeys(costCode);
        }

        public void EnterAnyCostCode()
        {
            string date = string.Format("{0:mmss}", DateTime.Now);
            Map.CostCodeInput.SendKeys(date);
        }

        public void ClickSaveBtn()
        {
            Map.SaveBtn.Click();
        }

        public void SelectAnyJobCategory()
        {
            ClickCategoryDropdwon();
            var options = Map.CategoryOptions;
            options.OrderBy(x => x.GetHashCode()).FirstOrDefault().Click();
        }

        public bool IsJobNamePresentOnJobTypeList(string jobName)
        {
            return Map.JobTypeFromList(jobName).Displayed;
        }
    }
}
