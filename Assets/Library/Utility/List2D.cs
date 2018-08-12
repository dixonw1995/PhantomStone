using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;

namespace AssemblyCSharp
{
	/// <summary>
	/// List2D is a 2-dimensional list which is a dictionary where 2D-coordinate acts as key.
	/// </summary>
	[Serializable]
	public class List2D<T> : IDictionary<Coordinate, T>, ISerializable
	{
		//A underlying dictionary which store the contents with coordinate.
		//It is sorted because binary search will be used very frequently.
		private readonly IDictionary<Coordinate, T> contents = new SortedDictionary<Coordinate, T> ();

		//Contructor
		public List2D ()
		{
		}

		/// <summary>
		/// Access content items by x, y value instead of coordinate instance
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public T this [int x, int y] {
			get {
				return contents [new Coordinate(x,y)];
			}
			set {
				contents [new Coordinate(x,y)] = value;
			}
		}

		/// <summary>
		/// Search result.
		/// Found: the target is found.
		/// Nearest: not found, therefore, return the nearest larger item.
		/// OtherRow: not found, return the nearest but it is in other row.
		/// OutOfRange: not found, and target is larger than all entity.
		/// </summary>
		protected enum SearchResult
		{
			Found,
			Nearest,
			OtherRow,
			OutOfRange
		}

		/// <summary>
		/// Search the specified coordinate and output 1D array index.
		/// The index point to the target, the nearest larger coordinate,
		/// or the end of array(length) when target coordinate is larger than all entity.
		/// SearchResult is returned to tell which kind of index it is.
		/// </summary>
		protected SearchResult Search (Coordinate target, out int index) {
			Coordinate[] keys = (Coordinate[])Keys;
			index = Array.BinarySearch<Coordinate> (keys, target);
			SearchResult result = SearchResult.Found;
			if (index < 0) {
				index = ~index;
				result = SearchResult.Nearest;
				if (index == keys.Length) {
					return SearchResult.OutOfRange;
				}
				if (keys [index].x != target.x) {
					return SearchResult.OtherRow;
				}
			}
			return result;
		}

		/// <summary>
		/// Return items in row x.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		public KeyValuePair<Coordinate, T>[] this [int x] {
			get {
				return GetRange (x, Int32.MinValue, x + 1, Int32.MinValue);
			}
		}

