namespace X10sions.Tests.EnumerableExtensions;
public class CombineTests
{
    [Fact]
    public void Combine_WhenFirstEnumerableNull_ThrowsArgumentNullException()
    {
        // Arrange
        var enumerable = default(IEnumerable<object>);

        // Act
        var act = () => enumerable.Combine(default(IEnumerable<object>)).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(() => act());
        Assert.Equal("first", exception.ParamName);
    }

    [Fact]
    public void Combine_WhenSecondEnumerableNull_ThrowsArgumentNullException()
    {
        // Arrange
        var enumerable = Enumerable.Empty<object>();

        // Act
        var act = () => enumerable.Combine(default(IEnumerable<object>)).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(() => act());
        Assert.Equal("second", exception.ParamName);
    }

    [Fact]
    public void Combine_WhenFirstEnumerableIsSmaller_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var first = Enumerable.Repeat("Hello World", 1);
        var second = Enumerable.Repeat("Hello World", 2);

        // Act
        var act = () => first.Combine(second).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => act());
        Assert.Equal("first", exception.ParamName);
    }

    [Fact]
    public void Combine_WhenSecondEnumerableIsSmaller_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var first = Enumerable.Repeat("Hello World", 2);
        var second = Enumerable.Repeat("Hello World", 1);

        // Act
        var act = () => first.Combine(second).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => act());
        Assert.Equal("second", exception.ParamName);
    }

    [Fact]
    public void Combine_WhenEnumerablesEqualLength_ReturnsTupleOfBothEnumerableValues()
    {
        // Arrange
        var first = new[] { "Hello", "World" };
        var second = new[] { "Howdy", "Y'all" };

        // Act
        var combined = first.Combine(second).ToList();

        // Assert
        Assert.Equal("Hello", combined[0].Item1);
        Assert.Equal("Howdy", combined[0].Item2);
        Assert.Equal("World", combined[1].Item1);
        Assert.Equal("Y'all", combined[1].Item2);
    }
}
