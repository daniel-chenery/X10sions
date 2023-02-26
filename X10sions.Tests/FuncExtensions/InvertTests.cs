namespace X10sions.Tests.FuncExtensions
{
    public class InvertTests
    {
        [Fact]
        public void Invert_WhenNull_ThrowsArgumentException()
        {
            // Act
            var act = () => default(Func<bool>).Invert();

            // Assert
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("func", exception.ParamName);
        }

        [Fact]
        public void Invert_WhenFalse_ReturnsTrue()
        {
            // Arrange
            Func<bool> func = () => false;

            // Act
            var inverted = func.Invert();

            // Assert
            Assert.True(inverted());
        }

        [Fact]
        public void Invert_WhenTrue_ReturnsFalse()
        {
            // Arrange
            Func<bool> func = () => true;

            // Act
            var inverted = func.Invert();

            // Assert
            Assert.False(inverted());
        }
    }
}