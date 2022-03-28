using System.Collections.Generic;

namespace BD_ITOG
{
    //якобы сущности Базы данных с "Удобными" методами для получения данных
    public interface IEitem
    {
        HeadDataGrid GetHead();
        List<string> GetValueForDataGrid();
        string GetValueForSql();
        List<string> GetListValForSql();
        string GetNameTable();
    }
}
