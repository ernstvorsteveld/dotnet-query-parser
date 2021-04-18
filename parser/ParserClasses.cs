using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace query_parser
{
    public interface Expression
    { 
        public string getName();
    }

    public enum BooleanOperator
    {
        AND,
        OR
    }

    public enum Operation
    {
        EQ,
        LT,
        LTE,
        GT,
        GTE,
        NE,
        CO
    }
    public class SimpleExpression : Expression
    {
        public String Name { get; set; }
        public Operation Operation { get; set; }
        public String Value { get; set; }

        public SimpleExpression(String name, Operation operation, String value)
        {
            Name = name;
            Operation = operation;
            Value = value;
        }
        public String GetExpression()
        {
            return Name + ", " + Operation + ", " + Value;
        }
        public FilterDefinition<BsonDocument> getFilter()
        {
            return Builders<BsonDocument>.Filter.Eq(Name, Value);
        }
        public string getName()
        {
            return "SimpleExpression";
        }
    }
    public class BetweenExpression : Expression
    {
        public String Name;
        public String From;
        public String To;

        public BetweenExpression(String name, String from, String to)
        {
            Name = name;
            From = from;
            To = to;
        }
        public string getName()
        {
            return "BetweenExpression";
        }
    }

    public class BooleanExpression : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }
        public BooleanOperator BooleanOperator { get; set; }

        public BooleanExpression(BooleanOperator booleanOperator, Expression left, Expression right)
        {
            Left = left;
            Right = right;
            BooleanOperator = booleanOperator;
        }
        public string getName()
        {
            return "BooleanExpression";
        }

    }
}