using NUnit.Framework;
using PostDemo.BL.Helpers;
using PostDemo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FakeItEasy;
using Newtonsoft.Json.Linq;

namespace PostDemo.Tests {
    [TestFixture]
    public class PostServiceTests {
        private IEmailService _emailServiceFake;
        private ISMTPConfig _smtpConfigFake;
        private PostService _postService;

        [SetUp]
        public void Setup() {
            
            _emailServiceFake = A.Fake<IEmailService>(); 
            _smtpConfigFake = A.Fake<ISMTPConfig>();
            _postService = new PostService(_emailServiceFake, _smtpConfigFake);
        }

        [Test]
        [TestCase("recepient", "subject", "emailBody", "attachmentName", new byte[] { 0x01, 0x02, 0x03 })]
        public void SendEmail_SMTPNotConfigured_ThrowsException(
            string recepient,
            string subject,
            string emailBody,
            string attachmentName,
            byte[] attachment) {
            // Arrange
            A.CallTo(() => _smtpConfigFake.IsConfigured).Returns(false);
            A.CallTo(() => _emailServiceFake.FormatAttachmentName(attachmentName,
                recepient,
                DateTime.Now)).Returns(attachmentName);
            //Act
            TestDelegate del = () => {
                _postService.SendEmail(recepient, subject, emailBody, attachmentName, attachment);
            };
            //Assert
            Assert.Throws<Exception>(del);
        }

        [Test]
        [TestCase(null, "subject", "emailBody", "attachmentName", new byte[] { 0x01, 0x02, 0x03 })]
        public void SendEmail_NoRecipient_ThrowsException(
    string recepient,
    string subject,
    string emailBody,
    string attachmentName,
    byte[] attachment) {
            // Arrange
            A.CallTo(() => _smtpConfigFake.IsConfigured).Returns(false);
            A.CallTo(() => _emailServiceFake.FormatAttachmentName(attachmentName,
                recepient,
                DateTime.Now)).Returns(attachmentName);
            //Act
            TestDelegate del = () => {
                _postService.SendEmail(recepient, subject, emailBody, attachmentName, attachment);
            };
            //Assert
            Assert.Throws<Exception>(del);
        }

        [Test]
        [TestCase(null, "subject", "emailBody", "attachmentName", new byte[] { 0x01, 0x02, 0x03 })]
        public void SendEmail_WithRecipient_DoesNotThrowException(
    string recepient,
    string subject,
    string emailBody,
    string attachmentName,
    byte[] attachment) { 
            // Act & Assert
            Assert.DoesNotThrow(() => _postService.SendEmail(recepient, subject, emailBody, attachmentName, attachment));
        }

        [Test]
        [TestCase("recepient",null, null, null, new byte[] { 0x01, 0x02, 0x03 })]
        public void SendEmail_SubjectEmailBodyAttachmentNameAreNull_SetsValueToThem(
string recepient,
string subject,
string emailBody,
string attachmentName,
byte[] attachment) {
            // Arrange
            A.CallTo(() => _smtpConfigFake.IsConfigured).Returns(false);
            A.CallTo(() => _emailServiceFake.FormatAttachmentName(attachmentName,
                recepient,
                DateTime.Now)).Returns(attachmentName);
            //Act
            TestDelegate del = () => {
                _postService.SendEmail(recepient, subject, emailBody, attachmentName, attachment);
            };
            //Assert
            Assert.DoesNotThrow(del);
            Assert.That(del, is );
        }


        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void IsSMTPConfigured_SetupsValue(bool value) {
            Assert.AreEqual(_postService.IsSMTPConfigured(value), value);
        }


    }

}

