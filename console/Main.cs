using System;
using System.IO;


namespace minesweeper
{
	class MainClass
	{
//		public static void Main (string[] args)
//		{
//			using (var reader = new StreamReader("input")) 
//			{
//				while(true)
//				{
//					var line = reader.ReadLine();
//					if(line == null)
//						break;
//					Console.WriteLine(line);
//				}
//			}
//		}


		public static void Main (string[] args)
		{
			var game = new Game ();
			game.Run();
		}


	}
}