		/// <summary>
		/// Return coordinates within certain range.
		/// </summary>
		/// <returns>The coordinates.</returns>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		public ICollection<Coordinate> GetCoordinates (Coordinate from, Coordinate to) {
			int start, end;
			if (Search (from, out start).Equals (SearchResult.OutOfRange))
				return new Coordinate[0];
			Search (to, out end);
			return ((List<Coordinate>)Keys).GetRange (start, end - start);
		}

		/// <summary>
		/// Return coordinates within certain range.
		/// </summary>
		/// <returns>The coordinates.</returns>
		/// <param name="fromX">From x.</param>
		/// <param name="fromY">From y.</param>
		/// <param name="toX">To x.</param>
		/// <param name="toY">To y.</param>
		public ICollection<Coordinate> GetCoordinates (int fromX, int fromY, int toX, int toY) {
			return GetCoordinates (new Coordinate (fromX, fromY), new Coordinate (toX, toY));
		}

		/// <summary>
		/// Return any coordinate-item-pair in certain range.
		/// </summary>
		/// <returns>The range.</returns>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		public KeyValuePair<Coordinate, T>[] GetRange (Coordinate from, Coordinate to) {
			Coordinate[] keys = (Coordinate[])GetCoordinates (from, to);
			int length = keys.Length;
			KeyValuePair<Coordinate, T>[] slice = new KeyValuePair<Coordinate, T>[length];
			for (int i = 0; i < length; i++) {
				Coordinate key = keys [i];
				slice [i] = new KeyValuePair<Coordinate, T> (key, contents [key]);
			}
			return slice;
		}

		/// <summary>
		/// Return any coordinate-item-pair in certain range.
		/// </summary>
		/// <returns>The range.</returns>
		/// <param name="fromX">From x.</param>
		/// <param name="fromY">From y.</param>
		/// <param name="toX">To x.</param>
		/// <param name="toY">To y.</param>
		public KeyValuePair<Coordinate, T>[] GetRange (int fromX, int fromY, int toX, int toY) {
			return GetRange (new Coordinate (fromX, fromY), new Coordinate (toX, toY));
		}

		/// <summary>
		/// Shift items from certain coordinate to the end of row.
		/// Unshift: shift right
		/// </summary>
		/// <param name="start">Start.</param>
		/// <param name="left">If set to <c>true</c> left.</param>
		public void Shift(Coordinate start, bool left) {
			int direction = left ? -1 : 1;
			//Get coordinates from start(inclusive) to minimun coordinate in next row(exclusive).
			//Which means getting coordinates from start to the end of row.
			Coordinate[] keys = (Coordinate[])GetCoordinates (start, new Coordinate (start.x + 1, int.MinValue));
			//If the right coordinate will be shift to current coordinate, removal of node is not needed.
			//Therefore, a temp coordinate store current coordinate.
			//Remove node if it is the last iteration or current coordinate isn't near the next.
			Coordinate temp = new Coordinate (0, 0);
			//Left-shift is ascending iteration. Right-shift is descending iteration.
			int i = left ? 0 : keys.Length - 1;
			Func<int, bool> criteria = arg => (left && arg < keys.Length) || (!left && arg >= 0);
			for (; criteria (i); i -= direction) {
				Coordinate key = keys [i];
				//Exclude the first. See if temp is the destination
				if (i > 0 && temp != key + direction)
					contents.Remove (temp);
				contents [key + direction] = contents [key];
				temp = key;
			}
			contents.Remove (temp);
		}

		//Shift items left from certain coordinate to the end of row.
		[Obsolete("Use Shift(Coordinate start, bool left) instead", true)]
		protected void Shift(Coordinate start) {
			//Get coordinates from start(inclusive) to minimun coordinate in next row(exclusive).
			//Which means getting coordinates from start to the end of row.
			Coordinate[] keys = (Coordinate[])GetCoordinates (start, new Coordinate (start.x + 1, int.MinValue));
			//If the right coordinate will be shift to current coordinate, removal of node is not needed.
			//Therefore, a temp coordinate store current coordinate.
			//Remove node if it is the first iteration, the last iteration or current coordinate isn't near the next.
			Coordinate temp = new Coordinate (0, 0);
			for (int i = 0; i < keys.Length; i++) {
				Coordinate key = keys [i];
				if (i > 0 && temp + 1 != key)
					contents.Remove (temp);
				contents [key - 1] = contents [key];
				temp = key;
			}
			contents.Remove (temp);
		}

		//Shift items right from certain coordinate to the end of row.
		[Obsolete("Use Shift(Coordinate start, bool left) instead", true)]
		protected void Unshift(Coordinate start) {
			//Get coordinates from start(inclusive) to minimun coordinate in next row(exclusive).
			//Which means getting coordinates from start to the end of row.
			Coordinate[] keys = (Coordinate[])GetCoordinates (start, new Coordinate (start.x + 1, int.MinValue));
			//If the left coordinate will be shift to current coordinate, removal of node is not needed.
			//Therefore, a temp coordinate store current coordinate.
			//Remove node if it is the first iteration, the last iteration or current coordinate isn't near the next.
			Coordinate temp = new Coordinate (0, 0);
			for (int i = keys.Length - 1; i >= 0; i--) {
				Coordinate key = keys [i];
				if (i < keys.Length - 1 && temp - 1 != key)
					contents.Remove (temp);
				contents [key + 1] = contents [key];
				temp = key;
			}
			contents.Remove (temp);
		}

		public void Add (Coordinate key, T value, bool unshift = false)
		{
			if (unshift)
				Shift (key, false);
			((IDictionary<Coordinate, T>)contents).Add (key, value);
		}

		public bool Remove (Coordinate key, bool shift = false)
		{
			bool exist = ((IDictionary<Coordinate, T>)contents).Remove (key);
			if (exist && shift)
				Shift (key, true);
			return exist;
		}

		public void Add (KeyValuePair<Coordinate, T> item, bool unshift = false)
		{
			if (unshift)
				Shift (item.Key, false);
			((ICollection<KeyValuePair<Coordinate, T>>)contents).Add (item);
		}

		public bool Remove (KeyValuePair<Coordinate, T> item, bool shift = false)
		{
			bool exist = ((ICollection<KeyValuePair<Coordinate, T>>)contents).Remove (item);
			if (exist && shift)
				Shift (item.Key, true);
			return exist;
		}

		public Coordinate CoordinateOf(T item) {
			foreach (KeyValuePair<Coordinate, T> pair in contents) {
				if (pair.Value.Equals (item))
					return pair.Key;
			}
			throw new ArgumentOutOfRangeException ();
		}

		public List<Coordinate> CoordinatesOf(T item) {
			List<Coordinate> coords = new List<Coordinate> ();
			foreach (KeyValuePair<Coordinate, T> pair in contents) {
				if (pair.Value.Equals (item))
					coords.Add (pair.Key);
			}
			return coords;
		}

		#region IDictionary implementation

		public bool ContainsKey (Coordinate key)
		{
			return contents.ContainsKey (key);
		}

		void IDictionary<Coordinate, T>.Add (Coordinate key, T value)
		{
			contents.Add (key, value);
		}

		bool IDictionary<Coordinate, T>.Remove (Coordinate key)
		{
			return contents.Remove (key);
		}

		public bool TryGetValue (Coordinate key, out T value)
		{
			return contents.TryGetValue (key, out value);
		}

		public T this [Coordinate index] {
			get {
				return contents [index];
			}
			set {
				contents [index] = value;
			}
		}

		public ICollection<Coordinate> Keys {
			get {
				return contents.Keys;
			}
		}

		public ICollection<T> Values {
			get {
				return contents.Values;
			}
		}

		#endregion

		#region ICollection implementation

		void ICollection<KeyValuePair<Coordinate, T>>.Add (KeyValuePair<Coordinate, T> item)
		{
			((ICollection<KeyValuePair<Coordinate, T>>)contents).Add (item);
		}

		public void Clear ()
		{
			contents.Clear ();
		}

		public bool Contains (KeyValuePair<Coordinate, T> item)
		{
			return ((ICollection<KeyValuePair<Coordinate, T>>)contents).Contains (item);
		}

		public void CopyTo (KeyValuePair<Coordinate, T>[] array, int arrayIndex)
		{
			((ICollection)contents).CopyTo (array, arrayIndex);
		}

		bool ICollection<KeyValuePair<Coordinate, T>>.Remove (KeyValuePair<Coordinate, T> item)
		{
			return ((ICollection<KeyValuePair<Coordinate, T>>)contents).Remove (item);
		}

		public int Count {
			get {
				return contents.Count;
			}
		}

		public bool IsReadOnly {
			get {
				return ((ICollection<KeyValuePair<Coordinate, T>>)contents).IsReadOnly;
			}
		}

		#endregion

		#region IEnumerable implementation

		public IEnumerator<KeyValuePair<Coordinate, T>> GetEnumerator ()
		{
			return contents.GetEnumerator ();
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		#endregion

		#region ISerializable implementation

		public void GetObjectData (SerializationInfo info, StreamingContext context)
		{
			info.AddValue ("Coordinates", (Coordinate[])Keys, typeof(Coordinate[]));
			info.AddValue ("Values", (T[])Values, typeof(T[]));
		}

		#endregion

		//Deserialization constructor
		protected List2D (SerializationInfo info, StreamingContext context) {
			Coordinate[] coords = (Coordinate[])info.GetValue ("Coordinates", typeof(Coordinate[]));
			T[] values = (T[])info.GetValue ("Values", typeof(T[]));
			for (int i = 0; i < coords.Length; i++) {
				contents [coords [i]] = values [i];
			}
		}
	}
}
