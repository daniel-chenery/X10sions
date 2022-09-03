﻿using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace X10sions.Tests
{
    public class ExpressionExtensionTests
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

        [Theory]
        [MemberData(nameof(GenericData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Argument required for generic type.")]
        public void InvertT1_WhenNull_ThrowsArgumentException<T>(T? _)
        {
            // Act
            var act = () => default(Expression<Func<T, bool>>).Invert();

            // Assert
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("expression", exception.ParamName);
        }

        [Theory]
        [MemberData(nameof(GenericData))]
        public void InvertT1_WhenFalse_ReturnsTrue<T>(T data)
        {
            // Arrange
            Expression<Func<T, bool>> expression = (input) => !EqualityComparer<T>.Default.Equals(input, data);

            // Act
            var inverted = expression.Invert();

            // Assert
            Assert.True(inverted.Compile()(data));
        }

        [Theory]
        [MemberData(nameof(GenericData))]
        public void InvertT1_WhenTrue_ReturnsFalse<T>(T data)
        {
            // Arrange
            Expression<Func<T, bool>> expression = (input) => EqualityComparer<T>.Default.Equals(input, data);

            // Act
            var inverted = expression.Invert();

            // Assert
            Assert.False(inverted.Compile()(data));
        }

        public static IEnumerable<object?[]> GenericData => new object?[][]
        {
            new object?[]{ null },
            new object[]{ 0 },
            new object[]{ "hello" }
        };
    }
}