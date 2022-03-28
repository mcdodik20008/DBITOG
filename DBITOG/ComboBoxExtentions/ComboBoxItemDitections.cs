﻿namespace BD_ITOG
{
    class ComboBoxItemDitections : IComboBoxItem
    {
        public int Pk;
        public string Name;
        public ComboBoxItemDitections(int pk, string name)
        {
            Pk = pk;
            Name = name;
        }

        public string[] GetValue()
        {
            return new[] { Pk.ToString() };
        }
    }
}
