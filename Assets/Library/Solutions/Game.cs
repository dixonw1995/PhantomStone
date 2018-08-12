using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[Serializable]
	public class Game
	{
		private readonly string id;
		private readonly Player[] players;
		private int turns = 0;
		private Timing timing = Timing.Start;
		private readonly List2D<Area> region;
		private readonly IDictionary<Card, CardState> cardStates;

		public Game ()
		{
		}

		public Game (string id, Player[] players, List2D<Area> region)
		{
			this.id = id;
			this.players = players;
			this.region = region;
		}

		public string Id {
			get {
				return this.id;
			}
		}

		public int Turns {
			get {
				return this.turns;
			}
		}

		public Timing Timing {
			get {
				return this.timing;
			}
		}
	}
}

