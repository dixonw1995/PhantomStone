using System;

namespace AssemblyCSharp
{
	public abstract class ChangeApplyer
	{
		public abstract void Init();
		public abstract void Apply();
		public abstract void Revert();
	}
}

