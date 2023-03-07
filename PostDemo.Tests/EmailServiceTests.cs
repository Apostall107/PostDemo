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
        [Test]
        public void FormatAttachmentName_ReplacesInvalidCharacters() {
            // Arrange
            var emailService = new EmailService();
            var attachmentName = "file\\name\"with/invalid\\characters.txt";
            var receiverName = "receiver\\name\"with/invalid\\characters";
            var date = new DateTime(2022, 01, 01);

            // Act
            var result = emailService.FormatAttachmentName(attachmentName, receiverName, date);

            // Assert
            Assert.That(result, Does.StartWith("receiver-name\'with-invalid-characters_file-name\'with-invalid-characters.txt_01012022_"));
        }

        [Test]
        public void FormatAttachmentName_ReceiverNameIsNull_ReturnsValidName() {
            // Arrange
            var emailService = new EmailService();
            var attachmentName = "file.txt";
            string receiverName = null;
            var date = new DateTime(2022, 01, 01);

            // Act
            var result = emailService.FormatAttachmentName(attachmentName, receiverName, date);

            // Assert
            Assert.That(result, Does.StartWith("file.txt_01012022_"));
        }

        [Test]
        public void FormatAttachmentName_DateIsNull_ReturnsValidName() {
            // Arrange
            var emailService = new EmailService();
            var attachmentName = "file.txt";
            var receiverName = "receiver";
            DateTime? date = null;

            // Act
            var result = emailService.FormatAttachmentName(attachmentName, receiverName, date);

            // Assert
            Assert.That(result, Is.Not.Null.Or.Empty);
        }
    }
}

