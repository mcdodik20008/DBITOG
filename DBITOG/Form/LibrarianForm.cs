using System;
using System.Collections.Generic;
using System.Linq;

namespace BD_ITOG
{
    public class LibrarianForm : DefultForm
    {
        static HeadDataGrid inBaseConstructor = ELibrarian.HeadDataGrid;
        public LibrarianForm() : base(inBaseConstructor)
        {
            TextAndComboBox.Add(InicialItem.TextBox());
            TextAndComboBox.Add(InicialItem.TextBox());

            commandMaxId = "SELECT MAx(id_Librarian) From InSy.dbo.Librarian";

            AddControls();
        }

        internal override void Form_Load(object sender, EventArgs e)
        {
            itemsInDateGrid = SQL
                .ReadSql(@"select * from InSy.dbo.Librarian")
                .Select(x => (IEitem)new ELibrarian(int.Parse(x[0]), x[1], DateTime.Parse(x[2])))
                .ToList();
            FillingDatagrid(itemsInDateGrid);
        }

        internal override void FillingComboBox(List<List<IComboBoxItem>> xx) { }

        internal override IEitem NewIEitem()
        {
            var outt = GetValuesFromTextAndComboBox();
            return new ELibrarian(int.Parse(outt[0]), outt[1], DateTime.Parse(outt[2]));
        }
    }
}
