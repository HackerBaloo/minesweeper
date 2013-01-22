using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
	public partial class Form1 : Form
	{
		Tile[,] tiles;

		public Form1 ()
		{
			var rows = 4;
			var columns = 4;
			var margin = 2;
			var size = new System.Drawing.Size(23, 23);
			tiles = new Tile[rows,columns];

			SuspendLayout();

			for (var row = 0; row < rows; row++) {
				for (var column = 0; column < columns; column++) {
					var tile = new Tile();
					tiles[row, column] = tile; 
					tile.Location = new System.Drawing.Point(13 + (size.Width + margin) * column, 24 + (size.Height + margin) * row);
					tile.Size = size;
					tile.TabIndex = 1 + column + columns * row;
					Controls.Add (tile);
					tile.Click += tile.HandleClick;
				}
			}
//			AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
//			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size (184, 262);
			Text = "Minesweeper";
			ResumeLayout (false);

		}


	}
}
