using System.Collections;
using System.Collections.Generic;
using System;

namespace AssemblyCSharp
{
	[Serializable]
	public struct Coordinate : IEquatable<Coordinate>
	{
		public int x, y;

		public Coordinate (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static Coordinate operator + (Coordinate a, Coordinate b) {
			return new Coordinate (a.x + b.x, a.y + b.y);
		}

		public static Coordinate operator - (Coordinate a, Coordinate b) {
			return new Coordinate (a.x - b.x, a.y - b.y);
		}

		public static bool operator == (Coordinate a, Coordinate b) {
			return a.Equals (b);
		}

		public static bool operator != (Coordinate a, Coordinate b) {
			return !a.Equals (b);
		}

		public override bool Equals (object obj)
		{
			return obj.GetType () == this.GetType () && Equals ((Coordinate)obj);
		}

		public override int GetHashCode ()
		{
			return x ^ y;
		}

		#region IEquatable implementation

		public bool Equals (Coordinate other)
		{
			return other.x == x && other.y == y;
		}

		#endregion
	}
}
