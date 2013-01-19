using System;
using Gtk;

namespace gtkmine
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			Window win = new Window ("Minesweeper");
			win.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child MainWindow.Gtk.Container+ContainerChild
			var table = new global::Gtk.Table (((uint)(5)), ((uint)(5)), false);
			table.RowSpacing = ((uint)(6));
			table.ColumnSpacing = ((uint)(6));
			for (uint i = 0; i < 25; i++) {
				var button = new Button();
				button.CanFocus = true;
				button.Label = i.ToString();
				button.Clicked += new EventHandler(OnButtonClicked);
				table.Attach(button, i%5, i%5+1,i/5, i/5+1);
				table.Add(button);
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
