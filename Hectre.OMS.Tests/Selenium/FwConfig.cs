namespace Hectre.OMS.Tests.Selenium
{
    internal class FwConfig
    {
        public string Environment { get; set; }
        public string Browser { get; set; }
        public bool IsLocal { get; set; }
        public string StartingUrl { get; set; }
        public int Wait_Seconds { get; set; }
        public int Page_Load { get; set; }
        public int Retry { get; set; }
        public bool Headless { get; set; }
        public EnvironmentUrls Environment_Urls { get; set; }
    }

    internal class EnvironmentUrls
    {
        public string Staging { get; set; }
        public string Develop { get; set; }
        public string Prod { get; set; }
    }
}
