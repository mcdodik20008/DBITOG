using System;
using System.Collections.Generic;

namespace BD_ITOG
{
    public class EAbonement : IEitem
    {
        public int Pk;
        public int FkLk;
        public int FkBook;
        public string NameBook;
        public int FkAuthor;
        public string NameAuthor;
        public int FkV;
        public string NameV;
        public DateTime DateV;
        public int? FkS;
        public string NameS;
        public DateTime? DateS;

        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "id_zap", "fk_libcard", "fk_b", "Книга", "fk_author", "Автор", "fk_v", "Выдал", "Дата выдачи", "fk_s", "Принял", "Дата сдачи" },
            new List<bool> { false, false, false, true, false, true, false, true, true, false, true, true },
            new List<string> { "id_zap", "fk_libCard", "fk_book", "", "", "", "fk_whoV", "", "dateV", "fk_whoS", "", "dateS"},
            "InSy.dbo.Subscription");


        public EAbonement(int pk, int fkLk, int fkBook, string nameBook, int fkAuthor, string nameAuthor, 
            int fkV, string nameV, DateTime dateV, int? fkS, string nameS, DateTime? dateS)
        {
            Pk = pk;
            FkLk = fkLk;
            FkBook = fkBook;
            NameBook = nameBook;
            FkAuthor = fkAuthor;
            NameAuthor = nameAuthor;
            FkV = fkV;
            NameV = nameV;
            DateV = dateV;
            FkS = fkS;
            NameS = nameS;
            DateS = dateS;
        }

        public List<string> GetValueForDataGrid()
        {
            return new List<string>() { Pk.ToString(), FkLk.ToString(), FkBook.ToString(), NameBook,
                FkAuthor.ToString(), NameAuthor, FkV.ToString(), NameV, DateV.ToShortDateString(), 
                FkS != null ? FkS.ToString() : null, 
                NameS, 
                DateS != null ? DateS.ToString().Substring(0, 12) : null };
        }

        public HeadDataGrid GetHead() { return HeadDataGrid; }

        public string GetValueForSql() { return $"{FkLk}, {FkBook}, {FkV}, {DateV}, {FkS}, {DateS}"; }

        public List<string> GetListValForSql()
        {
            return new List<string>() { $"{FkLk}", $"{FkBook}", $"{FkV}", $"'{DateV}'", $"'{(FkS != null ? FkS.ToString() : null)}'", 
                $"'{(DateS != null ? DateS.ToString().Substring(0, 12) : null)}'"};
        }
    }
}
