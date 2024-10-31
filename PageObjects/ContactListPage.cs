using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace DemoSelenium.PageObjects
{
    public class ContactListPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        /// <summary>
        /// Initilize Contact List Page
        /// </summary>
        /// <param name="driver"></param>
        public ContactListPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement addContactButton =>  driver.FindElement(By.Id("add-contact"));
        private IWebElement contactListTable => driver.FindElement(By.CssSelector(".contactTable"));
        private IWebElement searchContactList(string searchkey) => driver.FindElement(By.XPath($"//table[@id='myTable']//tr[@class='contactTableBodyRow' and td[contains(text(),'{searchkey}')]]"));

        private static readonly By idColumn = By.XPath("td[1]");
        private static readonly By nameColumn = By.XPath("td[2]");
        private static readonly By birthdate = By.XPath("td[3]");
        private static readonly By email = By.XPath("td[4]");
        private static readonly By phone = By.XPath("td[5]");
        private static readonly By address = By.XPath("td[6]");
        private static readonly By cityProvincePostalCode = By.XPath("td[7]");
        private static readonly By country = By.XPath("td[8]");

        /// <summary>
        /// Get Page Title
        /// </summary>
        /// <returns>Page Title</returns>
        public string GetPageTitle()
        {
            return this.driver.Title;
        }


        public void WaitTableVisible()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(contactListTable));
        }

        public void WaitTableUpdate(string searchkey)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(searchContactList(searchkey), searchkey));
        }

        /// <summary>
        /// Click Submit Button
        /// </summary>
        public void ClickAddContactButton() => addContactButton.Click();

        /// <summary>
        /// Return Contact Entry from list
        /// </summary>
        /// <param name="searchkey"></param>
        /// <returns>Contact Entry Web Element</returns>
        public IWebElement SearchContactList(string searchkey)
        {
            try{
                return searchContactList(searchkey);
            }
            catch{
                return null;
            }
        }

        /// <summary>
        /// Click Contact Item Row
        /// </summary>
        /// <param name="element"></param>
        public void ClickContactItem(IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Return Contact Id Text from Entry
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Contact Id Text</returns>
        public string GetContactIdText(IWebElement element)
        {
            return element.FindElement(idColumn).GetAttribute("textContent");
        }

        /// <summary>
        /// Return Contact Name Text from Entry
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Contact Name Text</returns>
        public string GetContactNameText(IWebElement element)
        {
            return element.FindElement(nameColumn).GetAttribute("textContent");
        }

        /// <summary>
        /// Return Contact Birthdate Text from Entry
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Contact Birthdate Text</returns>
        public string GetContactBirthdateText(IWebElement element)
        {
            return element.FindElement(birthdate).GetAttribute("textContent");
        }

        /// <summary>
        /// Return Contact Email Text from Entry
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Contact Email Text</returns>
        public string GetContactEmailText(IWebElement element)
        {
            return element.FindElement(email).GetAttribute("textContent");
        }

        /// <summary>
        /// Return Contact Phone Text from Entry
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Contact Phone Text</returns>
        public string GetContactPhoneText(IWebElement element)
        {
            return element.FindElement(phone).GetAttribute("textContent");
        }

        /// <summary>
        /// Return Contact Address Text from Entry
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Contact Address Text</returns>
        public string GetContactAddressText(IWebElement element)
        {
            return element.FindElement(address).GetAttribute("textContent");
        }

        /// <summary>
        /// Return Contact City Province Postal Code Text from Entry
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Contact City Province Postal Code Text</returns>
        public string GetContactCityProvincePostalCodeText(IWebElement element)
        {
            return element.FindElement(cityProvincePostalCode).GetAttribute("textContent");
        }

        /// <summary>
        /// Return Contact Country Text from Entry
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Contact Country Text</returns>
        public string GetContactCountryText(IWebElement element)
        {
            return element.FindElement(country).GetAttribute("textContent");
        }

    }
}
