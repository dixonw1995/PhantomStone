﻿using System;
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
	public class Area
	{
		private Fertility fertility = Fertility.Low;
		private List<Card> cards = new List<Card> ();

		public Area () {
		}

		public Area (Coordinate coordinate, Fertility fertility)
		{
			this.fertility = fertility;
		}

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

		public bool Remove (Card item)
		{
			return cards.Remove (item);
		}

		public int Count {
			get {
				return cards.Count;
			}
		}
	}
}

