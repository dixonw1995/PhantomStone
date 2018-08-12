using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[Serializable]
	public class Player : User
	{
		private readonly string team;
		private readonly List<Card> deck;
		private readonly List<Area> zone = new List<Area> ();
		private readonly List<Card> hand = new List<Card> ();
		private readonly List<Card> graveyard = new List<Card> ();

		public Player (string id, string name, string team, List<Card> deck) : base (id, name)
		{
			this.team = team;
			this.deck = deck;
		}

		public string Team {
			get {
				return this.team;
			}
		}
	}
}

