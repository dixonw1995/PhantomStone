using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[Serializable]
	public class Card
	{
		private string id;
		private string name;
		private Color color;
		private int cost;

		public Card ()
		{
		}

		public Card (string id, string name, Color color, int cost)
		{
			this.id = id;
			this.name = name;
			this.color = color;
			this.cost = cost;
		}

		public string Id {
			get {
				return this.id;
			}
			set {
				id = value;
			}
		}

		public string Name {
			get {
				return this.name;
			}
			set {
				name = value;
			}
		}

		public Color Color {
			get {
				return this.color;
			}
			set {
				color = value;
			}
		}

		public int Cost {
			get {
				return this.cost;
			}
			set {
				cost = value;
			}
		}

		public override string ToString ()
		{
			return string.Format ("[Card: id={0}, name={1}, color={2}, cost={3}]", id, name, color, cost);
		}
		
	}

	public class CardMetadata {
		private readonly Card card;
		private readonly Player owner;
		private Player controller;
		private Face face;

		public CardMetadata (Card card, Player owner)
		{
			this.card = card;
			this.owner = owner;

			this.controller = this.owner;
			this.face = Face.Down;
		}

		public Card Card {
			get {
				return this.card;
			}
		}

		public Player Owner {
			get {
				return this.owner;
			}
		}

		public Player Controller {
			get {
				return this.controller;
			}
			set {
				controller = value;
			}
		}

		public Face Face {
			get {
				return this.face;
			}
			set {
				face = value;
			}
		}
	}
}

