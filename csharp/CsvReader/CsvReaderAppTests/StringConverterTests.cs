using System;
using CsvReaderApp;
using Xunit;

namespace CsvReaderAppTests
{
    public class StringConverterTests
    {
        private readonly StringConverter _target;

        public StringConverterTests()
        {
            _target = new StringConverter();
        }

        [Fact]
        public void String_TryParse_DoubleValue()
        {
            // Arrange
            var str = "3.1234";

            // Action
            var actual = _target.TryParse<double>(str);

            // Assert
            Assert.Equal(3.1234, actual);
        }

        [Fact]
        public void EmptyString_TryParse_ArgumentNullException()
        {
            // Arrange
            var str = string.Empty;

            // Action & Assert
            Assert.Throws<ArgumentNullException>(() => _target.TryParse<TestStruct>(str));
        }

        [Fact]
        public void EmptyString_TryParse_DefaultStructValue()
        {
            // Arrange
            var str = string.Empty;
            var expected = new double();

            // Action
            var actual = _target.TryParse<double>(str);

            // Assert
            Assert.Equal(expected, actual);
        }

        struct TestStruct
        {
        }
    }
}