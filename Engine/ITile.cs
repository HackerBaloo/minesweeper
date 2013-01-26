using System;

namespace Engine
{
	public interface ITile
	{
		int Row { get;}
		int Column { get;}

		void SetStatus(TileStatus status, int warning = 0);
	}
}

