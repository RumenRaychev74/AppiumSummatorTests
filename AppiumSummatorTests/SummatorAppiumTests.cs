using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSummatorTests
{
    public class SummatorAppiumTests
    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        [OneTimeSetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };

            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\SummatorDekstopApp.exe");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }
        [OneTimeTearDown]
        public void ShutDownApp()
        {
            this.driver.Quit();
        }
        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            // Find first field, click it fill value 5
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("5");

            // Find second field, click it fill value 15
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("15");

            //Click calculate button
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            // Assert the result
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("20"));
        }
        [Test]
        public void Test_Sum_InvalidValues()
        {
            // Find first field, click it fill value "ibre"
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("ibre");

            // Find second field, click it fill value "abre"
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("abre");

            //Click calculate button
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            // Assert the result
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("error"));
        }
        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            // Find first field, click it fill value -2
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("-2");

            // Find second field, click it fill value -5
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("-5");

            //Click calculate button
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            // Assert the result
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("-7"));
        }
        [Test]
        public void Test_Sum_OneNegativ_OnePositive_Numbers()
        {
            // Find first field, click it fill value -2
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("-2");

            // Find second field, click it fill value 5
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("5");

            //Click calculate button
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            // Assert the result
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("3"));
        }
        [Test]
        public void Test_Sum_InvalidValues_OnePositiveNumber()
        {
            // Find first field, click it fill value "ibre"
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Clear();
            num1.SendKeys("ibre");

            // Find second field, click it fill value 7
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Clear();
            num2.SendKeys("7");

            //Click calculate button
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            // Assert the result
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

            Assert.That(result, Is.EqualTo("error"));
        }
    }    
}