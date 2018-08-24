using System;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{

	public static class CollectionExtension{

		public static string PrintOut<T> (this ICollection<T> collection, string format = "[{1}({2})], ")
		{
			string result = string.Format ("{0} item{1}", collection.Count, collection.Count == 0 ? "" : collection.Count >= 2 ? "s: " : ": ");
			int count = 0;
			foreach (T item in collection) {
				result += string.Format (format, count++, item.ToString (), item.GetHashCode ());
			}
			return result;
		}

		public static string[] ToStrings<KeyType, ValueType> (this ICollection<KeyValuePair<KeyType, ValueType>> collection) {
			if (collection == null)
				return new string[0];
			string[] result = new string[collection.Count];
			int index = 0;
			foreach (var kvp in collection) {
				result [index++] = string.Format ("[{0}->{1}]", kvp.Key.ToString (), kvp.Value.ToString ());
			}
			return result;
		}

		public static string[] ToStrings<T> (this ICollection<T> collection) {
			if (collection == null)
				return new string[0];
			string[] result = new string[collection.Count];
			int index = 0;
			foreach (T item in collection) {
				result [index++] = item.ToString ();
			}
			return result;
		}
	}
}
