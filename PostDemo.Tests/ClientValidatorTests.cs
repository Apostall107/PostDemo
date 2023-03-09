using FluentValidation.TestHelper;
using NUnit.Framework;
using PostDemo.BL.Helpers.ClientHelpers;
using PostDemo.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.Tests {

    [TestFixture]
    public class ClientValidatorTests {

        private ClientValidator _validator;
        private Client _client;

        [SetUp]
        public void Setup() {
            _validator = new ClientValidator();
            _client = new Client();
        }

        [Test]
        public void Name_ValueIsNull_HaveError() {
            _client.Name = null;

            var result = _validator.TestValidate(_client);

            result.ShouldHaveValidationErrorFor(x => x.Name)
                  .WithErrorMessage("Client name is required.");
        }

        [Test]
        public void Email_ValueIsNull_HaveError() {
            _client.Email = "asdffffff.";

            var result = _validator.TestValidate(_client);

            result.ShouldHaveValidationErrorFor(x => x.Email)
                  .WithErrorMessage("Invalid email address.");
        }

        [Test]
        public void Email_ValueIsNotAnEmailAddress_HaveError() {
            _client.Email = "notanemailaddress";

            var result = _validator.TestValidate(_client);

            result.ShouldHaveValidationErrorFor(x => x.Email)
                  .WithErrorMessage("Invalid email address.");
        }

        [Test]
        public void Country_ValueIsNull_HaveError() {
            _client.Country = null;

            var result = _validator.TestValidate(_client);

            result.ShouldHaveValidationErrorFor(x => x.Country)
                  .WithErrorMessage("Country is required.");
        }

        [Test]
        public void Region_ValueIsNull_HaveError() {
            _client.Region = null;


            var result = _validator.TestValidate(_client);

            result.ShouldHaveValidationErrorFor(x => x.Region)
                  .WithErrorMessage("Region is required.");
        }

        [Test]
        public void City_ValueIsNull_HaveError() {
            _client.City = null;


            var result = _validator.TestValidate(_client);

            result.ShouldHaveValidationErrorFor(x => x.City)
                  .WithErrorMessage("City is required.");
        }

        [Test]
        public void Address_ValueIsNull_HaveError() {
            _client.Address = null;

            var result = _validator.TestValidate(_client);

            result.ShouldHaveValidationErrorFor(x => x.Address)
                  .WithErrorMessage("Address is required.");
        }

        [Test]
        public void PostalCode_WhenValueIsNull_HaveError() {
            _client.PostalCode = null;


            var result = _validator.TestValidate(_client);

            result.ShouldHaveValidationErrorFor(x => x.PostalCode)
                  .WithErrorMessage("Postal code is required.");
        }

        [Test]
        public void PostalCode_ValueIsInvalid_HaveError() {
            _client.PostalCode = "notavalidpostalcode";


            var result = _validator.TestValidate(_client);

            result.ShouldHaveValidationErrorFor(x => x.PostalCode)
                  .WithErrorMessage("Invalid postal code.");
        }

        [Test]
        public void PostalCode_ValueIsValid_NoError() {
            _client.PostalCode = "12345";

            var result = _validator.TestValidate(_client);

            result.ShouldNotHaveValidationErrorFor(x => x.PostalCode);
        }
    }
}
