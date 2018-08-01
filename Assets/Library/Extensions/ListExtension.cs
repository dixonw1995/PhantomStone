using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public enum ItemPosition
	{
		Top,
		Bottom
	}

	public static class ListExtension
	{

		public static IList<T> Shuffle<T> (this IList<T> list, int times = 3)
		{
			int count = list.Count;
			if (times <= 0 || count <= 1)
				return list;

			int i;
			T temp;
			for ( int pos = 0; pos < count; pos++) {
				i = StaticRandom.random.Next (count);
				temp = list [i];
				list [i] = list [pos];
				list [pos] = temp;
			}

			return Shuffle (list, times-1);
		}

		public static bool MoveFirstItemTo<T> (this IList<T> src, IList<T> des)
		{
			if (src.Count > 0) {
				des.Add (src [0]);
				src.RemoveAt (0);
				return true;
			}
			return false;
		}

		public static void Add<T> (this IList<T> list, T item, ItemPosition position = ItemPosition.Top) {
			if (position.ToBool (ItemPosition.Top))
				list.Insert (0, item);
			else
				list.Add (item);
		}

		public static void AddRange<T> (this List<T> list, IEnumerable<T> items, ItemPosition position = ItemPosition.Top) {
			if (position.ToBool ())
				list.InsertRange (0, items);
			else
				list.AddRange (items);
		}
	}
}

