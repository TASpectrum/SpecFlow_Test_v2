using TechTalk.SpecFlow;
using SpecFlow_Test_v2.Aliases;

namespace SpecFlow_Test_v2.Aliases
{
    public static class Resolve
    {
        private static string[] AsStringArr(this Table table, string column)
        {
            return table.Rows.Select(row => row[column]).ToArray();
        }

        public static void AuthData (Table table, out string[] username, out string[] password)
        {
            username = table.AsStringArr(PageObjAlias.tableAsStringUser);
            password = table.AsStringArr(PageObjAlias.tableAsStringPassord);
            return;
        }

    }
}
