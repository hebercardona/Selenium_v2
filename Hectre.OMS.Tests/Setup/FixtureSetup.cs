using Hectre.OMS.Tests.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hectre.OMS.Tests
{
    [SetUpFixture]
    public class FixtureSetup
    {
        [OneTimeSetUp]
        public void Init()
        {
            Fw.CreateDirectories();
            Fw.SetConfig();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            
        }
    }
}
