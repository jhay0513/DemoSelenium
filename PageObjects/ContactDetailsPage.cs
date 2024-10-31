using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;

namespace DemoSelenium.PageObjects
{
    public class ContactDetailsPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        /// <summary>
        /// Initilize Contact List Page
        /// </summary>
        /// <param name="driver"></param>
        public ContactDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement editContactButton =>  driver.FindElement(By.Id("edit-contact"));
        private IWebElement deleteContactButton => driver.FindElement(By.Id("delete"));
        private IWebElement returnButton => driver.FindElement(By.Id("return"));
        private IWebElement contactDetailsForm => driver.FindElement(By.Id("contactDetails"));

        /// <summary>
        /// Get Page Title
        /// </summary>
        /// <returns>Page Title</returns>
        public string GetPageTitle()
        {
            return this.driver.Title;
        }

        /// <summary>
        /// Click Edit Button
        /// </summary>
        public void ClickEditContactButton() => editContactButton.Click();

        /// <summary>
        /// Click Delete Button
        /// </summary>
        public void ClickDeleteContactButton() => deleteContactButton.Click();

        /// <summary>
        /// Click Return Button
        /// </summary>
        public void ClickReturnButton() => returnButton.Click();

        /// <summary>
        /// Return Contact Details
        /// </summary>
        /// <returns>Contact Details</returns>
        public string GetContactDetailsText()
        {
            return contactDetailsForm.GetAttribute("textContent");
        }

        /// <summary>
        /// Accept Alert
        /// </summary>
        public void AcceptAlertDialog()
        {
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }

    }
}
