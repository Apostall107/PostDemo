using NUnit.Framework;
using PostDemo.BL.Helpers.PackageHelpers;
using PostDemo.DAL.Models.Entities;


namespace PostDemo.Tests {
    [TestFixture]
    public class PackageValidatorTests {

        Package _package;

        [SetUp]
        public void Setup() {
            _package = new Package();
        }

        [Test]
        public void ValidatePackage_SameSenderAndReceiver_ReturnsFalse() {
            // Arrange
            _package.SenderId = 1;
            _package.ReceiverId = 1;

            // Act
            var result = PackageValidator.ValidatePackage(_package);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidatePackage_SenderAndReceiverNotSame_ReturnsTrue() {
            // Arrange
            _package.SenderId = 1;
            _package.ReceiverId = 2;

            // Act
            var result = PackageValidator.ValidatePackage(_package);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSenderReceiverValid_SenderAndReceiverSame_ReturnsFalse() {
            // Arrange
            var senderId = 1;
            var receiverId = 1;

            // Act
            var result = PackageValidator.IsSenderReceiverValid(senderId, receiverId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsSenderReceiverValid_SenderAndReceiverNotSame_ReturnsTrue() {
            // Arrange
            var senderId = 1;
            var receiverId = 2;

            // Act
            var result = PackageValidator.IsSenderReceiverValid(senderId, receiverId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void VerifyFileName_ReplacesInvalidCharsInFileName() {
            // Arrange
            var fileName = "file?name*.txt";

            // Act
            PackageValidator.VerifyFileName(ref fileName);

            // Assert
            Assert.AreEqual("filename.txt", fileName);
        }

        [Test]
        public void VerifyFileName_DoesNotReplaceValidCharsInFileName() {
            // Arrange
            var fileName = "file-name.txt";

            // Act
            PackageValidator.VerifyFileName(ref fileName);

            // Assert
            Assert.AreEqual("file-name.txt", fileName);
        }

    }
}
