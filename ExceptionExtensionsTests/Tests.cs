using ExceptionExtensions;
using NUnit.Framework;
using System;

namespace ExceptionExtensionsTests
{
    public class Tests
    {
        #region Public Methods

        [Test]
        public void TestMessageStack()
        {
            var text2 = "Test1";
            var ex2 = new Exception(text2);

            var text1 = "Test1";
            var ex1 = new Exception(text1, ex2);

            var separator = " ";
            var result = ex1.GetMessageStack(separator);

            Assert.True(result == text1 + separator + text2);
        }

        #endregion Public Methods
    }
}