using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using System.Net;
using OpenQA.Selenium;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Interfaces;
using System.Net.Configuration;
using System.Collections.Generic;

namespace  Appium_Csharp
{
    [TestFixture]
    public class BasicTest
    {
        public AppiumDriver<AndroidElement> driver;

        // default constructor
        public BasicTest()
        {
            driver = null; // null value 
        }

        // Method to setup the device configuration
        [SetUp]
        public void DeviceSetup()
        {
            #region
            try
            {
                /*  -- this would work for the Real-device attached to the PC/Laptop -- */
                DesiredCapabilities caps = new DesiredCapabilities();
                caps.SetCapability("deviceName", "Nexus 4");
                caps.SetCapability("udid", "0099723a1a4c55ac"); //DeviceId from "adb devices" command
                caps.SetCapability("platformName", "Android");
                caps.SetCapability("platformVersion", "5.1.1");
                caps.SetCapability("skipUnlock", "true");
                caps.SetCapability("appPackage", "com.edible.consumer");
                caps.SetCapability("appActivity", "com.edible.consumer.LaunchActivity");
                caps.SetCapability("noReset", "false");
                driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), caps);
                


                /* this would work for Android-emulator  
                DesiredCapabilities caps = new DesiredCapabilities();
                caps.SetCapability("deviceName", "Galaxy Nexus API 24");
                caps.SetCapability("udid", "emulator-5554"); //DeviceId from "adb devices" command
                caps.SetCapability("platformName", "Android");
                caps.SetCapability("platformVersion", "7.0");
                caps.SetCapability("skipUnlock", "true");
                caps.SetCapability("appPackage", "com.edible.consumer");
                caps.SetCapability("appActivity", "com.edible.consumer.LaunchActivity");
                caps.SetCapability("noReset", "false");
                driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), caps);
                */
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to configure the device configuration .... " + e);
            }
            #endregion
        }

        // Method to setup the device configuration
        [Test]
        public void TestMethod1()
        {
            Task.Delay(9000).Wait();

            /* this is Absolute XPath 
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.support.v4.widget.DrawerLayout/android.widget.LinearLayout/android.view.View/android.widget.ImageButton")).Click();
            */

            // this is relative xpath 
            driver.FindElement(By.XPath("//android.widget.ImageButton[@index ='0']")).Click();

            Task.Delay(3000).Wait();
            driver.FindElement(By.Id("cb_myaccount")).Click();
            driver.FindElement(By.Id("btn_login")).Click();
            driver.FindElement(By.Id("et_email")).SendKeys("efcedible@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("Net$0lace#");
            driver.FindElement(By.Id("textView")).Click();
            
            Task.Delay(8000).Wait();
            var EditProfile = driver.FindElement(By.Id("tv_edit_profile"));
            // place order test order if login is successfull
            if (EditProfile.Displayed)
            {
                driver.FindElement(By.XPath("//android.widget.ImageButton[@index ='0']")).Click();
                driver.FindElement(By.Id("com.edible.consumer:id/cb_featured")).Click();
                driver.FindElement(By.XPath("//android.widget.ImageView[@index ='0']")).Click();
                
            }
        }

        // Method to teardown the device configuration
        [TearDown]
        public void DeviceClosure()
        {
            #region
            try
            {
                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failure in DeviceClosure method ... "+ e);
            }
            #endregion
        }

    }
}
