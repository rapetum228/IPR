using IPR.ExpressionTree.Visitors;
using System.Collections.Generic;
using System.Linq.Expressions;

Expression<Func<int, int>> add = (a) => 1 + a + 3 + 4;


foreach (var argumentExpression in add.Parameters)
{
    var visitor = Visitor.CreateFromExpression(argumentExpression);
    visitor.Visit(argumentExpression.Type.ToString());
}

Console.ReadLine();