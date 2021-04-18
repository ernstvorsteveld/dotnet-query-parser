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
            Query query = new Query("partner_id EQ 10");
            FieldExpression fieldExpression = query.getByFieldExpression();
            Assert.AreEqual("partner_id", fieldExpression.Name);
            Assert.AreEqual(Operation.EQ, fieldExpression.Operation);
            Assert.AreEqual("10", fieldExpression.Value);

            query = new Query("supplier_id EQ bok");
            fieldExpression = query.getByFieldExpression();
            Assert.AreEqual("supplier_id", fieldExpression.Name);
            Assert.AreEqual(Operation.EQ, fieldExpression.Operation);
            Assert.AreEqual("bok", fieldExpression.Value);
        }

        [TestMethod]
        public void should_parse_and_expression()
        {
            Query query = new Query("partner_id EQ 10 AND supplier_id EQ 20");
            AndExpression andExpression = query.getByAndExpression();
            Assert.AreEqual("partner_id", andExpression.Left.Name);
            Assert.AreEqual(Operation.EQ, andExpression.Left.Operation);
            Assert.AreEqual("10", andExpression.Left.Value);

            Assert.AreEqual("supplier_id", andExpression.Right.Name);
            Assert.AreEqual(Operation.EQ, andExpression.Right.Operation);
            Assert.AreEqual("20", andExpression.Right.Value);
        }
    }
}
