using System;
using System.Windows.Forms;

namespace WindowsForms
{
	public class Tile : Button
	{
		public Tile ()
		{
		}

		public void HandleClick (object sender, EventArgs e)
		{
			MessageBox.Show("Clicked: " + TabIndex.ToString());
		}
	}
}

