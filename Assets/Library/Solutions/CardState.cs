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

		public CardState (Player owner, object position) : this(owner)
		{
			this.position = position;
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

		public object Position {
			get {
				return this.position;
			}
			set {
				position = value;
			}
		}

		public override string ToString ()
		{
			return string.Format ("[CardState: owner={0}, controller={1}, face={2}, position={3}]", owner, controller, face, position);
		}
		
	}
}
