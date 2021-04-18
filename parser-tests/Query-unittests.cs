using Microsoft.VisualStudio.TestTools.UnitTesting;
using query_parser;
using System.IO;
using System;
using Sprache;
using MongoDB.Driver;
using MongoDB.Bson;

namespace query_tests
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void should_parse_field_expression()
        {
            FieldExpression fieldExpression = new ParserExecutor().getByFieldExpression("partner_id EQ 10");
            Assert.AreEqual("partner_id", fieldExpression.Name);
            Assert.AreEqual(Operation.EQ, fieldExpression.Operation);
            Assert.AreEqual("10", fieldExpression.Value);

            fieldExpression = new ParserExecutor().getByFieldExpression("supplier_id EQ bok");
            Assert.AreEqual("supplier_id", fieldExpression.Name);
            Assert.AreEqual(Operation.EQ, fieldExpression.Operation);
            Assert.AreEqual("bok", fieldExpression.Value);
        }

        [TestMethod]
        public void should_parse_and_expression()
        {
            AndExpression andExpression = new ParserExecutor().getByAndExpression("partner_id EQ 10 AND supplier_id EQ 20");
            Assert.AreEqual("partner_id", andExpression.Left.Name);
            Assert.AreEqual(Operation.EQ, andExpression.Left.Operation);
            Assert.AreEqual("10", andExpression.Left.Value);

            Assert.AreEqual("supplier_id", andExpression.Right.Name);
            Assert.AreEqual(Operation.EQ, andExpression.Right.Operation);
            Assert.AreEqual("20", andExpression.Right.Value);
        }

        [TestMethod]
        public void should_parse_query()
        {
            Query query = new ParserExecutor().getByQuery("partner_id EQ 10 AND supplier_id EQ 20");
            Assert.AreEqual("partner_id", query.AndExpression.Left.Name);
            Assert.AreEqual(Operation.EQ, query.AndExpression.Left.Operation);
            Assert.AreEqual("10", query.AndExpression.Left.Value);

            Assert.AreEqual("supplier_id", query.AndExpression.Right.Name);
            Assert.AreEqual(Operation.EQ, query.AndExpression.Right.Operation);
            Assert.AreEqual("20", query.AndExpression.Right.Value);
        }
    }
}
