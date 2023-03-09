using NUnit.Framework;
using PostDemo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.Tests {
    [TestFixture]
    public class EmailServiceTests {

        EmailService _emailService;

        [SetUp]
        public void Setup() {
            _emailService = new EmailService();
        }

        [Test]
        [TestCase("receiver-name\'with-invalid-characters_file-name\'with-invalid-characters.txt_01012022_")]
        public void FormatAttachmentName_ReplacesInvalidCharacters(string expected) {
            // Arrange
            var attachmentName = "file\\name\"with/invalid\\characters.txt";
            var receiverName = "receiver\\name\"with/invalid\\characters";
            var date = new DateTime(2022, 01, 01);

            // Act
            var result = _emailService.FormatAttachmentName(attachmentName, receiverName, date);

            // Assert
            Assert.That(result, Does.StartWith(expected));
            Assert.That(expected.Length + 3, Is.EqualTo(result.Length));
        }

        [Test]
        [TestCase("file.txt_01012022_")]
        public void FormatAttachmentName_ReceiverNameIsNull_ReturnsValidName(string expected) {
            // Arrange
            var attachmentName = "file.txt";
            string receiverName = null;
            var date = new DateTime(2022, 01, 01);

            // Act
            var result = _emailService.FormatAttachmentName(attachmentName, receiverName, date);

            // Assert
            Assert.That(result, Does.StartWith(expected));
            Assert.That(expected.Length + 3, Is.EqualTo(result.Length));
        }

        [Test]
        public void FormatAttachmentName_DateIsNull_ReturnsValidName() {
            // Arrange
            var attachmentName = "file.txt";
            var receiverName = "receiver";
            DateTime? date = null;

            // Act
            var result = _emailService.FormatAttachmentName(attachmentName, receiverName, date);

            // Assert
            Assert.That(result, Is.Not.Null.Or.Empty);
        }
    }
}

