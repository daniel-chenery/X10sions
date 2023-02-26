using System.Linq.Expressions;

namespace X10sions.Tests.ExpressionExtensions;

public class InvertTests
{
    [Fact]
    public void Invert_WhenNull_ThrowsArgumentException()
    {
        // Act
        var act = () => default(Expression<Func<bool>>).Invert();

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("expression", exception.ParamName);
    }

    [Fact]
    public void Invert_WhenFalse_ReturnsTrue()
    {
        // Arrange
        Expression<Func<bool>> expression = () => false;

        // Act
        var inverted = expression.Invert();

        // Assert
        Assert.True(inverted.Compile()());
    }

    [Fact]
    public void Invert_WhenTrue_ReturnsFalse()
    {
        // Arrange
        Expression<Func<bool>> expression = () => true;

        // Act
        var inverted = expression.Invert();

        // Assert
        Assert.False(inverted.Compile()());
    }
}