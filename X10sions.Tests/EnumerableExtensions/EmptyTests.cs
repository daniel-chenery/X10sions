namespace X10sions.Tests.EnumerableExtensions
{
    public class EmptyTests
    {
        [Fact]
        public void Empty_WhenNull_ThrowsArgumentNullException()
        {
            // Arrange
            var enumerable = default(IEnumerable<object>);

            // Act
            var act = () => enumerable.Empty();

            // Assert
            var exception = Assert.Throws<ArgumentNullException>(() => act());
            Assert.Equal("enumerable", exception.ParamName);
        }

        [Fact]
        public void Empty_WhenEmpty_ReturnsTrue()
        {
            // Arrange
            var enumerable = Enumerable.Empty<object>();

            // Act
            var empty = enumerable.Empty();

            // Assert
            Assert.True(empty);
        }

        [Fact]
        public void Empty_WhenPopulated_ReturnsFalse()
        {
            // Arrange
            var enumerable = Enumerable.Repeat(default(object), 10);

            // Act
            var empty = enumerable.Empty();

            // Assert
            Assert.False(empty);
        }
    }
}