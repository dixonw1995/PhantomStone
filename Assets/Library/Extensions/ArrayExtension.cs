using System;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public static class ArrayExtension
	{

		public static void Fill (this Array array, int dimension = 0, int[] indexes = null)
		{
			if (indexes == null)
				indexes = new int[array.Rank];

			for (indexes[dimension] = array.GetLowerBound(dimension);
				indexes[dimension] <= array.GetUpperBound(dimension);
				indexes[dimension]++) {
				if (dimension < array.Rank - 1) {
					array.Fill (dimension + 1, indexes);
				} else {
					array.SetValue (array.GetType ().GetElementType ().GetConstructor (Type.EmptyTypes).Invoke(new object[0]), indexes);
				}
			}
		}
	}

}

