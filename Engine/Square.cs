using System;

namespace Engine
{
	public class Square
	{
		bool flipp;
		bool flagg;
		bool mine;
		bool mineHit;
		int  warningCount;

		public bool Flip {
			get {
				return flipp;
			}
			set {
				flipp = value;
			}
		}

		public bool Flag {
			get {
				return flagg;
			}
			set {
				flagg = value;
			}
		}


		public bool Mine {
			get {
				return mine;
			}
			set {
				mine = value;
			}
		}

		public bool MineHit {
			get {
				return mineHit;
			}
			set {
				mineHit = value;
			}
		}
		public int Warning {
			get {
				return warningCount;
			}
			set {
				warningCount = value;
			}
		}

	}
}

