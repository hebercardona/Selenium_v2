using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Hectre.OMS.Tests.Selenium
{
    public class Element : IWebElement
    {
        private readonly IWebElement _element;

        public readonly string Name;
        public By FoundBy { get; set; }
        public Element(By foundBy, string name)
        {
            FoundBy = foundBy;
            Name = name;
            _element = Webdriver.Wait.AndGetElement(foundBy);
        }

        public IWebElement Current => _element ?? throw new NullReferenceException($"Current IWebElement {Name} is null");
        public string TagName => Current.TagName;
        public string Text => Current.Text;
        public bool Enabled => Current.Enabled;
        public bool Selected => Current.Selected;
        public Point Location => Current.Location;
        public Size Size => Current.Size;

        public bool Displayed => Current.Displayed;

        public string GetAttribute(string attributeName)
        {
            return Current.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return Current.GetCssValue(propertyName);
        }

        public string GetDomProperty(string propertyName)
        {
            return Current.GetDomProperty(propertyName);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            Current.Clear();
            Current.SendKeys(text);
            Webdriver.SwitchToDefaultContent();
            Fw.Log.Step($"Entered text {text} on input field {Name}");
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            Webdriver.Wait.AndClickElement(Current);
            Fw.Log.Step($"Clicked {Name}");
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

    }
}
