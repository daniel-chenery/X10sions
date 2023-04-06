namespace X10sions.Tests.EnumerableExtensions;
public class FuseT3Tests
{
    [Fact]
    public void Fuse_WhenFirstEnumerableNull_ThrowsArgumentNullException()
    {
        // Arrange
        var enumerable = default(IEnumerable<object>);

        // Act
        var act = () => enumerable.Fuse(default(IEnumerable<object>), default(IEnumerable<object>)).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(() => act());
        Assert.Equal("first", exception.ParamName);
    }

    [Fact]
    public void Fuse_WhenSecondEnumerableNull_ThrowsArgumentNullException()
    {
        // Arrange
        var enumerable = Enumerable.Empty<object>();

        // Act
        var act = () => enumerable.Fuse(default(IEnumerable<object>), default(IEnumerable<object>)).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(() => act());
        Assert.Equal("second", exception.ParamName);
    }

    [Fact]
    public void Fuse_WhenThirdEnumerableNull_ThrowsArgumentNullException()
    {
        // Arrange
        var enumerable = Enumerable.Empty<object>();

        // Act
        var act = () => enumerable.Fuse(Enumerable.Empty<object>(), default(IEnumerable<object>)).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(() => act());
        Assert.Equal("third", exception.ParamName);
    }

    [Fact]
    public void Fuse_WhenFirstEnumerableIsSmaller_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var first = Enumerable.Repeat("Hello World", 1);
        var second = Enumerable.Repeat("Hello World", 2);
        var third = Enumerable.Repeat("Hello World", 2);

        // Act
        var act = () => first.Fuse(second, third).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => act());
        Assert.Equal("first", exception.ParamName);
    }

    [Fact]
    public void Fuse_WhenSecondEnumerableIsSmaller_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var first = Enumerable.Repeat("Hello World", 2);
        var second = Enumerable.Repeat("Hello World", 1);
        var third = Enumerable.Repeat("Hello World", 2);

        // Act
        var act = () => first.Fuse(second, third).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => act());
        Assert.Equal("second", exception.ParamName);
    }

    [Fact]
    public void Fuse_WhenThirdEnumerableIsSmaller_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var first = Enumerable.Repeat("Hello World", 2);
        var second = Enumerable.Repeat("Hello World", 2);
        var third = Enumerable.Repeat("Hello World", 1);

        // Act
        var act = () => first.Fuse(second, third).ToList();

        // Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => act());
        Assert.Equal("third", exception.ParamName);
    }

    [Fact]
    public void Fuse_WhenEnumerablesEqualLength_ReturnsTupleOfThreeEnumerableValues()
    {
        // Arrange
        var first = new[] { 'a', 'b', 'c', 'd' };
        var second = new[] { 1, 2, 3, 4 };
        var third = new[] { "alpha", "beta", "gamma", "delta" };

        // Act
        var combined = first.Fuse(second, third).ToList();

        // Assert
        Assert.Equal('a', combined[0].Item1);
        Assert.Equal(1, combined[0].Item2);
        Assert.Same("alpha", combined[0].Item3);

        Assert.Equal('b', combined[1].Item1);
        Assert.Equal(2, combined[1].Item2);
        Assert.Same("beta", combined[1].Item3);

        Assert.Equal('c', combined[2].Item1);
        Assert.Equal(3, combined[2].Item2);
        Assert.Same("gamma", combined[2].Item3);

        Assert.Equal('d', combined[3].Item1);
        Assert.Equal(4, combined[3].Item2);
        Assert.Same("delta", combined[3].Item3);
    }
}
