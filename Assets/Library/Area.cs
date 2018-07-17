using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{

	public enum Fertility : int {
		Hollow = -1,
		Empty = 0,
		Low = 1,
		Medium = 2,
		High = 3
	}

	[Serializable]
	public class Area
	{
		public Coordinate coordinate;
		public Fertility fertility = Fertility.Low;
		public List<Card> cards = new List<Card> ();

		public Area () {
		}

		public Area (Coordinate coordinate, Fertility fertility)
		{
			this.coordinate = coordinate;
			this.fertility = fertility;
		}
	}
}

