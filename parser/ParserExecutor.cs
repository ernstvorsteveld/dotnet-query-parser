using Sprache;

namespace query_parser
{
    public class ParserExecutor
    {
        public Query Parse(string queryString) {
            return QueryParser.Query.Parse(queryString);
        }
    }
}