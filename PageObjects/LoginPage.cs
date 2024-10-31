using OpenQA.Selenium;

namespace DemoSelenium.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        /// <summary>
        /// Initilize Login Page
        /// </summary>
        /// <param name="driver"></param>
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement submitButton => driver.FindElement(By.Id("submit"));
        private IWebElement signupButton => driver.FindElement(By.Id("signup"));
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
        /// Click Signup Button
        /// </summary>
        public void ClickSignupButton()
        {
            signupButton.Click();
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
        /// Perform Login Action
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void Login(string email, string password)
        {
            this.EnterEmail(email);
            this.EnterPassword(password);
            this.ClickSubmitButton();
        }

    }
}
