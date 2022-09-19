using Hectre.OMS.Tests.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Hectre.OMS.Tests.Data
{
    public class TestData
    {
        public static Personal PersonalLoginData => GetPersonalLoginData();

        private static Personal GetPersonalLoginData()
        {
            var dataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Data/DataFiles","LoginData.json");
               var jsonStr = File.ReadAllText(dataPath);
            var loginData = JsonConvert.DeserializeObject<LoginDataModel>(jsonStr);
            return loginData.Personal;
        }
    }
}
