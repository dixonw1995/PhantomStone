using System;

namespace AssemblyCSharp
{
	
	public class User
	{
		protected readonly string id;
		protected string name;

		protected User() {
		}

		public User (string id, string name)
		{
			this.id = id;
			this.name = name;
		}

		public string Id {
			get {
				return this.id;
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

		public override string ToString ()
		{
			return string.Format ("[User: id={0}, name={1}]", id, name);
		}

		public override bool Equals (object obj)
		{
			if (obj == null)
				return false;
			if (ReferenceEquals (this, obj))
				return true;
			if (obj.GetType () != typeof(User))
				return false;
			User other = (User)obj;
			return id == other.id;
		}
		

		public override int GetHashCode ()
		{
			unchecked {
				return (id != null ? id.GetHashCode () : 0);
			}
		}
		
	}
}

