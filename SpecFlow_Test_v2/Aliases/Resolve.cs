
namespace SpecFlow_Test_v2.Aliases
{
    public static class Resolve
    {
        public static string[] AsStringArr(this Table table, string column)
        {
            return table.Rows.Select(row => row[column]).ToArray();
        }

    }
}
