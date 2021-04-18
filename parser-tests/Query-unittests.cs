using Microsoft.VisualStudio.TestTools.UnitTesting;
using query_parser;

namespace query_tests
{
    [TestClass]
    public class QueryTests
    {
        private ParserExecutor parserExecutor = new ParserExecutor();

        [TestMethod]
        public void should_parse_simple_expression()
        {
            SimpleExpression fieldExpression =
                (SimpleExpression)parserExecutor.Parse("partner_id EQ 10").Expression;
            Assert.AreEqual("partner_id", fieldExpression.Name);
            Assert.AreEqual(Operation.EQ, fieldExpression.Operation);
            Assert.AreEqual("10", fieldExpression.Value);

            fieldExpression =
                (SimpleExpression)parserExecutor.Parse("supplier_id EQ bok").Expression;
            Assert.AreEqual("supplier_id", fieldExpression.Name);
            Assert.AreEqual(Operation.EQ, fieldExpression.Operation);
            Assert.AreEqual("bok", fieldExpression.Value);
        }

        [TestMethod]
        public void should_parse_and_expression()
        {
            BooleanExpression booleanExpression =
                (BooleanExpression)parserExecutor.Parse("partner_id EQ 10 AND supplier_id EQ 20").Expression;
            Assert.AreEqual(BooleanOperator.AND, booleanExpression.BooleanOperator);
            SimpleExpression left = (SimpleExpression)booleanExpression.Left;
            Assert.AreEqual("partner_id", left.Name);
            Assert.AreEqual(Operation.EQ, left.Operation);
            Assert.AreEqual("10", left.Value);

            SimpleExpression right = (SimpleExpression)booleanExpression.Right;
            Assert.AreEqual("supplier_id", right.Name);
            Assert.AreEqual(Operation.EQ, right.Operation);
            Assert.AreEqual("20", right.Value);
        }

        [TestMethod]
        public void should_parse_query()
        {
            Query query = parserExecutor.Parse("partner_id EQ 10 AND supplier_id EQ 20");
            BooleanExpression booleanExpression = (BooleanExpression)query.Expression;
            Assert.AreEqual(BooleanOperator.AND, booleanExpression.BooleanOperator);            
            SimpleExpression left = (SimpleExpression)booleanExpression.Left;
            Assert.AreEqual("partner_id", left.Name);
            Assert.AreEqual(Operation.EQ, left.Operation);
            Assert.AreEqual("10", left.Value);

            SimpleExpression right = (SimpleExpression)((BooleanExpression)query.Expression).Right;
            Assert.AreEqual("supplier_id", right.Name);
            Assert.AreEqual(Operation.EQ, right.Operation);
            Assert.AreEqual("20", right.Value);
        }
    }
}
