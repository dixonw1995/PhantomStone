using System;

namespace AssemblyCSharp
{
	public class Ability
	{
		public Timing timing;
		public int cost;
		public Action effect;

		public Ability ()
		{
		}

		public Ability (Timing timing, int cost, Action effect)
		{
			this.timing = timing;
			this.cost = cost;
			this.effect = effect;
		}
	}
}

