using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace query_parser {

    public class Query {

        public FieldExpression FieldExpression { get; set; }
        public AndExpression AndExpression { get; set; }

        public Query(AndExpression andExpression) {
            this.AndExpression = andExpression;
        }
        public Query(FieldExpression fieldExpression) {
            this.FieldExpression  = fieldExpression;
        }

    }
}