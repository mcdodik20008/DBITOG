using System.Collections.Generic;
using System.Windows.Forms;


namespace BD_ITOG
{
    public class Сancel : ICommand
    {
        List<string> values = new List<string>();
        List<Control> TextAndCb;
        
        public Сancel(List<Control> textAndCb)
        {
            TextAndCb = textAndCb;
        }

        public void Command(DataGridView x)
        {
            for (int i = 0; i < TextAndCb.Count; i++)
            {
                if (TextAndCb[i] is TextBox tb)
                {
                    values.Add(tb.Text);
                    tb.Clear();
                    continue;
                }
                if (TextAndCb[i] is ComboBox cb)
                {
                    values.Add(cb.SelectedIndex.ToString());
                    cb.Text = "";
                    continue;
                }
            }
        }

        public void UnCommand(DataGridView x)
        {
            for (int i = 0; i < TextAndCb.Count; i++)
            {
                if (TextAndCb[i] is TextBox tb)
                {
                    tb.Text = values[i];
                    continue;
                }
                if (TextAndCb[i] is ComboBox cb)
                {
                    cb.SelectedItem = int.Parse(values[i]);
                    cb.Text = cb.SelectedItem.ToString();
                    continue;
                }
            }
        }

        public void SqveInSql() { }
    }
}
