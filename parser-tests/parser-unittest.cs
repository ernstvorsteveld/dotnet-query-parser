using Microsoft.VisualStudio.TestTools.UnitTesting;
using query_parser;


namespace query_parser_tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void should_create_field_expression()
        {
            string attributeName = "partner_id";
            Operation operation = Operation.EQ;
            string value = "10";
            FieldExpression fieldExpression = new FieldExpression(attributeName, operation, value);
            Assert.AreEqual(attributeName, fieldExpression.Name);
            Assert.AreEqual(operation, fieldExpression.Operation);
            Assert.AreEqual(value, fieldExpression.Value);
        }

        [TestMethod]
        public void should_create_between_expression() {
            string attributeName = "sign_date";
            string from = "01012021";
            string to = "01032021";
            BetweenExpression betweenExpression = new BetweenExpression(attributeName, from, to);
            Assert.AreEqual(attributeName, betweenExpression.Name);
            Assert.AreEqual(from, betweenExpression.From);
            Assert.AreEqual(to, betweenExpression.To);
        }
    }
}
