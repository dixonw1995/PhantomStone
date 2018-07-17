using System;
using UnityEngine;
using System.IO;

namespace AssemblyCSharp
{
	[Serializable]
	public class SimpleFileSystem
	{

		public static readonly string persistentDataPath = Application.persistentDataPath + "/";

		public static string Read (string directory, string path)
		{
			string filePath = directory + path;

			if (File.Exists (filePath)) {
				return File.ReadAllText (filePath);
			} else {
				return null;
			}
		}

		public static void Write (string directory, string path, string data)
		{
			string filePath = directory + path;
			File.WriteAllText (filePath, data);
		}
	}
}
