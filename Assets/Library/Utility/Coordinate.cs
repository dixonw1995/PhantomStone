using System.Collections;
using System.Collections.Generic;
using System;

namespace AssemblyCSharp
{
	/// <summary>
	/// 2D Coordinate.
	/// </summary>
	[Serializable]
	public struct Coordinate : IComparable<Coordinate>, IEquatable<Coordinate>
	{
		public int x, y;

		public Coordinate (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		//When adding single integer, add to y.
		public static Coordinate operator + (Coordinate a, int y) {
			return new Coordinate (a.x, a.y + y);
		}

		//When subtracting single integer, subtracted by y.
		public static Coordinate operator - (Coordinate a, int y) {
			return new Coordinate (a.x, a.y - y);
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

		#region IComparable implementation

		/// <summary>
		/// Compares to other coordinate. Compares x first, if equal, compares y.
		/// </summary>
		public int CompareTo (Coordinate other)
		{
			if (this.x > other.x)
				return 1;
			if (this.x < other.x)
				return -1;
			if (this.y > other.y)
				return 1;
			if (this.y < other.y)
				return -1;
			//(this.x == other.x && this.y == other.y)
			return 0;
		}

		#endregion

		#region IEquatable implementation

		public bool Equals (Coordinate other)
		{
			return other.x == this.x && other.y == this.y;
		}

		#endregion
	}
}
