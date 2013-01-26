using System;

namespace Engine
{
	public class GameEngine
	{
		int columns;
		int rows;
		bool mineHit = false;
		Square[,] squares;
		ITile[,] tiles;

		int numberOfMines;
		int totalLeft;
		int flagsLeft;

		public int Rows {
			get {
				return rows;
			}
		}

		public int Columns {
			get {
				return columns;
			}
		}

		event UserMessageEventHandler userMessage;
		public event UserMessageEventHandler UserMessage
		{
			add
			{
				userMessage += value;
			}
			remove
			{
				userMessage -= value;
			}
		}

		void FireUserMessage(string message)
		{
			if(userMessage != null)
				userMessage.Invoke(this, new UserMesssageArgs(message));
		}

		public GameEngine (int rows, int columns, int numberOfMines)
		{
			this.rows = rows;
			this.columns = columns;
			this.numberOfMines = numberOfMines;
			squares = new Square[rows, columns];
			tiles = new ITile[rows,columns];

		}

		public void Init ()
		{
			totalLeft = rows * columns;
			flagsLeft = numberOfMines;
			mineHit = false;
			for (var row = 0; row < rows; row++) {
				for(var col = 0; col < columns; col++){
					squares[row, col] = new Square();
					tiles[row, col].SetStatus(TileStatus.Unflippped);
				}
			}
			var newMines = 0;
			var random = new Random();
			while (newMines < numberOfMines) 
			{
				int column = random.Next(0, columns);
				int row = random.Next(0, rows);
				if(squares[row, column].Mine == true)
					continue;
				squares[row, column].Mine = true;
				Spreadwarnings(row, column);
				newMines++;
			}
		}

		public void AddTile (ITile tile)
		{
			tiles[tile.Row, tile.Column] = tile;
		}

		void Spreadwarnings (int row, int col)
		{
			int colOffset = col - 1;
			if(colOffset < 0)
				colOffset = 0;

			int rowOffset = row - 1;
			if(rowOffset < 0)
				rowOffset = 0;

			int rowMax = row + 1;
			if(rowMax >= rows)
				rowMax = rows - 1;

			int colMax = col + 1;
			if(colMax >= columns)
				colMax = columns - 1;

			var startCol = colOffset;
			for(; rowOffset <= rowMax; rowOffset++)
			{
				colOffset = startCol;
				for(;colOffset <= colMax; colOffset++)
					squares[rowOffset, colOffset].Warning++;
			}
		}

		public void Flag (int row, int column)
		{
			if (flagsLeft == 0) {
				FireUserMessage ("No flags left");
				return;
			}
			var square = squares[row, column];
			// Can't flag if already flipped
			if(square.Flip)
				return;
			square.Flag = !square.Flag;
			totalLeft--;
			flagsLeft--;
			Evaluate();
		}

		public void Flip (int row, int column)
		{
			var square = squares[row, column];
			// If already flagged, unflag
			if (square.Flag) {
				square.Flag = false;
				totalLeft++;
				flagsLeft++;
			}
			// If we hit a mine game is over
			if (square.Mine) {
				square.MineHit = true;
				mineHit = true;
			}

			SpreadFlip(row, column);

			Evaluate();
		}

		void SpreadFlip (int row, int col)
		{
			if(col < 0)
				return;
			if(col >= columns)
				return;

			if(row < 0)
				return;
			if(row >= rows)
				return;

			if(IsFlipped(row, col))
				return;
			// the actual flip
			squares[row, col].Flip = true;
			totalLeft--;

			if(squares[row, col].Warning != 0)
				return;
			SpreadFlip(row - 1, col - 1);
			SpreadFlip(row - 1, col);
			SpreadFlip(row - 1, col + 1);

			SpreadFlip(row, col - 1);
			SpreadFlip(row, col + 1);

			SpreadFlip(row + 1, col - 1);
			SpreadFlip(row + 1, col);
			SpreadFlip(row + 1, col + 1);
		}

		public bool Finished { get{ return mineHit || totalLeft == 0; }	}

		bool IsFlipped (int row, int column)
		{
			var square = squares[row, column];
			return square.Flip;
		}

		void Evaluate ()
		{
			for (var row = 0; row < rows; row++) {
				EvaluateColumns (row);
			}
			if (Finished) {
				if (mineHit)
					FireUserMessage ("Oooh nooo!");
				else
					FireUserMessage ("You made it, now the children can play here!!");
				Init();
			}
		}

		void EvaluateColumns(int row)
		{
			for(var column = 0;column < columns; column++)
			{
				var square = squares[row, column];
				var tile = tiles[row, column];

				if(square.Flag == true) /* == true not necessary*/
					tile.SetStatus(TileStatus.Flag);
				else if(IsFlipped(row, column))
				{
					if(square.Mine)
					{
						if(square.MineHit)
							tile.SetStatus(TileStatus.TheMine);
						else
							tile.SetStatus(TileStatus.Mine);
					}
					else
					{
						if(square.Warning != 0)
							tile.SetStatus(TileStatus.Warning, square.Warning);
						else
							tile.SetStatus(TileStatus.Flipped);
					}
				}
			}
		}

	}
}

