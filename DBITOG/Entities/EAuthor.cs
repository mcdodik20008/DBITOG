﻿using System;
using System.Collections.Generic;

namespace BD_ITOG
{
    public class EAuthor : IEitem
    {        
        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "id_Author", "ФИО", "Дата рождения" },
            new List<bool> { false, true, true },
            new List<string> { "id_Author", "fullNameAuthor", "dateBirth" }
            );

        public int PK;
        public string FIO;
        public DateTime DateBirth;
        public bool isGood = true;

        public EAuthor() => isGood = false;

        public EAuthor(int pK, string fIO, DateTime dateBirth)
        {
            PK = pK;
            FIO = fIO;
            DateBirth = dateBirth;
        }

        public string GetNameTable() => "InSy.dbo.Author";

        public List<string> GetListValForDataGrid() => new List<string>() { PK.ToString(), FIO, DateBirth.ToShortDateString() };

        public HeadDataGrid GetHeadDataGrid() => HeadDataGrid;

        public string GetValueForSql() => $"'{FIO}', '{DateBirth.ToShortDateString()}'";

        public List<string> GetListValForSql() => new List<string>() { $"'{FIO}'", $"'{DateBirth.ToShortDateString()}'" };

        public bool IsGood() => isGood;
    }
}
