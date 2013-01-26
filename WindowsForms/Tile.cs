using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Windows.Forms;
using Engine;

namespace WindowsForms
{
	public class Tile : Button, ITile
	{
		static readonly Size size = new Size(23, 23);
		static readonly Point startPos = new Point(13, 24);
		static readonly int margin = 2;

		GameEngine engine;
		int row;
		int column;

		public Tile (int row, int column, GameEngine engine)
		{
			this.row = row;
			this.column = column;
			this.engine = engine;
			engine.AddTile(this);
			this.MouseUp += HandleMouseUp;
			//Button specific
			TabIndex = 1 + column + engine.Columns * row;
			Size = size;
			Location = new System.Drawing.Point(startPos.X + (size.Width + margin) * column, startPos.Y + (size.Height + margin) * row);

		}

		void HandleMouseUp (object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
				DoFlip();
			else
				DoFlag();
			base.OnMouseClick (e);
		}

		protected override void OnMouseClick (MouseEventArgs e)
		{
		}

		public void DoFlip()
		{
			engine.Flip(row, column);
		}

		public void DoFlag ()
		{
			engine.Flag(row, column);
		}

		#region ITile implementation

		public int Row {
			get {
				return row;
			}
		}

		public int Column {
			get {
				return column;
			}
		}

		public void SetStatus (TileStatus status, int warning = 0)
		{
			switch(status)
			{
			default:
			case TileStatus.Unflippped:
				Text = string.Empty;break;
			case TileStatus.BadFlag:
				Text = "B";break;
			case TileStatus.Flag:
				Text = "F";break;
			case TileStatus.Warning:
				Text = warning.ToString();break;
			case TileStatus.Flipped:
				Text = ".";break;
			case TileStatus.TheMine:
				Text = "X";break;
			}
		}



		#endregion

	}
}

