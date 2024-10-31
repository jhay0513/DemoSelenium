using DemoSelenium.Base;
using DemoSelenium.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSelenium.Helper
{
    public class HelperMethod
    {
        /// <summary>
        /// Create New Contact
        /// </summary>
        /// <param name="addEditContactPage"></param>
        /// <param name="FirstName"></param>
        /// <param name="lastNamem"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="streetAddress1"></param>
        /// <param name="streetAddress2"></param>
        /// <param name="city"></param>
        /// <param name="stateOrProvince"></param>
        /// <param name="postalCode"></param>
        /// <param name="country"></param>
        public static void AddContact(AddEditContactPage addEditContactPage, string FirstName, string lastNamem, string dateOfBirth, string email, string phone, string streetAddress1,
            string streetAddress2, string city, string stateOrProvince, string postalCode, string country)
        {
            addEditContactPage.EnterFirstNameTextBox(FirstName);
            addEditContactPage.EnterLastNameTextBox(lastNamem);
            addEditContactPage.EnterBirthdateTextBox(dateOfBirth);
            addEditContactPage.EnterEmailTextBox(email);
            addEditContactPage.EnterPhoneTextBox(phone);
            addEditContactPage.EnterStreet1TextBox(streetAddress1);
            addEditContactPage.EnterStreet2TextBox(streetAddress2);
            addEditContactPage.EnterCityTextBox(city);
            addEditContactPage.EnterStateProvinceTextBox(stateOrProvince);
            addEditContactPage.EnterPostalCodeTextBox(postalCode);
            addEditContactPage.EnterCountryTextBox(country);
            addEditContactPage.ClickSubmitButton();
        }

        /// <summary>
        /// Create Default Contact
        /// </summary>
        /// <param name="addContactPage"></param>
        public static void AddDefaultContact(AddEditContactPage addContactPage, string id)
        {
            addContactPage.EnterFirstNameTextBox("defaultfirstname");
            addContactPage.EnterLastNameTextBox("defaultlastname");
            addContactPage.EnterBirthdateTextBox("1990-01-01");
            addContactPage.EnterEmailTextBox($"defaultemail{id}@gmail.com");
            addContactPage.EnterPhoneTextBox("1234567890");
            addContactPage.EnterStreet1TextBox("defaultstreetaddress1");
            addContactPage.EnterStreet2TextBox("defaultstreetaddress2");
            addContactPage.EnterCityTextBox("cefaultcity");
            addContactPage.EnterStateProvinceTextBox("defaultstate");
            addContactPage.EnterPostalCodeTextBox("0000");
            addContactPage.EnterCountryTextBox("defaultcountry");
            addContactPage.ClickSubmitButton();
        }
    }
}
