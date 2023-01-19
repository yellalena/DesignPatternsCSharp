namespace BuilderPattern
{
    public class SqlQueryBuilder : IQueryBuilder
    {
        protected Query query;
        public SqlQueryBuilder(string databaseName)
        {
            query = new(databaseName);
        }

        public IQueryBuilder Select(string tableName, string[] fields) 
        {
            query.AddSelectClause(tableName, fields);
            return this;
        }

        public IQueryBuilder WhereEquals(string fieldName, string value)
        {
            query.AddWhereEqualsClause(fieldName, value);
            return this;
        }

        public IQueryBuilder Limit(int limit)
        {
            query.AddLimitClause(limit);    
            return this;
        }

        public string GetQueryString() 
        {
            return query.ToString();
        }
    }
}
