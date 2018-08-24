using System;
using UnityEngine;

namespace AssemblyCSharp
{

	public interface IApplyChange
	{
		void Initialize();

		void Apply ();

		void Revert ();

	}
}

