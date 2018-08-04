using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[Serializable]
	public class Game
	{
		private string id;
		private List<Player> players;
		private int turns;
		private Timing timing;
		private List<Area> region;

		public Game ()
		{
		}
	}
}

