using System;
using System.Collections.Generic;

namespace BD_ITOG
{
    public class ELibrarian : IEitem
    {
        public int PK;
        public string FIO;
        public DateTime DateBirth;
        //содержит в себе названия для датагрида, соответственно виден столбец или нет и названия столбцов в скул.
        //пока что туда добавил еще название таблицы, из-за того, что пробегаюсь по всем свойствам ELibrarian и оно мешает
        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "id_lib", "Библиотекарь", "Дата рождения" },
            new List<bool> { false, true, true },
            new List<string> { "id_Librarian", "fullName", "dateBirth" }
           );
        public string GetNameTable() => "InSy.dbo.Librarian";
        public ELibrarian(int pK, string fIO, DateTime dateBirth)
        {
            PK = pK;
            FIO = fIO;
            DateBirth = dateBirth;
        }

        public List<string> GetValueForDataGrid()
        {
            return new List<string>() { PK.ToString(), FIO, DateBirth.ToShortDateString() };
        }

        public HeadDataGrid GetHead()
        {
            return HeadDataGrid;
        }

        public string GetValueForSql()
        {
            return $"'{FIO}', '{DateBirth.ToShortDateString()}'";
        }

        public List<string> GetListValForSql()
        {
            return new List<string>() { $"'{FIO}'", $"'{DateBirth.ToShortDateString()}'" };
        }
    }
}
