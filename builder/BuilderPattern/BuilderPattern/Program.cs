using BuilderPattern;

class Builder
{
    public static void Main()
    {
        SqlQueryBuilder sqlQueryBuilder1 = new("TestDatabase");

        sqlQueryBuilder1
                .Select("User", new string[] { "name", "bday", "city" })
                .WhereEquals("city", "London")
                .Limit(15);

        Console.WriteLine(sqlQueryBuilder1.GetQueryString());

        SqlQueryBuilder sqlQueryBuilder2 = new("TestDatabase");

        sqlQueryBuilder2
                .Select("User", new string[] { "name" })
                .Limit(1);

        Console.WriteLine(sqlQueryBuilder2.GetQueryString());
    }
}