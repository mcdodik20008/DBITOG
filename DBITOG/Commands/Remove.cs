using System.Collections.Generic;
using System.Windows.Forms;

namespace BD_ITOG
{
    public class Remove : ICommand
    {
        private int position;
        private List<string> values;
        private HeadDataGrid head;
        public Remove(DataGridView value, int pos, HeadDataGrid head)
        {
            values = new List<string>();
            foreach (DataGridViewCell cell in value.Rows[pos].Cells)
            {
                values.Add(cell.Value.ToString());
            }
            position = pos;
            this.head = head;
        }

        public void Command(DataGridView dataGrid)
        {
            dataGrid.Rows.RemoveAt(position);
        }

        public void UnCommand(DataGridView dataGrid)
        {
            dataGrid.Rows.Insert(position, values.ToArray());
        }

        public void SqveInSql()
        {
            string command = $"DELETE FROM {head.NameTable} WHERE {head.NameInSql[0]} = {values[0]}";
            SQL.InteractingSql(command);
        }
    }
}
