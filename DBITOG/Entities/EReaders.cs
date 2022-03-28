
using System;
using System.Collections.Generic;

namespace BD_ITOG
{
    public class EReaders : IEitem
    {
        public int Pk;
        public string FIO;
        public DateTime DateB;
        public string PhoneNumber;
        public string HomeAdres;
        public int FkDir;
        public string Dir;
        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "id_Lk", "ФИО", "Дата рождения", "Телефонный номер", "Домашний адрес", "fkDir", "Направление" },
            new List<bool> { false, true, true, true, true, false, true },
            new List<string> { "id_Lk", "fullName", "dateBirth", "phoneNumber", "homeAdres", "fk_dir", ""},
            "InSy.dbo.LibraryCard");

        public EReaders(int pk, string fIO, DateTime dateB, string phoneNumber, string hAdres, int fkDir, string dir)
        {
            Pk = pk;
            FIO = fIO;
            DateB = dateB;
            PhoneNumber = phoneNumber;
            HomeAdres = hAdres;
            FkDir = fkDir;
            Dir = dir;
        }

        public List<string> GetValueForDataGrid()
        {
            return new List<string>() { Pk.ToString(), FIO, DateB.ToShortDateString(), PhoneNumber, HomeAdres, FkDir.ToString(), Dir };
        }

        public HeadDataGrid GetHead()
        {
            return HeadDataGrid;
        }

        public string GetValueForSql()
        {
            return $"'{FIO}', '{DateB.ToShortDateString()}', '{PhoneNumber}', '{HomeAdres}', {FkDir}";
        }

        public List<string> GetListValForSql()
        {
            return new List<string>() {$"'{FIO}'", $"'{DateB.ToShortDateString()}'", $"'{PhoneNumber}'", $"'{HomeAdres}'", $"{FkDir}"};
        }
    }
}
