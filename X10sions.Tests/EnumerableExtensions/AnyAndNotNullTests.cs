namespace X10sions.Tests.EnumerableExtensions
{
    public class AnyAndNotNullTests
    {
        [Fact]
        public void AnyAndNotNull_WhenNull_ReturnsFalse()
        {
            // Arrange
            var enumerable = default(IEnumerable<object>);

            // Act
            var any = enumerable.AnyAndNotNull();

            // Assert
            Assert.False(any);
        }

        [Fact]
        public void AnyAndNotNull_WhenEmpty_ReturnsFalse()
        {
            // Arrange
            var enumerable = Enumerable.Empty<object>();

            // Act
            var any = enumerable.AnyAndNotNull();

            // Assert
            Assert.False(any);
        }

        [Fact]
        public void AnyAndNotNull_WhenPopulated_ReturnsTrue()
        {
            // Arrange
            var enumerable = Enumerable.Repeat(default(object), 10);

            // Act
            var any = enumerable.AnyAndNotNull();

            // Assert
            Assert.True(any);
        }
    }
}