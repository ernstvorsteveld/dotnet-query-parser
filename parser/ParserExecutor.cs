using Sprache;

namespace query_parser
{
    public class ParserExecutor
    {
        public SimpleExpression getBySimpleExpression(string queryString){
            return QueryParser.Expression.Parse(queryString);
        }

        public AndExpression getByAndExpression(string queryString) {
            return QueryParser.AndExpression.Parse(queryString);
        }

        public Query getByQuery(string queryString) {
            return QueryParser.Query.Parse(queryString);
        }
    }
}