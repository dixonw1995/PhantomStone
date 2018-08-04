using System;
using System.Collections.Generic;
using System.Collections;

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
	public class Area : IList<Card>
	{
		private Coordinate coordinate;
		private Fertility fertility = Fertility.Low;
		private List<Card> cards = new List<Card> ();

		public Area () {
		}

		public Area (Coordinate coordinate, Fertility fertility)
		{
			this.coordinate = coordinate;
			this.fertility = fertility;
		}

		#region IList implementation

		public int IndexOf (Card item)
		{
			return cards.IndexOf (item);
		}

		public void Insert (int index, Card item)
		{
			cards.Insert (index, item);
		}

		public void RemoveAt (int index)
		{
			cards.RemoveAt (index);
		}

		public Card this [int index] {
			get {
				return cards [index];
			}
			set {
				cards [index] = value;
			}
		}

		#endregion

		#region ICollection implementation

		public void Add (Card item)
		{
			cards.Add (item);
		}

		public void Clear ()
		{
			cards.Clear ();
		}

		public bool Contains (Card item)
		{
			return cards.Contains (item);
		}

		public void CopyTo (Card[] array, int arrayIndex)
		{
			cards.CopyTo (array, arrayIndex);
		}

		public bool Remove (Card item)
		{
			return cards.Remove (item);
		}

		public int Count {
			get {
				return cards.Count;
			}
		}

		public bool IsReadOnly {
			get {
				return ((IList)cards).IsReadOnly;
			}
		}

		#endregion

		#region IEnumerable implementation

		public IEnumerator<Card> GetEnumerator ()
		{
			return cards.GetEnumerator ();
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		#endregion
	}
}

