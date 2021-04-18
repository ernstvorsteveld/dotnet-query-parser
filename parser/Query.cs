using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace query_parser {

    public class Query {

        public FieldExpression field { get; set; }
        public AndExpression AndExpression { get; set; }

        private string QueryString;

        public Query(string query) {
            this.QueryString = query;
        }

        public FieldExpression getByFieldExpression(){
            return QueryParser.Expression.Parse(QueryString);
        }

        public AndExpression getByAndExpression() {
            return QueryParser.AndExpression.Parse(QueryString);
        }
    }
}