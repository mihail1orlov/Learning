using CsvReaderApp;
using NSubstitute;
using Xunit;

namespace CsvReaderAppTests
{
    public class CsvReaderTests
    {
        private readonly CsvReader _target;

        public CsvReaderTests()
        {
            var stringConverter = Substitute.For<IStringConverter>();
            stringConverter.TryParse<double>("1.3").Returns(1.3);
            stringConverter.TryParse<double>("4.5").Returns(4.5);
            stringConverter.TryParse<double>("2.63").Returns(2.63);
            stringConverter.TryParse<double>("5.32").Returns(5.32);
            stringConverter.TryParse<int>("1").Returns(1);
            stringConverter.TryParse<int>("3").Returns(3);
            stringConverter.TryParse<int>("4").Returns(4);
            stringConverter.TryParse<int>("5").Returns(5);
            stringConverter.TryParse<int>("2").Returns(2);
            stringConverter.TryParse<int>("63").Returns(63);
            stringConverter.TryParse<int>("5").Returns(5);
            stringConverter.TryParse<int>("32").Returns(32);
            _target = new CsvReader(stringConverter);
        }

        [Fact]
        public void Lines_Read_DoubleArray()
        {
            // Arrange
            var lines = new[] {"1.3,4.5", "2.63,5.32"};

            // Action
            var actual = _target.Read<double>(lines);

            // Assert
            Assert.Equal(new[] { new[] { 1.3, 4.5 }, new[] { 2.63, 5.32 } }, actual);
        }

        [Fact]
        public void Lines_Read_IntArray()
        {
            // Arrange
            var lines = new[] {"1,3,4,5", "2,63,5,32"};

            // Action
            var actual = _target.Read<int>(lines);

            // Assert
            Assert.Equal(new[] { new[] { 1,3, 4,5 }, new[] { 2,63, 5,32 } }, actual);
        }

        [Fact]
        public void EmptyArrayLines_Read_EmptyArray()
        {
            // Arrange
            var lines = new string[] {};

            // Action
            var actual = _target.Read<int>(lines);

            // Assert
            Assert.Equal(new int[][]{}, actual);
        }
    }
}
