using System.Text;

namespace BuilderPattern
{
    public class Query
    {
        private readonly string useDatabaseQuery;

        private string selectFromQuery;
        private string whereEqualsQuery;
        private string limitQuery;

        public Query(string databaseName) {
            useDatabaseQuery = $"use database {databaseName};";
        }

        public void AddSelectClause(string tableName, string[] fields)
        {
            selectFromQuery = $"select {string.Join(", ", fields)} from {tableName}";
        }

        public void AddWhereEqualsClause(string fieldName, string value)
        {
            whereEqualsQuery = $" where {fieldName}={value}";
        }

        public void AddLimitClause(int limitValue)
        {
            limitQuery = $" limit {limitValue}";
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(useDatabaseQuery);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(selectFromQuery);
            stringBuilder.Append(whereEqualsQuery ?? "");
            stringBuilder.Append(limitQuery ?? "");
            return stringBuilder.ToString();
        }
    }
}
