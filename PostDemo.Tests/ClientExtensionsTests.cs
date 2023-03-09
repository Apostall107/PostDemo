using NUnit.Framework;
using PostDemo.BL.Extentions;
using PostDemo.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.Tests {
    [TestFixture]
    public class ClientExtensionsTests {
        private Client _client;

        [SetUp]
        public void SetUp() {
            _client = new Client {
                Name = "",
                Email = "",
                PhoneNumber = "",
                Country = "",
                Region = "",
                City = "",
                Address = "",
                PostalCode = ""
            };
        }

        [Test]
        public void AddCountryCodeToPhoneNumber_WhenPhoneNumberIsNull_DoesNotModifyPhoneNumber() {
            // Arrange
            _client.PhoneNumber = null;

            // Act
            _client.AddCountryCodeToPhoneNumber();

            // Assert
            Assert.IsNull(_client.PhoneNumber);
        }

        [Test]
        public void AddCountryCodeToPhoneNumber_WhenPhoneNumberStartsWithPlus_DoesNotModifyPhoneNumber() {
            // Arrange
            _client.PhoneNumber = "+1234567890";

            // Act
            _client.AddCountryCodeToPhoneNumber();

            // Assert
            Assert.AreEqual("+1234567890", _client.PhoneNumber);
        }

        [Test]
        public void AddCountryCodeToPhoneNumber_WhenCountryIsRussia_AddsCountryCode() {
            // Arrange
            _client.PhoneNumber = "1234567890";
            _client.Country = "Russia";

            // Act
            _client.AddCountryCodeToPhoneNumber();

            // Assert
            Assert.AreEqual("+71234567890", _client.PhoneNumber);
        }

        [Test]
        public void AddCountryCodeToPhoneNumber_WhenCountryIsUSA_AddsCountryCode() {
            // Arrange
            _client.PhoneNumber = "1234567890";
            _client.Country = "USA";

            // Act
            _client.AddCountryCodeToPhoneNumber();

            // Assert
            Assert.AreEqual("+11234567890", _client.PhoneNumber);
        }

        [Test]
        public void AddCountryCodeToPhoneNumber_WhenCountryIsGermany_AddsCountryCode() {
            // Arrange
            _client.PhoneNumber = "1234567890";
            _client.Country = "Germany";

            // Act
            _client.AddCountryCodeToPhoneNumber();

            // Assert
            Assert.AreEqual("+491234567890", _client.PhoneNumber);
        }

        [Test]
        public void AddCountryCodeToPhoneNumber_WhenCountryIsUkraine_AddsCountryCode() {
            // Arrange
            _client.PhoneNumber = "1234567890";
            _client.Country = "Ukraine";

            // Act
            _client.AddCountryCodeToPhoneNumber();

            // Assert
            Assert.AreEqual("+381234567890", _client.PhoneNumber);
        }

        [Test]
        [TestCase("Not set")]
        public void SetEmptyFieldsToNotSet_SetsEmptyFieldsToNotSet(string expected) {
            // Arrange

            // Act
            _client.SetEmptyFieldsToNotSet();

            // Assert
            Assert.AreEqual(expected, _client.Name);
            Assert.AreEqual(expected, _client.Email);
            Assert.AreEqual(expected, _client.PhoneNumber);
            Assert.AreEqual(expected, _client.Country);
            Assert.AreEqual(expected, _client.Region);
            Assert.AreEqual(expected, _client.City);
            Assert.AreEqual(expected, _client.Address);
            Assert.AreEqual(expected, _client.PostalCode);
        }
    }
}
