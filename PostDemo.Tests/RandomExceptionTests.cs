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
        Random rand;

        [SetUp] 
        public void SetUp() {

            rand = new Random();
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
            RandomException.RandomExceptionGenerate(value);
            // Assert
            // Ensure no exception was thrown
        }
    }

}
