using System;
using Gtk;

namespace gtkmine
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int rows = 5;
			int columns = 5;
			Application.Init ();
			Window win = new Window ("Minesweeper");
			win.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child MainWindow.Gtk.Container+ContainerChild
			var table = new global::Gtk.Table (((uint)(5)), ((uint)(5)), false);
			table.RowSpacing = ((uint)(6));
			table.ColumnSpacing = ((uint)(6));
			for (uint row = 0; row < rows; row++) {
				for (uint column = 0; column < columns; column++) {
					var button = new Button();
					button.CanFocus = true;
					button.Label = (row + column + row * column).ToString();
					button.Clicked += new EventHandler(OnButtonClicked);
					table.Attach(button, row, row+1,column, column+1);
					table.Add(button);
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
