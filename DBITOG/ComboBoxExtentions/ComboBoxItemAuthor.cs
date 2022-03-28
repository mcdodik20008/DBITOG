namespace BD_ITOG
{
    public class ComboBoxItemAuthor : IComboBoxItem
    {
        int Pk;
        string Name;

        public ComboBoxItemAuthor(int pk, string name)
        {
            Pk = pk;
            Name = name;
        }

        public string[] GetValue()
        {
            return new[] { Pk.ToString(), Name };
        }
    }
}
