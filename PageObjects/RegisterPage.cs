using OpenQA.Selenium;

namespace DemoSelenium.PageObjects
{
    public class RegisterPage
    {
        private IWebDriver driver;

        /// <summary>
        /// Initilize Register Page
        /// </summary>
        /// <param name="driver"></param>
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement submitButton => driver.FindElement(By.Id("submit"));
        private IWebElement cancelButton => driver.FindElement(By.Id("cancel"));
        private IWebElement firstNameTextBox => driver.FindElement(By.Id("firstName"));
        private IWebElement lastNameTextBox => driver.FindElement(By.Id("lastName"));
        private IWebElement emailTextBox => driver.FindElement(By.Id("email"));
        private IWebElement passwordTextBox => driver.FindElement(By.Id("password"));

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

        /// <summary>
        /// Enter Fist Name in the Text box
        /// </summary>
        /// <param name="firstName"></param>
        public void EnterFirstName(string firstName)
        {
            firstNameTextBox.SendKeys(firstName);
        }

        /// <summary>
        /// Get the value from first name text box
        /// </summary>
        /// <returns>First Name Value</returns>
        public string GetValueTextBoxFirstName()
        {
            return firstNameTextBox.GetAttribute("value");
        }

        /// <summary>
        /// Enter Last Name in the Text box
        /// </summary>
        /// <param name="lastName"></param>
        public void EnterLastName(string lastName)
        {
            lastNameTextBox.SendKeys(lastName);
        }

        /// <summary>
        /// Get the value from last name text box
        /// </summary>
        /// <returns>First Name Value</returns>
        public string GetValueTextBoxLastName()
        {
            return lastNameTextBox.GetAttribute("value");
        }

        /// <summary>
        /// Enter Email in the Text box
        /// </summary>
        /// <param name="email"></param>
        public void EnterEmail(string email)
        {
            emailTextBox.SendKeys(email);
        }

        /// <summary>
        /// Get the value from email text box
        /// </summary>
        /// <returns>First Name Value</returns>
        public string GetValueTextBoxEmail()
        {
            return emailTextBox.GetAttribute("value");
        }

        /// <summary>
        /// Enter Password in the Text box
        /// </summary>
        /// <param name="password"></param>
        public void EnterPassword(string password)
        {
            passwordTextBox.SendKeys(password);
        }

        /// <summary>
        /// Get the value from password text box
        /// </summary>
        /// <returns>First Name Value</returns>
        public string GetValueTextBoxPassword()
        {
            return passwordTextBox.GetAttribute("value");
        }

        /// <summary>
        /// Perform Signup Action
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void SignUp(string firstName, string lastName, string email, string password)
        {

            this.EnterFirstName(firstName);
            this.EnterLastName(lastName);
            this.EnterEmail(email);
            this.EnterPassword(password);
            this.ClickSubmitButton();

        }

    }
}
