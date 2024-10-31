using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using DemoSelenium.Base;
using System.Web.UI.WebControls;

namespace DemoSelenium.PageObjects
{
    public class AddEditContactPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        /// <summary>
        /// Initilize Add Contact Page
        /// </summary>
        /// <param name="driver"></param>
        public AddEditContactPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement submitButton => driver.FindElement(By.Id("submit"));
        private IWebElement cancelButton => driver.FindElement(By.Id("cancel"));
        private IWebElement firstNameTextBox => driver.FindElement(By.Id("firstName"));
        private IWebElement lastNameTextBox => driver.FindElement(By.Id("lastName"));
        private IWebElement birthdateTextBox => driver.FindElement(By.Id("birthdate"));
        private IWebElement emailTextBox => driver.FindElement(By.Id("email"));
        private IWebElement phoneTextBox => driver.FindElement(By.Id("phone"));
        private IWebElement street1TextBox => driver.FindElement(By.Id("street1"));
        private IWebElement street2TextBox => driver.FindElement(By.Id("street2"));
        private IWebElement cityTextBox => driver.FindElement(By.Id("city"));
        private IWebElement stateProvinceTextBox => driver.FindElement(By.Id("stateProvince"));
        private IWebElement postalCodeTextBox => driver.FindElement(By.Id("postalCode"));
        private IWebElement countryTextBox => driver.FindElement(By.Id("country"));


        /// <summary>
        /// Get Page Title
        /// </summary>
        /// <returns>Page Title</returns>
        public string GetPageTitle()
        {
            return this.driver.Title;
        }

        /// <summary>
        /// Click Submit Button
        /// </summary>
        public void ClickSubmitButton()
        {
            submitButton.Click();
        }

        /// <summary>
        /// Click Cancel Button
        /// </summary>
        public void ClickCancelButton()
        {
            cancelButton.Click();
        }

        public void ClearAllTextBox()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(firstNameTextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(lastNameTextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(birthdateTextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(emailTextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(phoneTextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(street1TextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(street2TextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(cityTextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(stateProvinceTextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(postalCodeTextBox));
            wait.Until(ExpectedConditions.ElementToBeClickable(countryTextBox));

            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            birthdateTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();
            street1TextBox.Clear();
            street2TextBox.Clear();
            cityTextBox.Clear();
            stateProvinceTextBox.Clear();
            postalCodeTextBox.Clear();
            countryTextBox.Clear();
        }

        /// <summary>
        /// Enter First Name in the Text box
        /// </summary>
        /// <param name="firstName"></param>
        public void EnterFirstNameTextBox(string firstName)
        {
            firstNameTextBox.Click();
            firstNameTextBox.Clear();
            firstNameTextBox.SendKeys(firstName);
        }

        /// <summary>
        /// Enter Last Name in the Text box
        /// </summary>
        /// <param name="firstName"></param>
        public void EnterLastNameTextBox(string firstName)
        {
            lastNameTextBox.Click();
            lastNameTextBox.Clear();
            lastNameTextBox.SendKeys(firstName);
        }

        /// <summary>
        /// Enter birthday in the Text box
        /// </summary>
        /// <param name="birthdate"></param>
        public void EnterBirthdateTextBox(string birthdate)
        {
            birthdateTextBox.Click();
            birthdateTextBox.Clear();
            birthdateTextBox.SendKeys(birthdate);
        }

        /// <summary>
        /// Enter email in the Text box
        /// </summary>
        /// <param name="email"></param>
        public void EnterEmailTextBox(string email)
        {
            emailTextBox.Click();
            emailTextBox.Clear();
            emailTextBox.SendKeys(email);
        }

        /// <summary>
        /// Enter phone in the text box
        /// </summary>
        /// <param name="phone"></param>
        public void EnterPhoneTextBox(string phone)
        {
            phoneTextBox.Click();
            phoneTextBox.Clear();
            phoneTextBox.SendKeys(phone);
        }

        /// <summary>
        /// Enter street1 in the text box
        /// </summary>
        /// <param name="street1"></param>
        public void EnterStreet1TextBox(string street1)
        {
            street1TextBox.Click();
            street1TextBox.Clear();
            street1TextBox.SendKeys(street1);
        }

        /// <summary>
        /// Enter street2 in the text box
        /// </summary>
        /// <param name="street2"></param>
        public void EnterStreet2TextBox(string street2)
        {
            street2TextBox.Click();
            street2TextBox.Clear();
            street2TextBox.SendKeys(street2);
        }

        /// <summary>
        /// Enter city in the text box
        /// </summary>
        /// <param name="city"></param>
        public void EnterCityTextBox(string city)
        {
            cityTextBox.Click();
            cityTextBox.Clear();
            cityTextBox.SendKeys(city);
        }

        /// <summary>
        /// Enter stateProvince in the text box
        /// </summary>
        /// <param name="stateProvince"></param>
        public void EnterStateProvinceTextBox(string stateProvince)
        {
            stateProvinceTextBox.Click();
            stateProvinceTextBox.Clear();
            stateProvinceTextBox.SendKeys(stateProvince);
        }

        /// <summary>
        /// Enter postalCode in the text box
        /// </summary>
        /// <param name="postalCode"></param>
        public void EnterPostalCodeTextBox(string postalCode)
        {
            postalCodeTextBox.Click();
            postalCodeTextBox.Clear();
            postalCodeTextBox.SendKeys(postalCode);
        }

        /// <summary>
        /// Enter country in the text box
        /// </summary>
        /// <param name="country"></param>
        public void EnterCountryTextBox(string country)
        {
            countryTextBox.Click();
            countryTextBox.Clear();
            countryTextBox.SendKeys(country);
        }


    }
}
