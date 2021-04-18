using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace query_parser {

    public class Query {

        public Expression Expression { get; set; }

        public Query(Expression expression) {
            this.Expression = expression;
        }
    }
}