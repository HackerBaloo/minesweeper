using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace WindowsForms
{
	public class Board : Form
	{

		public Board ()
		{
			var engine = new GameEngine(4, 4, 1);
			engine.UserMessage += HandleUserMessage;

			SuspendLayout();

			for (var row = 0; row < engine.Rows; row++) {
				for (var column = 0; column < engine.Columns; column++) {
					var tile = new Tile(column, row, engine);
					Controls.Add (tile);
				}
			}
//			AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
//			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size (184, 262);
			Text = "Minesweeper";
			ResumeLayout (false);
			engine.Init();

		}

		void HandleUserMessage (object sender, UserMesssageArgs e)
		{
			MessageBox.Show(e.Message);
		}
	}
}
