using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BD_ITOG
{
    public class Readers : DefultForm
    {
        public Readers() : base(EReaders.HeadDataGrid)
        {
            for (int i = 0; i < 4; i++)
                TextAndComboBox.Add(InicialItem.TextBox());
            TextAndComboBox.Add(new ComboBox());
            commandMaxId = "SELECT Max(id_Lk) From InSy.dbo.LibraryCard";
            var button = InicialItem.Button("Подробнее");
            button.Click += (sender, args) => new Abonement(currentId, aboutCurrent).ShowDialog();
            Buttons.Add(button);
            AddControls();
        }

        internal override void Form_Load(object sender, EventArgs e)
        {
            dataGrid.Location = new Point(10, 10);

            string readers = @"SELECT id_Lk, fullName, dateBirth, phoneNumber, homeAdres, fk_dir, name
	                            from InSy.dbo.LibraryCard
	                            join InSy.dbo.Directions on fk_dir = id_napr";

            itemsInDateGrid = SQL
                .ReadSql(readers)
                .Select(x => (IEitem)
                new EReaders(int.Parse(x[0]), x[1], DateTime.Parse(x[2]), x[3], x[4], int.Parse(x[5]), x[6]))
                .ToList();
            FillingDatagrid(itemsInDateGrid);
            FillingComboBox(forSave);
        }

        internal override void FillingComboBox(List<List<IComboBoxItem>> xx)
        {
            foreach (var item in TextAndComboBox)
            {
                if (item is ComboBox comboBox)
                {
                    xx.Add(new List<IComboBoxItem>());
                    FillBooksDirections(comboBox, xx[0]);
                }
            }
        }

        private void FillBooksDirections(ComboBox comboBox, List<IComboBoxItem> comboBoxItems)
        {
            string command = @"SELECT id_napr, name
                                From InSy.dbo.Directions";
            foreach (var item in SQL.ReadSql(command))
            {
                comboBoxItems.Add(new ComboBoxItemAuthor(int.Parse(item[0]), item[1]));
                comboBox.Items.Add(item[1]);
            }
        }

        internal override IEitem NewIEitem()
        {
            var outt = GetValuesFromTextAndComboBox();
            return new EReaders(int.Parse(outt[0]), outt[1], DateTime.Parse(outt[2]), outt[3], outt[4], int.Parse(outt[5]), outt[6]);
        }
    }
}
