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
    public class PackageExtensionsTests {
        private Package _package;

        [SetUp]
        public void SetUp() {
            _package = new Package();
        }

        [Test]
        public void SetEmptyFieldsToNotSet_SetsTitleAndDescriptionIfEmpty() {
            // Arrange
            _package.Title = "";
            _package.Description = "";

            // Act
            _package.SetEmptyFieldsToNotSet();

            // Assert
            Assert.AreEqual("Not set", _package.Title);
            Assert.AreEqual("Not set", _package.Description);
        }

        [Test]
        [TestCase(10, 20)]
        [TestCase(50, 100)]
        [TestCase(100, 100)]
        public void ChangeKilosInLoop_UpdatesKilosIfCounterIsLessThan100(int initialKilos, int expectedKilos) {
            // Arrange
            _package.Kilos = initialKilos;

            // Act
            _package.ChangeKilosInLoop();

            // Assert
            Assert.AreEqual(expectedKilos, _package.Kilos);
        }
    }

}
