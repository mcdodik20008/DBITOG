using System.Collections.Generic;

namespace BD_ITOG
{
    public class EDirections : IEitem
    {
        public int PK;
        public string Name;
        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "Номер", "Название" },
            new List<bool> { true, true },
            new List<string> { "id_napr", "name" },
            "InSy.dbo.Directions");
        public EDirections(int pK, string name)
        {
            PK = pK;
            Name = name; 
        }

        public List<string> GetValueForDataGrid()
        {
            return new List<string>() { PK.ToString(), Name };
        }

        public HeadDataGrid GetHead()
        {
            return HeadDataGrid;
        }

        public string GetValueForSql()
        {
            return $"'{Name}'";
        }

        public List<string> GetListValForSql()
        {
            return new List<string>() { $"'{Name}'" };
        }
    }
}
