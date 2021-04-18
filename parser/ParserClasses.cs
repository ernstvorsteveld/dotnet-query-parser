using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace query_parser
{

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
    public class FieldExpression
    {
        public String Name { get; set; }
        public Operation Operation { get; set; }
        public String Value { get; set; }

        public FieldExpression(String name, Operation operation, String value)
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

    }

    public class BetweenExpression
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
    }

    public class AndExpression
    {
        public FieldExpression Left { get; set; }
        public FieldExpression Right { get; set; }

        public AndExpression(FieldExpression left, FieldExpression right)
        {
            Left = left;
            Right = right;
        }

    }
}