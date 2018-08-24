using System;
using UnityEngine;
using System.IO;

namespace AssemblyCSharp
{
	[Serializable]
	public class SimpleIO
	{

		public static string Read (string directory, string path, string extension = "")
		{
			string filePath = Path.Combine (directory, path) + extension;

			if (File.Exists (filePath)) {
				return File.ReadAllText (filePath);
			} else {
				return null;
			}
		}

		public static void Write (string directory, string path, string data, string extension = "")
		{
			string filePath = Path.Combine (directory, path) + extension;
			File.WriteAllText (filePath, data);
		}
	}
}
