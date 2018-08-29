using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;
using System.IO;

namespace AssemblyCSharp
{
	[Serializable]
	public class Game
	{
		private readonly string id;
		private readonly Player[] players;
		private int turns = 0;
		private Timing timing = Timing.Start;
		private readonly List2D<Area> region;
		private readonly IDictionary<Card, CardState> cardStates = new SerializableDictionary<Card, CardState> ();

		public Game ()
		{
		}

		public Game (string id, Player[] players)
		{
			this.id = id;
			this.players = players;
		}

		public Game (string id, Player[] players, List2D<Area> region)
		{
			this.id = id;
			this.players = players;
			this.region = region;
		}

		public Game (string id, Player[] players, string regionType = "standard") : this (id, players)
		{
			this.id = id;
			this.players = players;
			this.region = new List2D<Area> ();
			SetRegion (regionType);
		}

		public string Id {
			get {
				return this.id;
			}
		}

		public int Turns {
			get {
				return this.turns;
			}
		}

		public Timing Timing {
			get {
				return this.timing;
			}
		}

		public ReadOnlyCollection<Player> Players {
			get {
				return Array.AsReadOnly (this.players);
			}
		}

		public List2D<Area> Region {
			get {
				return this.region;
			}
		}

		public IDictionary<Card, CardState> CardStates {
			get {
				return this.cardStates;
			}
		}

		protected void SetRegion(List2D<Area> region) {
			foreach (KeyValuePair<Coordinate, Area> kvp in region) {
				Region [kvp.Key] = kvp.Value;
			}
		}

		protected void SetRegion(string regionType) {
			string path = Path.ChangeExtension (Path.Combine ("Assets/Resources/Data/Region_Code", regionType), ".bytes");
			using (StreamReader reader = new StreamReader (path)) {
				char ch;
				Coordinate cursor = new Coordinate (0, 0);
				int fertility = 0;
				bool negative = false;
				bool interpreting = false;

				// While not end of file,
				while (reader.Peek () >= 0) {
					ch = (char)reader.Read ();
					// if ch is numeric,
					if (ch >= '0' && ch <= '9') {
						// if no interpreting characters, interpret this numeric char;
						if (!interpreting) {
							fertility = (int)(ch - '0');
							interpreting = true;
							// if already interpreted previous digits so add it as new digit.
						} else
							fertility = fertility * 10 + (int)(ch - '0');
						// if ch is not numeric,
					} else {
						// if interpreting, it is over. Add new area. Move cursor.
						if (interpreting) {
							region [cursor] = new Area (negative ? -fertility : fertility);
							cursor += 1;
							interpreting = false;
							negative = false;
						}
						// Whether it is interpreting, new-line charater imply new row.
						// Move cursor to next row.
						if (ch == '\n')
							cursor = new Coordinate (cursor.x + 1, 0);
						// Surely not interpreting number. Default is positive.
						// Find negative sign. But not sure if next charater is numeric.
						if (ch == '-')
							negative = true;
					// Surely not interpreting number.
					// Ignore any previous sign and set to positive.
					else
							negative = false;
					}
				}
				// End of file. If still interpreting, finish it.
				if (interpreting) {
					region [cursor] = new Area (negative ? -fertility : fertility);
				}
			}
		}
	}
}

