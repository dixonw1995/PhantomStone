using System;
using System.Collections.Generic;
using System.Reflection;

namespace AssemblyCSharp
{
	[Serializable]
	public class CardState {
		private readonly Player owner;
		private Player controller;
		private Face face = Face.Down;
		private object position;

		public CardState (Player owner)
		{
			this.owner = owner;
			this.controller = this.owner;
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
