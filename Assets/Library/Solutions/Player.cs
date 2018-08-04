using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[Serializable]
	public class Player : User
	{
		private readonly List<Card> deck = new List<Card> ();
		private readonly List<Area> zone = new List<Area> ();
		private readonly List<Card> hand = new List<Card> ();
		private readonly List<Card> graveyard = new List<Card> ();

		public Player (string id, string name, List<Card> deck) : base (id, name)
		{
			this.deck = deck;
		}

		public Player (User user, List<Card> deck) : this (user.Id, user.Name, deck){
		}

		public List<Card> Deck {
			get {
				return this.deck;
			}
		}

		public List<Area> Zone {
			get {
				return this.zone;
			}
		}

		public List<Card> Hand {
			get {
				return this.hand;
			}
		}

		public List<Card> Graveyard {
			get {
				return this.graveyard;
			}
		}
	}
}

