using System;

namespace Engine
{
	public class UserMesssageArgs : EventArgs
	{
		readonly string message;

		public string Message {
			get {
				return message;
			}
		}

		public UserMesssageArgs (string message)
		{
			this.message = message;
		}
	}
}

