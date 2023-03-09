using Moq;
using NUnit.Framework;
using PostDemo.BL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.Tests {
    [TestFixture]
    public class RandomExceptionTests {
        Random rand = new Random();

        [SetUp] 
        public void SetUp() {
        }


        [Test]
        public void RandomExceptionGenerate_ArgumentException() {
            // Arrange
            var value = rand.Next(0, 3);
            // Act & Assert
            Assert.Throws<ArgumentException>(() => RandomException.RandomExceptionGenerate(value));
        }

        [Test]
        public void RandomExceptionGenerate_NullReferenceException() {
            // Arrange
            var value = rand.Next(4, 6);
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => RandomException.RandomExceptionGenerate(value));
        }

        [Test]
        public void RandomExceptionGenerate_InvalidOperationException() {
            // Arrange
            var value = rand.Next(7, 9);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => RandomException.RandomExceptionGenerate(value));
        }

        [Test]
        public void RandomExceptionGenerate_NoExceptionThrown() {
            var value = rand.Next(10, 100);
            // Act
            TestDelegate del = () => RandomException.RandomExceptionGenerate(value);
            // Assert
            Assert.DoesNotThrow(del);
        }
    }

}
