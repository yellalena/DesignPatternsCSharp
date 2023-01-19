namespace BuilderPattern
{
    public interface IQueryBuilder
    {
        public IQueryBuilder Select(string tableName, string[] fields);
        public IQueryBuilder WhereEquals(string fieldName, string value);
        public IQueryBuilder Limit(int limit);

        public string GetQueryString();
    }
}
