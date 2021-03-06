using System;
using Gtk;

namespace gtkmine
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			uint rows = 5;
			uint columns = 5;
			uint spacing = 2;
			Application.Init ();
			Window win = new Window ("Minesweeper");
			var table = new global::Gtk.Table (rows, columns, false);
			table.RowSpacing = (spacing);
			table.ColumnSpacing = (spacing);
			for (uint row = 0; row < rows; row++) {
				for (uint column = 0; column < columns; column++) {
					var button = new Button();

					button.CanFocus = true;
					button.Label = (string.Empty.PadLeft(5));
					button.Clicked += new EventHandler(OnButtonClicked);
					table.Attach(button, row, row+1,column, column+1);
				}
			}
			table.ShowAll();
			win.Add(table);
			win.Show ();
			Application.Run ();
		}

		static void OnButtonClicked (object sender, EventArgs e)
		{
		}

	}
}
