namespace X10sions.Tests.BooleanExtensions;

public class InvertTests
{
    [Fact]
    public void Invert_WhenFalse_ReturnsTrue()
    {
        // Arrange
        var input = true;

        // Act
        var result = input.Invert();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Invert_WhenTrue_ReturnsFalse()
    {
        // Arrange
        var input = false;

        // Act
        var result = input.Invert();

        // Assert
        Assert.True(result);
    }
}