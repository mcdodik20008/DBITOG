using System.Collections.Generic;
using System.Text;

namespace BD_ITOG
{
    public class HeadDataGrid
    {
        public List<string> HeaderTest;
        public List<bool> IsVisible;
        public List<string> NameInSql;
        public string NameTable;
        public HeadDataGrid(List<string> headerTest, List<bool> isVisible, List<string> nameInSql, string nameTable)
        {
            HeaderTest = headerTest;
            IsVisible = isVisible;
            NameInSql = nameInSql;
            NameTable = nameTable;
        }

        public override string ToString()
        {
            var x = new StringBuilder();
            for (int i = 1; i < NameInSql.Count; i++)
            {
                if (NameInSql[i] != "")
                {
                    x.Append(NameInSql[i] + ", ");
                }
            }
            x.Remove(x.Length - 2, 2);
            return x.ToString();
        }
    }
}
