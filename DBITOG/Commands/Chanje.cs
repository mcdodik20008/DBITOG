using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BD_ITOG
{
    public class Chanje : ICommand
    {
        internal int position;
        internal List<string> oldValues;
        private HeadDataGrid head;
        private IEitem newValues;
        private string nameTable;
        public Chanje(DataGridView value, int pos, IEitem item)
        {
            oldValues = new List<string>();
            foreach (DataGridViewCell cell in value.Rows[pos].Cells)
            {
                if (cell.Value != null)
                    oldValues.Add(cell.Value.ToString());
                else
                    oldValues.Add("");
            }
            position = pos;
            head = item.GetHead();
            newValues = item;
            nameTable = item.GetNameTable();
        }

        public void Command(DataGridView x)
        {
            var values = newValues.GetValueForDataGrid();
            for (int i = 0; i < x.Rows[position].Cells.Count; i++)
                x.Rows[position].Cells[i].Value = values[i];
        }

        public void UnCommand(DataGridView x)
        {
            int i = 0;
            foreach (DataGridViewCell item in x.Rows[position].Cells)
            {
                item.Value = oldValues[i];
                i++;
            }
        }
        public void SqveInSql()
        {
            var index = SQL.maxIndex($"SELECT MAX({head.NameInSql[0]}) FROM {nameTable}") - 1;
            string command;
            if (position >= index)
            { command = $"INSERT INTO {nameTable}({head}) " +
                    $"VALUES ({newValues.GetValueForSql()})";
                SQL.InteractingSql(command);
            } 
            else
            {
                var strBild = new StringBuilder();
                var x = newValues.GetListValForSql();
                for (int i = 1; i < head.NameInSql.FindAll(t => t != "").Count; i++)
                {
                    strBild.Append($"UPDATE {nameTable} SET {head.NameInSql[i]} = {x[i - 1]} WHERE {head.NameInSql[0]} = {newValues.GetValueForDataGrid()[0]}");
                    SQL.InteractingSql(strBild.ToString());
                    strBild.Clear();
                }
            }
        }
    }
}