using DemoSelenium.Base;
using DemoSelenium.DataModel;
using DemoSelenium.PageObjects;
using DemoSelenium.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json.Linq;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using DemoSelenium.Utility;

namespace DemoSelenium
{
    [TestClass]
    public class UpdateContactTest : BaseTest
    {
        
        public LoginPage loginPage;
        public LoginModel loginDetails;
        public ContactListPage contactListPage;
        public AddEditContactPage addEditContactPage;
        public ContactDetailsPage contactDetailsPage;

        private Reporter reporter;
        private string contactId;
        private string token;

        [TestInitialize]
        public void TestInit()
        {
            // Init Reporter
            reporter = new Reporter(driver, "UpdateContactTest");

            //Start Logging
            reporter.StartExtentTest(TestContext.TestName);

            //Initialize Pages
            loginPage = new LoginPage(driver);
            contactListPage = new ContactListPage(driver);
            addEditContactPage = new AddEditContactPage(driver);
            contactDetailsPage = new ContactDetailsPage(driver);

            //Login
            loginDetails = JsonConvert.DeserializeObject<LoginModel>(File.ReadAllText(LoginDetailsJson));
            loginPage.Login(loginDetails.Logins[1].Email, loginDetails.Logins[1].Password);
            contactListPage.WaitTableVisible();
            token = driver.Manage().Cookies.GetCookieNamed("token").ToString();
            token = (token.Split(';'))[0].Replace("token=", "");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Log result
            reporter.LoggingTestStatusExtentReport(TestContext);
            // End Report
            reporter.EndReporter();

            var options = new RestClientOptions("https://thinking-tester-contact-list.herokuapp.com");
            var client = new RestClient(options);
            var request = new RestRequest($"/contacts/{contactId}", Method.Delete);
            request.AddHeader("Authorization", $"Bearer {token}");
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        [TestCategory("Update")]
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"D:\Repos\SeleniumDemo\DemoCRUDAutomation\Data\ContactDetails.xml", "Row", DataAccessMethod.Sequential)]
        public void VerifyUpdatedContact()
        {

            //Arrange
            contactListPage.ClickAddContactButton();
            var id = DateTimeOffset.Now.ToString("ddHHmmss");
            HelperMethod.AddDefaultContact(addEditContactPage, id);
            var contactEntry = contactListPage.SearchContactList($"defaultemail{id}@gmail.com");
            contactId = contactListPage.GetContactIdText(contactEntry);
            contactListPage.ClickContactItem(contactEntry);

            //Act
            contactDetailsPage.ClickEditContactButton();
            addEditContactPage.ClearAllTextBox();
            addEditContactPage.EnterFirstNameTextBox(TestContext.DataRow["FirstName"].ToString());
            addEditContactPage.EnterLastNameTextBox(TestContext.DataRow["LastName"].ToString());
            addEditContactPage.EnterBirthdateTextBox(TestContext.DataRow["DateOfBirth"].ToString());
            addEditContactPage.EnterEmailTextBox(TestContext.DataRow["Email"].ToString());
            addEditContactPage.EnterPhoneTextBox(TestContext.DataRow["Phone"].ToString());
            addEditContactPage.EnterStreet1TextBox(TestContext.DataRow["StreetAddress1"].ToString());
            addEditContactPage.EnterStreet2TextBox(TestContext.DataRow["StreetAddress2"].ToString());
            addEditContactPage.EnterCityTextBox(TestContext.DataRow["City"].ToString());
            addEditContactPage.EnterStateProvinceTextBox(TestContext.DataRow["StateOrProvince"].ToString());
            addEditContactPage.EnterPostalCodeTextBox(TestContext.DataRow["PostalCode"].ToString());
            addEditContactPage.EnterCountryTextBox(TestContext.DataRow["Country"].ToString());
            addEditContactPage.ClickSubmitButton();
            contactDetailsPage.ClickReturnButton();
            contactListPage.WaitTableUpdate(TestContext.DataRow["Email"].ToString());
            contactEntry = contactListPage.SearchContactList(TestContext.DataRow["Email"].ToString());

            //Assert
            Assert.AreEqual($"{TestContext.DataRow["FirstName"]} {TestContext.DataRow["LastName"]}", contactListPage.GetContactNameText(contactEntry));
            Assert.AreEqual($"{TestContext.DataRow["DateOfBirth"]}", contactListPage.GetContactBirthdateText(contactEntry));
            Assert.AreEqual($"{TestContext.DataRow["Email"]}", contactListPage.GetContactEmailText(contactEntry));
            Assert.AreEqual($"{TestContext.DataRow["Phone"]}", contactListPage.GetContactPhoneText(contactEntry));
            Assert.AreEqual($"{TestContext.DataRow["StreetAddress1"]} {TestContext.DataRow["StreetAddress2"]}", contactListPage.GetContactAddressText(contactEntry));
            Assert.AreEqual($"{TestContext.DataRow["City"]} {TestContext.DataRow["StateOrProvince"]} {TestContext.DataRow["PostalCode"]}", contactListPage.GetContactCityProvincePostalCodeText(contactEntry));
            Assert.AreEqual($"{TestContext.DataRow["Country"]}", contactListPage.GetContactCountryText(contactEntry));

            //Thread.Sleep(5000);
        }


    }
}
