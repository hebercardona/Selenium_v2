using Hectre.OMS.Tests.Pages.PagesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hectre.OMS.Tests.Pages
{
    public class Page
    {
        public static LoginPage Login;
        public static HomePage Home;
        public static JobAndTasks JobAndTasks;
        public static void Init()
        {
            Login = new LoginPage();
            Home = new HomePage();
            JobAndTasks = new JobAndTasks();
        }
    }
}
