using System;
using System.Linq.Expressions;

namespace X10sions
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Inverts the current expression
        /// </summary>
        /// <param name="expression">The expression to negate</param>
        /// <returns>A new expression, which is the negated version of the current expression</returns>
        /// <include file='ExpressionExtensions.xml' path='common'/>
        public static Expression<Func<bool>> Invert(this Expression<Func<bool>> expression)
        {
            return (Expression<Func<bool>>)InvertInternal(expression);
        }

        /// <summary>
        /// Inverts the current expression
        /// </summary>
        /// <param name="expression">The expression to negate</param>
        /// <returns>A new expression, which is the negated version of the current expression</returns>
        /// <include file='ExpressionExtensions.xml' path='common'/>
        public static Expression<Func<T, bool>> Invert<T>(this Expression<Func<T, bool>> expression)
        {
            return (Expression<Func<T, bool>>)InvertInternal(expression);
        }

        private static Expression InvertInternal(LambdaExpression expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var negated = Expression.Not(expression.Body);

            return Expression.Lambda(negated, expression.Parameters);
        }
    }
}