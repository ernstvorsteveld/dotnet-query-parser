using Microsoft.VisualStudio.TestTools.UnitTesting;
using query_parser;

namespace query_tests
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void should_parse_field_expression()
        {
            SimpleExpression fieldExpression = new ParserExecutor().getBySimpleExpression("partner_id EQ 10");
            Assert.AreEqual("partner_id", fieldExpression.Name);
            Assert.AreEqual(Operation.EQ, fieldExpression.Operation);
            Assert.AreEqual("10", fieldExpression.Value);

            fieldExpression = new ParserExecutor().getBySimpleExpression("supplier_id EQ bok");
            Assert.AreEqual("supplier_id", fieldExpression.Name);
            Assert.AreEqual(Operation.EQ, fieldExpression.Operation);
            Assert.AreEqual("bok", fieldExpression.Value);
        }

        [TestMethod]
        public void should_parse_and_expression()
        {
            AndExpression andExpression = new ParserExecutor().getByAndExpression("partner_id EQ 10 AND supplier_id EQ 20");
            SimpleExpression left = (SimpleExpression) andExpression.Left;
            Assert.AreEqual("partner_id", left.Name);
            Assert.AreEqual(Operation.EQ, left.Operation);
            Assert.AreEqual("10", left.Value);

            SimpleExpression right = (SimpleExpression) andExpression.Right;
            Assert.AreEqual("supplier_id", right.Name);
            Assert.AreEqual(Operation.EQ, right.Operation);
            Assert.AreEqual("20", right.Value);
        }

        [TestMethod]
        public void should_parse_query()
        {
            Query query = new ParserExecutor().getByQuery("partner_id EQ 10 AND supplier_id EQ 20");
            SimpleExpression left = (SimpleExpression) query.AndExpression.Left;
            Assert.AreEqual("partner_id", left.Name);
            Assert.AreEqual(Operation.EQ, left.Operation);
            Assert.AreEqual("10", left.Value);

            SimpleExpression right = (SimpleExpression) query.AndExpression.Right;
            Assert.AreEqual("supplier_id", right.Name);
            Assert.AreEqual(Operation.EQ, right.Operation);
            Assert.AreEqual("20", right.Value);
        }
    }
}
