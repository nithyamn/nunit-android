﻿using System;
using System.Threading;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace android.first
{
  [TestFixture("first","pixel-3")]
  public class SingleTest : BrowserStackNUnitTest
  {
    public SingleTest(string profile, string device) : base(profile,device){}

    [Test]
    public void searchWikipedia()
    {
      AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia")));
      searchElement.Click();
      AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
      insertTextElement.SendKeys("BrowserStack");
      Thread.Sleep(5000);

      ReadOnlyCollection<AndroidElement> allProductsName = driver.FindElements(By.ClassName("android.widget.TextView"));
      Assert.True(allProductsName.Count > 0);
        if (allProductsName.Count > 0)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \"Expected\"}}");

        }
        else
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \"Unexpected\"}}");
        }
    }
  }
}
