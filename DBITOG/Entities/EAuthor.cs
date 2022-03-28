using System;
using System.Collections.Generic;

namespace BD_ITOG
{
    public class EAuthor : IEitem
    {
        public int PK;
        public string FIO;
        public DateTime DateBirth;
        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "id_Author", "ФИО", "Дата рождения" },
            new List<bool> { false, true, true },
            new List<string> { "id_Author", "fullNameAuthor", "dateBirth" }
            );
        public string GetNameTable() => "InSy.dbo.Author";

        public EAuthor(int pK, string fIO, DateTime dateBirth)
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
