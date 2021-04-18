using System;
using System.Linq;
using Sprache;

namespace query_parser
{
    public class QueryParser
    {
        public static Parser<string> StartBracket = Parse.Char('(').Once().Text().Token();
        public static Parser<string> EndBracket = Parse.Char(')').Once().Text().Token();
        public static Parser<string> Value = Parse.CharExcept(" ,())").Many().Text().Token();
        public static Parser<string> Identifier = Parse.CharExcept(" ,())").Many().Text().Token();
        public static Parser<Operation> OperationToken = Parse.String("EQ").Once().Return(Operation.EQ);
        public static Parser<BooleanOperator> BooleanOperatorToken = Parse.String("AND").Once().Return(BooleanOperator.AND).Or(Parse.String("OR").Once().Return(BooleanOperator.OR));
        public static Parser<string> CommaToken = Parse.Char(',').Once().Text().Token();
        public static Parser<string> BetweenToken = Parse.String("BETWEEN").Once().Return("BETWEEN");
        public static Parser<Expression> Expression =
            (from name in Identifier
             from between in BetweenToken
             from startBracket in StartBracket
             from left in Value
             from commaToken in CommaToken
             from right in Value
             from endBracket in EndBracket
             select (Expression)new BetweenExpression(name, left, right))
            .Or
            (from name in Identifier
             from operation in OperationToken
             from value in Value
             select new SimpleExpression(name, operation, value));

        public static Parser<BooleanExpression> BooleanExpression = 
            (from left in Expression
             from booleanOperatorToken in BooleanOperatorToken
             from right in Expression
             select new BooleanExpression(booleanOperatorToken, left, right));

        public static Parser<Query> Query =
            (from booleanExpression in BooleanExpression
             select new Query(booleanExpression)
            )
            .Or
            (from expression in Expression
             select new Query(expression)
            );
    }
}