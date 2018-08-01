using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[Serializable]
	public class Player : User
	{
		private List<Card> deck;
		private List<Area> zone;
		private List<Card> hand;
		private List<Card> graveyard;

		public Player ()
		{
		}
	}
}

