using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace query_parser
{
    public class QueryParser
    {
        public static Parser<string> StartBracket = Parse.Char('(').Once().Text().Token();
        public static Parser<string> EndBracket = Parse.Char(')').Once().Text().Token();
        public static Parser<string> Value = Parse.CharExcept(" ,):").Many().Text().Token();
        public static Parser<string> Identifier = Parse.CharExcept(" ,):").Many().Text().Token();
        public static Parser<string> Operation = Parse.CharExcept(" ").Many().Text().Token();

        public static Parser<string> AndToken = Parse.Chars("AND").Many().Text().Token();
        public static Parser<FieldExpression> Expression = from name in Identifier
                                                           from operation in Operation
                                                           from value in Value
                                                           select new FieldExpression(name, Enum.Parse<Operation>(operation), value);

        public static Parser<AndExpression> AndExpression = from left in Expression
                                                            from andToken in AndToken
                                                            from right in Expression
                                                            select new AndExpression(left, right);
    }
}