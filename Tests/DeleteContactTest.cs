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
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Newtonsoft.Json.Linq;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using DemoSelenium.Utility;

namespace DemoSelenium
{
    [TestClass]
    public class DeleteContactTest : BaseTest
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
            reporter = new Reporter(driver, "DeleteContactTest");

            //Start Logging
            reporter.StartExtentTest(TestContext.TestName);

            //Initialize Pages
            loginPage = new LoginPage(driver);
            contactListPage = new ContactListPage(driver);
            addEditContactPage = new AddEditContactPage(driver);
            contactDetailsPage = new ContactDetailsPage(driver);

            //Login
            loginDetails = JsonConvert.DeserializeObject<LoginModel>(File.ReadAllText(LoginDetailsJson));
            loginPage.Login(loginDetails.Logins[2].Email, loginDetails.Logins[2].Password);
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

        [TestCategory("Delete")]
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"D:\Repos\SeleniumDemo\DemoCRUDAutomation\Data\ContactDetails.xml", "Row", DataAccessMethod.Sequential)]
        public void VerifyDeleteContact()
        {

            //Arrange
            contactListPage.ClickAddContactButton();
            HelperMethod.AddContact(addEditContactPage, TestContext.DataRow["FirstName"].ToString(), TestContext.DataRow["LastName"].ToString(),
               TestContext.DataRow["DateOfBirth"].ToString(), TestContext.DataRow["Email"].ToString(), TestContext.DataRow["Phone"].ToString(), TestContext.DataRow["StreetAddress1"].ToString(),
               TestContext.DataRow["StreetAddress2"].ToString(), TestContext.DataRow["City"].ToString(), TestContext.DataRow["StateOrProvince"].ToString(), TestContext.DataRow["PostalCode"].ToString(),
               TestContext.DataRow["Country"].ToString());
            var contactEntry = contactListPage.SearchContactList(TestContext.DataRow["Email"].ToString());
            contactId = contactListPage.GetContactIdText(contactEntry);
            contactListPage.ClickContactItem(contactEntry);

            //Act
            contactDetailsPage.ClickDeleteContactButton();
            contactDetailsPage.AcceptAlertDialog();

            //Assert
            Assert.IsNull(contactListPage.SearchContactList(contactId));

            //Thread.Sleep(5000);
        }


    }
}
