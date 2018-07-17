using System;
using System.Collections;

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

		public static string PrintOut<T> (this T[] array)
		{
			string result = "";
			Array.ForEach (array, item => result += string.Format ("{0}({1})\n", item.ToString (), item.GetHashCode ()));
			return result;
		}
	}
}

