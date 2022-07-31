namespace X10sions.Tests.EnumerableExtensions
{
    public class EmptyOrNullTests
    {
        [Fact]
        public void EmptyOrNull_WhenNull_ReturnsTrue()
        {
            // Arrange
            var enumerable = default(IEnumerable<object>);

            // Act
            var empty = enumerable.EmptyOrNull();

            // Assert
            Assert.True(empty);
        }

        [Fact]
        public void EmptyOrNull_WhenEmpty_ReturnsTrue()
        {
            // Arrange
            var enumerable = Enumerable.Empty<object>();

            // Act
            var empty = enumerable.EmptyOrNull();

            // Assert
            Assert.True(empty);
        }

        [Fact]
        public void EmptyOrNull_WhenPopulated_ReturnsFalse()
        {
            // Arrange
            var enumerable = Enumerable.Repeat(default(object), 10);

            // Act
            var empty = enumerable.EmptyOrNull();

            // Assert
            Assert.False(empty);
        }
    }
}