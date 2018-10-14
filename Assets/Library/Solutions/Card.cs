using System;
using System.Collections.Generic;
using System.Reflection;

namespace AssemblyCSharp
{
	
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

}

