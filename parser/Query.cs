using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace query_parser {

    public class Query {

        public SimpleExpression SimpleExpression { get; set; }
        public AndExpression AndExpression { get; set; }

        public Query(AndExpression andExpression) {
            this.AndExpression = andExpression;
        }
        public Query(SimpleExpression simpleExpression) {
            this.SimpleExpression  = simpleExpression;
        }
    }
}